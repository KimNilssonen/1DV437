using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.View;
using Project.Controller;

namespace Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Project : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameController gameController;

        // Menu stuff.
        MainMenuButton playButton;
        Texture2D mainMenuBg;
        Texture2D playButtonTexture;

        enum GameState
        {
            MainMenu,
            Playing,
            Paused,
        }

        //Used when testing.
        GameState CurrentGameState = GameState.Playing;
        
        //GameState CurrentGameState = GameState.MainMenu;
        int screenWidth = 800, screenHeight = 600;

        public Project()
        {
            graphics = new GraphicsDeviceManager(this);
            
            // Screen setup.
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            
            IsMouseVisible = true;

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

            // GameControll stuff.
            gameController = new GameController(Content, graphics);


            // Player stuff.


            // Menu stuff.
            mainMenuBg = Content.Load<Texture2D>("MainMenuBg");
            playButtonTexture = Content.Load<Texture2D>("PlayButton");
            playButton = new MainMenuButton(playButtonTexture, graphics.GraphicsDevice);
            playButton.setPosition(new Vector2(350, 300));
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

            MouseState mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch(CurrentGameState)
            {
                case GameState.MainMenu:
                    if (playButton.isClicked)
                    {
                        CurrentGameState = GameState.Playing;
                    }
                    playButton.Update(mouseState);
                    break;

                case GameState.Playing:
                    gameController.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Begin();

                    spriteBatch.Draw(mainMenuBg, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    playButton.Draw(spriteBatch);

                    spriteBatch.End();
                    break;

                case GameState.Playing:
                    spriteBatch.Begin();

                    gameController.Draw(spriteBatch);

                    spriteBatch.End();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
