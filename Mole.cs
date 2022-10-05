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
    internal class Mole
    {
        public AssetLibrary assetLibrary;
        public AssetLibrary.State state;
        //public enum State { Inactive, GoingUp, Idle, GoingDown, Hit }
        //public State state;
        public enum Type { RegularMole, HeavyMole, FastMole, BombMole }
        public Type type;

        SpriteBatch spriteBatch;

        Texture2D[] sprites;
        Texture2D texture;

        public Vector2 position;
        public Rectangle rect;
        public Rectangle sourceRect;
        float timer;

        public int y;
        int ny = 2;
        int maxTime = 60;
        int speed = 4;

        public int radius;

        bool changestate;

        public Mole(SpriteBatch spriteBatch, AssetLibrary assetLibrary) //(Texture2D texture, SpriteBatch spriteBatch)
        {
            this.assetLibrary = assetLibrary;
            this.state = AssetLibrary.State.Idle;
            //this.texture = texture;
            this.spriteBatch = spriteBatch;
            //this.sprites = new Texture2D[sprites.Length];
            /*for (int i = 0; i < this.sprites.Length; i++)
            {
                this.sprites[i] = sprites[i];
            }*/
            this.rect = new Rectangle(0, 0, assetLibrary.sprites[assetLibrary.animationState[(int)state]].Width, assetLibrary.sprites[assetLibrary.animationState[(int)state]].Height);
            this.texture = assetLibrary.sprites[assetLibrary.animationState[2]];
        }
        public void Update()
        {
            UpdateRect();
            UpdateSourceRectangle();
            switch (state)
            {
                case AssetLibrary.State.GoingUp: //AssetLibrary.State.GoingUp:
                    if (y < 0) { y += speed; } else { y = -1; state = AssetLibrary.State.Idle; /*AssetLibrary.State.Idle;*/ }
                    break;

                case AssetLibrary.State.GoingDown: //AssetLibrary.State.GoingDown:
                    //timer = 0; if (y > -this.sourceRect.Height) { y -= speed; } else { y = -this.sourceRect.Height + 1; state = AssetLibrary.State.Inactive; /*AssetLibrary.State.Inactive;*/ }
                    //timer = 0; if (y > -this.sourceRect.Height) { y -= speed; } else { y = -this.sourceRect.Height + 1; state = AssetLibrary.State.Inactive; /*AssetLibrary.State.Inactive;*/ }
                    //timer = maxTime;
                    if (y > -this.sourceRect.Height) { y -= speed; } else { y = -this.sourceRect.Height + 1; state = AssetLibrary.State.Inactive; /*AssetLibrary.State.Inactive;*/ }
                    break;
                
                case AssetLibrary.State.Hit:
                    if (y > -this.sourceRect.Height) { y -= speed * 2; } else { y = -this.sourceRect.Height + 1; state = AssetLibrary.State.Inactive; /*AssetLibrary.State.Inactive;*/ }
                    break;

                case AssetLibrary.State.Idle: //AssetLibrary.State.Idle:
                    timer++; if (timer >= maxTime) { state = AssetLibrary.State.GoingDown; /*AssetLibrary.State.GoingDown;*/ timer = 0; y -= 2; }
                    break;

                case AssetLibrary.State.Inactive: //AssetLibrary.State.Inactive:
                    //timer++; if (timer >= maxTime) { state = AssetLibrary.State.GoingUp; /*AssetLibrary.State.GoingUp;*/ timer = 0; y += 2; }
                    break;
            }
        }

        public void Draw()
        {
            //this.rect.X = 200;
            //this.rect.Y = 200;
            //spriteBatch.Draw(texture, position, Color.White);
            //spriteBatch.Draw(assetLibrary.sprites[assetLibrary.animationState[(int)state]], rect, sourceRect, Color.White, 0f, new Vector2(assetLibrary.sprites[assetLibrary.animationState[(int)state]].Width / 2, assetLibrary.sprites[assetLibrary.animationState[(int)state]].Height / 2), SpriteEffects.None, 1);
            //spriteBatch.Draw(assetLibrary.sprites[assetLibrary.animationState[(int)state]], rect, sourceRect, Color.White, 0f, new Vector2(assetLibrary.sprites[assetLibrary.animationState[(int)state]].Width / 2, assetLibrary.sprites[assetLibrary.animationState[(int)state]].Height / 2), SpriteEffects.None, 1);
            spriteBatch.Draw(assetLibrary.sprites[assetLibrary.animationState[(int)state]], rect, sourceRect, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1);
            //spriteBatch.Draw(assetLibrary.sprites[assetLibrary.animationState[(int)state]], rect, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1);
            //spriteBatch.Draw(assetLibrary.sprites[assetLibrary.animationState[(int)state]], rect, Color.White);
            spriteBatch.DrawString(assetLibrary.font, $"{state}", new Vector2(rect.X, rect.Y), Color.Black);
        }

        void CheckCollision()
        {

        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
            UpdateRect();
        }
        
        public Vector2 GetPosition()
        {
            return this.position;
        }

        public void SetState(AssetLibrary.State state)
        {
            this.state = state;
            timer = maxTime;
            changestate = true;
        }

        void UpdateRect()
        {
            //this.sourceRect.Y = y;
            this.rect.X = (int)this.position.X;
            this.rect.Y = (int)this.position.Y;
        }

        void UpdateSourceRectangle()
        {
            this.sourceRect.Y = (int)y;
            //if (y > 0) { state = AssetLibrary.State.Idle; /*ny = -ny;*/ }
            //if (y < -this.sourceRect.Height) { state = AssetLibrary.State.Inactive; /*ny = -ny;*/ }
            this.sourceRect.Width = (int)assetLibrary.sprites[assetLibrary.animationState[(int)state]].Width;
            this.sourceRect.Height = (int)assetLibrary.sprites[assetLibrary.animationState[(int)state]].Height;
        }

        public void ResetTimer()
        {
            timer = 0;
        }
    }
}
