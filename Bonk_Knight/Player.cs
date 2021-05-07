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
        //The inventory will contain the Item Name so you can ref it and amount of that item
        public Dictionary<String, int> Inventory { get; set; }
        private bool HammerUp { get; set; }
        public Player(String UN)
        {
            Map.EnemyDied.EnemyDied += DefeatedEnemy;
            this.Name = "Player";
            this.UserName = UN;
            this.Money = 0;
            this.Inventory = new Dictionary<String, int>() { };
            this.HammerUp = false;
        }
        public void MoveR()
        {
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
                        System.Diagnostics.Debug.WriteLine("EnemyInfront");
                    }
                }
                if (!EnemyInfront)
                {
                    this.Position++;
                    System.Diagnostics.Debug.WriteLine("moved to - " + this.Position);
                    Animations.PlayerAni("WalkRight");
                }
                
            }
            else
            {
                //loads the next screen
                System.Diagnostics.Debug.WriteLine("Warping to next area");
                MainClass.GameMap.NextScreen();
                this.Position = 1;
            }
        }
        public void Attack()
        {
            //note it is a charge attack
            if (this.HammerUp == false)
            {
                //lift hammer up
                Animate.ControlableEntityAni(this.Position, Animations.PlayerAni("LiftHammer"), 240);
                this.HammerUp = true;
            }
            else
            {
                //swing hammer
            }
        }
        private void DefeatedEnemy(object sender, string e)
        {
            //loot system??
            String enemyType = MainClass.GameMap.GameSectionMap[MainClass.GameMap.CurrentSection].Type;
            //money

            double enemyDiff = MainClass.GameMap.GameSectionMap[MainClass.GameMap.CurrentSection].EnemyDifficulty;


            this.Money += Convert.ToInt32((new Random()).Next(0, 10) * enemyDiff);
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
