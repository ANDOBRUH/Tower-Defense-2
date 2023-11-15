using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Tower_Defence_2
{
    class Tile : TileMap
    { 
        public Tile(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("tile" + i);
            this.Rectangle = newRectangle;
        }
    }
}
