using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Whack_a_Mole
{
    internal class Timer
    {
        double timer;
        double totalTime;
        public void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            totalTime -= gameTime.ElapsedGameTime.TotalSeconds;
        }

        public int GetTime()
        {
            float tot = (float)totalTime;
            int tim = (int)tot;
            return tim;
        }
        
        public void SetTime(double time)
        {
            totalTime = time;
        }

        public double GetTimer()
        {
            return timer;
        }
        
        public void SetTimer()
        {
            timer = 0;
        }
    }
}
