using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Laboration3.View;

namespace Laboration3.Model
{
    class BallSimulation
    {
        public List<Ball> listOfBalls;
        int maxNumberOfBalls = 10;
        //Ball ball; Old code used for 1 ball.

        public BallSimulation()
        {
            listOfBalls = new List<Ball>(maxNumberOfBalls);
            for (int i = 0; i < maxNumberOfBalls; i++)
            {
                listOfBalls.Add(new Ball(i));
            }

            // ball = new Ball(); Old code used for 1 ball.
            
        }

        public void setBallToDead(Vector2 mousePos, float crosshairSize, float gameTime)
        {

            foreach(Ball ball in listOfBalls)
            {
                //ball.UpdatePosition(gameTime);

                if ((ball.getPosition().X + ball.getRadius()) >= (mousePos.X - crosshairSize / 2) &&
                    (ball.getPosition().X + ball.getRadius()) <= (mousePos.X + crosshairSize / 2) &&
                    (ball.getPosition().Y + ball.getRadius()) >= (mousePos.Y - crosshairSize / 2) &&
                    (ball.getPosition().Y + ball.getRadius()) <= (mousePos.Y + crosshairSize / 2))
                {
                    setBallToDead(ball);
                }
            }
        }

        public void setBallToDead(Ball ball)
        {
            if (ball.Alive)
            {
                ball.Alive = false;
            }
            
            
        }

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

                if (!ball.Alive)
                {
                    ball.setRotationToDead();
                    ball.setBallSpeedToDead();
                }
            }
        }

        // Old code used for 1 ball.
        //public Vector2 getBallPosition()  
        //{
        //    return ball.getPosition(); 
        //}

        //public float getBallRadius() Old code used for 1 ball.
        //{
        //    return ball.getRadius();
        //}

        //public float getRotation() Old code used for 1 ball.
        //{
        //    return ball.getRotation();
        //}
    }
}
