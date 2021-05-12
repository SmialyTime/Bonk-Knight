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
                case "shop":
                case "help":
                default:
                    NormalWindow();
                    break;
            }

        }
        public void MapWindow()
        {
            Functions.ClearKeyIntputs();
            //load custom map screen
            //Render.ChangeScreen(0, 0, Art.GameUI($"{this.WindowName}"));
            Render.ChangeScreen(0, 0, Art.GameUI($"FillerTEST"));
            Render.RenderScreen("all");
            var KeyBack = MainClass.keyInput();
            while (this.WindowOpen)
            {

                if (KeyBack != '㊀' && KeyBack != '㊅' && KeyBack != '回')
                {
                    this.WindowOpen = false;
                }
                KeyBack = MainClass.keyInput();
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
