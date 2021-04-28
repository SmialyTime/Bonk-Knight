using System;
using System.Collections.Generic;
using System.Threading;

namespace Bonk_Knight
{
    public static class Globals
    {
        public /*const*/ static int SSHeight = 15;
        public /*const*/ static int SSWidth = 15;
        //public static List<List<Char>> Screen = new List<List<Char>>{}  ;
        //Globals.Screen[rw,cl]
        public static char[,] Screen = {{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                       ,{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                       ,{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                       ,{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                       ,{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                       ,{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                       ,{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                       ,{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                       ,{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }};
    }

    class MainClass
    {
         
        public static void Main(string[] args)
        {
            //Console.WriteLine("my dude thats cool!");
            //AsciiArtTesting.funWAscii();  
            String lettre = "-" ;
            for (var i = 0; i < 1000; i++)
            {
                lettre = Convert.ToString("abcdefghijklmnopqrstuvwxyz"[(new Random()).Next(25)]);
                ChangeScreen(1, 1, lettre);
            }
            Console.WriteLine("having fun?");
            //Animations.MovingCloud(1);

            //TestingEvents EventRunnerGo = new TestingEvents();

            //come back to - Animations.HoleInRect();
            //remove later

            Console.ResetColor();
            Console.WriteLine("press any button to continue");
            Console.ReadLine();
            Console.ReadKey();
        }

        public static void ChangeScreen(int Row, int Column, String ToAdd)
        {
            //adds ToAdd it at the Row and Columb (from top left corner) if it will fit
            for (int rw = 0;rw<9;rw++)
            {
                for (int cl = 0; cl < 30; cl++)
                {
                    Globals.Screen[rw, cl] = ToAdd[0];
                }
            }
            RenderScreen();

        }
        public static void RenderScreen()
        {
            Console.SetCursorPosition(0, 0);
            //render surrounding box when game initialised -------------------------------add in later
            for (int rw = 0; rw < 9; rw++)
            {
                for (int cl = 0; cl < 30; cl++)
                {
                    Console.Write(Globals.Screen[rw,cl]);
                }
                Console.SetCursorPosition(0,Console.CursorTop+1);
            }
            //to ref the screen array use Screen[row][columb] & double nested for loops

        }
    }
}
