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
            
            THitbox = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, 1);
            BHitbox = new Rectangle((int)Position.X, (int)Position.Y + Image.Height, Image.Width, 1);
            RHitbox = new Rectangle((int)Position.X + Image.Width, (int)Position.Y + Image.Height/4, 1, Image.Height/2);
            LHitbox = new Rectangle((int)Position.X, (int)Position.Y + Image.Height / 4, 1, Image.Height/2);

        }

        public void Update()
        {
            Position.Y += GRAVITY;
            Position.Y -= jumpSpeed;
            jumpSpeed = (int)MathHelper.Clamp(jumpSpeed - jumpDecayRate, 0, maxJumpSpeed);
            if (Position.Y < 0)
            {
                Position.Y = 0;
            }
            if (touchpit == false && Position.Y > 460)
            {
            //if )
           // {
                Position.Y = 460;
                jumpCount = 0;
                jumpSpeed = 0;
          //  }
            }
            THitbox = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, 1);
            BHitbox = new Rectangle((int)Position.X, (int)Position.Y + Image.Height, Image.Width, 1);
            RHitbox = new Rectangle((int)Position.X + Image.Width, (int)Position.Y + Image.Height / 4, 1, Image.Height / 2);
            LHitbox = new Rectangle((int)Position.X, (int)Position.Y + Image.Height / 4, 1, Image.Height / 2);
        }

        public void moveUp()
        {
            if (jumpCount < 2)
            {
                jumpSpeed = maxJumpSpeed;
                jumpCount++;
                THitbox = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, 1);
                BHitbox = new Rectangle((int)Position.X, (int)Position.Y + Image.Height, Image.Width, 1);
                RHitbox = new Rectangle((int)Position.X + Image.Width, (int)Position.Y + Image.Height / 4, 1, Image.Height / 2);
                LHitbox = new Rectangle((int)Position.X, (int)Position.Y + Image.Height / 4, 1, Image.Height / 2);
            }
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont f)
        {

            //spriteBatch.Draw(Game1.pixel, hitbox, Color.Blue);
            spriteBatch.Draw(Image, Position, null, Color, 0f, Vector2.Zero, 1f, effect, 0);
            spriteBatch.DrawString(f, ("Health:" + Health + "\n Lives:" + lives), new Vector2(Position.X + (Image.Width / 4) - 12, Position.Y - 49), Color.Black);
        }
    }
}
