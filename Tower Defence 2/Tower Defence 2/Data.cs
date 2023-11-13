using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    internal class Data
    {
        public static Texture2D towerTexture;
        public static Texture2D enemyTexture;
        public static Texture2D hitboxTexture;
        public static Texture2D bulletTexture;

        public static float Time;
        public static ContentManager Content;
        public static SpriteBatch SpriteBatch;

        public static MouseState mousePosition;
        public static Point WindowSize;

        public static int bufferWidth = 1920;
        public static int bufferHeight = 1080;

        public static List<GameObject> gameObjects = new List<GameObject>();

        public static Random rng = new Random();

        public static void Update(GameTime gt)
        {
            Time = (float)gt.ElapsedGameTime.TotalSeconds;

            var mouseState = Mouse.GetState();

            mousePosition = mouseState;
        }
    }
}
