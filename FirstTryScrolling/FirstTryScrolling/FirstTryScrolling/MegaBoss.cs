using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    class MegaBoss
    {
        public Texture2D _image;
        public Vector2 _position;
        public Color _color;
        public Rectangle hitbox;
        TimeSpan _delayControl;
        TimeSpan _activeTimer;
        TimeSpan _damageTimer;
        TimeSpan _bulletDelay;
        public bool hit = false;
        public List<Bullet> Bullets;
        public Bullet _bullet;
        public Direction direction;

        public MegaBoss(Texture2D image, Vector2 position, Color color, Bullet bullet)
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0, 1);
            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0, 2);


            _bullet = bullet;
            _image = image;
            _position = position;
            _color = color;
            Bullets = new List<Bullet>();
            hitbox = new Rectangle((int)_position.X, (int)_position.Y, _image.Width, _image.Height);


        }

        public virtual void Update(GameTime gameTime, Player player)
        {
            hitbox = new Rectangle((int)_position.X, (int)_position.Y, _image.Width, _image.Height);
            _delayControl += gameTime.ElapsedGameTime;
            _activeTimer += gameTime.ElapsedGameTime;
            if (_delayControl > _bulletDelay)
            {
                _delayControl = TimeSpan.Zero;
                Vector2 bulletSpawn = new Vector2(_position.X + (_image.Width - _bullet._image.Width) / 2, _position.Y);
                Bullet boom = new Bullet(_bullet._image, bulletSpawn, _bullet._color, _bullet._speed, direction);
                boom.Target(player._position);
                Bullets.Add(boom);
                //where we shoot a bullet
            }
            foreach (Bullet bullet in Bullets)
            {
                bullet.Update();
            }



            if (hit)
            {
                _color = Color.Red;
                _activeTimer = TimeSpan.Zero;

            }
            else if (_damageTimer < _activeTimer)
            {
                _color = Color.White;
            }
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i]._position.X <= 0)
                {
                    Bullets.Remove(Bullets[i]);
                    i--;
                }
                else if (Bullets[i]._position.X >= 900)
                {
                    Bullets.Remove(Bullets[i]);
                    i--;
                }
            }
            hitbox = new Rectangle((int)_position.X, (int)_position.Y, _image.Width, _image.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Game1.pixel, hitbox, Color.Blue);
            spriteBatch.Draw(_image, _position, _color);

        }
    }
}


