using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    public class Tower : Collidable
    {
        public Vector2 rotation;
        public Vector2 direction;
        public Vector2 shootPosition;
        public Tower() 
        {
            texture = Data.towerTexture;
            SetOrigin(Data.towerTexture);
            position = InputManager.lastMousePosition;
            hitBox = new Rectangle(0, 0, 300, 300);
            shootPosition.X = texture.Width / 2;
            hitBox.X = (int)position.X - (hitBox.Width / 2) + (int)origin.X;
            hitBox.Y = (int)position.Y - (hitBox.Height / 2) + (int)origin.Y;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(Data.hitboxTexture, hitBox, Color.White);
        }
    }
    
}
