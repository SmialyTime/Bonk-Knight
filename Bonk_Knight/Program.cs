using System;

namespace Bonk_Knight
{
    public static class Globals
    {
        public /*const*/ static int SSHeight = 15;
        public /*const*/ static int SSWidth = 15;
    }
    class MainClass
    {
         
        public static void Main(string[] args)
        {
            //Console.WriteLine("my dude thats cool!");
            //AsciiArtTesting.funWAscii();
            Console.WriteLine("having fun?");
            //Animations.MovingCloud(1);

            TestingEvents EventRunnerGo = new TestingEvents();

            //come back to - Animations.HoleInRect();
            //remove later

            Console.ResetColor();
            Console.WriteLine("press any button to continue");
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
