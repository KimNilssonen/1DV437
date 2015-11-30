using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smoke;
using Splitter;
using Microsoft.Xna.Framework;

namespace FireAndExplosions
{
    class ApplicationView
    {
        SpriteBatch _spriteBatch;
        Texture2D _smokeTexture;
        Texture2D _splitterTexture;
        Texture2D _explosionTexture;
        Texture2D _shockwaveTexture;
        Camera _camera;

        Explosion explosion;
        SmokeSystem smokeSystem;
        SplitterSystem splitterSystem;

        Vector2 explosionPos = new Vector2(0.5f, 0.5f);


        public ApplicationView(Texture2D smokeTexture, Texture2D splitterTexture, Texture2D explosionTexture, Texture2D shockwaveTexture, Camera camera, SpriteBatch spriteBatch)
        {
            _smokeTexture = smokeTexture;
            _splitterTexture = splitterTexture;
            _explosionTexture = explosionTexture;
            _shockwaveTexture = shockwaveTexture;
            _camera = camera;
            _spriteBatch = spriteBatch;
            explosion = new Explosion(_explosionTexture, _camera);
            smokeSystem = new SmokeSystem(_smokeTexture, explosionPos);
            splitterSystem = new SplitterSystem(_splitterTexture, explosionPos);
        }

        public void createExplosion()
        {
            explosion = new Explosion(_explosionTexture, _camera);
            smokeSystem = new SmokeSystem(_smokeTexture, explosionPos);
            splitterSystem = new SplitterSystem(_splitterTexture, explosionPos);
        }

        public void Update(float elapsedTime)
        {
            smokeSystem.Update(elapsedTime);
            splitterSystem.Update(elapsedTime);
        }

        public void Draw(float elapsedTime)
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
