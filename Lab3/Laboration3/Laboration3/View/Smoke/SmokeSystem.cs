using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration3.View
{
    class SmokeSystem
    {
        int maxParticles = 50;
        float lifeTimeOfSmoke = 2.5f;
        // private float time;
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
            // Don't use this if-statement because I want the smoke to be more of a "poff" than a pillar.
            // time += gameTime;
            // if (time >= (float)lifeTimeOfSmoke / maxParticles)
            //  {
            addSmokeToList();
            //      time = 0;
            //  }

            foreach (SmokeParticle smokeParticle in smokeList)
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