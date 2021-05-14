using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bonk_Knight
{
    public class Functions
    {
        public static void WriteHelp()
        {
            Console.SetCursorPosition(Globals.Ox + Globals.GSW + 2, Globals.Oy);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("h - help  ");
            Console.ForegroundColor = ConsoleColor.White;
        }
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
        //public static int GetRowNum(String TextToGetHeight)
        //{
        //    var RowNumbers = 0;
        //    Tex
        //    return RowNumbers;
        //}
        public static void resetCursor()
        {
            Console.SetCursorPosition(Globals.Sx, Globals.Sy);
        }
        public static void CursorBellowScreen()
        {
            Console.SetCursorPosition(0, 13);
        }
        public static void CursourLogLineClear(String MessageToClear = null)
        {
            // if the input message is longer then 28 it will ruin screen so stop that
            
            if (MessageToClear != null) 
            {
                Console.SetCursorPosition(Globals.Sx, 11);
                // +28 to take into acount for the info asking in the screen
                Console.Write(new String(' ', MessageToClear.Length + 28));
            }
            Console.SetCursorPosition(Globals.Sx, 11);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(new String(' ', 30) + "│");
            Console.SetCursorPosition(Globals.Sx, 11);
        }
        public static void LineWithSubText(String MainText, String Subtext = "", ConsoleColor HighlightColor = ConsoleColor.White)
        {
            if (Subtext.Length + MainText.Length <= 28)
            {
                Console.ForegroundColor = HighlightColor;
                //centers text            Screen left + half width of screen - half text
                Console.SetCursorPosition(Globals.Sx , Console.CursorTop);
                Console.Write(MainText);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(Subtext);
            }
            else
            {
                MakeErrorMessage($"{Subtext} too long for Screen area");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void CursourLogLineWrite(String ToWriteIn)
        {
            CursourLogLineClear();
            if (ToWriteIn.Length <= 28) {
                Console.Write(ToWriteIn);
            }
            else
            {
                MakeErrorMessage($"{ToWriteIn} too long for Log area");
            }
        }
        public static void CentedTextSubText(String MainText, String Subtext = "",ConsoleColor HighlightColor = ConsoleColor.White)
        {
            if (Subtext.Length <= 28)
            {
                Console.ForegroundColor = HighlightColor;
                //centers text            Screen left + half width of screen - half text
                Console.SetCursorPosition((Globals.Sx + (Globals.GSW - 2) / 2 - Convert.ToInt32(MainText.Length/2)), Console.CursorTop);
                Console.Write(MainText);
            }
            else
            {
                MakeErrorMessage($"{MainText} too long for Screen area");
            }
            if (Subtext.Length <= 28)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(Globals.Sx + (Globals.GSW - 2) / 2 - Convert.ToInt32(Subtext.Length / 2), Console.CursorTop + 1);
                Console.Write(Subtext);
            }
            else
            {
                MakeErrorMessage($"{Subtext} too long for Screen area");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void SlowScrollText(String textToScroll, int LeftAlign = Globals.Sx, int speed = 10, ConsoleColor textClr = ConsoleColor.White)
        {
            Console.SetCursorPosition(LeftAlign, Console.CursorTop);
            Console.ForegroundColor = textClr;
            foreach (char ScrollText in textToScroll)
            {
                if (ScrollText == '%')
                {
                    Console.SetCursorPosition(LeftAlign,Console.CursorTop + 1);
                }
                else 
                {
                    Console.Write(ScrollText);
                    Thread.Sleep(Convert.ToInt32(speed * Globals.GameSpeed));
                }
            }
        }
        public static int LastRand = 1;
        public static int RandomRandUntilNewRand(int start, int end)
        {
            var rond = new Random();
            var Rnd = rond.Next(start, end + 1);
            while (Rnd == LastRand && start != end + 1 && start != end) {
                Rnd = rond.Next(start, end + 1);
            }
            LastRand = Rnd;
            return Rnd;
        }
        public static void MakeErrorMessage(String message)
        {
            //catches bugs
            CursorBellowScreen();
            Console.WriteLine(message);
            System.Diagnostics.Debug.WriteLine(message);
        }
        public static void ColourPalet(String ColorPalet, String letter = "")
        {
            ConsoleColor Col = ConsoleColor.White;
            switch (ColorPalet.ToLower()) 
            {
                case "logline":
                case "log":
                    switch (letter)
                    {
                        case "H":
                        case "P":
                            Col = GC("red");
                            break;
                        case "₿":
                            Col = GC("green");
                            break;
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
                        case "7":
                        case "8":
                        case "9":
                        case "0":
                            Col = GC("y");
                            break;
                        default:
                            Col = GC("w");
                            break;
                    }
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = Col;
        }
        public static ConsoleColor GC(string color)
        {
            String colour = "";
            //get color
            switch (color)
            {
                case "b":
                case "blue":
                    colour = "Blue";
                    break;
                case "B":
                case "DarkBlue":
                case "darkblue":
                    colour = "DarkBlue";
                    break;
                case "C":
                case "DarkCyan":
                case "darkcyan":
                    colour = "DarkCyan";
                    break;
                case "c":
                case "Cyan":
                case "cyan":
                    colour = "Cyan";
                    break;
                case "y":
                case "Yellow":
                case "yellow":
                    colour = "Yellow";
                    break;
                case "M":
                case "DarkMagenta":
                case "darkmagenta":
                    colour = "DarkMagenta";
                    break;
                case "m":
                case "Magenta":
                case "magenta":
                    colour = "Magenta";
                    break;
                case "r":
                case "Red":
                case "red":
                    colour = "Red";
                    break;
                case "g":
                case "DarkGray":
                case "darkgray":
                    colour = "DarkGray";
                    break;
                case "z":
                case "Y":
                case "DarkYellow":
                case "darkyellow":
                    colour = "DarkYellow";
                    break;
                case "x":
                case "DarkRed":
                case "darkred":
                    colour = "DarkRed";
                    break;
                case "e":
                case "Green":
                case "green":
                    colour = "Green";
                    break;
                case "E":
                case "DarkGreen":
                case "darkgreen":
                    colour = "DarkGreen";
                    break;
                case "?":
                    List<String> allCol = new List<String> { "b", "r", "g", "e", "d", "w","z","x","y","E","m","M","B" };
                    return GC(allCol[(new Random()).Next(allCol.Count)]);
                default:
                    colour = "White";
                    break;
            }

            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);
        }
    }
}
