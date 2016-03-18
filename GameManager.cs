using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Brick_Breaker
{
    class GameManager
    {
        private PaddleManager pPlayerManager;
        private ScoreManager pScoreManager;

        // C# Encapsulation
        internal PaddleManager GetPlayerManager
        {
            get { return pPlayerManager; }
        }

        private BallManager pBallManager;

        // C# Encapsulation
        public BallManager GetBallManager
        {
            get { return pBallManager; }
        }

        private int ballLives;
        private bool gameRunning;

        private bool showOnce;
        private bool firstLoad;

        Brick[] bricks1;
        Brick[] bricks2;
        Brick[] bricks3;

        /// <summary>
        /// Constructor for the GameManager that defines variables needed on load.
        /// </summary>
        public GameManager()
        {
            pScoreManager = new ScoreManager();

            gameRunning = false;
            showOnce = false;
            firstLoad = false;

            LoadGame();
        }

        /// <summary>
        /// Runs an update to update and check for updates through the game.
        /// </summary>
        public void Update()
        {
            if (pBallManager.rect.Y > 600)
            {
                ballLives--;
                StartGame();
            }

            if (ballLives == 0)
            {
                StopGame();
            }

            for (int i = 0; i < bricks1.Length; i++)
            {
                if (pBallManager != null)
                {
                    if (bricks1[i] != null)
                    {
                        // If the ball is colliding with the brick, destroy the brick
                        if (bricks1[i].IsColliding(pBallManager.rect))
                        {
                            bricks1[i] = null;

                            // Add to score on brick break
                            pScoreManager.AddScore(1);

                            CheckGame();
                        }
                    }

                    if (bricks2[i] != null)
                    {
                        if (bricks2[i].IsColliding(pBallManager.rect))
                        {
                            bricks2[i] = null;

                            // Add to score on brick break
                            pScoreManager.AddScore(1);

                            CheckGame();
                        }
                    }

                    if (bricks3[i] != null)
                    {
                        if (bricks3[i].IsColliding(pBallManager.rect))
                        {
                            bricks3[i] = null;

                            // Add to score on brick break
                            pScoreManager.AddScore(1);

                            CheckGame();
                        }
                    }
                }


            }
        }

        /// <summary>
        /// Checks to see if a game round is won.
        /// </summary>
        public void CheckGame()
        {
            // Check if a round is won by seeing if all values in the array are null

            if (bricks1 != null && bricks2 != null && bricks3 != null)
            {
                try
                {
                    if (bricks1.Skip(0).Take(bricks1.Length).All(null) && bricks2.Skip(0).Take(bricks2.Length).All(null) && bricks3.Skip(0).Take(bricks3.Length).All(null))
                    {
                        // Round won
                        LoadGame();
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        /// <summary>
        /// Loads game values and settings for the first time start.
        /// </summary>
        public void LoadGame()
        {
            if (!firstLoad)
            {
                ballLives = 3;
                firstLoad = true;
            }

            showOnce = false;

            bricks1 = new Brick[12];
            bricks2 = new Brick[12];
            bricks3 = new Brick[12];

            // Assign bricks to their location
            for (int i = 0; i < bricks1.Length; i++)
            {
                if (i == 0)
                {
                    bricks1[i] = new Brick(25, 50);
                    bricks2[i] = new Brick(25, 70);
                    bricks3[i] = new Brick(25, 90);

                }
                else
                {
                    bricks1[i] = new Brick(i * 45, 50);
                    bricks2[i] = new Brick(i * 45, 70);
                    bricks3[i] = new Brick(i * 45, 90);
                }
            }
        }

        /// <summary>
        /// Starts the game and allows for playing.
        /// </summary>
        public void StartGame()
        {
            pPlayerManager = new PaddleManager(250, 378);
            pBallManager = new BallManager(500, 100);

            gameRunning = true;
        }

        /// <summary>
        /// Ends the game and displays the score to the user. Score uploading done in the background.
        /// Name is taken from default system username.
        /// </summary>
        public void StopGame()
        {
            gameRunning = false;
            firstLoad = false;

            if (!showOnce)
            {
                MessageBox.Show("Game over! Your score was " + pScoreManager.GetScore + " " + Environment.UserName + ".");
                pScoreManager.UploadScore(Environment.UserName);

                showOnce = true;
            }

            pPlayerManager = null;
            pBallManager = null;
            pScoreManager = null;
        }

        /// <summary>
        /// Checks to see if the game is currently in a playable state or not.
        /// </summary>
        /// <returns>Boolean value of game state.</returns>
        public bool IsGameRunning()
        {
            return gameRunning;
        }

        /// <summary>
        /// Handles graphics drawing of all game objects and items.
        /// </summary>
        /// <param name="g">Graphics class and handler from form paint method.</param>
        public void DrawGame(Graphics g)
        {
            pPlayerManager.Draw(g);
            pBallManager.Draw(g);

            foreach (Brick b in bricks1)
            {
                if (b != null)
                {
                    b.Generate(g);
                }
            }

            foreach (Brick b in bricks2)
            {
                if (b != null)
                {
                    b.Generate(g);
                }
            }

            foreach (Brick b in bricks3)
            {
                if (b != null)
                {
                    b.Generate(g);
                }
            }
        }

        /// <summary>
        /// Initialized all movement and collision detection for the ball.
        /// </summary>
        public void InitBallControls()
        {
            pBallManager.MoveBall();
            pBallManager.Collision();

            pBallManager.PaddleHit(pPlayerManager.rect);
        }
    }
}