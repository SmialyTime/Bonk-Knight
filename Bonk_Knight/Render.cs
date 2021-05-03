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
            if (Part.Contains(',')) {
                //renders a box defined by 2 points start and end
                //pass in a part that has form "RowInitial, ColumnInital,RowFinal,ColumnFinal"
                List<int> Bounderies = new List<int>(); 
                bool ValidData = true;
                //converts into usefull form in List
                foreach (var prt in Part.Split(','))
                {
                    if (int.TryParse(prt, out _)) {
                        Bounderies.Add(Convert.ToInt32(prt));
                    }
                    else
                    {
                        MakeErrorMessage($"Boundaries wrong {Part}");
                        ValidData = false;
                    }
                }
                if (ValidData)
                //Change to check if within screen size
                {
                    //Bounderies[0] : RowInitial
                    //Bounderies[1] : ColumnInital
                    //Bounderies[2] : RowFinal
                    //Bounderies[3] : ColumnFinal
                    if (Bounderies[0] <= Bounderies[2] && Bounderies[1] <= Bounderies[3])
                    {
                        //renders from left to right not top to bottom
                        Console.SetCursorPosition(Bounderies[1] + Globals.Sx, Bounderies[0] + Globals.Sy);

                        for (int CLM = Bounderies[1];CLM <= Bounderies[3];CLM++)
                        {
                            for (int ROW = Bounderies[0]; ROW <= Bounderies[2]; ROW++)
                            {
                                //setColor(Globals.Screen[ROW, CLM]);-----------------------------------------------------------
                                Console.Write(Globals.Screen[ROW, CLM]); //-1 because 0 indexed
                                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop + 1);
                            }
                            Console.SetCursorPosition(Console.CursorLeft + 1, Bounderies[0] + Globals.Sy);
                        }
                    }
                    else{MakeErrorMessage($"Can't Render Backwards: {Bounderies[0]} > {Bounderies[2]} || {Bounderies[1]} > {Bounderies[3]}");}
                }
            }
            else if (Part.Length == 2 && int.TryParse(Part, out _))
            {
                //renders multiple lines
                //Change to check if within screen size---------------------------
                for (var StartH = Convert.ToInt32(Part[0]); StartH < Convert.ToInt32(Part[1]); StartH++)
                {

                }
            }
            else
            {
                //renders whole screen
                Console.SetCursorPosition(Globals.Sx, Globals.Sy);
                for (int rw = 0; rw < 9; rw++)
                {
                    for (int cl = 0; cl < 30; cl++)
                    {
                        setColor(Globals.Screen[rw, cl]);
                        //to ref the screen multi-array use Screen[row][columb] in double nested for loops
                        Console.Write(Globals.Screen[rw, cl]);
                    }
                    Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
                }
            }
            resetCursor();
            CursorBellowScreen();
        }
        public static void RenderCustomScreen(char[,] ScreenToTender)
        {
            //renders whole screen
            Console.SetCursorPosition(Globals.Sx, Globals.Sy);
            for (int rw = 0; rw < 9; rw++)
            {
                for (int cl = 0; cl < 30; cl++)
                {
                    setColor(ScreenToTender[rw, cl]);
                    //to ref the screen multi-array use Screen[row][columb] in double nested for loops
                    Console.Write(ScreenToTender[rw, cl]);
                }
                Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            }
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
                        //only works for whole screen rendering
                        junk += ToAdd[elm];
                    }
                    else
                    {
                        if (Globals.AnimationRunning == false)
                        {
                            Globals.Screen[rw, cl] = ToAdd[elm];
                        }
                        else
                        {
                            //it is an animation
                            if (ToAdd[elm] != ' ')
                            {
                                Globals.Screen[rw, cl] = ToAdd[elm];
                            }
                            else
                            {
                                //current map char behind
                                Globals.Screen[rw, cl] = '#';
                            }
                        }
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
                case 'σ':
                    forgColor = Functions.GC('z');
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
                case '#':
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
                case '|':
                    if (Globals.Terrain == "Forest" && Globals.AnimationRunning == false)
                    {
                        forgColor = Functions.GC('z');
                    }
                    else
                    {
                        forgColor = Functions.GC('w');
                    }
                    break;
                case '`':
                case '´':
                case '^':
                    if (Globals.Terrain == "Forest" && Globals.AnimationRunning == false)
                    {
                        forgColor = Functions.GC('e');
                    }
                    else
                    {
                        forgColor = Functions.GC('w');
                    }
                    break;
                case '\\':
                case '/':
                    if (Globals.Terrain == "Forest" && Globals.AnimationRunning == false)
                    {
                        forgColor = Functions.GC('E');
                    }
                    else
                    {
                        forgColor = Functions.GC('w');
                    }
                    break;
                default:
                    forgColor = Functions.GC('w');
                    break;
            }

            //set for specific terrains
            switch (Globals.Terrain)
            {

            }

            Console.ForegroundColor = forgColor;
        }
    }
}
