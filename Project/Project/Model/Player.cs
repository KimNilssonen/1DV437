using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Model
{
    class Player
    {
        // TODO: Fix start position.
        Vector2 position = new Vector2(0.1f, 0.8f);

        public Vector2 acceleration = new Vector2(0.0f, 0.8f);

        public Vector2 speed = Vector2.Zero;
       
        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        // X movement stuff.
        float maxSpeed = 0.25f;
        float deAccelerate = 0.03f;
        float accelerate = 0.01f;

        float size = 0.025f;
        
        private bool hasJumped;
        public bool HasJumped
        {
            get { return hasJumped; }
            set { hasJumped = value; }
        }

        private bool touchingFloor;
        public bool TouchingFloor
        {
            get { return touchingFloor; }
            set { touchingFloor = value; }
        }

        public void UpdatePosition(float gameTime)
        {
            if(hasJumped || !touchingFloor)
            {
                Fall();
            }
            else
            {
                speed.Y = 0;
                acceleration.Y = 0;
            }
            
            speed = gameTime * acceleration + speed;
            position += speed * gameTime;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public void setSpeedLeft()
        {
            speed.X -= accelerate;
            if(speed.X <= -maxSpeed)
            {
                speed.X = -maxSpeed;
            }
        }

        public void setSpeedRight()
        {
            speed.X += accelerate;
            if (speed.X >= maxSpeed)
            {
                speed.X = maxSpeed;
            }
        }

        public void setSpeedZero()
        {
            
            if (speed.X > 0)
            {
                speed.X -= deAccelerate;

                if (speed.X <= 0)
                {
                    speed.X = 0;
                }
            }
            if (speed.X < 0)
            {
                speed.X += deAccelerate;

                if (speed.X >= 0)
                {
                    speed.X = 0;
                }
            }
        }

        public void Jump()
        {

            if (!hasJumped)
            {
                speed.Y = -0.6f;
                hasJumped = true;
            }
        }

        public void Fall()
        {
            acceleration.Y = 1.5f;
        }

        public float getSize()
        {
            return size;
        }
    }
}
