using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace Bonk_Knight
{
    public static class Globals
    {
        public static int Ox = 0;
        public static int Oy = 0;
        public static int Sx = 1;
        public static int Sy = 1;
        public static int GroundInGameY = 8;
        public static bool AnimationRunning = false;
        public static bool GameGoing = false;
        public static String Terrain = "Uknown";
        //to print to position x,y do Console.SetCursorPosition(x,y); <remember 0 indexed
        //Globals.Screen[rw,cl]
        public static String LastEvent = "";
        public static char[,] Screen = new char[9, 30];
    }
    class MainClass
    {
        //makes an eventHandler to be called and referenced for the event of Key input
        public static KeyHandler Keys = new KeyHandler();
        public static Map GameMap = new Map("Medium");
        public static void Main(string[] args)
        {
            Console.SetWindowSize(32,15);
            InitializeComponents();
            Render.CursorBellowScreen();

            Map GameMap = new Map("Medium");

            Globals.GameGoing = true;
            char Continue = keyInput();
            while (Globals.GameGoing == true)
            {
                //use key 
                switch (Continue)
                {
                    case 'a':
                        //left
                        Map.PrevScreen();
                        break;
                    case 'd':
                        //right
                        Map.NextScreen();
                        break;
                    case 'n':
                        //displays next background
                        Render.ChangeScreen(0, 0, Art.Background(Map.nextBg()));
                        Render.RenderScreen("all");
                        break;
                    case 't':
                        TESTAni.RunWalkCycle();
                        break;
                    case ''/*Esc*/:
                        Globals.GameGoing = false;
                        break;
                }

                //make better
                Continue = ' ';
                Continue = keyInput();
                Functions.CursorBellowScreen();
            }

            //change later
            Console.ResetColor();
            Console.ForegroundColor = Functions.GC('z');
            Console.WriteLine("press Enter button to continue");
            Console.ReadLine();
        }
        public static void InitializeComponents()
        {
            //changes it so more characters can be used
            Console.OutputEncoding = Encoding.UTF8;
            //todo
            //
            //player
            //map
            //Initialise Screen dict
            for (int dic = 0; dic < 9; dic++)
            {
                for (int gap = 0; gap < 30;gap++)
                {
                    Globals.Screen[dic, gap] = ' ';
                }
            }
            //main screen outline
            Render.RenderOutline(30, 9);
        }
        public static char keyInput()
        {
            //missing some key inputs
            if (Globals.AnimationRunning == false) 
            {
                if (Console.KeyAvailable)
                {
                    Keys.KeyI();
                    var input = Console.ReadKey();
                    if (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Backspace) {
                        char ltr = Convert.ToChar(input.KeyChar);
                        //2System.Diagnostics.Debug.WriteLine($"{ltr} pressed");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(' ');
                        //clears character stuff
                        Functions.ClearKeyIntputs();
                        return ltr;
                    }
                    else{ System.Diagnostics.Debug.WriteLine($"Enter+stuff"); Functions.ClearKeyIntputs();return '回';/*place holder for enter*/}
                }
                else{Functions.ClearKeyIntputs(); return '㊅'; }
            }
            else{System.Diagnostics.Debug.WriteLine($"Animation running"); return ' ';}
        }
    }
    public class KeyHandler
    {
        public event EventHandler<KeyPressedInfo> KeyPressed;
        public void KeyI()
        {
            //way to pass in multipel args clearly
            KeyPressedInfo myCustomArgs = new KeyPressedInfo();
            myCustomArgs.Key = "c";
            //runs all events named clickEvent
            KeyPressed?.Invoke(this, myCustomArgs);
        }
    }
    public class KeyPressedInfo
    {
        public string Key { get; set; }
    }
}
