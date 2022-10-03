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
        public enum State { Inactive, GoingUp, Idle, GoingDown, Hit, Yard, Hole, ForegroundHole }
        public State state = State.Idle;
        public string[] animationState;

        public Color backgroundColor = new Color(111, 209, 72);
        public Dictionary<string, GameObject> assets = new Dictionary<string, GameObject>();
        public Dictionary<string, Texture2D> sprites = new Dictionary<string, Texture2D>();

        public SpriteFont font;
        public AssetLibrary()
        {

        }

        public void LoadContent(ContentManager contentManager)
        {
            InitializeStates();
            Texture2D tex = contentManager.Load<Texture2D>("mole");
            //GameObject mole = new GameObject(this);
            //mole.SetState(State.Idle);
            //mole.SetLibrary(this);
            //mole.AddTexture(tex);
            //this.sprites.Add("Idle", tex);
            //mole.sprites.Add("Idle", tex);
            //assets.Add("Mole", mole);
            sprites.Add("Idle", tex);
            
            //mole.SetState(State.GoingUp);
            //mole.sprites.Add("GoingUp", tex);
            sprites.Add("GoingUp", tex);

            //mole.SetState(State.GoingDown);
            //mole.sprites.Add("GoingDown", tex);
            sprites.Add("GoingDown", tex);
            
            //mole.SetState(State.Inactive);
            //mole.sprites.Add("Inactive", tex);
            sprites.Add("Inactive", tex);

            Texture2D bac = contentManager.Load<Texture2D>("background");
            //GameObject background = new GameObject(this);
            //background.SetState(State.Yard);
            //background.SetLibrary(this);
            //background.sprites.Add("Yard", bac);
            //assets.Add("Background", background);
            sprites.Add("Yard", bac);


            Texture2D hol = contentManager.Load<Texture2D>("hole");
            //GameObject hole = new GameObject(this);
            //hole.SetState(State.Hole);
            //hole.sprites.Add("Hole", hol);
            //assets.Add("Hole", hole);
            sprites.Add("Hole", hol);
            
            Texture2D foreHol = contentManager.Load<Texture2D>("foreground");
            /*GameObject foregroundHole = new GameObject(this);
            foregroundHole.SetState(State.ForegroundHole);
            foregroundHole.sprites.Add("ForegroundHole", foreHol);
            assets.Add("ForegroundHole", foregroundHole);*/
            sprites.Add("ForegroundHole", foreHol);

            font = contentManager.Load<SpriteFont>("Font");

        }

        /*public GameObject CreateObject(string key)
        {
            GameObject obj = new GameObject(this);
            obj.sprites = new Dictionary<string, Texture2D>(assets[key].sprites); //assets[key].sprites;
            obj.state = assets[key].state;
            //foreach(string keys in assets[key].sprites)
            //{
            //    obj.sprites.Add()
            //}
            return obj;
        }*/

        void InitializeStates()
        {
            animationState = new string[8];

            animationState[(int)State.Inactive] = "Inactive";
            animationState[(int)State.GoingUp] = "GoingUp";
            animationState[(int)State.Idle] = "Idle";
            animationState[(int)State.GoingDown] = "GoingDown";
            animationState[(int)State.Hit] = "Hit";
            animationState[(int)State.Yard] = "Yard";
            animationState[(int)State.Hole] = "Hole";
            animationState[(int)State.ForegroundHole] = "ForegroundHole";
        }
    }
}
