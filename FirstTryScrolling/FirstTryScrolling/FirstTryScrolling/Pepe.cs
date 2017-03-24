using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstTryScrolling
{
    class Pepe : Enemies
    {

        public Pepe(Texture2D image, Vector2 position, Color color, Bullet bullet, Direction direction)
            : base(image,position,color,bullet,direction)
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0, 1);

            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0, 2);
            _bullet = bullet;
            _Health = 40;

        }

        public virtual void Update(GameTime gameTime)
        {
            _delayControl += gameTime.ElapsedGameTime;
            _activeTimer += gameTime.ElapsedGameTime;
            if (_delayControl > _bulletDelay)
            {
                _delayControl = TimeSpan.Zero;
                Vector2 bulletSpawn = new Vector2(Position.X + (Image.Width - _bullet.Image.Width) / 2, Position.Y);
                _Bullets.Add(new Bullet(_bullet.Image, bulletSpawn, _bullet.Color, _bullet._speed,Direction.Right));
                //where we shoot a bullet
            }
            foreach (Bullet bullet in _Bullets)
            {
                bullet.Update();
            }



            if (hit)
            {
                Color = Color.Red;
                _activeTimer = TimeSpan.Zero;

            }


            else if (_damageTimer < _activeTimer)
            {
                Color = Color.White;
            }
            for (int i = 0; i < _Bullets.Count; i++)
            {
                if (_Bullets[i].Position.X <= 0)
                {
                    _Bullets.Remove(_Bullets[i]);
                    i--;
                }
                else if (_Bullets[i].Position.X >= 900)
                {
                    _Bullets.Remove(_Bullets[i]);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont s)
        {
            base.Draw(spriteBatch);

            for (int i = 0; i < _Bullets.Count; i++)
            {
                _Bullets[i].Draw(spriteBatch);
            }
            spriteBatch.DrawString(s, ("Health:" + _Health), new Vector2(Position.X + (Image.Width / 4), Position.Y - 25), Color.Black);
        }
    }
}


