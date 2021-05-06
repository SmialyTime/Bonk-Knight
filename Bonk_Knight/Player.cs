using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class Player : Entity
    {
        public int Money { get; set; }
        public List<String> Inventory { get; set; }
        public Player()
        {
            Map.EnemyDied.EnemyDied += EnemyDied_EnemyDied;
            this.Name = "Player";
        }

        private void EnemyDied_EnemyDied(object sender, string e)
        {
            //loot system??
            String enemyType = MainClass.GameMap.GameSectionMap[MainClass.GameMap.CurrentSection].Type;
            //money

            double enemyDiff = MainClass.GameMap.GameSectionMap[MainClass.GameMap.CurrentSection].EnemyDifficulty;


            this.Money += Convert.ToInt32((new Random()).Next(0,10)*enemyDiff);
        }
    }
}
