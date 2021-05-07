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
        //the amount the attack at least does
        public double BaseDamage { get; set; }
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
        //shows if this thing is dodging
        public bool Dodging { get; set; }
        //decides what animation plays - Fight vs move mode
        public bool Moving { get; set; }

        public Entity()
        {
            this.Strength = 1;
            this.Name = "Blank";
            this.Health = 100;
            this.Defence = 1;
            this.CritChance = 0.1;
            this.Range = 1;
            this.Position = 1;
            //CHANGE
            this.BaseDamage = 100;
        }
        public void TakeDamage(double AtkStrength, String atkType)
        {
            //ADD differnt attack types - heavy,normal,projectile
            //IMPROVE
            //LOG crit hit
            double dmgMultiplier = AtkStrength / this.Defence;
            dmgMultiplier *= Crit()? 2 : 1;
            dmgMultiplier *= Dodge()? 0 : 1;
            dmgMultiplier *= RandomMultiplier();
            //EVENT dodge or item activated??
            this.Health -= Convert.ToInt32(this.BaseDamage*dmgMultiplier);
            System.Diagnostics.Debug.WriteLine($"Enemy {this.Name} took {this.BaseDamage * dmgMultiplier} and now is at {this.Health}/100");
            CheckLiving();
        }
        public void RenderEntity(int PlusPos = 0)
        {
            //make it 1 down?
            if (this.Name == "Player") {
                if (Moving == false) {
                    Animate.ControlableEntityPlace(this.Position + PlusPos, Art.Enemy(this.Name));
                }
                else
                {
                    Animate.ControlableEntityPlace(this.Position + PlusPos, Art.Enemy(this.Name + "Moving"));
                }
            }
            else
            {
                Animate.ControlableEntityPlace(this.Position + PlusPos, Art.Enemy(this.Name));
            }
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
        private bool Crit()
        {
            if ((new Random()).NextDouble() <= this.CritChance)
            {
                System.Diagnostics.Debug.WriteLine("CRIT");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Dodge()
        {
            if (this.Dodging == true)
            {
                System.Diagnostics.Debug.WriteLine($"{this.Name} Dodged");
                this.Dodging = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        private double RandomMultiplier()
        {
            double Rmulti = 1;
            //gives a multiplier of 1-1.2
            Rmulti += Convert.ToDouble((new Random()).Next(0,20))/100;
            System.Diagnostics.Debug.WriteLine("rando - " + Rmulti + " "+(Convert.ToDouble((new Random()).Next(0, 20)) / 100));
            return Rmulti;
        }
    }
}
