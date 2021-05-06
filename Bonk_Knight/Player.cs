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
        //The inventory will contain the Item Name so you can ref it and amount of that item
        public Dictionary<String, int> Inventory { get; set; }
        private bool HammerUp { get; set; }
        public Player()
        {
            Map.EnemyDied.EnemyDied += DefeatedEnemy;
            this.Name = "Player";
            this.Money = 0;
            this.Inventory = new Dictionary<String, int>() { };
            this.HammerUp = false;
        }
        public void Attack()
        {
            //it is a charge attack
            if (HammerUp == false)
            {
                //lift hammer up
                Animate.ControlableEntityAni(this.Position, Animations.PlayerAni("LiftHammer"));
            }
            else
            {

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
