using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    public abstract class TileMap : Collidable
    {
        private List<Tile> tile = new List<Tile>();
        public List<Tile> Tile
        {
            get { return tile; }
        }

        private int width, height;
        public int widht
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public TileMap() { }

        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {

            }
        }

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value;}
        }




        //public static void CreateMap(int width, int height)
        //{
        //    map = new Tile[width, height];

        //    for (int x = 0; x < width; x++)
        //    {
        //        for (int y = 0; y < height; y++)
        //        {
        //            map[x, y] = new Tile(new(x * 64, y * 64));
        //        }
        //    }
        //}

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Data.hitboxTexture, rectangle, Color.White);
        }
    }
}
