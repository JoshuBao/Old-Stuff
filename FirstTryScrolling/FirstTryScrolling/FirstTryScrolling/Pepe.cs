using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstTryScrolling
{
    class Pepe
    {
        public Texture2D _image;
        public Vector2 _position;
        public Color _color;
        public Rectangle hitbox;
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
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0, 1);

            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0,2);
            _image = image;
            _position = position;
            _color = color;
            _bullet = bullet;
            Bullets = new List<Bullet>();
            hitbox = new Rectangle((int)_position.X,(int) _position.Y, _image.Width, _image.Height);

        }
        public virtual void Update(GameTime gameTime)
        {
            _delayControl += gameTime.ElapsedGameTime;
            _activeTimer += gameTime.ElapsedGameTime;
            if (_delayControl > _bulletDelay)
            {
                _delayControl = TimeSpan.Zero;
                Vector2 bulletSpawn = new Vector2( _position.X + (_image.Width - _bullet._image.Width) / 2, _position.Y);
                Bullets.Add(new Bullet(_bullet._image, bulletSpawn, _bullet._color, _bullet._speed, direction));
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


