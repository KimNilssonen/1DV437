using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BallApplication.Model
{
    class Ball
    {
        Vector2 position;
        Vector2 speed;
        Random random = new Random();
        float rotation = 0;

        private static float radius = 0.05f;
        // Used before I used random as startspeed.
        //float acceleration = 0.25f;

        public Ball()
        {
            position = new Vector2(0.2f, 0.6f);
            speed = new Vector2((float)random.NextDouble(), (float)random.NextDouble());
        }

        public void UpdatePosition(float gameTime)
        {
            position.X += speed.X * gameTime;
            position.Y += speed.Y * gameTime;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public float getRadius()
        {
            return radius;
        }

        public void setSpeedX()
        {
            speed.X = -speed.X;
        }

        public void setSpeedY()
        {
            speed.Y = -speed.Y;
        }

        public float getRotation()
        {
            return rotation += 0.075f;
        }

    }
}
