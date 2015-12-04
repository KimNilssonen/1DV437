using Laboration3.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration3.View
{
    class BallView
    {
        BallSimulation _ballSimulation;
        Camera _camera;
        Texture2D _ballTexture;
        Texture2D gameAreaTexture;

        public BallView(BallSimulation Ballsimulation, Camera Camera, GraphicsDevice Graphics, Texture2D BallTexture)
        {
            _ballSimulation = Ballsimulation;
            _camera = Camera;
            _ballTexture = BallTexture;

            gameAreaTexture = new Texture2D(Graphics, 1, 1);
            gameAreaTexture.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            // Draw board.
            spriteBatch.Draw(gameAreaTexture, _camera.getGameArea(), Color.Brown);

            foreach (Ball ball in _ballSimulation.listOfBalls)
            {
                // Set scale of the ball.
                float ballScale = _camera.getBallScale(ball.getRadius(), _ballTexture.Width);

                // Draw ball. Added rotation for fun =)
                spriteBatch.Draw(_ballTexture, _camera.getBallVisualCoords(ball.getPosition(), _ballTexture.Width),
                                _ballTexture.Bounds, Color.White, ball.getRotation(),
                                new Vector2(_ballTexture.Width / 2, _ballTexture.Width / 2),
                                ballScale, SpriteEffects.None, 0);

            }
            spriteBatch.End();
        }
    }
}