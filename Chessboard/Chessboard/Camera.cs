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
        private int visualX;
        private int visualY;

        public Vector2 getVisualCoordinates(int xCoordinate, int yCoordinate)
        {
            visualX = borderSize + xCoordinate * tileSize;
            visualY = borderSize + yCoordinate * tileSize;

            return new Vector2(visualX, visualY);
        }

        public Vector2 getRotatedBoard(int xCoordinate, int yCoordinate)
        {
            visualX = (tileSize * 8 + borderSize - tileSize) - (xCoordinate * tileSize);
            visualY = (tileSize * 8 + borderSize - tileSize) - (yCoordinate * tileSize);

            return new Vector2(visualX, visualY);
        }
    }
}