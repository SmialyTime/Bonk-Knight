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
            else { /*Doesn't run*/  Functions.ClearKeyIntputs(); System.Diagnostics.Debug.WriteLine($"Animation running"); return ' '; }
        }


        /*
        //must open and load this function from the inital stuff first to get it linked 
        public void EventMap()
        {
            MainClass.Keys.KeyPressed += Keys_KeyPressed;
        }

        private void Keys_KeyPressed(object sender, KeyPressedInfo e)
        {
            System.Diagnostics.Debug.WriteLine("ME too");
        }*/
    }
}
