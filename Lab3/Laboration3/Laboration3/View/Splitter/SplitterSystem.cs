using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration3.View
{
    class SplitterSystem
    {
        Texture2D _splitterTexture;

        int maxParticles = 100;
        public SplitterParticle[] particleArray;
        Random rand = new Random();


        public SplitterSystem(Texture2D splitterTexture, Vector2 explosionPos)
        {
            _splitterTexture = splitterTexture;
            particleArray = new SplitterParticle[maxParticles];

            for (int i = 0; i < particleArray.Length; i++)
            {
                particleArray[i] = new SplitterParticle(rand, _splitterTexture, explosionPos);
            }
        }

        public void Update(float gameTime)
        {
            foreach (SplitterParticle splitterParticle in particleArray)
            {
                splitterParticle.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (SplitterParticle splitterParticle in particleArray)
            {
                splitterParticle.Draw(spriteBatch, camera);
            }
        }

    }
}