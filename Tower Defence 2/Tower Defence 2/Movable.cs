using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    public abstract class Movable : Collidable
    {
        public float moveSpeed;
        public Vector2 velocity;
        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            base.Update(gameTime);
        }

        public void Move(GameTime gameTime)
        {
            position += velocity * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
