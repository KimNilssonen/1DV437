using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Laboration3.View
{
    class ExplosionView
    {
        SpriteBatch _spriteBatch;
        Texture2D _smokeTexture;
        Texture2D _splitterTexture;
        Texture2D _explosionTexture;
        Texture2D _shockwaveTexture;
        Camera _camera;
        SoundEffect _fireSound;

        Explosion explosion;
        SmokeSystem smokeSystem;
        SplitterSystem splitterSystem;

        MouseState mouseState; 
        Vector2 mousePosition;
        //Vector2 explosionPos = new Vector2(0.5f, 0.5f);

        

        public ExplosionView(Texture2D smokeTexture, Texture2D splitterTexture, Texture2D explosionTexture, 
                                Texture2D shockwaveTexture, Camera camera, SpriteBatch spriteBatch, 
                                SoundEffect fireSound)
        {
            _smokeTexture = smokeTexture;
            _splitterTexture = splitterTexture;
            _explosionTexture = explosionTexture;
            _shockwaveTexture = shockwaveTexture;
            _camera = camera;
            _spriteBatch = spriteBatch;
            _fireSound = fireSound;

            createExplosion();
        }



        public void createExplosion()
        {
            mouseState = Mouse.GetState();
            mousePosition = _camera.getLogicalCoords(new Vector2(mouseState.X, mouseState.Y));

            explosion = new Explosion(_explosionTexture, _camera, mousePosition);
            smokeSystem = new SmokeSystem(_smokeTexture, mousePosition);
            splitterSystem = new SplitterSystem(_splitterTexture, mousePosition);
            _fireSound.Play();
        }

        public void Update(float elapsedTime)
        {
            
            if (explosion != null)
            {
                smokeSystem.Update(elapsedTime);
                splitterSystem.Update(elapsedTime);
            }
        }

        public void Draw(float elapsedTime)
        {
            if (explosion != null)
            {
                // SpriteSortMode is used for layers in the draw. This makes it possible to put the particles behind the explosion, which looks better imo.
                _spriteBatch.Begin(SpriteSortMode.FrontToBack);

                explosion.Draw(elapsedTime, _spriteBatch);
                smokeSystem.Draw(_spriteBatch, _camera);
                splitterSystem.Draw(_spriteBatch, _camera);

                _spriteBatch.End();
            }
        }
    }
}