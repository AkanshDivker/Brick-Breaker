using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Brick_Breaker
{
    public class GameObject
    {
        // Image of the object to be drawn
        Image displayImage;

        // C# Encapsulation
        public Image image
        {
            get { return displayImage; }
            set { displayImage = value; }
        }

        // The bounding area of the object
        Rectangle rectangle;

        // C# Encapsulation
        public Rectangle rect
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        /// <summary>
        /// Initializes the GameObject class.
        /// </summary>
        /// <param name="x">X-Coordinate of the object.</param>
        /// <param name="y">Y-Coordinate of the object.</param>
        /// <param name="width">The width of the object.</param>
        /// <param name="height">The height of the object.</param>
        public GameObject(int x, int y, int width, int height)
        {
            rectangle = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Draws the object to the window.
        /// </summary>
        /// <param name="g">Graphics class and handler from form paint method.</param>
        public void Draw(Graphics g)
        {
            g.DrawImage(displayImage, rectangle);
        }
    }
}
