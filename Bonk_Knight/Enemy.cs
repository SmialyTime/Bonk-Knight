using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    public partial class Enemy : Entity
    {

        public Enemy(String Biome, double DifficultyLevel)
        {
            //initialise enemy stats + random stuff
            this.Strength = 1;
            this.Name = "Slime";
            this.Health = 100;
            this.Defence = 1;
            this.CritChance = 0.1;
            this.Range = 1;

            switch (Biome) 
            {
                //sets  the type of enemy based on random chance it appears in biome
            }
            switch (this.Name) 
            {
                //sets special stats such as extra range, defence , stregth
            }
            this.Strength = this.Strength*DifficultyLevel;
            this.Defence = this.Strength*DifficultyLevel;



            void MakeMove()
            {
                //if
            }
        }
    }
}
