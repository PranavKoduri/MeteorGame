using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.CommandController;
using CrossPlatformDesktopProject.Sprites;
using CrossPlatformDesktopProject.InGameInfo;
using CrossPlatformDesktopProject.Entities;
using CrossPlatformDesktopProject.GameState;

namespace CrossPlatformDesktopProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public readonly Vector2 Dimensions = new Vector2(320, 240);

        private Matrix transformationMatrix;
        private KeyboardController keyboard;

        public Grass Grass;
        public Rover Rover;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            int scale = 3;
            graphics.PreferredBackBufferWidth = (int)Dimensions.X * scale;
            graphics.PreferredBackBufferHeight = (int)Dimensions.Y * scale;
            graphics.ApplyChanges();
            transformationMatrix = Matrix.CreateScale(scale, scale, 0);

            keyboard = new KeyboardController(this);
            IsMouseVisible = true;
            GameStateManager.Instance.Game = this;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadTextures(Content, spriteBatch, GraphicsDevice);

            Ammo.Instance.Initialize(Dimensions.X);

            Grass = new Grass(this);
            Rover = new Rover(this);

            Stars.Instance.Game = this;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();
            GameStateManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, transformationMatrix);
            GameStateManager.Instance.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}