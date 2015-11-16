using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BallApplication.Model
{
    class BallSimulation
    {
        Ball ball;

        public BallSimulation()
        {
            ball = new Ball();
        }

        public Vector2 getBallPosition()
        {
            return ball.getPosition();
        }

        public float getBallRadius()
        {
            return ball.getRadius();
        }

        public void Update(float gameTime)
        {
            // TODO: Add collision and other update stuff.
            ball.UpdatePosition(gameTime);

            if (getBallPosition().X + getBallRadius() >= 1 || getBallPosition().X - getBallRadius() <= 0)
            {
                ball.setSpeedX();
            }

            if (getBallPosition().Y + getBallRadius() >= 1 || getBallPosition().Y - getBallRadius() <= 0)
            {
                ball.setSpeedY();
            }
        }
    }
}
