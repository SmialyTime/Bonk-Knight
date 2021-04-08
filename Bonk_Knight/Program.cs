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
            Console.WriteLine("my dude thats cool!");
            //AsciiArtTesting.funWAscii();
            Animations.MovingCloud(5);
            
            //come back to - Animations.HoleInRect();
            //remove later

            Console.ResetColor();
            Console.Write("\n press any button to continue");
            Console.ReadKey();
        }
    }
}
