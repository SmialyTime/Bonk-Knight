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
        //Globals.Screen[rw,cl]
        public static String LastEvent = "";
        public static char[,] Screen = new char[9, 30];
    }

    class MainClass
    {
         
        public static void Main(string[] args)
        {
            InitializeComponents();
            Render.CursorBellowScreen();
            char Continue = keyInput();
            while(Continue != ''/*esc*/)
            {
                //use key 
                switch (Continue)
                {
                    case 'a':
                        //left
                        break;
                    case 'd':
                        //right
                        break;
                    case 'n':
                        //displays next background
                        Render.ChangeScreen(0,0,Art.Background(Map.nextBg()));
                        Render.RenderScreen("all");
                        break;
                }

                //make better
                Continue = ' ';
                Continue = keyInput();
                Functions.CursorBellowScreen();
            }
            Functions.CursorBellowScreen();
            TESTAni.RunWalkCycle();


            Console.ResetColor();
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
            if (Globals.AnimationRunning == false) 
            {
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();
                    if (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Backspace) {
                        char ltr = Convert.ToChar(input.KeyChar);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(' ');
                        //clears character stuff
                        while (Console.KeyAvailable == true)
                        {
                            input = Console.ReadKey();
                            if (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Backspace)
                            {
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                Console.Write(' ');
                            }
                        }
                        return ltr;
                    }
                    else
                    {
                        while (Console.KeyAvailable == true)
                        {
                            input = Console.ReadKey();
                            if (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Backspace)
                            {
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                Console.Write(' ');
                            }
                        }
                        return '回';/*place holder for enter*/}
                }
                else { return ' '; }
            }
            else{return ' ';}
        }
    }
}
