using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class helpful
    {
        public int let;
        /*
        helpful b = new helpful();
        Animation a = new Animation();
        a.let = 1;
            a.spot = 2;
            a.ab = 5;
            Animation.WriteSomething();*/
        public static void WriteSomething()
        {
            Console.WriteLine("Hello World");
        }
    }
    class Render: helpful
    {
        public int spot;
    }
    class Animation : Render
    {
        public int ab;
        
        public static void wolf()
        {
            WriteSomething();
        }
    }
}
