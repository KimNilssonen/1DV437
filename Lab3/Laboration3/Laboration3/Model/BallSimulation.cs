using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Laboration3.Model
{
    class BallSimulation
    {
        public List<Ball> listOfBalls;
        int maxNumberOfBalls = 20;
        //Ball ball;

        public BallSimulation()
        {
            listOfBalls = new List<Ball>(maxNumberOfBalls);
            for (int i = 0; i < maxNumberOfBalls; i++)
            {
                listOfBalls.Add(new Ball(i));
            }
            
           // ball = new Ball();
            
        }

        //public Vector2 getBallPosition()
        //{
        //    return ball.getPosition();
        //}

        //public float getBallRadius()
        //{
        //    return ball.getRadius();
        //}

        //public float getRotation()
        //{
        //    return ball.getRotation();
        //}

        public void Update(float gameTime)
        {
            foreach (Ball ball in listOfBalls)
            {
                ball.UpdatePosition(gameTime);

                if (ball.getPosition().X + ball.getRadius() >= 1 || ball.getPosition().X - ball.getRadius() <= 0)
                {
                    ball.setSpeedX();
                }

                if (ball.getPosition().Y + ball.getRadius() >= 1 || ball.getPosition().Y - ball.getRadius() <= 0)
                {
                    ball.setSpeedY();
                }
            }
        }
    }
}
