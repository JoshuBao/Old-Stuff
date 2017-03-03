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
        public void Update()
        {
            Position += _speed;
        }

        public void Target(Vector2 target)
        {
            //find angle
            Vector2 diff = target - Position;
            rotation = (float)Math.Atan2(diff.Y, diff.X);

            //set speed
            diff.Normalize();
            _speed = diff * _speed.Length();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, null, Color.White, rotation, Vector2.One , 1, effect, 0);
        }
    }
}
