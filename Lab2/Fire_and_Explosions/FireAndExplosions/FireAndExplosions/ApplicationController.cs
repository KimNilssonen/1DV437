using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FireAndExplosions
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ApplicationController : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D smokeTexture;
        Texture2D splitterTexture;
        Texture2D explosionTexture;
        Texture2D shockwaveTexture;
        
        Camera camera;
        ApplicationView applicationView;

        public ApplicationController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
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
            // TODO: Add your initialization logic here

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

            // TODO: use this.Content to load your game content here
            smokeTexture = Content.Load<Texture2D>("particlesmoke.png");
            splitterTexture = Content.Load<Texture2D>("spark.png");
            explosionTexture = Content.Load<Texture2D>("explosion.png");
            shockwaveTexture = Content.Load<Texture2D>("Shockwave.png");
            
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            applicationView = new ApplicationView(smokeTexture, splitterTexture, explosionTexture, shockwaveTexture, camera, spriteBatch);



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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                applicationView.createExplosion();
            }
            
            applicationView.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            // TODO: Add your update logic here
            //if (Keyboard.GetState().IsKeyDown(Keys.E))
            //{
            //    applicationView.createExplosion();
            //    applicationView.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            //}

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            applicationView.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Draw(gameTime);
        }
    }
}
