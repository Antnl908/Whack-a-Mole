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


        public StateMenu(SpriteBatch spriteBatch, AssetLibrary assetLibrary, Game game, Game1 gameClass)
        {
            this.spriteBatch = spriteBatch;
            this.assetLibrary = assetLibrary;
            game.IsMouseVisible = true;
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

        public bool mouseVisibility()
        {
            return true;
        }

        public void Reset()
        {

        }
    }
}
