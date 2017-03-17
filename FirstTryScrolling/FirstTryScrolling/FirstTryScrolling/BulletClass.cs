using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    public class BulletClass : Sprite
    {

        public Vector2 _speed;
        public BulletClass(Texture2D texture, Vector2 position, Color color, Vector2 speed)
            : base(texture, position, color)
        {
            _speed = speed;
        }
        public override void Update()
        {
            _position += _speed;


            hitbox.X = (int)_position.X;
            hitbox.Y = (int)_position.Y;

            base.Update();
        }

    }
}
