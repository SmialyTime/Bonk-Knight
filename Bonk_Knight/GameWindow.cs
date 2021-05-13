﻿using System;
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
                    LogWindow();
                    break;
                case "shop":
                    break;
                case "help":
                    HelpWindow();
                    break;
                default:
                    //window template
                    System.Diagnostics.Debug.WriteLine($"{this.WindowName} - is unrecognised as a window");
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

            //check for key inputs to return to main
            while (this.WindowOpen)
            {
                this.KeyBack = MainClass.keyInput();
                if (this.KeyBack != '㊀')
                {
                    this.WindowOpen = false;
                }
            }
            CloseScreen();
        }
        public void LogWindow()
        {
            //renders log messages
            Render.RenderBlankOutline(Globals.GSW, Globals.GSH);
            Console.SetCursorPosition(Globals.Sx,Globals.Sy);
            var Counter = 0;
            foreach (String log in Globals.Logs)
            {
                if (log != Globals.LastLog)
                {
                    Console.Write($"L{Counter}- ");
                    foreach (char ltr in log)
                    {
                        Functions.ColourPalet("logline", Convert.ToString(ltr));
                        Console.Write(ltr);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
                }
                else
                {
                    Console.Write("C - ");
                    foreach (char ltr in log)
                    {
                        Functions.ColourPalet("logline", Convert.ToString(ltr));
                        Console.Write(ltr);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);

                }
                Counter++;
            }
            Functions.CursourLogLineWrite("press any key to return");
            Console.ForegroundColor = ConsoleColor.White;

            //wait till input to return to main
            while (this.WindowOpen)
            {
                this.KeyBack = MainClass.keyInput();
                if (this.KeyBack != '㊀' && this.KeyBack != '㊅')
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
            if (TopRow.Count != 0) {
                var TopRowCellWidth = ((TopRow[0].Length - TopRow[0].Count(f => f == '%')) / TopRow[0].Count(f => f == '%'));
                var TopRowCellHeight = TopRow[0].Count(f => f == '%');
                Console.SetCursorPosition(Globals.Sx + 6, Globals.Sy);
                //for each row
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                for (var i = 0; i < TopRowCellHeight; i++)
                {
                    //and each small screen
                    for (var j = 0; j < TopRow.Count; j++)
                    {
                        //get the first section
                        for (var k = 0; k < TopRowCellWidth; k++)
                        {
                            Console.Write(TopRow[j][k + (i *( TopRowCellWidth + 1))]);
                        }
                    }
                    Console.SetCursorPosition(Globals.Sx + 6, Console.CursorTop + 1);
                }
            }
            TopRow.Clear();
            //middle row
            if (MiddleRow.Count != 0)
            {
                var MiddleRowCellWidth = ((MiddleRow[0].Length - MiddleRow[0].Count(f => f == '%')) / MiddleRow[0].Count(f => f == '%'));
                var MiddleRowCellHeight = MiddleRow[0].Count(f => f == '%');
                Console.SetCursorPosition(Globals.Sx, Globals.Sy + 3);
                //for each row
                for (var i = 0; i < MiddleRowCellHeight; i++)
                {
                    //and each small screen
                    for (var j = 0; j < MiddleRow.Count; j++)
                    {
                        //sets progress colour
                        if (j == Progress - 1) { Console.ForegroundColor = ConsoleColor.Yellow; }
                        else if (j < Progress - 1) { Console.ForegroundColor = ConsoleColor.Green; }
                        else { Console.ForegroundColor = ConsoleColor.DarkGray; }

                        //get the first section
                        for (var k = 0; k < MiddleRowCellWidth; k++)
                        {
                            Console.Write(MiddleRow[j][k + (i *( MiddleRowCellWidth + 1))]);
                        }
                    }
                    Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
                }
            }
            MiddleRow.Clear();

            //bottom row
            
            if (BottomRow.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                var BottomRowCellWidth = ((BottomRow[0].Length - BottomRow[0].Count(f => f == '%')) / BottomRow[0].Count(f => f == '%'));
                var BottomRowCellHeight = BottomRow[0].Count(f => f == '%');
                Console.SetCursorPosition(Globals.Sx, Globals.Sy + 6);
                //for each row
                for (var i = 0; i < BottomRowCellHeight; i++)
                {
                    //and each small screen
                    for (var j = 0; j < BottomRow.Count; j++)
                    {
                        //get the first section
                        for (var k = 0; k < BottomRowCellWidth; k++)
                        {
                            Console.Write(BottomRow[j][k + (i *( BottomRowCellWidth + 1))]);
                        }
                    }
                    Console.SetCursorPosition(Globals.Sx, Console.CursorTop + 1);
                }
            }
            BottomRow.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            //stoping map feature
            while (this.WindowOpen)
            {
                this.KeyBack = MainClass.keyInput();
                if (this.KeyBack != '㊀' && this.KeyBack != '㊅')
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
