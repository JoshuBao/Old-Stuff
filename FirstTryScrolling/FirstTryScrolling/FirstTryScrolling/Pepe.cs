using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstTryScrolling
{
    class Pepe : Sprite 
    {
        public Bullet _bullet;
        public int Health = 50;
        TimeSpan _bulletDelay;
        public List<Bullet> Bullets;
        TimeSpan _delayControl;
        TimeSpan _activeTimer;
        TimeSpan _damageTimer;
        public bool hit = false;
        public Direction direction;

        public Pepe(Texture2D image, Vector2 position, Color color, Bullet bullet)
            : base(image, position, color)
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0, 1);

            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0, 2);
            _bullet = bullet;
            Bullets = new List<Bullet>();

        }

        public virtual void Update(GameTime gameTime)
        {
            _delayControl += gameTime.ElapsedGameTime;
            _activeTimer += gameTime.ElapsedGameTime;
            if (_delayControl > _bulletDelay)
            {
                _delayControl = TimeSpan.Zero;
                Vector2 bulletSpawn = new Vector2(Position.X + (Image.Width - _bullet.Image.Width) / 2, Position.Y);
                Bullets.Add(new Bullet(_bullet.Image, bulletSpawn, _bullet.Color, _bullet._speed, direction));
                //where we shoot a bullet
            }
            foreach (Bullet bullet in Bullets)
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
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i].Position.X <= 0)
                {
                    Bullets.Remove(Bullets[i]);
                    i--;
                }
                else if (Bullets[i].Position.X >= 900)
                {
                    Bullets.Remove(Bullets[i]);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont s)
        {
            base.Draw(spriteBatch);

            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i].Draw(spriteBatch);
            }
            spriteBatch.DrawString(s, ("Health:" + Health), new Vector2(Position.X + (Image.Width / 4), Position.Y - 25), Color.Black);
        }
    }
}


