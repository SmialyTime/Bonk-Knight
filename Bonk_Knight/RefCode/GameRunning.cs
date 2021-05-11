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
            Globals.GameGoing = false;
        }

        /*
        //must open and load this function from the inital stuff first to get it linked 
        public void EventMap()
        {
            MainClass.Keys.KeyPressed += Keys_KeyPressed;
        }

        private void Keys_KeyPressed(object sender, KeyPressedInfo e)
        {
        }*/
    }
}
