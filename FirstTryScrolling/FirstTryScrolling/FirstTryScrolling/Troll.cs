using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    class Troll : Enemies
    {
  
        bool updown = false;

        
        public Troll(Texture2D image, Vector2 position, Color color, Bullet bullet,Direction direction)
           : base(image,position,color,bullet,direction)
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0, 0, 100);

            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0, 0 , 300);
            _Health = 30;
            
        }
        public virtual void Update(GameTime gameTime, List<Bullet> Bullet)
        {
            _activeTimer += gameTime.ElapsedGameTime;
            if (_delayControl > _bulletDelay)
            {
                _delayControl = TimeSpan.Zero;
                Vector2 bulletSpawn = new Vector2( Position.X + (Image.Width - _bullet.Image.Width) / 2, Position.Y);
                _Bullets.Add(new Bullet(_bullet.Image, bulletSpawn, _bullet.Color, _bullet._speed, _direction));
                //where we shoot a bullet
            }
            foreach (var B in _Bullets)
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

            for (int i = 0; i < _Bullets.Count; i++)
            {
                _Bullets[i].Draw(spriteBatch);
            }

            spriteBatch.DrawString(s, ("Health:" + _Health), new Vector2(Position.X + (Image.Width /4) ,Position.Y - 25), Color.Black);
        }
    }
}
