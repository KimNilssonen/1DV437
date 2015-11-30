using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Explosion
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
        public Vector2 getVisualCoords(Vector2 logicalCoords, Explosion explosion)
        {
            // (explosion.frameWidth / 2) and (explosion.frameHeight / 2) makes the explosion to be drawn from it's center, not the upper-left corner.
            float visualX = (logicalCoords.X * scaleX) - (explosion.frameWidth / 2);
            float visualY = (logicalCoords.Y * scaleY) - (explosion.frameHeight / 2);

            return new Vector2(visualX, visualY);
        }
    }
}
