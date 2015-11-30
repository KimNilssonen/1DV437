using FireAndExplosions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke
{
    class SmokeSystem
    {
        int maxParticles = 100;
        float lifeTimeOfSmoke = 2.5f;
        private float time;
        List<SmokeParticle> smokeList = new List<SmokeParticle>();
        Random rand = new Random();
        Texture2D _smokeTexture;
        Vector2 position;

        public SmokeSystem(Texture2D smokeTexture, Vector2 explosionPos)
        {
            _smokeTexture = smokeTexture;
            position = explosionPos;
        }

        public void addSmokeToList()
        {
            if (smokeList.Count < maxParticles)
            {
                smokeList.Add(new SmokeParticle(rand, _smokeTexture, lifeTimeOfSmoke, position));
            }
        }

        public void Update(float gameTime)
        {
            time += gameTime;

            if (time >= (float)lifeTimeOfSmoke / maxParticles)
            {
                addSmokeToList();
                time = 0;
            }
            
            foreach(SmokeParticle smokeParticle in smokeList)
            {
                smokeParticle.Update(gameTime);
                // Used to repeat the smoke. Don't want this for the explosion.
                //if(smokeParticle.isLifeOver())
                //{
                //    smokeParticle.startParticle();
                //}
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (SmokeParticle smokeParticle in smokeList)
            {
                smokeParticle.Draw(spriteBatch, camera);
            }
        }

    }
}
