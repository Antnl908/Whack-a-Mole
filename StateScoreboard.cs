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
    internal class StateScoreboard : IStateInterface
    {
        AssetLibrary assetLibrary;
        SpriteBatch spriteBatch;
        Game1 gameClass;
        int Y;

        public StateScoreboard(SpriteBatch spriteBatch, AssetLibrary assetLibrary, Game game, Game1 gameClass)
        {
            this.spriteBatch = spriteBatch;
            this.assetLibrary = assetLibrary;
            game.IsMouseVisible = true;
            this.gameClass = gameClass;

        }
        public void Update(GameTime gameTime)
        {

            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.R))
            {
                gameClass.gameState = Game1.GameState.Game;
                gameClass.states[(int)Game1.GameState.Game].Reset();
            }
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.DrawString(assetLibrary.font, $"Highscore", new Vector2(50, 200), Color.Black);

            for (int i = 0; i < gameClass.scoreboard.scoreboard.Count; i++)
            {
                Y = 300 + i * 100;
                spriteBatch.DrawString(assetLibrary.font, $"{gameClass.scoreboard.scoreboard[i]}", new Vector2(50, Y), Color.Black);
            }
            //spriteBatch.Draw();

            spriteBatch.DrawString(assetLibrary.font, $"Press \"R\" to restart", new Vector2(400, 200), Color.Black);

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
