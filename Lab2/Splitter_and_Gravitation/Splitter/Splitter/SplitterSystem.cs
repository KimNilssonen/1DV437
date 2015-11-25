using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Splitter
{
    class SplitterSystem
    {
        int maxParticles = 100;
        public SplitterParticle[] particleArray;
        Random rand = new Random();

        public SplitterSystem()
        {
            particleArray = new SplitterParticle[maxParticles];

            for (int i = 0; i < particleArray.Length; i++)
            {
                particleArray[i] = new SplitterParticle(rand);
            }
        }

    }
}
