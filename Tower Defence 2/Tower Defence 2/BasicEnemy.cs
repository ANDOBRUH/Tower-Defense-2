using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    public class BasicEnemy : Movable
    {
        bool hit = false;
        bool coolDownStart = false;
        int hitCount;
        int coolDown = 12;
        int health = 100;
        public BasicEnemy() 
        {
            position.X = -200;
            position.Y = 127;
            moveSpeed = 300;
            velocity.X= 1;
            texture = Data.enemyTexture;
            hitBox = new Rectangle(0, 0,texture.Width, texture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            if (coolDownStart == true)
            {
                coolDown += 1;
            }
            base.Update(gameTime);

            if (health <= 0)
            {
                isRemoved = true;
            }
        }

        public override void CollisionEvent(Collidable other)
        {

            if (other is Tower)
            {
                health -= 10;
            }

            if (other is EnemyMovementHitbox)
            {
                coolDownStart = true;
                if (coolDown >= 13)
                {
                    hit = !hit;
                    hitCount += 1;

                    if (hit == false)
                    {                     
                       velocity.X = 1;
                       velocity.Y = 0;
                       coolDownStart = false;
                       coolDown = 0;
                    }
                    if (hit == true)
                    {
                        if (hitCount <= 4)
                        {
                            velocity.X = 0;
                            velocity.Y = 1;
                            coolDownStart = false;
                            coolDown = 0;
                        }
                        else if (hitCount == 5)
                        {
                            velocity.X = 0;
                            velocity.Y = -1;
                            coolDownStart = false;
                            coolDown = 0;
                        }
                        else
                        {
                            velocity.X = 0;
                            velocity.Y = 1;
                            coolDownStart = false;
                            coolDown = 0;
                        }
                    }
                    if (hitCount == 9)
                    {
                        isRemoved = true;
                    }
                }
            }
        }
    }
}
