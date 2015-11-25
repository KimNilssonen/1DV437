using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke
{
    class SmokeSystem
    {
        int maxParticles = 200;
        float lifeTimeOfSmoke = 3.5f;
        private float time;
        List<SmokeParticle> smokeList = new List<SmokeParticle>();
        Random rand = new Random();
        Texture2D _smoke;

        public SmokeSystem(Texture2D smoke)
        {
            _smoke = smoke;
        }

        public void addSmokeToList()
        {
            if (smokeList.Count < maxParticles)
            {
                smokeList.Add(new SmokeParticle(rand, _smoke));
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
                if(smokeParticle.isLifeOver())
                {
                    smokeParticle.startParticle();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Begin();
            foreach(SmokeParticle smokeParticle in smokeList)
            {
                smokeParticle.Draw(spriteBatch, camera);
            }
            spriteBatch.End();
        }

    }
}
