using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    class MegaBoss : Enemies
    {
        public MegaBoss(Texture2D image, Vector2 position, Color color, Bullet bullet, Direction direction)
            : base(image, position, color, bullet, direction)
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0, 1);
            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0, 2);


            _bullet = bullet;
            
        }

        public void Update(GameTime gameTime, Player player)
        {
            _delayControl += gameTime.ElapsedGameTime;
            _activeTimer += gameTime.ElapsedGameTime;
            if (_delayControl > _bulletDelay)
            {
                _delayControl = TimeSpan.Zero;
                Vector2 bulletSpawn = new Vector2(Position.X + (Image.Width - _bullet.Image.Width) / 2, Position.Y);
                Bullet boom = new Bullet(_bullet.Image, bulletSpawn, _bullet.Color, _bullet._speed, Direction.Right);
                boom.Target(player.Position);
                _Bullets.Add(boom);
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
    }
}


