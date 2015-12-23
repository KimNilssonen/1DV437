using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Model
{
    class PlayerSimulation
    {

        Player player = new Player();

        public void Update(float gameTime)
        {
            player.UpdatePosition(gameTime);
           
        }

        public void UpdateMovement(KeyboardState currentKeyboardState)
        {
            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                player.Jump();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                player.setSpeedLeft();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                player.setSpeedRight();
            }
            if(currentKeyboardState.IsKeyUp(Keys.Left) &&
                currentKeyboardState.IsKeyUp(Keys.Right) &&
                currentKeyboardState.IsKeyUp(Keys.Up))
            {
                player.setSpeedZero();
            }
            
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset, Camera camera)
        {
            Vector2 position = camera.getVisualCoords(player.getPosition());
            Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            if (rectangle.TouchTop(newRectangle))
            {
                position.Y = newRectangle.Y - rectangle.Height;
                player.TouchingFloor = true;
                player.HasJumped = false;
            }

            if (rectangle.TouchLeft(newRectangle))
            {
                position.X = newRectangle.X - rectangle.Width;
                player.speed.X = -0.05f;
                
            }
            if (rectangle.TouchRight(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width;
                player.speed.X = 0.05f;
            }

            if (rectangle.TouchBottom(newRectangle))
            {
                player.speed.Y = 0.5f;
            }

            if (position.X < 0)
            {
                position.X = 0;
                player.speed.X = 0.05f;
            }

            if (position.X > xOffset - rectangle.Width)
            {
                position.X = xOffset - rectangle.Width;
                player.speed.X = -0.05f;
            }

            if (position.Y < 0)
            {
                player.speed.Y = 1f;
            }

            if (position.Y > yOffset - rectangle.Height)
            {
                
                position.Y = yOffset - rectangle.Height;
            }

            // If player leaves top of a rectangle.
            if(position.X > newRectangle.X + newRectangle.Width)
            {
                player.TouchingFloor = false;
                player.HasJumped = true; // Maybe should be called, CanJump...
            }
        }

        public Vector2 getPosition()
        {
            return player.getPosition();
        }

        public Rectangle getRectangle()
        {
            return player.Rectangle;
        }

        public float getSize()
        {
            return player.getSize();
        }
    }
}
