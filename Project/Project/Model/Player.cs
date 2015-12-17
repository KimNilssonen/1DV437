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
        Vector2 position = new Vector2(0.1f, 0.9f);
        Vector2 acceleration = new Vector2(0.0f, 0.8f);
        Vector2 speed = Vector2.Zero;
        float maxSpeed = 0.5f;
        float deAccelerate = 0.03f;
        float accelerate = 0.02f;

        float size = 0.025f;

        public void UpdatePosition(float gameTime)
        {
            if (position.Y >= 0.9f && acceleration.Y >= 0.8f)
            {
                acceleration.Y = 0;
                speed.Y = 0;
            }
            else if(position.Y < 0.9f && acceleration.Y < 0.8f)
            {
                acceleration.Y = 1.0f;
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

        public void jump()
        {
            // TODO: Implement jump function.
            if (speed.Y == 0)
            {
                speed.Y = -0.3f;
            }

        }

        public float getSize()
        {
            return size;
        }
    }
}
