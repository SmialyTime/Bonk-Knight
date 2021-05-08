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
            //Mountain,Cave,Forest,Village,Kingdom,ThroneRoom
            Random rand = new Random();
            switch (Biome)
            {
                //sets  the type of enemy based on random chance it appears in biome
                case "Home":
                    //none
                    this.Health = 0;
                    break;
                case "Mountain":
                    //80% crab + 20% slime
                    if (rand.NextDouble() <= 0.8) { this.Name = "crab"; }
                    else { this.Name = "slime"; }
                    break;
                case "Cave":
                    //60% bat + 20% crab + 20% slime
                    if (rand.NextDouble() <= 0.6) { this.Name = "bat"; }
                    else if (rand.NextDouble() >= 0.8) { this.Name = "slime"; }
                    else { this.Name = "crab"; }
                    break;                                                                       
                case "Forest":
                    //70% croc + 30% WoodCutter (croc and Axe don't mix with multiple enemies)
                    if (MainClass.GameMap.CurrentEnemies.Count == 0)
                    {
                        if (rand.NextDouble() <= 0.7){this.Name = "croc";}
                        else{this.Name = "WoodCutter";}
                    }
                    else
                    {
                        if (MainClass.GameMap.CurrentEnemies[MainClass.GameMap.CurrentEnemies.Count].Name == "WoodCutter") { this.Name = "WoodCutter"; }
                        else
                        {
                            if (rand.NextDouble() <= 0.7) { this.Name = "crab"; }
                            else { this.Name = "croc"; }
                        }
                    }
                    break;
                case "Village":
                    // 50% Tiller 50% Pitchfork 
                    if (rand.NextDouble() <= 0.5) { this.Name = "Tiller"; }
                    else { this.Name = "Pitchfork"; }
                    break;
                case "Kingdom":
                    //1st enemy 40% Knight 60% Archer
                    if (MainClass.GameMap.CurrentEnemies.Count == 0)
                    {
                        if (rand.NextDouble() <= 0.6) { this.Name = "Archer"; }
                        else { this.Name = "Knight"; }
                    }
                    else { this.Name = "Knight"; }
                    break;
                case "ThroneRoom":
                    //100% king
                    this.Name = "King";
                    break;
            }
            switch (this.Name) 
            {
                //sets special stats such as extra range, defence , streagth
                //slime,crab,bat,croc,WoodCutter,Tiller,Pitchfork,Knight,Archer,King
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
