using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    public class Player : Sprite
    {
        int GRAVITY = 10;
        public int jumpCount = 0;
        public int jumpSpeed = 0;
        public int maxJumpSpeed = 24;
        public int jumpDecayRate = 1;
        public bool touchpit;
        public Rectangle THitbox;
        public Rectangle BHitbox;
        public int Health = 100;
        public int lives = 3;
        public Rectangle RHitbox;
        public Rectangle LHitbox;
        public Bullet _Bullet;
        public SpriteEffects effect;
        public Direction Direction;
       
        public Player(Texture2D image, Vector2 position, Color color, Bullet Bullet)
            : base(image, position, color)
        {
            _Bullet = Bullet;
            effect = SpriteEffects.None;
            
            THitbox = new Rectangle((int)_position.X, (int)_position.Y, _image.Width, 1);
            BHitbox = new Rectangle((int)_position.X, (int)_position.Y + _image.Height, _image.Width, 1);
            RHitbox = new Rectangle((int)_position.X + _image.Width, (int)_position.Y + _image.Height/4, 1, _image.Height/2);
            LHitbox = new Rectangle((int)_position.X, (int)_position.Y + _image.Height / 4, 1, _image.Height/2);

        }

        public override void Update()
        {
            _position.Y += GRAVITY;
            _position.Y -= jumpSpeed;
            jumpSpeed = (int)MathHelper.Clamp(jumpSpeed - jumpDecayRate, 0, maxJumpSpeed);
            if (_position.Y < 0)
            {
                _position.Y = 0;
            }
            if (touchpit == false && _position.Y > 460)
            {
            //if )
           // {
                _position.Y = 460;
                jumpCount = 0;
                jumpSpeed = 0;
          //  }
            }
            THitbox = new Rectangle((int)_position.X, (int)_position.Y, _image.Width, 1);
            BHitbox = new Rectangle((int)_position.X, (int)_position.Y + _image.Height, _image.Width, 1);
            RHitbox = new Rectangle((int)_position.X + _image.Width, (int)_position.Y + _image.Height / 4, 1, _image.Height / 2);
            LHitbox = new Rectangle((int)_position.X, (int)_position.Y + _image.Height / 4, 1, _image.Height / 2);

            base.Update();
        }

        public void moveUp()
        {
            if (jumpCount < 2)
            {
                jumpSpeed = maxJumpSpeed;
                jumpCount++;
                THitbox = new Rectangle((int)_position.X, (int)_position.Y, _image.Width, 1);
                BHitbox = new Rectangle((int)_position.X, (int)_position.Y + _image.Height, _image.Width, 1);
                RHitbox = new Rectangle((int)_position.X + _image.Width, (int)_position.Y + _image.Height / 4, 1, _image.Height / 2);
                LHitbox = new Rectangle((int)_position.X, (int)_position.Y + _image.Height / 4, 1, _image.Height / 2);
            }
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont f)
        {

            //spriteBatch.Draw(Game1.pixel, hitbox, Color.Blue);
            spriteBatch.Draw(_image, _position, null, _color, 0f, Vector2.Zero, 1f, effect, 0);
            spriteBatch.DrawString(f, ("Health:" + Health + "\n Lives:" + lives), new Vector2(_position.X + (_image.Width / 4) - 12, _position.Y - 49), Color.Black);
        }
    }
}
