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
    internal class StateGameOver : IStateInterface
    {
        AssetLibrary assetLibrary;
        SpriteBatch spriteBatch;
        Game1 gameClass;

        int t;
        public StateGameOver(SpriteBatch spriteBatch, AssetLibrary assetLibrary, Game game, Game1 gameClass)
        {
            this.spriteBatch = spriteBatch;
            this.assetLibrary = assetLibrary;
            game.IsMouseVisible = true;
            this.gameClass = gameClass;
        }
        public void Update(GameTime gameTime)
        {
            t++;
            if(t > 200)
            {
                //gameClass.gameState = Game1.GameState.Scoreboard;
                NextState();
            }

            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Enter))
            {
                gameClass.gameState = Game1.GameState.Scoreboard;
            }
        }

        public void Draw(GameTime gameTime)
        {
            //spriteBatch.Draw();
            spriteBatch.DrawString(assetLibrary.font, $"Game Over!", new Vector2(300, 300), Color.Black);
        }

        public bool mouseVisibility()
        {
            return true;
        }

        void NextState()
        {
            gameClass.gameState = Game1.GameState.Scoreboard;
            gameClass.scoreboard.scoreboard.Sort();
        }

        public void Reset()
        {
            
        }
    }
}
