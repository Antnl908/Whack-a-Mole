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
    internal class GameObject
    {
        AssetLibrary library;
        SpriteBatch spriteBatch;
        //public enum State{ Inactive, GoingUp, Idle, GoingDown, Hit }
        public AssetLibrary.State state; // = State.Idle;
        //public Dictionary<string, Texture2D> sprites = new Dictionary<string, Texture2D>();
        //string name;
        public Texture2D texture;
        public SpriteFont font;
        Model model;
        //string[] animationState = new string[5];
        Vector2 position;
        public Rectangle rect;
        public Rectangle sourceRect;
        float timer;

        int y;
        int ny = 2;
        int maxTime = 60;
        int speed = 4;

        public int radius;
        public GameObject(SpriteBatch spriteBatch, AssetLibrary library)//(string name, Texture2D texture = default, Model model = default)
        {
            this.library = library;
            this.spriteBatch = spriteBatch;
            this.rect = new Rectangle();
            //this.state = state;
            //this.name = name;
            //this.texture = texture;
            //this.model = model;
            /*animationState[(int)State.Inactive] = "Inactive";
            animationState[(int)State.GoingUp] = "GoingUp";
            animationState[(int)State.Idle] = "Idle";
            animationState[(int)State.GoingDown] = "GoingDown";
            animationState[(int)State.Hit] = "Hit";*/
            

        }

        public void AddTexture(Texture2D tex)
        {
            this.texture = tex;
        }

        public void Update()
        {
            this.radius = (int)library.sprites[library.animationState[(int)state]].Width / 2;
            switch (state)
            {
                case AssetLibrary.State.GoingUp: if(y < 0) { y += speed; } else { y = -1; state = AssetLibrary.State.Idle; }
                    break;

                case AssetLibrary.State.GoingDown: timer = 0; if(y > -this.sourceRect.Height) { y -= speed; } else { y = -this.sourceRect.Height + 1; state = AssetLibrary.State.Inactive;}
                    break;
                
                case AssetLibrary.State.Idle: timer++; if(timer >= maxTime) { state = AssetLibrary.State.GoingDown; timer = 0; y -= 2; }
                    break;
                
                case AssetLibrary.State.Inactive: timer++; if (timer >= maxTime) { state = AssetLibrary.State.GoingUp; timer = 0; y += 2; }
                    break;
            }
            //y += ny;
        }

        public void Draw()
        {
            
            //spriteBatch.Draw(sprites["Idle"], new Vector2(100, 200), Color.White);
            //spriteBatch.Draw(sprites[animationState[(int)state]], new Vector2(100, 200), Color.White);
            //spriteBatch.Draw(sprites[animationState[(int)state]], this.position, Color.White);

            //spriteBatch.Draw(library.sprites[library.animationState[(int)state]], this.position, Color.White);

            //UpdateRectangle();
            //UpdateSourceRectangle();
            //spriteBatch.Draw(library.sprites[library.animationState[(int)state]], rect, Color.White);
            //spriteBatch.Draw(library.sprites[library.animationState[(int)state]], rect, null, Color.White, 0f, new Vector2(library.sprites[library.animationState[(int)state]].Width/2, library.sprites[library.animationState[(int)state]].Height / 2), SpriteEffects.None, 1);
            //spriteBatch.Draw(library.sprites[library.animationState[(int)state]], rect, sourceRect, Color.White, 0f, new Vector2(library.sprites[library.animationState[(int)state]].Width/2, library.sprites[library.animationState[(int)state]].Height / 2), SpriteEffects.None, 1);
            spriteBatch.Draw(library.sprites[library.animationState[(int)state]], rect, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1);
            //spriteBatch.Draw(library.sprites[library.animationState[(int)state]], rect, sourceRect, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 1);
        }

        public void SetPosition(Vector2 pos)
        {
            this.position = pos;
            UpdateRectangle();
        }

        public void SetState(AssetLibrary.State state)
        {
            this.state = state;
            //this.rect = new Rectangle(0, 0, library.sprites[library.animationState[(int)state]].Width, library.sprites[library.animationState[(int)state]].Height);
            //y = -140;
        }

        public void SetLibrary(AssetLibrary library)
        {
            this.library = library;

            this.radius = (int)library.sprites[library.animationState[(int)state]].Width / 2;



        }

        void UpdateRectangle()
        {
            this.rect.X = (int)position.X;
            this.rect.Y = (int)position.Y;
            this.rect.Width = (int)library.sprites[library.animationState[(int)state]].Width;
            this.rect.Height = (int)library.sprites[library.animationState[(int)state]].Height;
        }

        public void SetScale(Vector2 scale)
        {
            if(scale.X != 0)
            {
                this.rect.Width = (int)scale.X;
            }
            if(scale.Y != 0)
            {
                this.rect.Height = (int)scale.Y;
            }
            
            
        }

        void UpdateSourceRectangle()
        {
            this.sourceRect.Y = (int)y;
            if (y > 0) { state = AssetLibrary.State.Idle; /*ny = -ny;*/ }
            if(y < -this.sourceRect.Height) { state = AssetLibrary.State.Inactive; /*ny = -ny;*/ }
            this.sourceRect.Width = (int)library.sprites[library.animationState[(int)state]].Width;
            this.sourceRect.Height = (int)library.sprites[library.animationState[(int)state]].Height;
        }

        public void SetState()
        {
            this.state = AssetLibrary.State.GoingDown;
        }

        public Vector2 GetPosition()
        {
            return new Vector2(rect.X, rect.Y);
        }

        public Vector2 GetHeight()
        {
            return new Vector2(0, library.sprites[library.animationState[(int)state]].Height);
        }
    }
}
