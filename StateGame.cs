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
    internal class StateGame : IStateInterface
    {
        AssetLibrary assetLibrary;
        SpriteBatch spriteBatch;

        Mole[,] moles = new Mole[3,3];

        Vector2[,] molePosition;// = new Vector2[3,3];
        int xpos;
        int ypos;

        public StateGame(SpriteBatch spriteBatch, AssetLibrary assetLibrary)
        {
            this.spriteBatch = spriteBatch;
            this.assetLibrary = assetLibrary;
            moles = new Mole[3,3];
            molePosition = new Vector2[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    //moles[i,j] = new Mole(assetLibrary.sprites["Idle"], spriteBatch);
                    moles[i,j] = new Mole(spriteBatch, assetLibrary);
                    molePosition[i,j] = new Vector2(xpos, ypos);
                    moles[i, j].position = molePosition[i, j];

                    xpos += 100;
                    ypos += 100;

                }
            }
        }
        public void Update(GameTime gameTime)
        {
            foreach(Mole m in moles)
            {
                m.Update();
            }
        }

        public void Draw(GameTime gameTime)
        {
            //spriteBatch.Draw();
            foreach (Mole m in moles)
            {
                m.Draw();
            }
        }
    }
}
