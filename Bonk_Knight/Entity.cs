using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    public partial class Entity : Animate
    {
        public double Strength { get; set; }
        public String Name { get; set; }
        public int Health { get; set; }
        public double Defence { get; set; }
        public double CritChance { get; set; }
        public int Range { get; set; }
        public int Position { get; set; }

        public Entity()
        {
            this.Strength = 1;
            this.Name = "Blank";
            this.Health = 100;
            this.Defence = 1;
            this.CritChance = 0.1;
            this.Range = 1;
            this.Position = 1;
        }
        public void TakeDamage(float AtkStrength)
        {
            //IMPROVE
            //LOG crit hit
            int dmg = Crit() ? Convert.ToInt32(AtkStrength / this.Defence) : Convert.ToInt32(AtkStrength * 2 / this.Defence);
            //EVENT dodge or item activated??
            this.Health -= dmg;
            CheckLiving();
        }
        public void CheckLiving()
        {
            if (this.Health <=0)
            {
                //EVENT dead 
                //will remove the enemy if dead
                if (this.Name != "Player") {
                    Map.EnemyDied.Enemyded(this.Name);
                }
                else
                {
                    MainClass.PlayerEventSystem.PlayerDied();
                }
            }
        }
        public bool Crit()
        {
            if ((new Random()).NextDouble() < this.CritChance)
            {
                return false;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("CRIT");
                return true;
            }
        }

    }
    

}
