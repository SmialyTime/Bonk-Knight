using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bonk_Knight
{
    class AsciiArtTesting
    {
        public static void funWAscii()
        {
            Console.Clear();

            //Console.CursorVisible = false;
            int count = 0;
            while (count < 1)
            {/*
                w("  \___/\")
                w("   ___ |" + new String(' ', 5) + "xx");
                w("  / | \/" + new String(' ', 5) + "xx");
                w("    |    " + new String(' ', 5) + "xx");
                w("    x    " + new String(' ', 5)+"xx");
                 
                w("  (>|<)    "    )
                w("    |      "    )
                w("    x    "*/
                count++;
            }
            w("   ██  ██");
            w(" ██  ██");
            w(" █▄▀▌▐░▒▓ ");
            w("(>-<)");
            w("  | ");
            w("  x ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            w(" █╦█");
            w("  ║ ");
            w("  ╨ ");




            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            //
            //Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("     test        ");
            String mount = @"   /\   ";
            w(mount);
            mount = @"  /  \  ";
            w(mount);
            mount = @" /    \ ";
            w(mount);
            Console.Clear();

            w("|     |    |    |   |  |  |  |  | ");
            w("'--┬--'--.-'--.-'-.-'-.'-.'-.'-.'-.");
            w("   |     |    |   |   |  |  |  |  |");
            w("   ````''`:---:.__!   |  |  |  |  | ");
            w("                   ``'''':--:-.:__|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            var floor = @"___\____\____";
            var floor2 = @"\____\____";
            w(floor);
            w(floor2);
            w(floor);


            //trails == really cool , .........:::::::

            ///font!!!!!!!! 1:1 vs 1:2
            //using ‾ vs _     •
            //using A Y other chars are very eye catching but v V o O T L 7 U c C x X
            /*  o7
               /|
                \7     */
            // Lines & Materials
            /* lower angles mean more variety - higher = less(centre aligned)
                
			      /
			     /
			    /
			       ,´
			      /
			    ,´
			        .´
			      .´
			    .´   _
			       _/
			     _/
			    /
			       _.-´
			    .-´
			          _,.- 
			    ,.-'´‾
			         ___,- 
			    ,---´

            
             
              /‾‾\
              [oo]
            \./||\,/
             \-:\/

            '   ' ' '
             ' ' ' '  '
            ,-.  /‾‾]'
            ,[‾‾‾   ]'

              */
        }
        public static void w(String a)
        {
            Console.WriteLine(a);
        }
    }
}
