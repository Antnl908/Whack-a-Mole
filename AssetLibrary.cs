using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Whack_a_Mole
{
    internal class AssetLibrary
    {
        public enum State { Inactive, GoingUp, Idle, GoingDown, Hit, Yard, Hole, ForegroundHole, Rock }
        public State state = State.Idle;
        public string[] animationState;

        public Color backgroundColor = new Color(111, 209, 72);
        public Dictionary<string, Texture2D> sprites = new Dictionary<string, Texture2D>();

        public SpriteFont font;
        public AssetLibrary()
        {

        }

        public void LoadContent(ContentManager contentManager)
        {
            InitializeStates();
            Texture2D tex = contentManager.Load<Texture2D>("mole");
            
            sprites.Add("Idle", tex);
            
            
            sprites.Add("GoingUp", tex);

            
            sprites.Add("GoingDown", tex);
            
            
            sprites.Add("Inactive", tex);

            Texture2D texHit = contentManager.Load<Texture2D>("mole_KO");
            sprites.Add("Hit", texHit);

            Texture2D bac = contentManager.Load<Texture2D>("background");
            
            sprites.Add("Yard", bac);


            Texture2D hol = contentManager.Load<Texture2D>("hole");
            
            sprites.Add("Hole", hol);
            
            Texture2D foreHol = contentManager.Load<Texture2D>("foreground");
            
            sprites.Add("ForegroundHole", foreHol);
            
            Texture2D rock = contentManager.Load<Texture2D>("Rock");
            
            sprites.Add("Rock", rock);

            font = contentManager.Load<SpriteFont>("Font");

        }

        void InitializeStates()
        {
            animationState = new string[9];

            animationState[(int)State.Inactive] = "Inactive";
            animationState[(int)State.GoingUp] = "GoingUp";
            animationState[(int)State.Idle] = "Idle";
            animationState[(int)State.GoingDown] = "GoingDown";
            animationState[(int)State.Hit] = "Hit";
            animationState[(int)State.Yard] = "Yard";
            animationState[(int)State.Hole] = "Hole";
            animationState[(int)State.ForegroundHole] = "ForegroundHole";
            animationState[(int)State.Rock] = "Rock";
        }
    }
}
