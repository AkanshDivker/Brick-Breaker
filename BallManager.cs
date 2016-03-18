using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Brick_Breaker
{
    class BallManager : GameObject
    {
        private int speedX, speedY;

        /// <summary>
        /// Initializes the BallManager class and calls base constructor.
        /// </summary>
        /// <param name="x">X-Coordinate of the ball</param>
        /// <param name="y">Y-Coordinate of the ball</param>
        public BallManager(int x, int y)
            : base(x, y, 10, 10)
        {
            speedX = 5;
            speedY = 5;

            image = Properties.Resources.Ball;
        }

        /// <summary>
        /// Moves the ball with respect to its current speed.
        /// </summary>
        public void MoveBall()
        {
            rect = new Rectangle(rect.X + speedX, rect.Y, rect.Width, rect.Height);
            rect = new Rectangle(rect.X, rect.Y + speedY, rect.Width, rect.Height);
        }

        /// <summary>
        /// Checks to see if the ball collides with anything, and then changes direction.
        /// </summary>
        public void Collision()
        {
            if (rect.X <= 0 || rect.X >= 590)
            {
                speedX *= -1;
            }

            if (rect.Y < 0)
            {
                speedY *= -1;
            }
        }

        /// <summary>
        /// Checks to see if the ball collides with the paddle.
        /// </summary>
        /// <param name="paddleRect">The bounds of the Paddle</param>
        public void PaddleHit(Rectangle paddleRect)
        {
            if (paddleRect.IntersectsWith(rect))
            {
                speedY *= -1;

                // Bug fix so that the ball never gets stuck inside the paddle
                rect = new Rectangle(rect.X, rect.Y - 3, rect.Width, rect.Height);
            }
        }
    }
}
