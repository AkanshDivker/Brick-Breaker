using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brick_Breaker
{
    public partial class MainWindow : Form
    {
        MenuManager pMenuManager;
        GameManager pGameManager;

        /// <summary>
        /// Initializes the MainWindow of the program.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Remove flicker
            this.DoubleBuffered = true;

            // Create the menu display functionality
            pMenuManager = new MenuManager();
        }

        /// <summary>
        /// The paint method of the form. Handles all paint events.
        /// </summary>
        /// <param name="sender">The form that is sending the event.</param>
        /// <param name="e">Paint arguments, which includes the graphics component.</param>
        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            if (pGameManager != null)
            {
                if (pGameManager.IsGameRunning())
                {
                    pGameManager.DrawGame(e.Graphics);
                    pGameManager.Update();
                }
                else
                {
                    pMenuManager.DrawMenu(e.Graphics);
                }
            }
            else
            {
                pMenuManager.DrawMenu(e.Graphics);
            }
        }

        /// <summary>
        /// Fixed timed update which updates all components every 25ms.
        /// </summary>
        /// <param name="sender">The form that is sending the event.</param>
        /// <param name="e">Arguments about the timer event.</param>
        private void FixedUpdate_Tick(object sender, EventArgs e)
        {
            if (pGameManager.IsGameRunning())
            {
                pGameManager.InitBallControls();
            }

            this.Invalidate();
        }

        /// <summary>
        /// Handles all key presses on the window and manages input for the game.
        /// </summary>
        /// <param name="sender">The form that is sending the event.</param>
        /// <param name="e">Arguments about the key down event. Includes which key was pressed.</param>
        private void KeyboardInput(object sender, KeyEventArgs e)
        {
            if (pGameManager != null)
            {
                if (pGameManager.IsGameRunning())
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        pGameManager.GetPlayerManager.Movement("Left");
                    }

                    if (e.KeyCode == Keys.Right)
                    {
                        pGameManager.GetPlayerManager.Movement("Right");
                    }
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                pMenuManager.NavigateTo(pMenuManager.GetCurrentMenu - 1);
                this.Invalidate();
            }

            if (e.KeyCode == Keys.Down)
            {
                pMenuManager.NavigateTo(pMenuManager.GetCurrentMenu + 1);
                this.Invalidate();
            }

            if (e.KeyCode == Keys.Back)
            {
                // Go back
                pMenuManager.NavigateTo(1);
                this.Invalidate();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (pMenuManager.GetCurrentMenu == 1)
                {
                    pGameManager = new GameManager();

                    FixedUpdate.Start();
                    pGameManager.StartGame();
                }

                if (pMenuManager.GetCurrentMenu == 2)
                {
                    pMenuManager.NavigateTo(6);
                }

                if (pMenuManager.GetCurrentMenu == 3)
                {
                    pMenuManager.NavigateTo(7);
                }

                if (pMenuManager.GetCurrentMenu == 4)
                {
                    pMenuManager.NavigateTo(8);
                }

                this.Invalidate();
            }
        }
    }
}