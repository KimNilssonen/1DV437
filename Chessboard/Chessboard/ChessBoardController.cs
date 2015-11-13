using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
            graphics.PreferredBackBufferWidth = 320; // 512 + 128...(64*2)
            graphics.PreferredBackBufferHeight = 240; // 512 + 128...(64*2)
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
            camera.setScale(graphics);
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
            
            // Used to easier change the position of the pawn.
            int peasantX = 2;
            int peasantY = 3;

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            int counter = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if(counter % 2 == 0)
                    {
                        spriteBatch.Draw(whiteBoxTexture, camera.getVisualCoordinates(x, y), null, Color.White,
                                        0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
                    }
                    else
                    {
                        spriteBatch.Draw(blackBoxTexture, camera.getVisualCoordinates(x, y), null, Color.White,
                                        0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
                    }
                    counter++;
                }
                counter++;
            }

            /* Draw a symbol so that I will be able to see the logical coordinates.
             * Swap between these two...*/

            //spriteBatch.Draw(peasantTexture, camera.getVisualCoordinates(peasantX, peasantY), null, Color.White,
            //                            0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
            spriteBatch.Draw(peasantTexture, camera.getRotatedBoard(peasantX, peasantY), null, Color.White,
                                        0, new Vector2(0, 0), camera.scale, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
