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
        Game game;
        GameObject background;
        //GameObject[,] gameObject = new GameObject[3,3];
        Mole[,] gameObject = new Mole[3,3];
        GameObject[,] holeObjects = new GameObject[3,3];
        GameObject[,] foreholeObjects = new GameObject[3,3];
        Vector2[,] positions;
        int g;

        int x;
        int y;

        bool released = true;
        bool hit;
        //Vector2[,] positions = { { new Vector2(100, 100), new Vector2(300, 100), new Vector2(500, 100) }, { new Vector2(100, 200), new Vector2(300, 200), new Vector2(500, 200) }, { new Vector2(100, 300), new Vector2(300, 300), new Vector2(500, 300) } };

        MouseState mouseState;
        public StateIntro(SpriteBatch spriteBatch, AssetLibrary assetLibrary, Game game)
        {
            this.spriteBatch = spriteBatch;
            this.assetLibrary = assetLibrary;
            this.game = game;
            this.x = game.Window.ClientBounds.Width / 5;
            this.y = game.Window.ClientBounds.Height / 5;
            Vector2[,] positions = { { new Vector2(0, y * 2), new Vector2(x * 3, y * 2), new Vector2(x * 4, y * 2) }, { new Vector2(x * 2, y * 3), new Vector2(x * 3, y * 3), new Vector2(x * 4, y * 3) }, { new Vector2(x * 2, y * 4), new Vector2(x * 3, y * 4), new Vector2(x * 4, y * 4) } };

            //this.gameObject = assetLibrary.CreateObject("Mole");//assetLibrary.assets["Mole"];
            for (int i = 0; i < gameObject.GetLength(0); i++)
            {
                for(int j = 0; j < gameObject.GetLength(1); j++)
                {
                    gameObject[i, j] = new Mole(spriteBatch, assetLibrary); //assetLibrary.CreateObject("Mole");
                    gameObject[i,j].SetPosition(positions[i,j]);

                    /*holeObjects[i, j] = assetLibrary.CreateObject("Hole");
                    holeObjects[i, j].SetPosition(positions[i, j]);

                    foreholeObjects[i, j] = assetLibrary.CreateObject("ForegroundHole");
                    foreholeObjects[i, j].SetPosition(positions[i, j]);*/
                }
            }
            //background = assetLibrary.CreateObject("Background");
            //background.SetPosition(new Vector2(0, 0));
        }
        public void Update()
        {
            mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                if(released)
                {
                    Aim();
                    released = false;
                }
                //background.SetState(AssetLibrary.State.Idle);
            }
            else
            {
                released = true;
                //background.SetState(AssetLibrary.State.Yard);
            }
            SimpleHit();
            this.x = game.Window.ClientBounds.Width / 6;
            this.y = game.Window.ClientBounds.Height / 6;
            //g++;
            Vector2[,] positions = { { new Vector2(x, y * 2.15f), new Vector2(x * 3, y * 2.15f), new Vector2(x * 5, y * 2.15f) }, { new Vector2(x, y * 3.15f), new Vector2(x * 3, y * 3.15f), new Vector2(x * 5, y * 3.15f) }, { new Vector2(x, y * 4.15f), new Vector2(x * 3, y * 4.15f), new Vector2(x * 5, y * 4.15f) } };
            Vector2[,] holePositions = { { new Vector2(x, y * 3), new Vector2(x * 3, y * 3), new Vector2(x * 5, y * 3) }, { new Vector2(x, y * 4), new Vector2(x * 3, y * 4), new Vector2(x * 5, y * 4) }, { new Vector2(x, y * 5), new Vector2(x * 3, y * 5), new Vector2(x * 5, y * 5) } };
            Vector2[,] foreholePositions = { { new Vector2(x, y * 3), new Vector2(x * 3, y * 3), new Vector2(x * 5, y * 3) }, { new Vector2(x, y * 4), new Vector2(x * 3, y * 4), new Vector2(x * 5, y * 4) }, { new Vector2(x, y * 5), new Vector2(x * 3, y * 5), new Vector2(x * 5, y * 5) } };

            for (int i = 0; i < gameObject.GetLength(0); i++)
            {
                for (int j = 0; j < gameObject.GetLength(1); j++)
                {
                    
                    gameObject[i, j].SetPosition(positions[i, j]);
                    gameObject[i, j].Update();
                    /*holeObjects[i, j].SetPosition(holePositions[i, j]);
                    foreholeObjects[i, j].SetPosition(foreholePositions[i, j]);*/
                }
            }

            
            
        }

        public void Draw()
        {
            
            //spriteBatch.Draw();
            //spriteBatch.Draw(assetLibrary.assets["Background"].sprites["Yard"], new Vector2(100, 0), Color.White);
            //spriteBatch.Draw(assetLibrary.assets["Mole"].sprites["Idle"], new Vector2(100, 200), Color.White);
            //gameObject.Draw(spriteBatch);
            //background.Draw(spriteBatch);
            for (int i = 0; i < gameObject.GetLength(0); i++)
            {
                for (int j = 0; j < gameObject.GetLength(1); j++)
                {
                    //holeObjects[i, j].Draw(spriteBatch);
                    //gameObject[i,j].Draw(spriteBatch);
                    gameObject[i, j].Draw();
                    //foreholeObjects[i,j].Draw(spriteBatch);
                }
            }
            /*foreach(GameObject g in gameObject)
            {
                g.Draw(spriteBatch);
            }*/
            spriteBatch.DrawString(assetLibrary.font, $"{hit}", new Vector2(mouseState.X, mouseState.Y), Color.Black);
        }

        public void Aim()
        {
            hit = false;
            Vector2 aimPos = new Vector2(mouseState.X, mouseState.Y);
            Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            foreach(Mole g in gameObject)
            {
                if(g.state == AssetLibrary.State.Idle || g.state == AssetLibrary.State.GoingUp)
                {
                    if(mouseRect.Intersects(g.rect))
                    {
                        hit = true;
                        //g.state = AssetLibrary.State.GoingDown;
                        g.SetState(AssetLibrary.State.GoingDown);
                        break;
                    }

                    /*if(Vector2.Distance(aimPos, g.GetPosition()) < g.radius)
                    {
                        hit = true;
                        g.state = AssetLibrary.State.GoingDown;
                        //g.SetState();
                        break;
                    }*/
                }
                

                
            }
        }

        public void SimpleHit()
        {
            hit = false;
            Vector2 aimPos = new Vector2(mouseState.X, mouseState.Y);
            Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1, 1);

            /*foreach (Mole g in gameObject)
            {
                if (mouseRect.Intersects(g.rect))
                {
                    hit = true;
                    //g.state = AssetLibrary.State.GoingDown;
                    //g.SetState(AssetLibrary.State.GoingDown);
                    break;
                }
            }*/

            for (int i = 0; i < gameObject.GetLength(0); i++)
            {
                for (int j = 0; j < gameObject.GetLength(1); j++)
                {
                    //holeObjects[i, j].Draw(spriteBatch);
                    //gameObject[i,j].Draw(spriteBatch);
                    //gameObject[i, j].Draw();
                    //foreholeObjects[i,j].Draw(spriteBatch);

                    if (mouseRect.Intersects(gameObject[i,j].rect))
                    {
                        hit = true;
                        gameObject[i,j].SetState(AssetLibrary.State.GoingDown);
                    }
                }
            }
            
            /*for (int i = 0; i < gameObject.Length; i++)
            {
                for (int j = 0; j < gameObject.Length; j++)
                {
                    //holeObjects[i, j].Draw(spriteBatch);
                    //gameObject[i,j].Draw(spriteBatch);
                    //gameObject[i, j].Draw();
                    //foreholeObjects[i,j].Draw(spriteBatch);

                    if (mouseRect.Intersects(gameObject[i,j].rect))
                    {
                        hit = true;
                        gameObject[i,j].SetState(AssetLibrary.State.GoingDown);
                    }
                }
            }*/
        }
    }
}
