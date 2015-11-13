using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace Chessboard
{
    class Camera
    {
        private int tileSize = 64;
        private int borderSize = 64;

        private float visualX;
        private float visualY;

        public float scale = 1;

        public Vector2 getVisualCoordinates(int xCoordinate, int yCoordinate)
        {
            visualX = (borderSize + xCoordinate * tileSize);
            visualY = (borderSize + yCoordinate * tileSize);

            return new Vector2(visualX, visualY);
        }

        public Vector2 getRotatedBoard(int xCoordinate, int yCoordinate)
        {
            visualX = (tileSize * 8 + borderSize - tileSize) - (xCoordinate * tileSize);
            visualY = (tileSize * 8 + borderSize - tileSize) - (yCoordinate * tileSize);

            return new Vector2(visualX, visualY);
        }

        public void setScale(GraphicsDeviceManager graphics)
        {

            // Thinking of trying to use a Vector2 for the scaling...
            //Vector2 windowCenterPos = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            float scaleX = (float)graphics.GraphicsDevice.Viewport.Width / (tileSize * 8 + borderSize * 2);
            float scaleY = (float)graphics.GraphicsDevice.Viewport.Height / (tileSize * 8 + borderSize * 2);

            if (scaleX < scaleY)
            {
                scale = scaleX;
            }
            else
            {
                scale = scaleY;
            }
            borderSize = Convert.ToInt32(Math.Round(scale * borderSize));
            tileSize = Convert.ToInt32(Math.Round(scale * tileSize));
        }
    }
}