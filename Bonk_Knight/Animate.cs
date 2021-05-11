using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bonk_Knight
{
    public class Animate : Render
    {
        public static void ControlableEntityAni(int Position, int ActualEndPos ,List<String> Animation, int speed = 120)//240?
        {
            speed = Convert.ToInt32(speed * Globals.GameSpeed);
            //FIX CHANGE
            //meant for player and enemy
            if (Globals.AnimationRunning == false) {
                if (!(Position > 6 || Position < 1)) {
                    Globals.AnimationRunning = true;

                    //note the animtaion starts from the ground
                    //all animations are square

                    //Work out Max area animation happens so you can just render that area
                    //Max row above the surface of the ground
                    int RowFinal = Globals.GroundInGameY-1;
                    //Starting row of animation
                    int RowInitial = RowFinal;
                    //Starting Column of animation
                    int ColumnInitial = ((Position - 1) * 5);
                    //Max Column
                    int ColumnFinal = ColumnInitial;
                    foreach (var AnimationFrames in Animation)
                    {
                        //checks for the max height of animation
                        RowInitial = Math.Min(RowInitial, Globals.GroundInGameY - AnimationFrames.Count(f => f == '%'));
                        //checks for the max width of animation
                        ColumnFinal = Math.Max(ColumnFinal, ColumnInitial+((AnimationFrames.Length - AnimationFrames.Count(f => f == '%')) / AnimationFrames.Count(f => f == '%')));
                    }
                    //IDK why probs 0 index
                    ColumnFinal--;
                    if (ColumnFinal >= Globals.GSW)
                    {
                        ColumnFinal = Globals.GSW - 1 ;
                    }
                    //System.Diagnostics.Debug.WriteLine($"{RowInitial},{ColumnInitial},{RowFinal},{ColumnFinal}");

                    //set up the Location of the Animation to change the screen list
                    List<List<int>> Location = new List<List<int>>() { };
                    foreach (var AnimationFram in Animation)
                    {
                        List<int> FrameCoords = new List<int>() { };
                        //row
                        FrameCoords.Add(Globals.GroundInGameY - AnimationFram.Count(f => f == '%'));
                        //Column
                        FrameCoords.Add((Position - 1) * 5);
                        Location.Add(FrameCoords);
                    }


                    //Runs for each Frame of animation ------------add time for each animation
                    for (int Frame = 0; Frame < Animation.Count; Frame++)
                    {
                        //Layer on animation
                        ChangeScreen(Convert.ToInt32(Location[Frame][0]), Convert.ToInt32(Location[Frame][1]), Animation[Frame]);

                        //Render animation
                        RenderScreen($"{RowInitial},{ColumnInitial},{RowFinal},{ColumnFinal}");
                        //RenderScreen("all");
                        //wait to next frame
                        //System.Diagnostics.Debug.WriteLine($"Completed Frame {Frame}");
                        Thread.Sleep(speed);
                    }
                    ResetArea(Position, ActualEndPos, RowInitial, ColumnInitial, RowFinal, ColumnFinal);
                    RenderScreen($"{RowInitial},{ColumnInitial},{RowFinal},{ColumnFinal}");
                    EndAni();
                }
                else
                {
                    //catches bugs
                    MakeErrorMessage("Position should be from 1-6 on screen");
                    //maybe check for next positon on map??????????????????????
                }
            }
            else
            {
                //catches bugs
                MakeErrorMessage("Couldn't run animation as one already runnign");
            }
        }
        public static void ControlableEntityPlace(int Position, String EntityStationary)
        {
            //FIX CHANGE IMPROVE make the loading of entities better
            //meant for player and enemy
            if (Globals.AnimationRunning == false) {
                if (!(Position > 6 || Position < 1)) {
                    Globals.AnimationRunning = true;

                    //note the animtaion starts from the ground
                    //all animations are within square

                    //Max row above the surface of the ground
                    int RowFinal = Globals.GroundInGameY-1;
                    //Starting row of animation
                    int RowInitial = RowFinal;
                    //Starting Column of animation
                    int ColumnInitial = ((Position - 1) * 5);
                    //Max Column
                    int ColumnFinal = ColumnInitial;

                    //checks for the max height of animation
                    RowInitial = Math.Min(RowInitial, Globals.GroundInGameY - EntityStationary.Count(f => f == '%'));
                    //checks for the max width of animation
                    ColumnFinal = Math.Max(ColumnFinal, ColumnInitial+((EntityStationary.Length - EntityStationary.Count(f => f == '%')) / EntityStationary.Count(f => f == '%')));
                    //IDK why probs 0 index
                    ColumnFinal--;
                    if (ColumnFinal >= Globals.GSW) {ColumnFinal = Globals.GSW - 1; }

                    //set up the Location of the Animation to change the screen list
                    List<int> ThingCoords = new List<int>() { };
                    //row
                    ThingCoords.Add(Globals.GroundInGameY - EntityStationary.Count(f => f == '%'));
                    //Column
                    ThingCoords.Add((Position - 1) * 5);

                    //Layer on animation
                    ChangeScreen(Convert.ToInt32(ThingCoords[0]), Convert.ToInt32(ThingCoords[1]), EntityStationary);
                    RenderScreen($"{RowInitial},{ColumnInitial},{RowFinal},{ColumnFinal}");
                    EndAni();
                }
                else
                {
                    //catches bugs
                    MakeErrorMessage("Position should be from 1-6 on screen");
                    //maybe check for next positon on map??????????????????????
                }
            }
            else
            {
                //catches bugs
                MakeErrorMessage("Couldn't run animation as one already runnign");
            }
        }
        public static void EndAni()
        {
            //add event??
            Functions.ClearKeyIntputs();
            Globals.AnimationRunning = false;
        }
        public static void ResetArea(int positon,int actualendpos , int RI, int CI, int RF, int CF)
        {
            //IMPROVE FIX CHANGE make this work
            String Gap = "";
            for (var Ri = RI; Ri <= RF; Ri++)
            {
                //                              *2???
                Gap += new String(' ',(CF - CI)+1) + '%';
            }
            //fills it in
            var RwoCord = Convert.ToInt32(Globals.GroundInGameY - Gap.Count(f => f == '%'));
            var ClmCord = Convert.ToInt32((positon - 1) * 5);
            Render.ChangeScreen(RwoCord, ClmCord, Gap);


            if (Globals.AnimationRunning == true) { Globals.AnimationRunning = false; }
            //use positon to rerender the thing back to original state
            if (MainClass.Player_1.Position == positon)
            {
                MainClass.Player_1.RenderEntity(actualendpos - positon);
            }
            //FIX IMPROVE solves case of walking backwards only works for 1 backwards from orig
            else if (MainClass.Player_1.Position == positon + 1)
            {
                MainClass.Player_1.RenderEntity(-1);
            }
            else
            {
                foreach (var emy in MainClass.GameMap.CurrentEnemies)
                {
                    if (emy.Position == positon)
                    {
                        emy.RenderEntity();
                    }
                }
            }
        }
        public static void HoleInRect()
        {
            //o = original , co = current original
            int oXCur = Console.CursorLeft;
            int oYCur = Console.CursorTop;
            int coXCur = Console.CursorLeft;
            int coYCur = Console.CursorTop;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write("██");
                }
                Console.Write("\n");
            }
            /*         solution 1
                       //don't know if this is good for setting to inside box
                       coXCur+=2;
                       coYCur++;

                       //space around
                       Console.SetCursorPosition(coXCur, coYCur);
                       String hole = "";
                       for (int i = 0; i < 18; i++)
                       {
                           for (int j = 0; j < 18; j++)
                           {
                               hole += "  ";
                           }
                           hole += "\n";
                       }
                       foreach (char wrd in hole)
                       {
                           Console.Write(wrd);
                           Console.SetCursorPosition(!(wrd == Convert.ToChar("\n")) ? Console.CursorLeft : Console.CursorLeft+2, Console.CursorTop);
                           //Console.WriteLine(true? "well Done":"well none");
                       }
            */


            //sol 2 
            Console.SetCursorPosition(oXCur + 2, oYCur + 1);
            String hole = "";
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    Console.Write("  ");
                }
                Console.SetCursorPosition(oXCur + 2, Console.CursorTop += 1);
            }
            Console.Write(hole);


            Console.SetCursorPosition(coXCur, coYCur);
            Console.ReadKey();
            //indent it you have to do it the line before
            Console.SetCursorPosition(Console.CursorLeft + 25, Console.CursorTop += 1);
            Console.Write("boo");
            var wordToScroll = "\n got ba \n you";

            //need to work on still doesn't work
            /*
                        for (int i = 0; i<wordToScroll.Length; i++)
                        {
                            //// is there a nicer way to do this if????
                            Console.Write(wordToScroll[i]);
                            if (!(i==wordToScroll.Length-1)) {
                                Console.SetCursorPosition(!(Convert.ToString(wordToScroll[i]) + Convert.ToString(wordToScroll[i + 1]) == "\n") ? Console.CursorLeft : Console.CursorLeft + 25, Console.CursorTop);
                                //Console.Write((wordToScroll[i] + wordToScroll[i + 1] == Convert.ToChar("\n")) ?"YES": $"[{Convert.ToString(wordToScroll[i]) + Convert.ToString(wordToScroll[i + 1])}]");
                            }
                            Thread.Sleep(300);
                        }
            */

            /*
                        foreach(var word in wordToScroll.Split(' '))
                        {
                            Console.Write(word);
                            Console.SetCursorPosition(!(word == "\n") ? Console.CursorLeft : Console.CursorLeft+25, Console.CursorTop);
                            Thread.Sleep(300);
                        }
            */
            /////////////////remember to set cursour back to after the image
            Console.SetCursorPosition(oXCur + 20, oYCur + 20);

        }
        public static void MovingCloud(int ofSetY)
        {
            //clears input so doesn't automatically stop
            var prevKey = (Console.KeyAvailable) ? Convert.ToString(Console.ReadKey()) : "";

            //make take in -ves
            //could cause problems if you want to change screen size
            var width = 20;
            int animationOX = Console.CursorLeft;
            int animationOY = Console.CursorTop + ofSetY - 1;
            String Cloud = "(██████)";
            int cloudLen = Cloud.Length;
            String aCloud = Cloud;
            int aCloudLen = aCloud.Length;

            //checks if input avalible  
            while (!Console.KeyAvailable) {
                if (aCloud.TrimEnd('░').Length < width) {
                    //may be right?
                    aCloud = "░" + aCloud.TrimEnd('░') + new String('░', width - aCloud.TrimEnd('░').Count());

                }
                else
                {
                    //only errors if cloud doesn't fit on screen
                    aCloud = Cloud + new String('░', width - Cloud.Length);
                }
                Console.SetCursorPosition(animationOX, animationOY);
                Console.Write(aCloud);
                Thread.Sleep(500);
            }
            //gets rid of key input
            Console.ReadKey();
            Console.SetCursorPosition(animationOX, animationOY);
            Console.Write(new String(' ', aCloud.Length));
            Console.SetCursorPosition(animationOX, animationOY);



        }
    }

}
