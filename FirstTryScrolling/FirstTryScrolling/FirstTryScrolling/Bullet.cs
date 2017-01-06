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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, _position, null, Color.White, 0, Vector2.One , 1, effect, 0);
        }
    }
}
