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
        Timer timer = new Timer();
        Game game;
        Game1 gameClass;
        SpawnManager spawnManager;
        GameObject background;

        Mole[,] gameObject = new Mole[3, 3];
        GameObject[,] holeObjects = new GameObject[3, 3];
        GameObject[,] foreholeObjects = new GameObject[3, 3];

        Vector2[,] positions = new Vector2[3, 3];
        int g;

        int x;
        int y;

        int posX = 200;
        int posY = 200;

        bool released = true;
        int estimateDeadzone = 82;

        public int score = 0;



        //Rectangle mouseMallet;
        float malletRot;


        MouseState mouseState;

        public StateGame(SpriteBatch spriteBatch, AssetLibrary assetLibrary, Game game, Game1 gameClass)
        {
            this.spriteBatch = spriteBatch;
            this.assetLibrary = assetLibrary;
            this.gameClass = gameClass;
            this.x = game.Window.ClientBounds.Width / 5;
            this.y = game.Window.ClientBounds.Height / 5;

            for (int i = 0; i < gameObject.GetLength(0); i++)
            {
                for (int j = 0; j < gameObject.GetLength(1); j++)
                {
                    positions[i, j] = new Vector2(75 + posX * i, 600 + posY * j);

                    holeObjects[i, j] = new GameObject(spriteBatch, assetLibrary);
                    holeObjects[i, j].SetPosition(positions[i, j]);
                    holeObjects[i, j].state = AssetLibrary.State.Hole;

                    foreholeObjects[i, j] = new GameObject(spriteBatch, assetLibrary);
                    foreholeObjects[i, j].SetPosition(positions[i, j]);
                    foreholeObjects[i, j].state = AssetLibrary.State.ForegroundHole;

                    gameObject[i, j] = new Mole(spriteBatch, assetLibrary);
                    gameObject[i, j].SetPosition(positions[i, j] + foreholeObjects[i, j].GetHeight());

                }
            }
            background = new GameObject(spriteBatch, assetLibrary);
            background.SetPosition(new Vector2(0, 0));
            background.SetScale(new Vector2(x * 5, 0));
            background.state = AssetLibrary.State.Yard;
            spawnManager = new SpawnManager(gameObject);

            Reset();
            game.IsMouseVisible = false;
        }
        public void Update(GameTime gameTime)
        {
            timer.Update(gameTime);
            spawnManager.Update(gameTime);
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                malletRot = 0f;
                if (released)
                {
                    SimpleHit();
                    released = false;
                }
            }
            else
            {
                malletRot = 0.25f;
                released = true;
            }

            for (int i = 0; i < gameObject.GetLength(0); i++)
            {
                for (int j = 0; j < gameObject.GetLength(1); j++)
                {
                    gameObject[i, j].SetPosition(positions[i, j] - foreholeObjects[i, j].GetHeight() / 3 * 2);
                    gameObject[i, j].Update();
                    holeObjects[i, j].SetPosition(positions[i, j]);
                    foreholeObjects[i, j].SetPosition(positions[i, j]);
                }
            }

            if(timer.GetTime() < 0)
            {
                gameClass.gameState = Game1.GameState.GameOver;
                gameClass.scoreboard.AddScore(score);
            }
        }

        public void Draw(GameTime gameTime)
        {
            background.Draw();
            for (int i = 0; i < gameObject.GetLength(0); i++)
            {
                for (int j = 0; j < gameObject.GetLength(1); j++)
                {
                    holeObjects[i, j].Draw();

                    gameObject[i, j].Draw();
                    foreholeObjects[i, j].Draw();
                }
            }
            if(timer.GetTime() > timer.GetMaxTime()/ 2)
            {
                spriteBatch.DrawString(assetLibrary.font, $"{timer.GetTime()}", new Vector2(100, 300), Color.Black);
            }
            else
            {
                spriteBatch.DrawString(assetLibrary.font, $"{timer.GetTime()}", new Vector2(100, 300), Color.Red);
                
            }

            spriteBatch.Draw(assetLibrary.sprites["Mallet"], new Vector2(mouseState.X + assetLibrary.sprites["Mallet"].Width - 40, mouseState.Y), null, Color.White, malletRot, new Vector2(assetLibrary.sprites["Mallet"].Width, assetLibrary.sprites["Mallet"].Height), 1, SpriteEffects.None, 0);

            spriteBatch.DrawString(assetLibrary.font, $"{score}", new Vector2(600, 300), Color.Red);
        }


        public void Aim()
        {
            Vector2 aimPos = new Vector2(mouseState.X, mouseState.Y);
            Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            foreach (Mole g in gameObject)
            {
                if (g.state != AssetLibrary.State.Hit)
                {
                    if (g.state == AssetLibrary.State.Idle || g.state == AssetLibrary.State.GoingUp)
                    {
                        if (mouseRect.Intersects(g.rect))
                        {

                            g.SetState(AssetLibrary.State.GoingDown);
                            break;
                        }

                    }
                }



            }
        }

        public void SimpleHit()
        {
            Vector2 aimPos = new Vector2(mouseState.X, mouseState.Y);
            Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 10, 10);

            for (int i = 0; i < gameObject.GetLength(0); i++)
            {
                for (int j = 0; j < gameObject.GetLength(1); j++)
                {
                    if (gameObject[i, j].state != AssetLibrary.State.Hit)
                    {
                        if (gameObject[i, j].state == AssetLibrary.State.Idle || gameObject[i, j].state == AssetLibrary.State.GoingUp)
                        {

                            if (mouseRect.Intersects(gameObject[i, j].rect) && (mouseRect.Y - gameObject[i, j].rect.Y) + gameObject[i, j].y >= estimateDeadzone)
                            {
                                gameObject[i, j].SetState(AssetLibrary.State.Hit);
                                score += 100;
                            }
                        }
                    }
                }
            }


        }

        public void Reset()
        {
            timer.SetTime(30);
            foreach (Mole mole in gameObject)
            {
                mole.ResetMole();
            }
            spawnManager.ResetInterval();
            score = 0;
        }

        public bool mouseVisibility()
        {
            return false;
        }
    }
}
