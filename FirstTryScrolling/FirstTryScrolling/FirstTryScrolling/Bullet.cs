using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    public class Bullet : Sprite
    {
        public Vector2 _speed;
        public SpriteEffects effect;
        public float rotation = 0;

        public Bullet(Texture2D texture, Vector2 position, Color color, Vector2 speed, Direction direction)
            : base(texture, position, color)
        {
            _speed = speed;

            if (direction == Direction.Left)
            {
                effect = SpriteEffects.None;
            }
            else
            {
                effect = SpriteEffects.FlipHorizontally;
            }
        }
        public override void Update()
        {
            _position += _speed;


            hitbox.X = (int)_position.X;
            hitbox.Y = (int)_position.Y;

            base.Update();
        }

        public void Target(Vector2 target)
        {
            //find angle
            Vector2 diff = target - _position;
            rotation = (float)Math.Atan2(diff.Y, diff.X);

            //set speed
            diff.Normalize();
            _speed = diff * _speed.Length();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, _position, null, Color.White, rotation, Vector2.One , 1, effect, 0);
        }
    }
}
