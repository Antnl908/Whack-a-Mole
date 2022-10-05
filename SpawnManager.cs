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
    internal class SpawnManager
    {
        Mole[,] moles;
        List<Mole> moleList = new List<Mole>();
        Random random = new Random();
        int interval;

        public SpawnManager(Mole[,] moles)
        {
            this.moles = moles;
            this.interval = random.Next(40, 180);
        }

        public void Update(GameTime gameTime)
        {
            interval--;
            if(interval <= 0)
            {
                SpawnMole();
                interval = random.Next(40, 180);
            }
            
        }

        public void SpawnMole()
        {
            moleList.Clear();
            foreach (Mole m in moles)
            {
                if(m.state == AssetLibrary.State.Inactive)
                {
                    moleList.Add(m);
                }
            }

            if(moleList.Count > 0)
            {
                int index = random.Next(0, moleList.Count - 1);
                moleList[index].SetState(AssetLibrary.State.GoingUp);
                moleList[index].ResetTimer();
            }
        }
    }
}
