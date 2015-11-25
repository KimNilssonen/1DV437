using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Splitter
{
    class Camera
    {
        float scaleX;
        float scaleY;
        private float particleSizeOfField = 0.015f;
        float scale;

        public Camera(Viewport viewPort)
        {
            scaleX = viewPort.Width;
            scaleY = viewPort.Height;

            if (scaleX < scaleY)
            {
                scaleY = scaleX;
            }
            else if (scaleY < scaleX)
            {
                scaleX = scaleY;
            }
        }

        public Vector2 getVisualCoords(Vector2 logicalCoords, Texture2D texture)
        {
            float visualX = (logicalCoords.X * scaleX) - (texture.Width / 2) * scale;
            float visualY = (logicalCoords.Y * scaleY) - (texture.Height / 2) * scale;

            return new Vector2(visualX, visualY);
        }

        public float getTextureScale(float textureWidth)
        {
            scale = scaleX * particleSizeOfField / textureWidth;
            return scale;
        }
    }
}
