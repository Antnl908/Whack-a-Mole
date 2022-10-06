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
    class Rock
    {
        AssetLibrary assetLibrary;
        AssetLibrary.State state = AssetLibrary.State.Rock;
        SpriteBatch spriteBatch;
        Texture2D tex;
        Rectangle rect;
        Rectangle source;
        int row;
        int col;
        int currentFrame;
        int totalFrames;
        public Vector2 position;

        public Rock(SpriteBatch spriteBatch, AssetLibrary assetLibrary, Vector2 position = default)
        {
            this.assetLibrary = assetLibrary;
            this.tex = assetLibrary.sprites[assetLibrary.animationState[(int)state]];
            this.spriteBatch =
            this.spriteBatch = spriteBatch;
            this.row = 4;
            this.col = 4;
            this.position = position;
            currentFrame = 0;
            totalFrames = row * col;
        }

        public void Update()
        {
            currentFrame++;
            if(currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            position.X -= 2;
            position.Y += 1;

        }

        public void Draw()
        {
            int width = tex.Width / col;
            int height = tex.Height / row;
            int rows = currentFrame / col;
            int colu = currentFrame % col;

            source = new Rectangle(width * colu, height * rows, width, height);
            rect = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(assetLibrary.sprites[assetLibrary.animationState[(int)state]], rect, source, Color.White);
        }
    }
}
