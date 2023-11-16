using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    public abstract class GameObject
    {
        public Vector2 position;
        public Texture2D texture;
        public bool isRemoved = false;
        public Vector2 origin;

        public abstract void Update(GameTime gameTime);

        public void SetOrigin(Texture2D _texture)
        {
            origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
