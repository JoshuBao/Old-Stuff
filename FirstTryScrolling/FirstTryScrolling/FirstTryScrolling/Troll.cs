using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    class Troll
    {
        public Texture2D _image;
        public Vector2 _position;
        public Color _color;
        public Rectangle hitbox;
        bool updown = false;
        public Bullet _bullet;
        public int Health = 30;
        TimeSpan _bulletDelay;
        public List<Bullet> Bullets;
        TimeSpan _delayControl;
        TimeSpan _activeTimer;
        TimeSpan _damageTimer;
        public bool hit = false;
        public Direction Direction;

        public Troll(Texture2D image, Vector2 position, Color color, Bullet bullet)
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0, 0, 100);

            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0, 0 , 300);
            _image = image;
            _position = position;
            _color = color;
            _bullet = bullet;
            Bullets = new List<Bullet>();
            hitbox = new Rectangle((int)_position.X,(int) _position.Y, _image.Width, _image.Height);

        }
        public virtual void Update(GameTime gameTime, List<Bullet> Bullet)
        {
            _activeTimer += gameTime.ElapsedGameTime;
            if (_delayControl > _bulletDelay)
            {
                _delayControl = TimeSpan.Zero;
                Vector2 bulletSpawn = new Vector2( _position.X + (_image.Width - _bullet._image.Width) / 2, _position.Y);
                Bullets.Add(new Bullet(_bullet._image, bulletSpawn, _bullet._color, _bullet._speed, Direction));
                //where we shoot a bullet
            }
            foreach (var B in Bullets)
            {
                B.Update();
            }
            if (updown == false)
            {
                _position.Y -= 10;
            }
            if (updown == true)
            {
                _position.Y += 10;
            }
            if (_position.Y <= 0)
            {
                updown = true;
            }
            if (_position.Y >= 400)
            {
                updown = false;
            }
            _delayControl += gameTime.ElapsedGameTime;
            if (hit)
            {
                _color = Color.Red;
                _activeTimer = TimeSpan.Zero;
            }
            else if (_damageTimer < _activeTimer)
            {
                _color = Color.White;
            }

            
            hitbox = new Rectangle((int)_position.X, (int)_position.Y, _image.Width, _image.Height);
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont s)
        {
            //spriteBatch.Draw(Game1.pixel, hitbox, Color.Blue);
            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i].Draw(spriteBatch);
            }
            spriteBatch.Draw(_image, _position, _color);
            spriteBatch.DrawString(s, ("Health:" + Health), new Vector2(_position.X + (_image.Width /4) ,_position.Y - 25), Color.Black);
            
        }
    }
}
