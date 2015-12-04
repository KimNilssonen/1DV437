using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Laboration3.View;
using Laboration3.Model;
using Microsoft.Xna.Framework.Audio;

namespace Laboration3.Controller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameController : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D smokeTexture;
        Texture2D splitterTexture;
        Texture2D explosionTexture;
        Texture2D shockwaveTexture;
        Texture2D ballTexture;
        Texture2D circleAimTexture;

        SoundEffect fireSound;

        Camera camera;
        StartView startView;
        //ExplosionView explosionView;
        BallView ballView;
        MouseCrosshairView mouseCrosshairView;

        BallSimulation ballSimulation;

        MouseState mouseState;
        MouseState oldMouseState;


        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            IsMouseVisible = false;
            
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
            ballTexture = Content.Load<Texture2D>("EightBall.png");
            circleAimTexture = Content.Load<Texture2D>("circleaim.png");

            fireSound = Content.Load<SoundEffect>("fire");

            camera = new Camera(graphics.GraphicsDevice.Viewport);
            //explosionView = new ExplosionView(smokeTexture, splitterTexture, explosionTexture,
            //                                    shockwaveTexture, camera, spriteBatch, fireSound);

            ballSimulation = new BallSimulation();
            startView = new StartView(smokeTexture, splitterTexture, explosionTexture,
                                                shockwaveTexture, camera, spriteBatch, fireSound, ballSimulation);
            ballView = new BallView(ballSimulation, camera, graphics.GraphicsDevice, ballTexture);
            mouseCrosshairView = new MouseCrosshairView(/*camera, circleAimTexture*/);

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
            mouseState = Mouse.GetState();

            ballSimulation.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            mouseCrosshairView.Update(mouseState);
            startView.Update((float)gameTime.ElapsedGameTime.TotalSeconds);


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                startView.createExplosion(mouseState.X, mouseState.Y, (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            oldMouseState = mouseState;

            
         
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
            ballView.Draw(spriteBatch);
            mouseCrosshairView.Draw(spriteBatch, circleAimTexture, camera);
            startView.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Draw(gameTime);
        }
    }
}