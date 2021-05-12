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
            MainClass.PlayerEventSystem.Deaded += PlayerEventSystem_Deaded;
            var dif = 2;// 1  = easy , 2 = medium, 3 = hard
            switch (Difficulty)
            {
                case "easy":
                case "1":
                    dif = 1;
                    Globals.MoneyMultiplier = 2;
                    break;
                case "medium":
                case "2":
                    dif = 2;
                    Globals.MoneyMultiplier = 1;
                    break;
                case "hard":
                case "3":
                    dif = 3;
                    Globals.MoneyMultiplier = 0.5;
                    break;
            }
            CreateGameMap(dif, 4);
            Map.EnemyDied.EnemyDied += RemoveDeadEnemies;
        }
        private void PlayerEventSystem_Deaded(object sender, PlayerStats e)
        {
            this.GameSectionMap[this.CurrentSection].Enemies = 0;
            this.CurrentEnemies = new List<Enemy>() { };
            //resets to previous area and re-adds in the enemies
            var SectionToRespawnAt = 0;
            while(this.GameSectionMap[this.CurrentSection].Type != this.GameSectionMap[SectionToRespawnAt].Type)
            {
                SectionToRespawnAt++;
            }
            //re-adds in enemies defeated
            for (var i = SectionToRespawnAt; i <= this.CurrentSection; i++)
            {
                if (this.GameSectionMap[i].Enemies == 0)
                {
                    this.GameSectionMap[i].Enemies = (new Random()).Next(1, 3);
                }
                if (this.GameSectionMap[i].Type == "ThroneRoom")
                {
                    //only 1 king
                    this.GameSectionMap[i].Enemies = 1;
                }
            }
            //loads new screen
            if (this.GameSectionMap[SectionToRespawnAt].Type != "ThroneRoom" && this.GameSectionMap[SectionToRespawnAt].Type != "Home")
            {
                this.CurrentSection = SectionToRespawnAt - 1;
                MainClass.Player_1.Position = 6;
                LoadCurrentScreen();
                NextScreen();
            }
            else if (this.GameSectionMap[SectionToRespawnAt].Type == "ThroneRoom")
            {
                this.CurrentSection = SectionToRespawnAt - 2;
                MainClass.Player_1.Position = 6;
                LoadCurrentScreen();
                NextScreen();
            }
            else
            {
                Functions.CursorBellowScreen();
                Console.WriteLine("How did you die with no Enemies");
            }
        }
        private void RemoveDeadEnemies(object sender, string e)
        {
            List<Enemy> ToRem = new List<Enemy>() { };
            foreach (Enemy EDeadCheck in this.CurrentEnemies)
            {
                if (EDeadCheck.Health <= 0)
                {
                    ToRem.Add(EDeadCheck);
                }
            }
            foreach (Enemy Cull in ToRem)
            {
                //LOG
                System.Diagnostics.Debug.WriteLine($"{Cull.Name} was defeated");
                Cull.dead();
                this.CurrentEnemies.Remove(Cull);
                this.GameSectionMap[this.CurrentSection].Enemies--;
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
                    Enemy NewEnemy = new Enemy(this.GameSectionMap[this.CurrentSection].Enemies, this.GameSectionMap[this.CurrentSection].Type, this.GameSectionMap[this.CurrentSection].EnemyDifficulty);
                    //randomised enemy spawn if only 1
                    if (this.GameSectionMap[this.CurrentSection].Enemies == 1) { NewEnemy.Position = 6 - (new Random()).Next(1,3); }
                    else
                    {
                        if (this.CurrentEnemies.Count >= 1) {
                            NewEnemy.Position = 5 - this.CurrentEnemies.Count;
                        }
                        else
                        {
                            NewEnemy.Position = 6 - (new Random()).Next(0,2);
                        }
                    }
                    this.CurrentEnemies.Add(NewEnemy);
                    //make it so they appear on screen
                    this.CurrentEnemies[i].RenderEntity();
                }

                //render everything
                MainClass.Player_1.Position = 1;
                MainClass.Player_1.RenderEntity();
                Render.RenderScreen("all");
            }
            else
            {
                //LOG can't exit ENDING 
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

                //renders the past sceen
                //IMPROVE make the player walk on from off screen
                MainClass.Player_1.Position = 6;
                MainClass.Player_1.RenderEntity();
                Render.RenderScreen("all");
            }
            else
            {
                //LOG?
                System.Diagnostics.Debug.WriteLine($"@Beginning {this.CurrentSection} {this.CurrentSection > 0 }|| @enterance? {MainClass.Player_1.Position == 1 } {MainClass.Player_1.Position}|| enemies {this.CurrentEnemies.Count} {this.CurrentEnemies.Count == 0}");
            }
        }
        public void Completed()
        {

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
                home.Type = "Home";
                home.SectionName = "Home";
                this.GameSectionMap.Add(home);
            //only 1 mountain
            Section Mount = new Section();
            Mount.Enemies = 1;
            Mount.EnemyDifficulty = difficulty / 2;
            Mount.Type = "Mountain";
            Mount.SectionName = "Mountain";
            this.GameSectionMap.Add(Mount);

            //older code
            //Mountain,Cave,Forest,Village,Kingdom,ThroneRoom
            //List<String> typetst = new List<string>() { "Mountain", "Cave", "Forest", "Village", "Kingdom", "ThroneRoom" };
            //Section Tester = new Section();
            //Tester.Enemies = (new Random()).Next(1, 3);
            //Tester.EnemyDifficulty = 1;
            //Tester.Type = typetst[(new Random()).Next(0,6)];
            //Tester.SectionName = "Test";
            //this.GameSectionMap.Add(Tester);
            //Mountains 
            //or (var MountainRange = 0 ; MountainRange <= SectionPerStage; MountainRange++) {
            //   Section Mount = new Section();
            //   Mount.Enemies = (new Random()).Next(1,1);
            //   Mount.EnemyDifficulty = difficulty/2 + (MountainRange / 20);
            //   Mount.Type = "Mountain";
            //   if (MountainRange == 0){Mount.SectionName = "MountainEntrance";}
            //   else if (MountainRange == SectionPerStage){Mount.SectionName = "MountainExit";}
            //   else{Mount.SectionName = "Mountain" + MountainRange;}
            //   this.GameSectionMap.Add(Mount);
            //
            //Cave
            for (var CaveVein = 0 ; CaveVein <= SectionPerStage; CaveVein++) {
                Section Caven = new Section();
                Caven.Enemies = (new Random()).Next(1,3);
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
                Forst.Enemies = (new Random()).Next(1,3);
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
                Vill.Enemies = (new Random()).Next(1,3);
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
                Castle.Enemies = (new Random()).Next(1,3);
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
