using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class Player : Entity
    {
        //money stores how much money player has ranges normaly 0-100s
        public int Money { get; set; }
        //sets the name of this instant of the player
        public String UserName { get; set; }
        //The inventory will contain the Item Name so you can ref it and amount of that item *unimplimented
        public Dictionary<String, int> Inventory { get; set; }
        public Player(String UN)
        {
            Map.EnemyDied.EnemyDied += DefeatedEnemy;
            MainClass.PlayerEventSystem.Deaded += PlayerEventSystem_Deaded;
            this.Name = "Player";
            this.UserName = UN;
            this.Money = 0;
            this.Inventory = new Dictionary<String, int>() { };
            this.AtkCharged = false;
            this.Moving = true;
            this.Strength = 1;
            this.Defence = 1;
            this.Range = 1;
            this.CritChance = 0.2;
            this.Health = 100;
            this.BaseDamage = 40;
            //game dev hack
            if (this.UserName.ToLower() == "bonkknight"||this.UserName.ToLower() == "nolan")
            {
                this.BaseDamage = 1000;
                this.Health = 500;
            }
            this.MaxHealth = this.Health;
        }
        private void PlayerEventSystem_Deaded(object sender, PlayerStats e)
        {
            this.living = false;
            PlayerDied();
        }
        public void MoveR()
        {
            this.Moving = true;
            //checks if at edge of screen
            if (this.Position < 6)
            {
                bool EnemyInfront = false;
                foreach (var ens in MainClass.GameMap.CurrentEnemies)
                {
                    //checks if enemy is infront of player
                    if (ens.Position == this.Position + 1)
                    {
                        EnemyInfront = true;
                        Log.UpdateLog("can't move into Enemy");
                    }
                }
                if (!EnemyInfront)
                {
                    if (this.AtkCharged == false)
                    {
                        Animate.ControlableEntityAni(this.Position,this.Position + 1, Animations.PlayerAni("WalkRight"),80);
                    }
                    else
                    {
                        Animate.ControlableEntityAni(this.Position, this.Position + 1, Animations.PlayerAni("WalkRightHammerUp"), 80);
                    }
                    this.Position++;
                    MainClass.PlayerEventSystem.MadeMove("right");
                }
            }
            else
            {
                //loads the next screen if conditions met - enemies = 0, is at edge of screen, not at end of game
                MainClass.GameMap.NextScreen();
            }
        }
        public void MoveL()
        {
            this.Moving = true;
            //checks if at edge of screen
            if (this.Position > 1)
            {
                //don't need to check if enemy behind
                if (this.AtkCharged == false) {
                    //as animation has position of square it goes to
                    Animate.ControlableEntityAni(this.Position - 1, this.Position - 1, Animations.PlayerAni("WalkLeft"), 80);
                }
                else
                {
                    Animate.ControlableEntityAni(this.Position - 1, this.Position - 1, Animations.PlayerAni("WalkLeftHammerUp"), 80);
                }
                this.Position--;
                MainClass.PlayerEventSystem.MadeMove("left");
            }
            else
            {
                //loads the prev screen if conditions met - enemies = 0, is at edge of screen, not at start of game
                MainClass.GameMap.PrevScreen();
            }
        }
        public void Attack()
        {
            this.Moving = false;
            //note it is a charge attack
            if (this.AtkCharged == false)
            {
                //lift hammer up
                this.AtkCharged = true;
                Animate.ControlableEntityAni(this.Position,this.Position, Animations.PlayerAni("LiftHammer"));
            }
            else
            {
                //swing hammer
                this.AtkCharged = false;
                Animate.ControlableEntityAni(this.Position,this.Position, Animations.PlayerAni("Bonk"),80);

                //as can't change list while in foreach loop create new list
                List<Enemy> EtoCheck = new List<Enemy>() { };
                foreach (Enemy ETA in MainClass.GameMap.CurrentEnemies)
                {
                    EtoCheck.Add(ETA);
                }
                foreach (Enemy EnemyToAttack in EtoCheck)
                {
                    if (this.Position == EnemyToAttack.Position - 1)
                    {
                        if (EnemyToAttack.PlanedMove == "dodge")
                        {
                            EnemyToAttack.MakeMove();
                            EnemyToAttack.TakeDamage(this.Strength, this.BaseDamage);
                        }
                        else
                        {
                            EnemyToAttack.TakeDamage(this.Strength, this.BaseDamage);
                        }
                    }
                }
            }
            this.Moving = true;
            MainClass.PlayerEventSystem.MadeMove("attack");
        }
        public void Dodge()
        {
            //add in code here 
            this.Dodging = true;
            MainClass.PlayerEventSystem.MadeMove("dodge");
        }
        public void PlayerDied()
        {
            //LOG player died and lost money
            this.Health = this.MaxHealth;
            var moneyDropped = (new Random()).Next(0,21);
            if ((this.Money - moneyDropped) >0) 
            {

                this.Money -= moneyDropped;
            }
            else
            {
                this.Money = 0;
            }

            Log.ClearLog($"Player respawned lost ₿{moneyDropped}");


            //Code discontinued as player doesn't actualy die just respawns
            //if (this.living == false) 
            //{
            //    Map.EnemyDied.EnemyDied -= DefeatedEnemy;
            //    MainClass.PlayerEventSystem.Deaded -= PlayerEventSystem_Deaded;
            //}
        }
        private void DefeatedEnemy(object sender, string e)
        {
            //loot based on terain
            String enemyType = MainClass.GameMap.GameSectionMap[MainClass.GameMap.CurrentSection].Type;
            int extraMoney = 0;
            switch (enemyType)
            {
                case "Mountain":
                    break;
                case "Cave":
                    extraMoney = 5;
                    break;
                case "Forest":
                    extraMoney = 15;
                    break;
                case "Village":
                    extraMoney = 30;
                    break;
                case "Kingdom":
                    extraMoney = 50;
                    break;
                case "ThroneRoom":
                    extraMoney = 1000;
                    break;
            }

            //loot based on enemy
            var ItemToAdd = "none";
            switch (e.ToLower())
            { 
            case "Pitchfork":
                    ItemToAdd = "wheat";
                    break;
            case "WoodCutter":
                    ItemToAdd = "wood";
                    break;
            case "Tiller":
                    ItemToAdd = "wheat";
                    break;
            case "croc":
                    ItemToAdd = "scale";
                    break;
            case "slime":
                    ItemToAdd = "slime";
                    break;
            case "crab":
                    ItemToAdd = "scale";
                    break;
            case "bat":
                    ItemToAdd = "fang";
                    break;
            case "Knight":
                    ItemToAdd = "iron";
                    break;
            case "Archer":
                    ItemToAdd = "arrow";
                    break;
            case "King":
                break;
            }
            if (ItemToAdd != "none") {
                if (this.Inventory.ContainsKey(ItemToAdd))
                {
                    this.Inventory[ItemToAdd] += (new Random()).Next(1, 3);
                }
                else
                {
                    Log.UpdateLog($"{e} dropped {ItemToAdd}");
                    this.Inventory.Add(ItemToAdd, 1);
                }
            }

            //money
            double enemyDiff = MainClass.GameMap.GameSectionMap[MainClass.GameMap.CurrentSection].EnemyDifficulty;
            int moneyLoot = Convert.ToInt32((extraMoney + (new Random()).Next(1, 31) * enemyDiff)*Globals.MoneyMultiplier);
            this.Money += moneyLoot;
            Log.UpdateLog($"Looted ₿{moneyLoot} purse ₿{this.Money}");
        }
    }
    public class Item
    {
        public String Name { get; set; }
        public int SellPrice { get; set; }
        public int BuyPrice { get; set; }
        public int Rarity { get; set; }
    }
    public class Gear
    {

        public bool CanCraftGear(String GearTryCraft, int amount)
        {
            //need more materials 
            return false;
        }
        public bool CraftGear(String GearCrafting, int amount)
        {
            //CHANGE return bool????? 

            if (CanCraftGear(GearCrafting,1))
            {
                //need more materials 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
