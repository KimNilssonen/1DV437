using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration3.View
{
    class Explosion
    {
        private Texture2D _explosionTexture;
        private Camera _camera;
        private Vector2 _mousePosition;

        // Changing numberOfFrames makes the explosion smoother(higher value) or less smooth(lower value).
        //   This also depends on the maxTime.
        int numberOfFrames = 24;
        int numFramesX = 4;
        int numFramesY = 8;

        // Public so that I can call these in camera.
        public int frameWidth;
        public int frameHeight;

        float size = 0.25f;
        float maxTime = 0.5f;
        float timeElapsed;



        public Explosion(Texture2D explosionTexture, Camera camera, Vector2 mousePosition)
        {
            _explosionTexture = explosionTexture;
            _camera = camera;
            _mousePosition = mousePosition;
            timeElapsed = 0;

            frameWidth = _explosionTexture.Width / numFramesX;
            frameHeight = _explosionTexture.Height / numFramesY;

        }

        public void Draw(float elapsedGameTime, SpriteBatch spriteBatch)
        {
            timeElapsed += elapsedGameTime;
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            int frameX;
            int frameY;

            frameX = frame % numFramesX;
            frameY = frame / numFramesX;

            float scale = _camera.getTextureScale(frameWidth, size);
            spriteBatch.Draw(_explosionTexture, _camera.getVisualCoords(_mousePosition, frameWidth, frameHeight, scale),
                                new Rectangle(frameWidth * frameX, frameHeight * frameY, frameWidth, frameHeight), 
                                Color.White, 0, Vector2.Zero, 
                                scale, SpriteEffects.None, 0.5f);
        }
    }
}
