using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class GameWindow : Render
    {

        public String WindowName = "Map";
        public GameWindow(String windowNm)
        {
            this.WindowName = windowNm;
            Globals.ExtraScreenOpen = this.WindowName;
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
        }
        public void LoadCurrentScreen()
        {
            Render.ChangeScreen(0, 0, Art.Background($"{this.WindowName}"));
            Render.RenderScreen("all");
        }
    }
}
