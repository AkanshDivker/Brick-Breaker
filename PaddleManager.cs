using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Brick_Breaker
{
    class PaddleManager : GameObject
    {
        private int speed;

        /// <summary>
        /// Initializes the PaddleManager class and calls base constructor.
        /// </summary>
        /// <param name="x">X-Coordinate of the paddle</param>
        /// <param name="y">Y-Coordinate of the paddle</param>
        public PaddleManager(int x, int y) : base(x, y, 100, 10)
        {
            image = Properties.Resources.Paddle;
            speed = 8;
        }

        /// <summary>
        /// Handles directional movement of the paddle.
        /// </summary>
        /// <param name="direction">The direction the paddle should move in.</param>
        public void Movement(String direction)
        {
            if (direction == "Left")
            {
                rect = new Rectangle(rect.X - speed, rect.Y, rect.Width, rect.Height);
            }

            if (direction == "Right")
            {
                rect = new Rectangle(rect.X + speed, rect.Y, rect.Width, rect.Height);
            }

            if (rect.X < 0)
            {
                rect = new Rectangle(0, rect.Y, rect.Width, rect.Height);
            }

            if (rect.X > 500)
            {
                rect = new Rectangle(500, rect.Y, rect.Width, rect.Height);
            }
        }
    }
}
