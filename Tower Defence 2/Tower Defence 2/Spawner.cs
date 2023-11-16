using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    internal class Spawner
    {
        int timer;
        public void Update()
        {
            timer += 1;

            if (timer == 60)
            {
               Data.gameObjects.Add(new BasicEnemy());
                timer = 0;
            }

            if (InputManager.MouseClicked)
            {
                Data.gameObjects.Add(new Tower());
            }
        }
    }
}
