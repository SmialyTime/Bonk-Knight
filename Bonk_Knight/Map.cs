using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    public static class Areas
    {
        public static List<String> bg = new List<string>() { "Throne", "Mountain","Caves", "ForestEntrance", "ForestExit", "KingdomEntrance", "Wall","Wall2","Wall3","Courtyard"};
        public static int CurrentBg = 0;
    }
    class Map : Render
    {
        public static String nextBg()
        {
            if (Areas.bg.Count - 1 == Areas.CurrentBg)
            {
                Areas.CurrentBg = 0;
            }
            else
            {
                Areas.CurrentBg++;
            }
            return Areas.bg[Areas.CurrentBg];
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
