using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Brick_Breaker
{
    class MenuManager
    {
        private Image MainMenu1;
        private Image MainMenu2;
        private Image MainMenu3;
        private Image MainMenu4;

        private Image MenuHighScores;
        private Image MenuHelp;
        private Image MenuCredits;

        private int currentMenu;
        
        // C# Encapsulation
        public int GetCurrentMenu
        {
            get { return currentMenu; }
        }

        /// <summary>
        /// Initlializes the MenuManager class and sets variable values.
        /// </summary>
        public MenuManager()
        {
            currentMenu = 1;

            MainMenu1 = Properties.Resources.Main_Menu;
            MainMenu2 = Properties.Resources.Main_Menu_2;
            MainMenu3 = Properties.Resources.Main_Menu_3;
            MainMenu4 = Properties.Resources.Main_Menu_4;

            MenuHighScores = Properties.Resources.Menu_Background;
            MenuCredits = Properties.Resources.Menu_Credits;
            MenuHelp = Properties.Resources.Menu_Help;
        }

        /// <summary>
        /// Draws the menu based on current selection to the window.
        /// </summary>
        /// <param name="g">Graphics class and handler from form paint method.</param>
        public void DrawMenu(Graphics g)
        {
            if (currentMenu == 1)
            {
                g.DrawImage(MainMenu1, new Rectangle(0, 0, 600, 400));
            }

            if (currentMenu == 2)
            {
                g.DrawImage(MainMenu2, new Rectangle(0, 0, 600, 400));
            }

            if (currentMenu == 3)
            {
                g.DrawImage(MainMenu3, new Rectangle(0, 0, 600, 400));
            }

            if (currentMenu == 4)
            {
                g.DrawImage(MainMenu4, new Rectangle(0, 0, 600, 400));
            }

            //////////////// Sub Menus ///////////////////

            if (currentMenu == 6)
            {
                // Highscore Menu
                g.DrawImage(MenuHighScores, new Rectangle(0, 0, 600, 400));
                g.DrawString("Backspace to go Back", new Font("Segoe UI", 11), Brushes.White, 5, 5);

                var request = (HttpWebRequest)WebRequest.Create("http://ics.net78.net/brick/display.php");

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                String[] scores = responseString.Split(' ');

                g.DrawString(scores[0] + "              " + scores[2], new Font("Segoe UI", 11), Brushes.White, 200, 100);
            }

            if (currentMenu == 7)
            {
                // Help Menu
                g.DrawImage(MenuHelp, new Rectangle(0, 0, 600, 400));
                g.DrawString("Backspace to go Back", new Font("Segoe UI", 11), Brushes.White, 5, 5);
            }

            if (currentMenu == 8)
            {
                // Credits Menu
                g.DrawImage(MenuCredits, new Rectangle(0, 0, 600, 400));
                g.DrawString("Backspace to go Back", new Font("Segoe UI", 11), Brushes.White, 5, 5);
            }
        }

        /// <summary>
        /// Changes the current menu highlighted.
        /// </summary>
        /// <param name="menu">Current menu to highlight.</param>
        public void NavigateTo(int menu)
        {
            currentMenu = menu;

            if (currentMenu == 0)
                currentMenu = 4;

            if (currentMenu == 5)
                currentMenu = 1;
        }
    }
}
