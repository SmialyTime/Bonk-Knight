using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bonk_Knight
{
    class Animations
    {
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
                Console.SetCursorPosition(oXCur + 2, Console.CursorTop+=1);
            }
            Console.Write(hole);


            Console.SetCursorPosition(coXCur, coYCur);
            Console.ReadKey();
            //indent it you have to do it the line before
            Console.SetCursorPosition(Console.CursorLeft + 25, Console.CursorTop+=1);
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
            Console.SetCursorPosition(oXCur+20, oYCur+20);

        }
        public static void MovingCloud(int LineNumberUP)
        {
            //make take in -ves
            //could cause problems if you want to change screen size
            var width = Globals.SSWidth;
            int animationOX = Console.CursorTop;
            int animationOY = Console.CursorLeft+1;
            String Cloud = "(██████)";
            int cloudLen = Cloud.Length;
            String aCloud = Cloud;
            int aCloudLen = aCloud.Length;
            while (! Console.KeyAvailable) {
                if (aCloud.TrimEnd(' ').Length<width) {
                    //may be right?
                    aCloud = " " + aCloud.TrimEnd(' ') + new String(' ',width - aCloud.TrimEnd(' ').Count()) ;
                    
                }
                else
                {
                    //only errors if cloud doesn't fit on screen
                    aCloud = Cloud + new String(' ',width-Cloud.Length);
                }
                Console.SetCursorPosition(animationOX, animationOY);
                Console.Write(aCloud);
                Thread.Sleep(500);
            }
            
        }
    
        public static void ControlableAni(String keyToPress)
        {

        }

        public static void doubleAniWhat()
        {

        }
    }
}
