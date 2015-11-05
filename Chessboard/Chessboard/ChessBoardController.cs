using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chessboard
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ChessBoardController : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D whiteBoxTexture;
        Texture2D blackBoxTexture;
        Texture2D peasantTexture;

        Camera camera;

        public ChessBoardController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 632; // 512 + 128...(64*2)
            graphics.PreferredBackBufferHeight = 632; // 512 + 128...(64*2)
            Content.RootDirectory = "Content";

            camera = new Camera();
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
            whiteBoxTexture = Content.Load<Texture2D>("whiteBox.png");
            blackBoxTexture = Content.Load<Texture2D>("blackBox.png");
            peasantTexture = Content.Load<Texture2D>("peasant.png");

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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Vector2 windowCenterPos = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            //Vector2 whiteBoxStartPos = new Vector2(0, 0);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            
            int counter = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if(counter % 2 == 0)
                    {
                        spriteBatch.Draw(whiteBoxTexture, camera.getVisualCoordinates(x, y), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(blackBoxTexture, camera.getVisualCoordinates(x, y), Color.White);
                    }
                    counter++;
                }
                counter++;
            }

            /* Draw a symbol so that I will be able to see the logical coordinates.
             * Swap between these two...*/
            spriteBatch.Draw(peasantTexture, camera.getRotatedBoard(1, 1), Color.White);
            //spriteBatch.Draw(peasantTexture, camera.getVisualCoordinates(1, 1), Color.White);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // MOVED TO CAMERA CLASS
        //public Vector2 getCoordinates(int xCoordinate, int yCoordinate)
        //{
        //    int tileSize = 64;
        //    int borderSize = 64;
        //    int visualX = borderSize + xCoordinate * tileSize;
        //    int visualY = borderSize + yCoordinate * tileSize; 
            
        //    return new Vector2(visualX, visualY);
        //}
    }
}
