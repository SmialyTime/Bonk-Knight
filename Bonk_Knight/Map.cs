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
        public static int CurrentSection = -1;
        public static List<Section> GameSectionMap = new List<Section>() { };
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
        public static void NextScreen()
        {
            //check player position edge of screen and enemies = 0;
            if (CurrentSection < GameSectionMap.Count-1)
            {
                CurrentSection++;
                //System.Diagnostics.Debug.WriteLine($"{CurrentSection}: {GameSectionMap[CurrentSection].SectionName}");
                Globals.Terrain = GameSectionMap[CurrentSection].Type;
                Render.ChangeScreen(0, 0, Art.Background($"{GameSectionMap[CurrentSection].SectionName}"));
                Render.RenderScreen("all");
            }
            else
            {
                //game ended??
                System.Diagnostics.Debug.WriteLine("GameEnd?????");
            }

            //initalize the new enemies
        }
        public static void PrevScreen()
        {
            //need to change --------------------check enemies = 0
            //check player position edge of screen and enemies = 0;
            if (CurrentSection > 0)
            {
                CurrentSection--;
                //System.Diagnostics.Debug.WriteLine($"{CurrentSection}: {GameSectionMap[CurrentSection].SectionName}");
                Globals.Terrain = GameSectionMap[CurrentSection].Type;
                Render.ChangeScreen(0, 0, Art.Background($"{GameSectionMap[CurrentSection].SectionName}"));
                Render.RenderScreen("all");
            }
            else
            {
                //game ended??
                System.Diagnostics.Debug.WriteLine("at start");
            }

            //initalize the new enemies
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
            CreateGameMap(dif,4);
        }
        public static void CreateGameMap(int difficulty, int SectionPerStage)
        {
            GameSectionMap = new List<Section>() { };
            //basic hard coded layout home -> Mountains -> Cave -> Forest -> Village -> Castle -> throneRoom
            //home
            //add tutorial to home??
            Section home = new Section();
                home.Enemies = 0;
                home.EnemyDifficulty = 0;
                home.Type = "home";
                home.SectionName = "Home";
                GameSectionMap.Add(home);
            //Mountains 
            for (var MountainRange = 0 ; MountainRange <= SectionPerStage; MountainRange++) {
                Section Mount = new Section();
                Mount.Enemies = (new Random()).Next(1,1);
                Mount.EnemyDifficulty = difficulty/2 + (MountainRange / 20);
                Mount.Type = "Mountain";
                if (MountainRange == 0){Mount.SectionName = "MountainEntrance";}
                else if (MountainRange == SectionPerStage){Mount.SectionName = "MountainExit";}
                else{Mount.SectionName = "Mountain" + MountainRange;}
                GameSectionMap.Add(Mount);
            }
            //Cave
            for (var CaveVein = 0 ; CaveVein <= SectionPerStage; CaveVein++) {
                Section Caven = new Section();
                Caven.Enemies = (new Random()).Next(1,2);
                Caven.EnemyDifficulty = difficulty/2 + (CaveVein / 20);
                Caven.Type = "Cave";
                if (CaveVein == 0){Caven.SectionName = "CaveEntrance";}
                else if (CaveVein == SectionPerStage){Caven.SectionName = "CaveExit"; }
                else{Caven.SectionName = "Cave" + CaveVein; }
                GameSectionMap.Add(Caven);
            }
            //Forest
            for (var ForestPart = 0 ; ForestPart <= SectionPerStage; ForestPart++) {
                Section Forst = new Section();
                Forst.Enemies = (new Random()).Next(1,2);
                Forst.EnemyDifficulty = difficulty/2 + (ForestPart / 20);
                Forst.Type = "Forest";
                if (ForestPart == 0){Forst.SectionName = "ForestEntrance"; }
                else if (ForestPart == SectionPerStage){Forst.SectionName = "ForestExit"; }
                else{Forst.SectionName = "Forest" + ForestPart; }
                GameSectionMap.Add(Forst);
            }
            //Village
            for (var VillageNum = 0 ; VillageNum <= SectionPerStage; VillageNum++) {
                Section Vill = new Section();
                Vill.Enemies = (new Random()).Next(1,2);
                Vill.EnemyDifficulty = difficulty/2 + (VillageNum / 20);
                Vill.Type = "Village";
                if (VillageNum == 0){Vill.SectionName = "VillageEntrance"; }
                else if (VillageNum == SectionPerStage){Vill.SectionName = "VillageExit"; }
                else{Vill.SectionName = "Village" + VillageNum; }
                GameSectionMap.Add(Vill);
            }
            //Kingdom/Castle
            for (var CastleNum = 0 ; CastleNum <= SectionPerStage; CastleNum++) {
                Section Castle = new Section();
                Castle.Enemies = (new Random()).Next(1,2);
                Castle.EnemyDifficulty = difficulty/2 + (CastleNum / 10);
                Castle.Type = "Kingdom";
                if (CastleNum == 0){Castle.SectionName = "KingdomEntrance"; }
                else if (CastleNum == SectionPerStage){Castle.SectionName = "Courtyard"; }
                else{Castle.SectionName = "Wall" + CastleNum; }
                GameSectionMap.Add(Castle);
            }
            //ThroneRoom
            Section ThroneRoom = new Section();
            ThroneRoom.Enemies = 1;
            ThroneRoom.EnemyDifficulty = difficulty/2;
            ThroneRoom.Type = "ThroneRoom";
            ThroneRoom.SectionName = "Throne";
            GameSectionMap.Add(ThroneRoom);

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
