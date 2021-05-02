using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class buttons
    {
        //ON start up
        public buttons()
        {
            KeyPress();            
        }


        public static void KeyPress()
        {
            button but = new button();
            //defines what happens when ClickEvent called
            but.ClickEvent += (s, args) =>
            {
                Console.WriteLine($"I know you are {args.num} {args.Name}");
            };
        }
        /*public event EventHandler KeyDown;
        public static void checkKeyDown()
        {
            
        }*/
    }
    public class button
    {
        public event EventHandler<myCustomArgs> ClickEvent;

        public void OnClick()
        {
            //way to pass in multipel args clearly
            myCustomArgs myCustomArgs = new myCustomArgs();
            myCustomArgs.Name = "Mimi";
            myCustomArgs.num = 19;
            //runs all events named clickEvent
            ClickEvent?.Invoke(this, myCustomArgs);
        }
    }
    public class myCustomArgs
    {
        public string Name { get; set; }
        public int num { get; set; }
    }
}