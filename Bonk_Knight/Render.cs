using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class Render : Functions
    {
        public static void RenderScreen(String Part)
        {
            //Part == all
            Console.SetCursorPosition(Globals.Sx, Globals.Sy);
            for (int rw = 0; rw < 9; rw++)
            {
                for (int cl = 0; cl < 30; cl++)
                {
                    setColor(Globals.Screen[rw, cl]);
                    Console.Write(Globals.Screen[rw, cl]);
                }
                Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            }
            //to ref the screen array use Screen[row][columb] & double nested for loops
            resetCursor();
            CursorBellowScreen();
        }
        public static void ChangeScreen(int Row, int Column, String ToAdd)
        {
            //adds ToAdd it at the Row and Columb (from top left corner) if it will fix
            int rw = Row;
            int cl = Column;
            int elm = 0;
            String junk = "";
            for (int i = 0; i < ToAdd.Length; i++)
            {
                if (ToAdd[elm] == '%')
                {
                    rw++;
                    cl = Column;
                }
                else
                {
                    if (rw >= 9 || cl >= 30)
                    {
                        junk += ToAdd[rw + cl];
                    }
                    else
                    {
                        Globals.Screen[rw, cl] = ToAdd[elm];
                    }
                    cl++;
                }
                elm++;
            }
        }
        public static void RenderOutline(int w, int h)
        {
            int OrigX = Globals.Sx - 1;
            int OrigY = Globals.Sy - 1;
            char side = '│';
            char topB = '─';
            Console.SetCursorPosition(OrigX, OrigY);
            Console.Write($"┌{new String(topB, w)}┐");
            for (int hig = 0; hig < h; hig++)
            {
                Console.SetCursorPosition(OrigX, Console.CursorTop + 1);
                Console.Write(side);
                mc(w, 0);
                Console.Write(side);
            }
            //clean up the console at the end
            Console.SetCursorPosition(OrigX, Console.CursorTop + 1);
            Console.Write($"├{new String(topB, w)}┤");
            Console.SetCursorPosition(OrigX, Console.CursorTop + 1);
            Console.Write($"│{new String(' ', w)}│");
            Console.SetCursorPosition(OrigX, Console.CursorTop + 1);
            Console.Write($"└{new String(topB, w)}┘");
            //set the cursour back to the original position??
        }
        public static void setColor(char inChar)
        {
            ConsoleColor forgColor;
            switch (inChar)
            {
                case '*':
                    forgColor = Functions.GC('?');
                    break;
                case 'τ':
                    forgColor = Functions.GC('r');
                    break;
                case 'c':
                    forgColor = Functions.GC('y');
                    break;
                case '~':
                case '╬':
                    forgColor = Functions.GC('m');
                    break;
                case '⌡':
                case '⌠':
                case '║':
                case '╦':
                    forgColor = Functions.GC('B');
                    break;
                case '╢':
                case '╖':
                case '╓':
                case '╟':
                    forgColor = Functions.GC('b');
                    break;
                case '╘':
                case 'δ':
                case 'Φ':
                case '╛':
                    forgColor = Functions.GC('M');
                    break;
                case '(':
                case ')':
                case '′':
                case '″':
                case '‴':
                    forgColor = Functions.GC('g');
                    break;
                case '‘':
                case '’':
                case ',':
                case '‛':
                case '“':
                case '”':
                case '„':
                    forgColor = Functions.GC('E');
                    break;
                default:
                    forgColor = Functions.GC('w');
                    break;
            }
            Console.ForegroundColor = forgColor;
        }
    }
}
