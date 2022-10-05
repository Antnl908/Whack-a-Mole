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
    internal class StateMenu : IStateInterface
    {
        AssetLibrary assetLibrary;
        SpriteBatch spriteBatch;

        MouseState mouseState;

        Button[] buttons;

        public StateMenu(SpriteBatch spriteBatch, AssetLibrary assetLibrary)
        {
            this.spriteBatch = spriteBatch;
            this.assetLibrary = assetLibrary;
        }
        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            CheckButtonHit();
        }

        public void Draw(GameTime gameTime)
        {
            //spriteBatch.Draw();
        }

        void CheckButtonHit()
        {
            Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1,1);
            for(int i = 0; i < buttons.Length; i++)
            {
                if(mouseRect.Intersects(buttons[i].rect))
                {
                    buttons[i].Action();
                }
            }
        }
    }
}
