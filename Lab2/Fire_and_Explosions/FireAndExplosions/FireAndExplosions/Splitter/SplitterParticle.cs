using FireAndExplosions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Splitter
{
    class SplitterParticle
    {
        float maxSpeed = 0.35f;
        float particleSize = 0.015f;
        public Vector2 randomDirection;
        Vector2 velocity;
        Vector2 acceleration = new Vector2(0.0f, 0.5f);
        Vector2 position;
        Texture2D _splitterTexture;


        public SplitterParticle(Random rand, Texture2D splitterTexture, Vector2 explosionPos) 
        {
            _splitterTexture = splitterTexture;
            position = explosionPos;

            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            //normalize to get it spherical vector with length 1.0
            randomDirection.Normalize();
            //add random length between 0 to maxSpeed
            randomDirection = randomDirection * ((float)rand.NextDouble() * maxSpeed);
            velocity = randomDirection;
        }

        public void Update(float gameTime)
        {
            velocity = gameTime * acceleration + velocity;
            position = gameTime * velocity + position;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            float scale = camera.getTextureScale(_splitterTexture.Width, particleSize);
            spriteBatch.Draw(_splitterTexture, camera.getVisualCoords(position, _splitterTexture.Width, _splitterTexture.Height, scale), null, Color.White, 0, randomDirection, scale, SpriteEffects.None, 0.5f);
        }
    }
}
