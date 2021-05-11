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
        public int MaxHealth { get; set; }
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
        //charged attacks
        public bool AtkCharged { get; set; }
        //makes the player/enemy do nothing
        public bool debuff { get; set; }
        //living
        public bool living { get; set; }

        public Entity()
        {
            this.Strength = 1;
            this.living = true;
            this.debuff = false;
            this.Name = "Blank";
            this.Health = 100;
            this.MaxHealth = this.Health;
            this.Defence = 1;
            this.CritChance = 0.1;
            this.Range = 1;
            this.Position = 1;
            //CHANGE
            this.BaseDamage = 100;
            MainClass.PlayerEventSystem.MadeCombatMove += PlayerEventSystem_MadeCombatMove;
        }

        private void PlayerEventSystem_MadeCombatMove(object sender, string e)
        {
            //reset dogeing
            this.Dodging = false;
        }

        public void TakeDamage(double AtkStrength, double AtkDmg)
        {
            //ADD differnt attack types - heavy,normal,projectile
            //IMPROVE
            //LOG crit hit
            double dmgMultiplier = AtkStrength / this.Defence;
            dmgMultiplier *= Crit()? 2 : 1;
            dmgMultiplier *= RandomMultiplier();
            //EVENT dodge or item activated??
            if (this.Dodging == true)
            {
                //LOG the dodge
                System.Diagnostics.Debug.WriteLine($"{this.Name} Dodged");
                //loads the enemy again
                Animate.ControlableEntityAni(this.Position, this.Position, new List<string>() { Art.Enemy(this.Name) });
                this.Dodging = false;
                dmgMultiplier *= 0;
            }
            else
            {
                //IMPROVE ADD FIX make a take damage flash? function
                Animate.ControlableEntityAni(this.Position, this.Position, new List<string>() { Art.Enemy(this.Name) });
                dmgMultiplier *= 1;
            }
            this.Health -= Convert.ToInt32(AtkDmg * dmgMultiplier);
            System.Diagnostics.Debug.WriteLine($"Enemy {this.Name} took {AtkDmg * dmgMultiplier} and now is at {this.Health}/{this.MaxHealth}");
            CheckLiving();
        }
        public void RenderEntity(int PlusPos = 0)
        {
            var StanceName = this.Name;
            //make it 1 down?
            if (this.Name == "Player") {
                if (Moving == true) {StanceName += "Moving";}
                if (this.AtkCharged == true) {StanceName += "HammerUp";}
            }
            Animate.ControlableEntityPlace(this.Position + PlusPos, Art.Enemy(StanceName));
        }
        public void CheckLiving()
        {
            if (this.Health <=0)
            {
                this.living = false;
                //EVENT dead 
                //will remove the enemy if dead
                if (this.Name != "Player") {
                    Map.EnemyDied.Enemyded(this.Name);
                    MainClass.PlayerEventSystem.MadeCombatMove -= PlayerEventSystem_MadeCombatMove;
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
        private double RandomMultiplier()
        {
            double Rmulti = 1;
            //gives a multiplier of 1-1.2
            Rmulti += Convert.ToDouble((new Random()).Next(0,21))/100;
            System.Diagnostics.Debug.WriteLine("rando - " + Rmulti + " "+(Convert.ToDouble((new Random()).Next(0, 21)) / 100));
            return Rmulti;
        }
    }
}
