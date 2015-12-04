using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration3.View
{
    class SplitterParticle
    {
        float maxSpeed = 0.35f;
        float particleSize = 0.01f;

        float maxTimeToLive = 1f;
        float fade;

        public Vector2 randomDirection;
        Vector2 velocity;
        Vector2 acceleration = new Vector2(0.0f, 0.5f);
        Vector2 position;
        Texture2D _splitterTexture;


        public SplitterParticle(Random rand, Texture2D splitterTexture, Vector2 explosionPos)
        {
            // explosionPos is the same as mousePos.
            _splitterTexture = splitterTexture;
            position = explosionPos;

            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            //normalize to get it spherical vector with length 1.0
            randomDirection.Normalize();
            //add random length between 0 to maxSpeed
            randomDirection = randomDirection * ((float)rand.NextDouble() * maxSpeed);
            velocity = randomDirection;

            fade = 1;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public void Update(float gameTime)
        {
            
            if (position.Y > 1)
            {
                fade -= gameTime / maxTimeToLive;

                velocity.Y = -velocity.Y * 0.1f;
                velocity.X = velocity.X * 0.85f;
            }
            if (position.X >= 1 || position.X <= 0)
            {
                velocity.X = -velocity.X;
            }

            velocity = gameTime * acceleration + velocity;
            position = gameTime * velocity + position;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            float scale = camera.getTextureScale(_splitterTexture.Width, particleSize);
            Color color = new Color(fade, fade, fade, fade);
            spriteBatch.Draw(_splitterTexture, 
                            camera.getVisualCoords(position, _splitterTexture.Width, _splitterTexture.Height, scale), 
                            null, color, 0, randomDirection, scale, SpriteEffects.None, 0.4f);
        }
    }
}