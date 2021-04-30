using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace Bonk_Knight
{
    public static class Globals
    {
        public static int Sx = 1;
        public static int Sy = 1;
        //Globals.Screen[rw,cl]
        public static String LastEvent = "";
        public static char[,] Screen = new char[9, 30];
    }

    class MainClass
    {
         
        public static void Main(string[] args)
        {
            InitializeComponents();
            CursorBellowScreen();
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
                        ChangeScreen(0,0,Art.Background(Map.nextBg()));
                        break;
                }

                //make better
                Continue = ' ';
                Continue = keyInput();
                CursorBellowScreen();
            }
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
            RenderOutline(30, 9);
        }
        public static void ChangeScreen(int Row, int Column, String ToAdd)
        {
            //adds ToAdd it at the Row and Columb (from top left corner) if it will fix
            int rw = Row;
            int cl = Column;
            int elm = 0;
            String junk = "";
            for (int i = 0;i<ToAdd.Length;i++)
            {
                if (ToAdd[elm] == '%')
                {
                    rw++;
                    cl = Column;
                }
                else
                {
                    if (rw >= 9 ||cl >=30)
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
            RenderScreen();
        }
        public static void RenderScreen()
        {
            Console.SetCursorPosition(Globals.Sx, Globals.Sy);
            for (int rw = 0; rw < 9; rw++)
            {
                for (int cl = 0; cl < 30; cl++)
                {
                    setColor(Globals.Screen[rw, cl]);
                    Console.Write(Globals.Screen[rw,cl]);
                }
                Console.SetCursorPosition(Globals.Sx, Console.CursorTop+1);
            }
            //to ref the screen array use Screen[row][columb] & double nested for loops
            resetCursor();
            CursorBellowScreen();
        }
        public static void RenderOutline(int w,int h){
            int OrigX = Globals.Sx-1;
            int OrigY = Globals.Sy-1;
            char side = '│';
            char topB = '─';
            Console.SetCursorPosition(OrigX,OrigY);
            Console.Write($"┌{new String(topB,w)}┐");
            for(int hig=0; hig<h;hig++) {
                Console.SetCursorPosition(OrigX,Console.CursorTop+1);
                Console.Write(side);
                mc(w,0);
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
        public static void mc(int xPlus,int yPlus)
        {
            Console.SetCursorPosition(Console.CursorLeft + xPlus, Console.CursorTop + yPlus);
        }
        public static char keyInput()
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
            else{return ' ';}
        }

        public static void setColor(char inChar)
        {
            ConsoleColor forgColor;
            switch (inChar)
            {
                case '*':
                    forgColor = GC('?');
                    break;
                case 'τ':
                    forgColor = GC('r');
                    break;
                case 'c':
                    forgColor = GC('y');
                    break;
                case '~':
                case '╬':
                    forgColor = GC('m');
                    break;
                case '⌡':
                case '⌠':
                    forgColor = GC('B');
                    break;
                case '╘':
                case 'δ':
                case 'Φ':
                case '╛':
                    forgColor = GC('M');
                    break;
                case '(':
                case ')':
                case '′':
                case '″':
                case '‴':
                    forgColor = GC('g');
                    break;
                case '‘':         
                case '’':
                case ',':
                case '‛':
                case '“':
                case '”':
                case '„':
                    forgColor = GC('E');
                    break;
                default:
                    forgColor = GC('w');
                    break;
            }
            Console.ForegroundColor = forgColor;
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
                case 'e':
                    colour = "Green";
                    break;
                case 'E':
                    colour = "DarkGreen";
                    break;
                case '?':
                    List<char> allCol = new List<char>{'b','r','g','e','d','w'};
                    return GC(allCol[(new Random()).Next(allCol.Count)]);
                    break;
                default:
                    colour = "White";
                    break;
            }
            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);
        }
        public static void resetCursor()
        {
            Console.SetCursorPosition(Globals.Sx, Globals.Sy);
        }
        public static void CursorBellowScreen()
        {
            Console.SetCursorPosition(0,13);
        }

    }
}
