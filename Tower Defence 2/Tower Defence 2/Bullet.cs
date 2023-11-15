using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    internal class Bullet : Movable
    {
        public Bullet(Vector2 spawnposition, Vector2 direction) 
        {
           moveSpeed = 100;
           position = spawnposition;
           velocity = direction;
        }
    }
}
