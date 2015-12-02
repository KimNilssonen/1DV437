using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Laboration3.Model
{
    class Ball
    {
        Vector2 position;
        Vector2 startPos = new Vector2(0.5f, 0.5f);
        Vector2 speed;
        float rotation = 0;
        Random random;

        private static float radius = 0.025f;
        // Used before I used random as startspeed.
        //float acceleration = 0.25f;

        public Ball(int seed)
        {
            random = new Random(seed);
            Console.WriteLine(seed);
            position = new Vector2(startPos.X, startPos.Y);
            speed = new Vector2((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
            speed.Normalize();
        }

        public void UpdatePosition(float gameTime)
        {
            position.X += speed.X * gameTime;
            position.Y += speed.Y * gameTime;
        }

        public Vector2 getPosition()
        {
            //Console.WriteLine(position.X + " " + position.Y);
            return this.position;
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