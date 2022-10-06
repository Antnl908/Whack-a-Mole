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
    internal class StateIntro : IStateInterface
    {
        AssetLibrary assetLibrary;
        SpriteBatch spriteBatch;
        GameObject background;
        Game1 gameClass;

        int t;

        Rock rock;
        
        public StateIntro(SpriteBatch spriteBatch, AssetLibrary assetLibrary, Game game, Game1 gameClass)
        {
            this.spriteBatch = spriteBatch;
            this.assetLibrary = assetLibrary;
            this.gameClass = gameClass;
            background = new GameObject(spriteBatch, assetLibrary);
            background.SetPosition(new Vector2(0, 0));
            background.SetScale(new Vector2(game.Window.ClientBounds.Width, 0));
            background.state = AssetLibrary.State.Yard;

            rock = new Rock(spriteBatch, assetLibrary, new Vector2(game.Window.ClientBounds.Width, 200));
            game.IsMouseVisible = true;
        }
        public void Update(GameTime gameTime)
        {
            

            rock.Update();
            t++;
            KeyboardState ks = Keyboard.GetState();
            if(ks.IsKeyDown(Keys.Enter))
            {
                gameClass.gameState = Game1.GameState.Game;
            }
            
        }

        public void Draw(GameTime gameTime)
        {
            
            
            background.Draw();
            
            rock.Draw();

            if(t >= 120)
            {
                spriteBatch.DrawString(assetLibrary.font, $"Whacky Moles", new Vector2(250, 500), Color.Yellow);
            }
            
            if(t >= 180)
            {
                spriteBatch.DrawString(assetLibrary.font, $"Press \"Enter\" to start", new Vector2(200, 700), Color.Yellow);
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
