using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BallApplication.View
{
    class Camera
    {
        float scaleX;
        float scaleY;
        int borderSize = 25;

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

            scaleX = scaleX - borderSize * 2;
            scaleY = scaleY - borderSize * 2;
        }

        public Rectangle getGameArea()
        {
            return new Rectangle(borderSize, borderSize, (int)scaleX, (int)scaleY);
        }

        public Vector2 getVisualCoords(Vector2 logicalCoords)
        {
            int visualX = (int)(logicalCoords.X * scaleX) + borderSize;
            int visualY = (int)(logicalCoords.Y * scaleY) + borderSize;

            return new Vector2(visualX, visualY);
        }

        public float getTextureScale(float radius, int ballWidth)
        {
            return (radius * 2) * scaleX / ballWidth;
        }
    }
}
