using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class GameRunning
    {
        public GameRunning()
        {
            Globals.GameGoing = true;
            char Continue = keyInput();
            while (Continue != ''/*esc*/)
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
                        Render.ChangeScreen(0, 0, Art.Background(Map.nextBg()));
                        Render.RenderScreen("all");
                        break;
                    case 't':
                        TESTAni.RunWalkCycle();
                        break;
                }

                //make better
                Continue = ' ';
                Continue = keyInput();
                Functions.CursorBellowScreen();
            }
            Globals.GameGoing = false;
        }
        public static char keyInput()
        {
            //missing some key inputs
            if (Globals.AnimationRunning == false)
            {
                if (Console.KeyAvailable)
                {
                    //KeyPressed?.Invoke(this, EventArgs.Empty);
                    var input = Console.ReadKey();
                    if (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Backspace)
                    {
                        char ltr = Convert.ToChar(input.KeyChar);
                        System.Diagnostics.Debug.WriteLine($"{ltr} pressed");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(' ');
                        //clears character stuff
                        Functions.ClearKeyIntputs();
                        return ltr;
                    }
                    else { System.Diagnostics.Debug.WriteLine($"Enter+stuff"); Functions.ClearKeyIntputs(); return '回';/*place holder for enter*/}
                }
                else { Functions.ClearKeyIntputs(); return '㊅'; }
            }
            else { System.Diagnostics.Debug.WriteLine($"Animation running"); return ' '; }
        }

    }
}
