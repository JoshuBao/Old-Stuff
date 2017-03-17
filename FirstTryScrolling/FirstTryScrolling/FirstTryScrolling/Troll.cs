using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    class Troll : Sprite
    {
  
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
           : base(image,position,color)
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0, 0, 100);

            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0, 0 , 300);
            _bullet = bullet;
            Bullets = new List<Bullet>();
             
        }
        public virtual void Update(GameTime gameTime, List<Bullet> Bullet)
        {
            _activeTimer += gameTime.ElapsedGameTime;
            if (_delayControl > _bulletDelay)
            {
                _delayControl = TimeSpan.Zero;
                Vector2 bulletSpawn = new Vector2( Position.X + (Image.Width - _bullet.Image.Width) / 2, Position.Y);
                Bullets.Add(new Bullet(_bullet.Image, bulletSpawn, _bullet.Color, _bullet._speed, Direction));
                //where we shoot a bullet
            }
            foreach (var B in Bullets)
            {
                B.Update();
            }
            if (updown == false)
            {
                Position.Y -= 10;
            }
            if (updown == true)
            {
                Position.Y += 10;
            }
            if (Position.Y <= 0)
            {
                updown = true;
            }
            if (Position.Y >= 400)
            {
                updown = false;
            }
            _delayControl += gameTime.ElapsedGameTime;
            if (hit)
            {
                Color = Color.Red;
                _activeTimer = TimeSpan.Zero;
            }
            else if (_damageTimer < _activeTimer)
            {
                Color = Color.White;
            }

            
           
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont s)
        {
            base.Draw(spriteBatch);

            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i].Draw(spriteBatch);
            }

            spriteBatch.DrawString(s, ("Health:" + Health), new Vector2(Position.X + (Image.Width /4) ,Position.Y - 25), Color.Black);
        }
    }
}
