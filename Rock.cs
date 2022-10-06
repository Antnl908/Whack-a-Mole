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
        Texture2D tex;
        Rectangle rect;
        Rectanle source;
        int row;
        int col;
        int currentFrame;
        int totalFrames;
        public Vector2 position;

        public Rock(SpriteBatch spriteBatch, AssetLibrary assetLibrary, int row, int col, Vector2 position = Vector2.Zero)
        {
            this.assetLibrary = assetLibrary;
            this.tex = assetLibrary.sprites[assetLibrary.animationState[state]];
            this.row = row;
            this.col = col;
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
        }

        public void Draw()
        {
            int width = tex.Width / col;
            int height = tex.Height / row;
            row = currentFrame / col;
            col = currentFrame % col;

            source = new Rectangle(width * col, height * row, width, height);
            rect = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(assetLibrary.sprites[assetLibrary.animationState[state]], rect, source, Color.White);
        }
    }
}
