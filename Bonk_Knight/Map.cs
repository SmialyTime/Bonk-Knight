using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    public class Section
    {
        //number of enemies
        public int Enemies { get; set;}

        //A multiplyer of the enemy streangth
        public double EnemyDifficulty { get; set;}

        //Biome type for Color and Enemy Type
        public String Type { get; set; }

        //Name for background referance 
        public String SectionName { get; set; }
    }

    public class EnemyHandler
    {
        public event EventHandler<String> EnemyDied;
        public void Enemyded(String EnemyNm)
        {
            //way to pass in multipel args clearly
            //runs all events named clickEvent
            EnemyDied?.Invoke(this, EnemyNm);
        }
    }

    public class Map : Render
    {
        public int CurrentSection = 0;
        public List<Section> GameSectionMap = new List<Section>() { };
        public List<Enemy> CurrentEnemies = new List<Enemy>() { };
        public static EnemyHandler EnemyDied = new EnemyHandler();


        public Map(String Difficulty)
        {
            //add to event stuff  if 'm' => LoadMapWindow()

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
            CreateGameMap(dif, 4);
            Map.EnemyDied.EnemyDied += RemoveDeadEnemies;
        }
        private void RemoveDeadEnemies(object sender, string e)
        {
            foreach (Enemy EDeadCheck in this.CurrentEnemies)
            {
                if (EDeadCheck.Health <= 0)
                {
                    this.CurrentEnemies.Remove(EDeadCheck);
                }
            }
        }
        public static void LoadMapWindow()
        {
            Art.MapUI("Home",1);
        }
        public void LoadCurrentScreen()
        {
            Render.ChangeBackground(this);
            Globals.Terrain = this.GameSectionMap[this.CurrentSection].Type;
            Render.ChangeScreen(0, 0, Art.Background($"{this.GameSectionMap[this.CurrentSection].SectionName}"));
            Render.RenderScreen("all");

        }
        public void NextScreen()
        {
            //IMPROVE - null case?
            if (CurrentSection < this.GameSectionMap.Count - 1 && MainClass.Player_1.Position == 6 && this.CurrentEnemies.Count == 0)
            {
                this.CurrentSection++;
                Render.ChangeBackground(this);
                //System.Diagnostics.Debug.WriteLine($"{this.this.CurrentSection}: {this.GameSectionMap[this.this.CurrentSection].SectionName}");
                Globals.Terrain = this.GameSectionMap[this.CurrentSection].Type;
                Render.ChangeScreen(0, 0, Art.Background($"{this.GameSectionMap[this.CurrentSection].SectionName}"));


                //initalize the new enemies
                for (int i = 0; i < this.GameSectionMap[this.CurrentSection].Enemies ; i++)
                {
                    //ADD enemies
                    Enemy NewEnemy = new Enemy(this.GameSectionMap[this.CurrentSection].Type, this.GameSectionMap[this.CurrentSection].EnemyDifficulty);
                    NewEnemy.Position = 6 - CurrentEnemies.Count;
                }

                //render everything
                Render.RenderScreen("all");

            }
            else
            {
                //game ended??
                System.Diagnostics.Debug.WriteLine($"at end {CurrentSection < this.GameSectionMap.Count - 1}|| player positon not at enterance {MainClass.Player_1.Position == 6 }|| enemies remaining {this.CurrentEnemies.Count}");
            }
        }
        public void PrevScreen()
        {
            //CHANGE ? can back out even if enemies not dead?
            if (this.CurrentSection > 0 && MainClass.Player_1.Position == 1 && this.CurrentEnemies.Count == 0)
            {

                this.CurrentSection--;
                Render.ChangeBackground(this);
                //System.Diagnostics.Debug.WriteLine($"{this.CurrentSection}: {this.GameSectionMap[this.CurrentSection].SectionName}");
                Globals.Terrain = this.GameSectionMap[this.CurrentSection].Type;
                Render.ChangeScreen(0, 0, Art.Background($"{this.GameSectionMap[this.CurrentSection].SectionName}"));
                Render.RenderScreen("all");
            }
            else
            {
                //game ended??
                System.Diagnostics.Debug.WriteLine($"@Beginning {this.CurrentSection} {this.CurrentSection > 0 }|| @enterance? {MainClass.Player_1.Position == 1 } {MainClass.Player_1.Position}|| enemies {this.CurrentEnemies.Count} {this.CurrentEnemies.Count == 0}");
            }
            
            //initalize the new enemies
        }
        public void CreateGameMap(int difficulty, int SectionPerStage)
        {
            this.GameSectionMap = new List<Section>() { };
            //basic hard coded layout home -> Mountains -> Cave -> Forest -> Village -> Castle -> throneRoom
            //home
            //add tutorial to home??
            Section home = new Section();
                home.Enemies = 0;
                home.EnemyDifficulty = 0;
                home.Type = "home";
                home.SectionName = "Home";
                this.GameSectionMap.Add(home);
            //Mountains 
            for (var MountainRange = 0 ; MountainRange <= SectionPerStage; MountainRange++) {
                Section Mount = new Section();
                Mount.Enemies = (new Random()).Next(1,1);
                Mount.EnemyDifficulty = difficulty/2 + (MountainRange / 20);
                Mount.Type = "Mountain";
                if (MountainRange == 0){Mount.SectionName = "MountainEntrance";}
                else if (MountainRange == SectionPerStage){Mount.SectionName = "MountainExit";}
                else{Mount.SectionName = "Mountain" + MountainRange;}
                this.GameSectionMap.Add(Mount);
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
                this.GameSectionMap.Add(Caven);
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
                this.GameSectionMap.Add(Forst);
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
                this.GameSectionMap.Add(Vill);
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
                this.GameSectionMap.Add(Castle);
            }
            //ThroneRoom
            Section ThroneRoom = new Section();
            ThroneRoom.Enemies = 1;
            ThroneRoom.EnemyDifficulty = difficulty/2;
            ThroneRoom.Type = "ThroneRoom";
            ThroneRoom.SectionName = "Throne";
            this.GameSectionMap.Add(ThroneRoom);

        }
        
    }
}
