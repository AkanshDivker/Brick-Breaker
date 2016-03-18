using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brick_Breaker
{
    class Brick : GameObject
    {
        /// <summary>
        /// Initializes a Brick object. Calls base constructor (super class).
        /// </summary>
        /// <param name="x">X-Coordinate of brick</param>
        /// <param name="y">Y-Coordinate of brick</param>
        public Brick(int x, int y) : base(x, y, 40, 10)
        {
            int brick = new Random().Next(4);

            switch (brick)
            {
                case 0:
                    image = Properties.Resources.Paddle;
                    break;
                case 1:
                    image = Properties.Resources.Brick1;
                    break;
                case 2:
                    image = Properties.Resources.Brick2;
                    break;
                case 3:
                    image = Properties.Resources.Brick3;
                    break;
                case 4:
                    image = Properties.Resources.Brick4;
                    break;
            }
        }

        /// <summary>
        /// Draws the brick onto the window.
        /// </summary>
        /// <param name="g">Graphics class and handler from form paint method.</param>
        public void Generate(Graphics g)
        {
            base.Draw(g);
        }

        /// <summary>
        /// Checks to see if the Brick is colliding with another object's Rectangle area.
        /// </summary>
        /// <param name="rect">Bounding box and coordinates that define a rectangle.</param>
        /// <returns>Boolean value based on collision.</returns>
        public bool IsColliding(Rectangle rect)
        {
            if (this.rect.IntersectsWith(rect))
                return true;
            return false;
        }
    }
}
