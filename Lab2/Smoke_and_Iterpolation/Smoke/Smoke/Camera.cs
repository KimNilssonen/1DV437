using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Smoke
{
    class Camera
    {
        float scaleX;
        float scaleY;
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

        public float getTextureScale(Texture2D smokeTexture, float size)
        {
            scale = scaleX * size / smokeTexture.Width;
            return scale;
        }
    }
}
