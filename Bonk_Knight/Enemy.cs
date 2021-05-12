using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    public partial class Enemy : Entity
    {
        //classes of enemies
        public static List<String> standard = new List<string>() { "slime", "crab", "croc", "tiller" };
        public static List<String> defensive = new List<string>() { "bat", "knight" };
        public static List<String> agressive = new List<string>() { "woodCutter", "pitchfork" };
        public static List<String> ranged = new List<string>() { "archer" };
        public static List<String> special = new List<string>() { "king" };
        //position one above enemy
        public int OneLineAboveEnemy { get; set; }
        //enemy Width
        public int enemyWidth { get; set; }
        //the centre of the top of the enemy
        public int CentredAboveEnemy { get; set; }
        //the text that displays what the enemy will do
        public String PlanedMoveChar = "??";
        //the enemies next move
        public String PlanedMove { get; set; }


        //initalizes enemy
        public Enemy(int otherEns,String Biome, double DifficultyLevel)
        {
            //recives the player events
            MainClass.PlayerEventSystem.MadeCombatMove += PlayerEventSystem_MadeCombatMove;
            MainClass.PlayerEventSystem.Deaded += PlayerEventSystem_Deaded;

            this.PlanedMove = "debuff";
            this.PlanedMoveChar = "??";
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
                    this.Strength = 3;
                    this.Range = 1;
                    this.Defence = 3;
                    this.Health = 200;
                    break;
            }
            this.Strength = this.Strength*DifficultyLevel;
            this.Defence = this.Strength*DifficultyLevel;
            this.MaxHealth = this.Health;
            this.AtkCharged = false;


            this.RenderEntity();
        }
        private void PlayerEventSystem_Deaded(object sender, PlayerStats e)
        {
            //removes instance of Enemy
            this.living = false;
            dead();
        }
        public void dead()
        {
            if (this.living == false)
            {
                MainClass.PlayerEventSystem.MadeCombatMove -= PlayerEventSystem_MadeCombatMove;
            }
        }
        private void PlayerEventSystem_MadeCombatMove(object sender, string e)
        {
            //recives player input
            CheckLiving();
            if (this.living == false)
            {
                dead();
            }
            else
            {
                MakeMove();

            }
        }
        public void MakeMove()
        {
            //clears Planned move
            if (this.CentredAboveEnemy != 0 && this.OneLineAboveEnemy != 0) {
                Console.SetCursorPosition(this.CentredAboveEnemy, this.OneLineAboveEnemy);
                Console.WriteLine($"{new String(' ', this.PlanedMoveChar.Length)}");
            }
            else
            {
                //MakeErrorMessage("Enemy indicatior not right");
            }
            //remember player moves then enemy
            //ADD animations
            switch (this.PlanedMove.ToLower())
            {
                case "dodge":
                    this.Dodging = true;
                    break;
                case "debuff":
                    //do nothing
                    break;
                case "move":
                    //this.Position -= 1; not working
                    Animate.ControlableEntityPlace(this.Position,Art.Enemy("blank"));
                    bool spaceInfrontAvalible = true;
                    foreach (Enemy spaceInfrontAvalibleToCheck in MainClass.GameMap.CurrentEnemies)
                    {
                        if (spaceInfrontAvalibleToCheck.Position == this.Position - 1)
                        {
                            spaceInfrontAvalible = false;
                        }
                    }
                    if (MainClass.Player_1.Position != this.Position - 1 && spaceInfrontAvalible)
                    {
                        this.Position-=1;
                    }
                    //UNCOMMENT
                    else { System.Diagnostics.Debug.WriteLine("Can't move there player or enemy is there");}
                    this.RenderEntity();
                    break;
                case "increasedefence":
                    this.Defence += 0.1;
                    break;
                case "increaseattack":
                    this.Strength += 0.1;
                    break;
                case "chargeattack":
                    this.AtkCharged = true;
                    break;
                case "attack":
                    if (MainClass.Player_1.Position >= this.Position - this.Range)
                    {
                        MainClass.Player_1.TakeDamage(this.Strength,this.BaseDamage);
                    }
                    this.AtkCharged = false;
                    break;
                default:
                    MakeErrorMessage($"unregistered move {this.PlanedMove}");
                    break;
            }
            
            //plans the next move
            PlanMove();
        }
        public void PlanMove()
        {
            //checks if enemy is debuffed (can't move)
            if (this.debuff == true)
            {
                this.PlanedMove = "debuff";
            }
            else
            {
                //checks if player in range otherwise moves forward
                if (MainClass.Player_1.Position < this.Position - this.Range)
                {
                    this.PlanedMove = "move";
                }
                else
                {
                    //checks if attack needs to be charged
                    if (/*NOT*/!(this.AtkCharged == true || (agressive.Contains(this.Name))))
                    {
                        if (ranged.Contains(this.Name))
                        {
                            //ranged enemies take longer to "aim" attacks
                            this.PlanedMove = "chargeAttack";
                            this.debuff = true;
                        }
                        else
                        {
                            this.PlanedMove = "chargeAttack";
                        }
                    }
                    else
                    {
                        //attacks dodges or does a special move
                        switch (this.Name.ToLower())
                        {
                            //basic enemies
                            case "crab":
                            case "slime":
                            case "croc":
                            case "tiller":
                                //80% Attack + 15% dodge + 5% debuff
                                if (RandomRandUntilNewRand(0, 10) <= 8) { this.PlanedMove = "Attack"; }
                                else if (RandomRandUntilNewRand(0, 10) <= 7) { this.PlanedMove = "dodge"; }
                                else { this.PlanedMove = "debuff"; }

                                break;
                            //defensive enemies
                            case "bat":
                            case "knight":
                                //60% Attack + 40% increaseDefence 
                                if (RandomRandUntilNewRand(0, 10) <= 6) { this.PlanedMove = "Attack"; }
                                else { this.PlanedMove = "increaseDefence"; }
                                
                                break;
                            //agressive enemies (no charge but debuff after)
                            case "pitchfork":
                            case "woodcutter":
                                //60% Attack + 40% increaseAttack
                                if (RandomRandUntilNewRand(0, 10) <= 6) 
                                {
                                    this.PlanedMove = "Attack";
                                    this.debuff = true;
                                }
                                else { this.PlanedMove = "increaseAttack"; }
                                break;
                            //ranged enemies (high charge) 80% attack 20% dodge/debuf
                            case "archer":
                                if (RandomRandUntilNewRand(0, 10) <= 8) { this.PlanedMove = "Attack"; }
                                else { this.PlanedMove = "dodge"; }
                                break;
                            //special enemies 90% attack 10% dodge
                            case "king":
                                if (RandomRandUntilNewRand(0, 10) <= 9) { this.PlanedMove = "Attack"; }
                                else { this.PlanedMove = "dodge"; }
                                break;
                        }
                    }
                }
            }
            //Improve as may be inefficent to redeclare
            String EnemyArtLook = Art.Enemy(this.Name);
            this.OneLineAboveEnemy = Globals.GroundInGameY - EnemyArtLook.Count(f => f == '%');
            this.enemyWidth = (EnemyArtLook.Length - EnemyArtLook.Count(f => f == '%')) / EnemyArtLook.Count(f => f == '%');
            this.CentredAboveEnemy = ((this.Position - 1) * 5) + (this.enemyWidth / 2);

            Console.SetCursorPosition(this.CentredAboveEnemy,this.OneLineAboveEnemy);
            switch (this.PlanedMove.ToLower())
            {
                case "dodge":
                    Console.ForegroundColor = ConsoleColor.Green;
                    PlanedMoveChar = "d";
                    break;
                case "move":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    PlanedMoveChar = "←";
                    break;
                case "increasedefence":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    PlanedMoveChar = "↑D";
                    break;
                case "increaseattack":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    PlanedMoveChar = "↑A";
                    break;
                case "chargeattack":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    PlanedMoveChar = "ϟ";
                    break;
                case "attack":
                    Console.ForegroundColor = ConsoleColor.Red;
                    PlanedMoveChar = "A";
                    break;
                default:
                    //debuff
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    PlanedMoveChar = "??";
                    break;
            }

            
            Console.WriteLine($"{this.PlanedMoveChar}");
            Console.ForegroundColor = ConsoleColor.White;

            //testing dodging and attacking
            //System.Diagnostics.Debug.WriteLine($"            {this.Name} Plan  - {this.PlanedMove}");
            //if (RandomRandUntilNewRand(0, 10) == 0) { this.PlanedMove = "Attack"; }
            //else { this.PlanedMove = "dodge"; }

        }

    }
}
