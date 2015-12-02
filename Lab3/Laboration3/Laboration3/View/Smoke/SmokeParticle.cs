using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration3.View
{
    class SmokeParticle
    {

        public Vector2 randomDirection;
        Vector2 velocity;
        Vector2 acceleration = new Vector2(0.0f, -0.2f);
        Vector2 startPosition;

        Texture2D _smokeTexture;
        Random _random;
        float _maxTimeToLive;

        float maxSpeed = 0.1f;
        float timeLived;
        float lifePercent;
        float size;
        float minSize = 0.0f;
        float maxSize = 0.3f;
        float fade;
        float rotation;
        float randomRotation;

        public Vector2 position;


        public SmokeParticle(Random rand, Texture2D smokeTexture, float lifeTimeOfSmoke, Vector2 explosionPos)
        {

            _smokeTexture = smokeTexture;
            _random = rand;
            _maxTimeToLive = lifeTimeOfSmoke;
            startPosition = explosionPos;

            randomRotation = 0.02f * ((float)_random.NextDouble() - (float)_random.NextDouble());

            startParticle();
        }

        public void startParticle()
        {
            size = minSize;
            fade = 1;
            timeLived = 0;
            rotation = 0;
            position = startPosition;

            randomDirection = new Vector2((float)_random.NextDouble() - 0.5f, (float)_random.NextDouble() - 0.5f);

            //normalize to get it spherical vector with length 1.0
            randomDirection.Normalize();

            //add random length between 0 to maxSpeed
            randomDirection = randomDirection * ((float)_random.NextDouble() * maxSpeed);
            velocity = randomDirection;
        }

        public bool isLifeOver()
        {
            if (timeLived >= _maxTimeToLive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(float gameTime)
        {
            timeLived += gameTime;
            lifePercent = timeLived / _maxTimeToLive;
            fade -= gameTime / _maxTimeToLive;
            size = minSize + lifePercent * maxSize;
            rotation += randomRotation;

            velocity = gameTime * acceleration + velocity;
            position = gameTime * velocity + position;

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Color color = new Color(fade, fade, fade, fade);
            float scale = camera.getTextureScale(_smokeTexture.Width, size);
            spriteBatch.Draw(_smokeTexture, camera.getVisualCoords(position, _smokeTexture.Width, _smokeTexture.Height, scale), null,
                                color, rotation, randomDirection, scale, SpriteEffects.None, 0.1f);
        }
    }
}
