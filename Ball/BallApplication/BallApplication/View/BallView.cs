using BallApplication.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallApplication.View
{
    class BallView
    {
        BallSimulation ballSimulation;
        Camera camera;
        Texture2D ballTexture;
        Texture2D gameAreaTexture;
        

        public BallView(BallSimulation Ballsimulation, Camera Camera, GraphicsDevice Graphics, Texture2D BallTexture)
        {
            ballSimulation = Ballsimulation;
            camera = Camera;
            ballTexture = BallTexture;

            gameAreaTexture = new Texture2D(Graphics, 1, 1);
            gameAreaTexture.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Set scale of the ball.
            float ballScale = camera.getTextureScale(ballSimulation.getBallRadius(), ballTexture.Bounds.Width);

            spriteBatch.Begin();

            // Draw board.
            spriteBatch.Draw(gameAreaTexture, camera.getGameArea(), Color.DarkGreen);

            // Draw ball. Added rotation for fun =)
            spriteBatch.Draw(ballTexture, camera.getVisualCoords(ballSimulation.getBallPosition()), 
                        ballTexture.Bounds, Color.White, ballSimulation.getRotation(), new Vector2(ballTexture.Bounds.Width/2, ballTexture.Bounds.Height/2),
                        ballScale, SpriteEffects.None, 0);

            spriteBatch.End();
        }
    }
}
