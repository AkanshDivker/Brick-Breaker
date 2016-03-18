using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Brick_Breaker
{
    class ScoreManager
    {
        private int score;

        // C# Encapsulation
        public int GetScore
        {
            get { return score; }
        }

        /// <summary>
        /// Initializes the ScoreManager class.
        /// </summary>
        public ScoreManager()
        {
            // Set starting score to 0
            score = 0;
        }

        /// <summary>
        /// Adds to player score.
        /// </summary>
        /// <param name="score">Value to add to the current score.</param>
        public void AddScore(int score)
        {
            this.score += score;
        }

        /// <summary>
        /// Uploads the score data to the server via a POST request.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        public void UploadScore(String name)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://ics.net78.net/brick/addscore.php");

            var postData = "name=" + name;
            postData += "&score=" + score;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
        }
    }
}
