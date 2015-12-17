using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Model
{
    class PlayerSimulation
    {

        Player player = new Player();

        enum State
        {
            Still,
            Moving,
        }
        State currentState = State.Still;

        public void Update(float gameTime)
        {
            Console.WriteLine(player.getPosition());

            player.UpdatePosition(gameTime);
        }

        public void UpdateMovement(KeyboardState currentKeyboardState)
        {
            currentState = State.Moving;
            if(currentState == State.Moving)
            {
                if (currentKeyboardState.IsKeyDown(Keys.Up))
                {
                    player.jump();
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
                    currentState = State.Still;
                }
            }
        }

        public Vector2 getPosition()
        {
            return player.getPosition();
        }

        public float getSize()
        {
            return player.getSize();
        }
    }
}
