﻿using System;
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
        public StateGameOver(SpriteBatch spriteBatch, AssetLibrary assetLibrary)
        {
            this.spriteBatch = spriteBatch;
            this.assetLibrary = assetLibrary;
        }
        public void Update()
        {

        }

        public void Draw()
        {
            //spriteBatch.Draw();
        }
    }
}
