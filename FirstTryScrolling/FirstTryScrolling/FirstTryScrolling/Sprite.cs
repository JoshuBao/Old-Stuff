using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    public class Sprite
    {
        public Texture2D Image;
        public Vector2 Position;
        public Color Color;

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            }
        }

        public Sprite(Texture2D image, Vector2 position, Color color)
        {
            Image = image;
            Position = position;
            Color = color;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Game1.pixel, hitbox, Color.Blue);
            spriteBatch.Draw(Image, Position, Color);
            
        }
    }
}
