using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    public partial class Entity : Animate
    {
        //the name of the entity so it can be referenced
        public String Name { get; set; }
        //the total health you have before the entity dies  (h=0)
        public int Health { get; set; }
        //the amount the attack is multiplied by (extra dmg)
        public double Strength { get; set; }
        //the amount the incoming attack is reduced by
        public double Defence { get; set; }
        //the chance for it to do double damage
        public double CritChance { get; set; }
        //the amount of tiles attack reaches
        public int Range { get; set; }
        //not 0 indexed norm 1-6 tiles on the screen width 5char
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
        public void TakeDamage(float AtkStrength, String atkType)
        {
            //ADD differnt attack types - heavy,normal,projectile
            //IMPROVE
            //LOG crit hit
            int dmg = Crit() ? Convert.ToInt32(AtkStrength / this.Defence) : Convert.ToInt32(AtkStrength * 2 / this.Defence);
            //EVENT dodge or item activated??
            this.Health -= dmg;
            CheckLiving();
        }
        public void RenderEntity()
        {
            //make it 1 down?
            Animate.ControlableEntityPlace(this.Position,Art.Enemy(this.Name));
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
