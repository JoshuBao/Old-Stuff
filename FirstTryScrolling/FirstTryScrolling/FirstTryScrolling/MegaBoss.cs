using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    class MegaBoss : Sprite
    {
        TimeSpan _delayControl;
        TimeSpan _activeTimer;
        TimeSpan _damageTimer;
        TimeSpan _bulletDelay;
        public bool hit = false;
        public List<Bullet> Bullets;
        public Bullet _bullet;
        public Direction direction;

        public MegaBoss(Texture2D image, Vector2 position, Color color, Bullet bullet)
            : base(image, position, color)
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0, 1);
            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0, 2);


            _bullet = bullet;
            Bullets = new List<Bullet>();
        }

        public void Update(GameTime gameTime, Player player)
        {
            _delayControl += gameTime.ElapsedGameTime;
            _activeTimer += gameTime.ElapsedGameTime;
            if (_delayControl > _bulletDelay)
            {
                _delayControl = TimeSpan.Zero;
                Vector2 bulletSpawn = new Vector2(Position.X + (Image.Width - _bullet.Image.Width) / 2, Position.Y);
                Bullet boom = new Bullet(_bullet.Image, bulletSpawn, _bullet.Color, _bullet._speed, direction);
                boom.Target(player.Position);
                Bullets.Add(boom);
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
    }
}


