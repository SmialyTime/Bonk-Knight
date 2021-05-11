using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;

namespace Bonk_Knight
{
    public static class Globals
    {
        public const int Ox = 0;
        public const int Oy = 0;
        public const int Sx = 1;
        public const int Sy = 1;
        public const int GSW = 30;
        public const int GSH = 9;

        public static int GroundInGameY = 8;
        public static bool AnimationRunning = false;
        public static double GameSpeed = 1;
        public static String GameDifficulty = "medium";
        public static bool GameGoing = false;
        public static String Terrain = "Uknown";
        //to print to position x,y do Console.SetCursorPosition(x,y); <remember 0 indexed
        //Globals.Screen[rw,cl]
        public static String LastEvent = "";
        public static char[,] Screen = new char[9, GSW];
        public static char[,] CurrentBackground = new char[9, GSW];
        public static List<String> canBeBigEnemies = new List<String>() {"crab","bat","croc"};
        //CHANGE make a dictionary with all items and one for gear
    }
    class MainClass
    {
        //makes an eventHandler to be called and referenced for the event of Key input
        //public static KeyHandler Keys = new KeyHandler();
        public static PlayerHandler PlayerEventSystem = new PlayerHandler();
        public static Map GameMap { get; set; }
        public static ChangeConsoleSize MaxSize = new ChangeConsoleSize();
        public static Player Player_1 {get;set;}
        public static void Main(string[] args)
        {
            Console.WriteLine("Press any key to Start");
            InitializeComponents();

            GameOptions();
            //add in intro page


            Render.CursorBellowScreen();
            //CHANGE load first screen
            Player_1.Position = 4;
            GameMap.LoadCurrentScreen();
            Player_1.RenderEntity();
            Globals.GameGoing = true;
            char Continue = keyInput();
            while (Globals.GameGoing == true)
            {
                //use key 
                switch (Continue)
                {
                    case 'a':
                    //left  
                        Player_1.MoveL();
                        break;
                    case 'y':
                        //obstain  
                        PlayerEventSystem.MadeMove("left");
                        break;
                    case 'd':
                        //right
                        Player_1.MoveR();
                        break;
                    case 'w':
                    case 's':
                    //dodge  
                        Player_1.Dodge();
                        break;
                    case 'm':
                        //displays Map Screen
                        //make it so any button after changes to the normal screen
                        break;
                    case 'h':
                        //attack with player
                        Player_1.Attack();
                        break;
                    case 't':
                        //TESTAni.RunWalkCycle();
                        break;
                    case ''/*Esc*/:
                        Globals.GameGoing = false;
                        break;
                }
                Functions.CursorBellowScreen();

                //make better
                Continue = ' ';
                Continue = keyInput();
                Functions.CursorBellowScreen();
            }

            //CHANGE later
            Console.ResetColor();
            Console.ForegroundColor = Functions.GC("w");
            Console.WriteLine("press Enter button to continue");
            Console.ReadLine();
        }
        
        public static void GameOptions()
        {
            Functions.GC("White");
            //input game preferences
            Functions.CursourLogLineWrite("Username: ");
            var Username = Console.ReadLine();
            //10 because too long would mess up the display of things
            while (Username.Length > 10)
            {
                Functions.CursourLogLineWrite("Username (max of 10): ");
                Username = Console.ReadLine();
                //ADD cencorship?
            }
            Player_1 = new Player(Username);

            //writes out info
            Functions.resetCursor();
            Console.Write("Enter the difficulty you want:");
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
            Functions.CentedTextSubText("> easy  ", " Weaker Enemies , Less gold required", 10);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
            Functions.CentedTextSubText("> medium", " Normal Enemies , Norm gold required", 10);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
            Functions.CentedTextSubText("> hard  ", " Harder Enemies , More gold required", 10);

            //easy:   
            //medium: enemies x1.0 as Strong,x1.0 total gold to collect
            //hard:   enemies x1.5 as Strong,x1.5 total gold to collect
            //does checks for the input
            Functions.CursourLogLineWrite("Enter Difficulty: ");
            Globals.GameDifficulty = Console.ReadLine().ToLower();
            while (/*not*/!(Globals.GameDifficulty == "easy" || Globals.GameDifficulty == "medium" || Globals.GameDifficulty == "hard"))
            {
                Functions.CursourLogLineWrite("Enter valid Difficulty: ");
                Globals.GameDifficulty = Console.ReadLine().ToLower();
                //LOG enter valid difficulty
            }
            GameMap = new Map(Globals.GameDifficulty);

            var GameSpeed = "Normal".ToLower();
            while (/*not*/!(GameSpeed == "slow" || GameSpeed == "normal" || GameSpeed == "fast"))
            {
                //LOG enter valid difficulty
            }
        }
        public static void InitializeComponents()
        {
            //changes it so more characters can be used
            Console.OutputEncoding = Encoding.UTF8;
            //Initialise Screen arrays
            for (int dic = 0; dic < Globals.GSH; dic++)
            {
                for (int gap = 0; gap < Globals.GSW; gap++)
                {
                    Globals.Screen[dic, gap] = ' ';
                    Globals.CurrentBackground[dic, gap] = ' ';
                }
            }
            //main screen outline
            Render.RenderOutline(Globals.GSW, Globals.GSH);
        }
        public static char keyInput()
        {
            if (Globals.AnimationRunning == false)
            {
                if (Console.KeyAvailable)
                {
                    //Keys.KeyI();
                    var input = Console.ReadKey();
                    if (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Backspace)
                    {
                        char ltr = Convert.ToChar(input.KeyChar);
                        //2System.Diagnostics.Debug.WriteLine($"{ltr} pressed");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(' ');
                        //clears character stuff
                        Functions.ClearKeyIntputs();
                        return ltr;
                    }
                    else { System.Diagnostics.Debug.WriteLine($"Enter+stuff"); Functions.ClearKeyIntputs(); return '回';/*place holder for enter*/}
                }
                else { Functions.ClearKeyIntputs(); return '㊀'; }
            }
            else { /*Doesn't run*/  Functions.ClearKeyIntputs(); System.Diagnostics.Debug.WriteLine($"Animation running"); return '㊅'; }
        }
    }
    public class PlayerHandler
    {
        public event EventHandler<PlayerStats> Deaded;
        public void PlayerDied()
        {
            //way to pass in multipel args clearly
            PlayerStats myCustomArgs = new PlayerStats();
            myCustomArgs.Score = 100;
            //runs all events named clickEvent
            Deaded?.Invoke(this, myCustomArgs);
        }
        
        public event EventHandler<String> MadeCombatMove;
        //public event EventHandler<String> Moved;
        public void MadeMove(String Move)
        {
            //runs all events that happen when the player moves
            switch (Move.ToLower()) 
            {
                case "left":
                case "right":
                case "attack":
                case "dodge":
                    //handles when combat is happening and the moves make a difference
                    MadeCombatMove?.Invoke(this, Move);
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine(Move);
                    //handles normal moves 
                    //Moved?.Invoke(this, Move);
                    break;
            }
        }
        
    }
    public class PlayerStats
    {
        public int Score { get; set; }
    }
    public class ChangeConsoleSize
    {
            [DllImport("kernel32.dll", ExactSpelling = true)]
            private static extern IntPtr GetConsoleWindow();
            private static IntPtr ThisConsole = GetConsoleWindow();
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            private const int HIDE = 0;
            private const int MAXIMIZE = 3;
            private const int MINIMIZE = 6;
            private const int RESTORE = 9;
            public ChangeConsoleSize()
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                ShowWindow(ThisConsole, MAXIMIZE);
            }
    }
}
