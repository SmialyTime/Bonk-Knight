using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class Events
    {
        //ON start up
        public Events()
        {
            Console.WriteLine("Test button press a");
            var key = Convert.ToString(Console.ReadKey());
            if (key == "a")
            {
                KeyPress();
            }
        }
        public static void KeyPress()
        {
            button but = new button();
        }
        /*public event EventHandler KeyDown;
        public static void checkKeyDown()
        {
            
        }*/
    }
    public class button
    {
        public event EventHandler OnSpacePressed;
        public void OnClick()
        {
            OnSpacePressed.Invoke(this, EventArgs.Empty);
        }

    }
}