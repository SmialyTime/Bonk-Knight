using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    public static class Areas
    {
        public static List<String> bg = new List<string>(){ "Mountain","Caves", "ForestEntrance", "Forest1", "Forest2","Forest3", "ForestExit", "KingdomEntrance", "Wall","Wall2","Wall3","Courtyard", "Throne"};
        public static int CurrentBg = 0;
    }
    public class Section
    {
        //number of enemies
        public int Enemies { get; set;}

        //A multiplyer of the enemy streangth
        public Decimal EnemyDifficulty { get; set;}

        //Biome type for Color and Enemy Type
        public String Type { get; set; }

        //Name for background referance 
        public String SectionName { get; set; }
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

        public Map(String Difficulty)
        {
            var dif = 2;// 1  = easy , 2 = medium, 3 = hard
            //easy:   enemies x0.5 as Strong, normaly x1   enemies, 3 Stages per Section,x0.5 total gold to collect
            //medium: enemies x1.0 as Strong, normaly x1-2 enemies, 5 Stages per Section,x1.0 total gold to collect
            //hard:   enemies x1.5 as Strong, normaly x2-3 enemies, ?? Stages per Section,x1.5 total gold to collect
            switch (Difficulty)
            {
                case "Easy":
                    dif = 1;
                    break;
                case "Medium":
                    dif = 2;
                    break;
                case "Hard":
                    dif = 3;
                    break;
            }
            CreateGameMap(dif,5);
        }
        public static void CreateGameMap(int difficulty, int SectionPerStage)
        {
            //basic hard coded layout home -> Mountains -> Cave -> Forest -> Village -> castle -> throneRoom
            List<Section> GameSectionMap = new List<Section>() { };
            //home
            //add tutorial to home??
            Section home = new Section();
                home.Enemies = 0;
                home.EnemyDifficulty = 0;
                home.Type = "Regular";
                home.SectionName = "Home";
                GameSectionMap.Add(home);
            //Mountains 
            for (var MountainRange = 0 ; MountainRange <= SectionPerStage; MountainRange++) {
                Section Mount = new Section();
                Mount.Enemies = (new Random()).Next(1,1);
                Mount.EnemyDifficulty = 0;
                Mount.Type = "Mountain";
                if (MountainRange == 0){Mount.SectionName = "MountainEnterance";}
                else if (MountainRange == SectionPerStage){Mount.SectionName = "MountainExit";}
                else{Mount.SectionName = "Mountain" + MountainRange;}
                GameSectionMap.Add(Mount);
            }
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
