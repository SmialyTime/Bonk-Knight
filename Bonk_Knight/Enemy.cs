using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    public partial class Enemy : Entity
    {
        public Enemy(int otherEns,String Biome, double DifficultyLevel)
        {
            this.Name = "null";
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
                    if (RandomRandUntilNewRand(0,10) <= 8) { this.Name = "crab"; }
                    else { this.Name = "slime"; }
                    break;
                case "Cave":
                    //60% bat + 20% crab + 20% slime
                    if (RandomRandUntilNewRand(0,10) <= 6) { this.Name = "bat"; }
                    else if (RandomRandUntilNewRand(0,10) <= 4) { this.Name = "slime"; }
                    else { this.Name = "crab"; }
                    break;                                                                       
                case "Forest":
                    //70% croc + 30% WoodCutter (croc and Axe don't mix with multiple enemies)
                    if (MainClass.GameMap.CurrentEnemies.Count == 0)
                    {
                        if (RandomRandUntilNewRand(0,10) <= 7){this.Name = "croc";}
                        else{this.Name = "WoodCutter";}
                    }
                    else
                    {
                        if (MainClass.GameMap.CurrentEnemies[MainClass.GameMap.CurrentEnemies.Count - 1].Name == "WoodCutter") { this.Name = "WoodCutter"; }
                        else
                        {
                            if (RandomRandUntilNewRand(0,10) >= 3) { this.Name = "crab"; }
                            else { this.Name = "croc"; }
                        }
                    }
                    break;
                case "Village":
                    // 50% Tiller 50% Pitchfork 
                    if (RandomRandUntilNewRand(0,10) <= 5) { this.Name = "Tiller"; }
                    else { this.Name = "Pitchfork"; }
                    break;
                case "Kingdom":
                    //1st enemy 40% Knight 60% Archer
                    if (MainClass.GameMap.CurrentEnemies.Count == 0)
                    {
                        if (RandomRandUntilNewRand(0,10) <= 6) { this.Name = "Archer"; }
                        else { this.Name = "Knight"; }
                    }
                    else { this.Name = "Knight"; }
                    break;
                case "ThroneRoom":
                    //100% king
                    this.Name = "King";
                    break;
            }
            //make bigger thing if only 1 enemy
            if (otherEns - 1  == 0)
            {
                if (Globals.canBeBigEnemies.Contains(this.Name)) {
                    this.Name = this.Name.ToUpper();
                }
            }

            //stats 
            //set standard stats
            this.Strength = 1;
            this.BaseDamage = 20;
            this.Defence = 1;
            this.Range = 1;
            this.CritChance = 0.1;
            this.Health = 40;
            this.MaxHealth = this.Health;
            switch (this.Name) 
            {
                /*sets special stats for special enemies
                Animals: slime-weak, crab-standard, bat-def, croc-hard,
                People:  WoodCutter-atk, Tiller-standard, Pitchfork-atk,
                Guards:  Knight-def, Archer-range, King -special stats CHANGE IMPROVE ADD new special class?
                */
                case "slime"://weak
                    //initialise enemy stats + random stuff
                    this.Strength = 0.5;
                    this.Health = 20;
                    this.BaseDamage = 10;
                    this.Defence = 0.5;
                    break;
                case "crab":
                case "CRAB":
                    //standard
                    break;
                case "bat":
                case "BAT"://def
                    this.Strength = 1;
                    this.Defence = 1.4;
                    this.Health = 50;
                    break;
                case "croc"://hard
                    this.Strength = 1.4;
                    this.Defence = 1.4;
                    this.Health = 80;
                    break;
                case "WoodCutter"://WoodCutter-atk
                    this.Strength = 2;
                    this.Defence = 0.7;
                    this.Health = 100;
                    break;
                case "Tiller"://Tiller-standard
                    this.Strength = 1.6;
                    this.Defence = 1.6;
                    this.Health = 100;
                    break;
                case "Pitchfork"://Pitchfork-atk
                    this.Strength = 2.5;
                    this.Defence = 1;
                    this.Health = 100;
                    break;
                case "Knight"://Knight-def
                    this.Strength = 2;
                    this.Defence = 3;
                    this.Health = 150;
                    break;
                case "Archer"://Archer-range
                    this.Strength = 2;
                    this.Range = 2;
                    this.Defence = 0.8;
                    this.Health = 100;
                    break;
                case "King"://King -special
                    this.Strength = 2;
                    this.Range = 2;
                    this.Defence = 2;
                    this.Health = 200;
                    break;
            }
            this.Strength = this.Strength*DifficultyLevel;
            this.Defence = this.Strength*DifficultyLevel;
            this.MaxHealth = this.Health;

            this.RenderEntity();
        }

        public void MakeMove()
        {
            //if
        }
    }
}
