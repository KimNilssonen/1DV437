using Laboration3.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration3.View
{
    class StartView
    {

        List<ExplosionView> explosionViews;
        MouseCrosshairView crosshairView;
        BallSimulation _ballSimulation;

        SpriteBatch _spriteBatch;
        Texture2D _smokeTexture;
        Texture2D _splitterTexture;
        Texture2D _explosionTexture;
        Texture2D _shockwaveTexture;
        Camera _camera;
        SoundEffect _fireSound;

        public StartView(Texture2D smokeTexture, Texture2D splitterTexture, Texture2D explosionTexture,
                                Texture2D shockwaveTexture, Camera camera, SpriteBatch spriteBatch,
                                SoundEffect fireSound, BallSimulation ballSimulation)
        {
            explosionViews = new List<ExplosionView>();
            crosshairView = new MouseCrosshairView();
            _ballSimulation = ballSimulation;


            _smokeTexture = smokeTexture;
            _splitterTexture = splitterTexture;
            _explosionTexture = explosionTexture;
            _shockwaveTexture = shockwaveTexture;
            _camera = camera;
            _spriteBatch = spriteBatch;
            _fireSound = fireSound;
        }

        public void createExplosion(float mousePosX, float mousePosY, float gameTime)
        {
            explosionViews.Add(new ExplosionView(_smokeTexture, _splitterTexture, _explosionTexture,
                                                _shockwaveTexture, _camera, _spriteBatch, _fireSound));

            float crosshairSize = crosshairView.getCrossHairSize();
            Vector2 mousePos = _camera.getLogicalCoords(new Vector2(mousePosX, mousePosY));

            _ballSimulation.setBallToDead(mousePos, crosshairSize, gameTime);
        }
        public void Update(float gameTime)
        {
            foreach (ExplosionView explosion in explosionViews)
            {
                explosion.Update(gameTime);
            }
        }

        public void Draw(float gameTime)
        {
            foreach(ExplosionView explosion in explosionViews)
            {
                explosion.Draw(gameTime);
            }
        }
    }
}
