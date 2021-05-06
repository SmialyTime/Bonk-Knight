using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    public class Functions
    {
        public static void mc(int xPlus, int yPlus)
        {
            Console.SetCursorPosition(Console.CursorLeft + xPlus, Console.CursorTop + yPlus);
        }
        public static void mcL(int yPlus)
        {
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + yPlus);
        }
        public static void w(String a)
        {
            Console.Write(a);
        }
        public static void ClearKeyIntputs()
        {
            while (Console.KeyAvailable == true)
            {
                var input = Console.ReadKey();
                if (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Backspace)
                {
                    if (Console.CursorLeft > 0) {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(' ');
                    }
                }
            }
        }
        public static void mmcL(int yPlus)
        {
            Console.SetCursorPosition(Globals.Ox, Console.CursorTop + yPlus);
        }
        public static void resetCursor()
        {
            Console.SetCursorPosition(Globals.Sx, Globals.Sy);
        }
        public static void CursorBellowScreen()
        {
            Console.SetCursorPosition(0, 13);
        }
        public static void MakeErrorMessage(String message)
        {
            //catches bugs
            CursorBellowScreen();
            Console.WriteLine(message);
            System.Diagnostics.Debug.WriteLine(message);
        }
        public static ConsoleColor GC(char color)
        {
            String colour = "";
            //get color
            switch (color)
            {
                case 'b':
                    colour = "Blue";
                    break;
                case 'B':
                    colour = "DarkBlue";
                    break;
                case 'C':
                    colour = "DarkCyan";
                    break;
                case 'c':
                    colour = "Cyan";
                    break;
                case 'y':
                    colour = "Yellow";
                    break;
                case 'M':
                    colour = "DarkMagenta";
                    break;
                case 'm':
                    colour = "Magenta";
                    break;
                case 'r':
                    colour = "DarkRed";
                    break;
                case 'g':
                    colour = "DarkGray";
                    break;
                case 'z':
                    colour = "DarkYellow";
                    break;
                case 'x':
                    colour = "DarkRed";
                    break;
                case 'e':
                    colour = "Green";
                    break;
                case 'E':
                    colour = "DarkGreen";
                    break;
                case '?':
                    List<char> allCol = new List<char> { 'b', 'r', 'g', 'e', 'd', 'w','z','x','y','E','m','M','B' };
                    return GC(allCol[(new Random()).Next(allCol.Count)]);
                default:
                    colour = "White";
                    break;
            }

            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);
        }
    }
}
