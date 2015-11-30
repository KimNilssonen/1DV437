using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FireAndExplosions
{
    class Camera
    {
        float scaleX;
        float scaleY;

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

        // Gets an instance of explosion instead of just the texture. This gives me more options and freedom, 
        //   aslong as the variables etc. are public in the class Explosion.
        public Vector2 getVisualCoords(Vector2 logicalCoords, float textureWidth, float textureHeight, float scale)
        {
            // (explosion.frameWidth / 2) and (explosion.frameHeight / 2) makes the explosion to be drawn from it's center, not the upper-left corner.
            float visualX = (logicalCoords.X * scaleX) - (textureWidth / 2) *scale;
            float visualY = (logicalCoords.Y * scaleY) - (textureHeight / 2) *scale;

            return new Vector2(visualX, visualY);
        }


        public float getTextureScale(float textureWidth, float size)
        {
            return scaleX * size / textureWidth;
        }
    }
}
