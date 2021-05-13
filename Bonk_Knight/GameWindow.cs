using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class GameWindow : Render
    {
        public String WindowName { get; set; }
        public bool WindowOpen { get; set; }
        public char KeyBack = MainClass.keyInput();
        public GameWindow(String windowNm)
        {
            this.WindowName = windowNm;
            this.WindowOpen = true;
            Globals.ExtraScreenOpen = this.WindowName;
            switch (this.WindowName) 
            {
                //could seperate into different classes later
                case "Map":
                    MapWindow();
                    //has to custom render
                    break;
                case "log":
                    break;
                case "shop":
                    break;
                case "help":
                    HelpWindow();
                    break;
                default:
                    //window template
                    NormalWindow();
                    break;
            }

        }
        public void HelpWindow()
        {
            Functions.ClearKeyIntputs();
            //load custom map screen
            Render.RenderBlankOutline(Globals.GSW,Globals.GSH);
            Console.SetCursorPosition(Globals.Sx, Globals.Sy);
            LineWithSubText("Player move keys","-Action     ",ConsoleColor.DarkCyan);
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            LineWithSubText("Space - ","Attack/Charge");
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            LineWithSubText("W / S - ","Dodge        ");
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            LineWithSubText("D / A - ","Move Right/Left");
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            LineWithSubText("                | Screens", "", ConsoleColor.DarkCyan);
            LineWithSubText("Enemy Next Move", "", ConsoleColor.DarkCyan);
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            LineWithSubText("                 l","-logs");
            LineWithSubText(" d  ", "dodge", ConsoleColor.Green);
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            LineWithSubText("                 m", "-map");
            LineWithSubText(" ←  ", "move", ConsoleColor.DarkBlue);
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            LineWithSubText("                 b", "-shop");
            LineWithSubText(" A  ", "attack", ConsoleColor.Red);
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            LineWithSubText("↑A  ","buff attack", ConsoleColor.DarkRed);
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            LineWithSubText("↑D  ","buff defence", ConsoleColor.DarkGreen); 
            Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
            //LineWithSubText("                    Esc", "-end");
            LineWithSubText(" /?? ","charge/debuff", ConsoleColor.White);
            LineWithSubText("ϟ", "", ConsoleColor.Yellow);

            //run input things
            while (this.WindowOpen)
            {
                this.KeyBack = MainClass.keyInput();
                if (this.KeyBack != '㊀' && this.KeyBack != '㊅' && this.KeyBack != '回')
                {
                    this.WindowOpen = false;
                }
            }
            CloseScreen();
        }
        public void MapWindow()
        {
            Functions.ClearKeyIntputs();
            //load custom map screen
            Map Area = MainClass.GameMap;
            //work out where start of area is and what area
            var TerainNum = 0;
            while (Area.GameSectionMap[Area.CurrentSection].Type != Area.GameSectionMap[TerainNum].Type)
            {
                TerainNum++;
            }

            //runs as many times as needed to get to current area
            var Progress = 0;//for green colour
            for (var i = TerainNum; i <= Area.CurrentSection; i++)
            {
                Progress++;
            }

            var Areas = MainClass.GameMap.GameSectionMap[TerainNum].Type.ToLower();
            List<String> TopRow = new List<string>() { };
            //how many are shown
            int TopRowRev = 0;
            List<String> MiddleRow = new List<string>() { };
            int SecLen = 0;
            List<String> BottomRow = new List<string>() { };
            int BotHidden = 0;
            Console.SetCursorPosition(Globals.Sx, Globals.Sy + 4);
            switch (Areas) 
            {
                case "home":
                    TopRowRev = 0;
                    SecLen = 5;
                    BotHidden = 0;
                    break;
                case "throneroom":
                    Progress = 5;
                    TopRowRev = 0;
                    SecLen = 5;
                    BotHidden = 0;
                    break;
                case "mountain":
                    TopRowRev = 0;
                    SecLen = 1;
                    BotHidden = 4;
                    break;
                case "cave":
                    TopRowRev = 1;
                    SecLen = 5;
                    BotHidden = 3;
                    break;
                case "forest":
                    TopRowRev = 2;
                    SecLen = 5;
                    BotHidden = 2;
                    break;
                case "village":
                    TopRowRev = 3;
                    SecLen = 5;
                    BotHidden = 1;
                    break;
                case "kingdom":
                    TopRowRev = 4;
                    SecLen = 5;
                    BotHidden = 0;
                    break;
                default:
                    MakeErrorMessage($"{Area} not loaded");
                    break;
            }
            Random rnd = new Random();
            for (var i = 0; i< TopRowRev;i++)
            {
                TopRow.Add(Art.MapUI(Convert.ToString(i),rnd.Next(0,4)));
            }
            for (var i = 0; i < SecLen; i++)
            {
                if (Areas == "home")
                {
                    MiddleRow.Add(Art.MapUI("unknown", i));
                }
                else 
                {
                    MiddleRow.Add(Art.MapUI(Area.GameSectionMap[TerainNum].Type, i));
                }
            }
            for (var i = 0; i < BotHidden; i++)
            {
                BottomRow.Add(Art.MapUI("unknown", i));
            }

            //Write actual screen
            Render.RenderMapOutline(Art.MapUI("MapScreen", 1));
            //top row
            Console.SetCursorPosition(Globals.Sx+6, Globals.Sy);
            
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            //middle row
            Console.SetCursorPosition(Globals.Sx, Globals.Sy + 3);
            Console.Write("bob");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            //bottom row
            Console.SetCursorPosition(Globals.Sx, Globals.Sy + 6);
            Console.Write("bab");
            Console.ForegroundColor = ConsoleColor.DarkGray;


            Console.ForegroundColor = ConsoleColor.White;

            //stoping map feature
            while (this.WindowOpen)
            {
                this.KeyBack = MainClass.keyInput();
                if (this.KeyBack != '㊀' && this.KeyBack != '㊅' && this.KeyBack != '回')
                {
                    this.WindowOpen = false;
                }
            }
            CloseScreen();
        }
        public void NormalWindow()
        {
            Functions.ClearKeyIntputs();
            //load custom map screen
            Render.ChangeScreen(0, 0, Art.GameUI($"{this.WindowName}"));
            Render.RenderScreen("all");

            Functions.CursourLogLineWrite("Input Text: ");
            var TextInputToScreen = Console.ReadLine().ToLower();
            while (this.WindowOpen)
            {
                //check if player wants to exit screen
                if (TextInputToScreen == "exit" || TextInputToScreen == "e" || TextInputToScreen == "'exit'" || TextInputToScreen == "esc" || TextInputToScreen == "stop" || TextInputToScreen == "leave" || TextInputToScreen == "end")
                {
                    this.WindowOpen = false;
                }
                else
                {
                    //get input
                    Functions.CursourLogLineClear(TextInputToScreen);
                    Functions.CursourLogLineWrite("Input Text: ");
                    TextInputToScreen = Console.ReadLine().ToLower();
                }
            }
            CloseScreen();
        }
        public void CloseScreen()
        {
            Globals.ExtraScreenOpen = "Game";
            Render.RenderOutline(Globals.GSW, Globals.GSH);
            MainClass.GameMap.LoadCurrentScreen();
            MainClass.Player_1.RenderEntity();
            foreach (Enemy ennmy in MainClass.GameMap.CurrentEnemies)
            {
                ennmy.RenderEntity();
                ennmy.LoadIndicator();
            }
            Functions.ClearKeyIntputs();
        }
        public void LoadCurrentScreen()
        {
            Render.ChangeScreen(0, 0, Art.GameUI($"{this.WindowName}"));
            Render.RenderScreen("all");
        }
    }
}
