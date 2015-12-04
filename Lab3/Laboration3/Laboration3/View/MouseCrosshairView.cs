using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration3.View
{
    class MouseCrosshairView
    {
        //Camera _camera;
        MouseState _mouseState;
        Vector2 mousePosition;

        float size = 0.2f;

        public void Update(MouseState mouseState)
        {
            _mouseState = mouseState;
            _mouseState = Mouse.GetState();
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D _circleAimTexture, Camera _camera)
        {
            float aimScale = _camera.getTextureScale(_circleAimTexture.Width, size);
            mousePosition = _camera.getLogicalCoords(new Vector2(_mouseState.X, _mouseState.Y));

            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            spriteBatch.Draw(_circleAimTexture, _camera.getVisualCoords(mousePosition, _circleAimTexture.Width, _circleAimTexture.Height, aimScale),
                        _circleAimTexture.Bounds, Color.White, 0, 
                        new Vector2(aimScale, aimScale), 
                        aimScale, SpriteEffects.None, 0.6f);
            spriteBatch.End();
        }

        public Vector2 getMousePos()
        {
            return mousePosition;
        }
        public float getCrossHairSize()
        {
            return size;
        }
    }
}
