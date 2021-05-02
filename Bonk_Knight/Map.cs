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
    class Map
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
    }
}
