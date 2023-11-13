using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    public static class CollisionManager
    {
        public static void Update()
        {
            foreach (GameObject g1 in Data.gameObjects)
            {
                if (g1 is Collidable c1)
                {
                    foreach (GameObject g2 in Data.gameObjects)
                    {
                        if (g2 is Collidable c2)
                        {
                            if (g1 != g2)
                            {
                                if (c1.hitBox.Intersects(c2.hitBox))
                                {
                                    c1.CollisionEvent(c2);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
