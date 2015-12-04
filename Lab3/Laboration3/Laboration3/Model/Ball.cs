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
        Vector2 startPos ;
        Vector2 speed;
        float maxSpeed = 0.5f;
        float minSpeed = 0.1f;
        float rotation = 0.0f;
        Random random;
        bool alive = true;

        private static float radius = 0.020f;
        // Used before I used random as startspeed.
        //float acceleration = 0.25f;

        public Ball(int seed)
        {
            random = new Random(seed);
            Console.WriteLine(seed);
            startPos = new Vector2(0.5f, 0.5f);
            position = new Vector2(startPos.X, startPos.Y);
            speed = new Vector2((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
            speed.Normalize();
            speed = speed * ((float)random.NextDouble() * maxSpeed + minSpeed);
            
        }

        public void UpdatePosition(float gameTime)
        {
           position += speed * gameTime;
           
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

        public void setBallSpeedToDead()
        {
            speed.X = 0;
            speed.Y = 0;
        }

        public void setRotationToDead()
        {
            rotation = 0;
        }
        public float getRotation()
        {
            return rotation += 0.25f;
        }

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

    }
}