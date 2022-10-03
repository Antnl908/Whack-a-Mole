using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Whack_a_Mole
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public enum GameState { Intro, Menu, Game, GameOver, Scoreboard}
        public GameState gameState = GameState.Intro;

        public IStateInterface[] states = new IStateInterface [5];

        AssetLibrary assetLibrary = new AssetLibrary();

        //string[] textureName;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 1280; 

            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            assetLibrary.LoadContent(Content);

            states[(int)GameState.Intro] = new StateIntro(_spriteBatch, assetLibrary, this);
            states[(int)GameState.Menu] = new StateMenu(_spriteBatch, assetLibrary);
            states[(int)GameState.Game] = new StateGame(_spriteBatch, assetLibrary);
            states[(int)GameState.GameOver] = new StateGameOver(_spriteBatch, assetLibrary);
            states[(int)GameState.Scoreboard] = new StateScoreboard(_spriteBatch, assetLibrary);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            UpdateGamestate();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(assetLibrary.backgroundColor);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            DrawGamestate();
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        void UpdateGamestate()
        {
            states[(int)gameState].Update(); 
        }

        void DrawGamestate()
        {
            states[(int)gameState].Draw();
        }

        public void SetState(GameState state)
        {
            this.gameState = state;
        }
    }
}