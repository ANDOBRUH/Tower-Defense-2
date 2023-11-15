using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    public class EnemyMovementHitbox : Collidable
    { 
        public EnemyMovementHitbox(Vector2 Position, Rectangle HitBox)
        {
            position = Position;
            texture = Data.hitboxTexture;
            hitBox = HitBox;
        }

        public override void CollisionEvent(Collidable other)
        {
            if (other is BasicEnemy)
            {
              // isRemoved= true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
           // spriteBatch.Draw(Data.hitboxTexture, hitBox, Color.White);
        }
    }
}
