using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    public abstract class Collidable : GameObject
    {
        public Rectangle hitBox;
        public override void Update(GameTime gameTime)
        {
            hitBox.Location = position.ToPoint();
        }

        public virtual void CollisionEvent(Collidable other)
        {

        }


        public void DrawHitbox(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Data.towerTexture, hitBox, Color.White);
        }
    }
}
