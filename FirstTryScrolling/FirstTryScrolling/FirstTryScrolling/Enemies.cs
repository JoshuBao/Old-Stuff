using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstTryScrolling
{
    class Enemies : Sprite
    {
        public int _Health = 0;
        protected TimeSpan _delayControl;
        protected TimeSpan _activeTimer;
        protected TimeSpan _damageTimer;
        protected TimeSpan _bulletDelay;
        public bool hit;
        public List<Bullet> _Bullets;
        protected Direction _direction;
        public Bullet _bullet;


        public void Settimespan(TimeSpan delayControl, TimeSpan activeTimer, TimeSpan bulletDelay,TimeSpan damageTimer)
        {
            _delayControl = delayControl;
            _activeTimer = activeTimer;
            _damageTimer = damageTimer;
            _bulletDelay = bulletDelay;
        }
        public Enemies(Texture2D image, Vector2 position, Color color, Bullet bullet, Direction direction)
            : base(image, position, color)
        {
            
            _bullet = bullet;
            
            _Bullets = new List<Bullet>();
            _direction = direction;

        }
    }
}
