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

        //enum State
        //{
        //    Still,
        //    Moving,
        //}
        //State currentState = State.Still;

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

        // TODO: Fix collision error!!!!!!
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset, Camera camera)
        {
            Vector2 position = camera.getVisualCoords(player.getPosition());
            Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            //Console.WriteLine("\n\nRectangle: " + rectangle + "\n New rectangle: " + newRectangle + "\n  Position: " + position);
            if (rectangle.TouchTop(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;

                player.HasJumped = false;
                player.TouchingFloor = true;

                Console.WriteLine(rectangle.Size);
                Console.WriteLine("HEJ Top");

                if((rectangle.X + rectangle.Width/2) > (newRectangle.X + newRectangle.Width))
                {
                    player.TouchingFloor = false;
                }
            }

            else if (rectangle.TouchLeft(newRectangle))
            {
                Console.WriteLine("HEJ Left");
                position.X = newRectangle.X - rectangle.Width - 4;
                player.speed.X = -0.1f;
                
            }
            else if (rectangle.TouchRight(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width + 4;
                player.speed.X = 0.1f;
            }

            else if (rectangle.TouchBottom(newRectangle))
            {
                player.speed.Y = 1;
            }

            if (position.X < 0)
            {
                position.X = 0;
                player.speed.X = 0.1f;
            }

            if (position.X > xOffset - rectangle.Width)
            {
                position.X = xOffset - rectangle.Width;
                player.speed.X = -0.1f;
            }

            if (position.Y < 0)
            {
                player.speed.Y = 1f;
            }

            if (position.Y > yOffset - rectangle.Height)
            {
                position.Y = yOffset - rectangle.Height;
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
