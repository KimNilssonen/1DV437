using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke
{
    class SmokeParticle
    {
        float maxSpeed = 0.1f;
        public Vector2 randomDirection;
        Vector2 velocity;
        Vector2 acceleration = new Vector2(0.05f, -0.2f);
        Vector2 startPosition = new Vector2(0.5f, 0.9f);
        Texture2D _smoke;
        Random _random;

        float timeLived;
        float lifePercent;
        float maxTimeToLive = 3.0f;
        float size;
        float minSize = 0.0f;
        float maxSize = 0.3f;
        float fade;
        float rotation;
        float randomRotation;

        public Vector2 position;


        public SmokeParticle(Random rand, Texture2D smoke)
        {

            _smoke = smoke;
            _random = rand;
            randomRotation = 0.02f * ((float)_random.NextDouble() - (float)_random.NextDouble());

            startParticle();
        }

        public void startParticle()
        {
            size = minSize;
            fade = 1;
            timeLived = 0;
            position = startPosition;
            rotation = 0;

            randomDirection = new Vector2((float)_random.NextDouble() - 0.5f, (float)_random.NextDouble() - 0.5f);

            //normalize to get it spherical vector with length 1.0
            randomDirection.Normalize();

            //add random length between 0 to maxSpeed
            randomDirection = randomDirection * ((float)_random.NextDouble() * maxSpeed);
            velocity = randomDirection;
        }

        public bool isLifeOver()
        {
            if(timeLived >= maxTimeToLive)
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
            lifePercent = timeLived / maxTimeToLive;
            fade -= gameTime / maxTimeToLive;
            size = minSize + lifePercent * maxSize;
            rotation += randomRotation;

            velocity = gameTime * acceleration + velocity;
            position = gameTime * velocity + position;

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Color color = new Color(fade, fade, fade, fade);
            spriteBatch.Draw(_smoke, camera.getVisualCoords(position, _smoke), null, 
                                color, rotation, randomDirection, camera.getTextureScale(_smoke, size), SpriteEffects.None, 0);
        }
    }
}
