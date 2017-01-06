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
        public Texture2D _image;
        public Vector2 _position;
        public Color _color;
        public Rectangle hitbox;

        public Sprite(Texture2D image, Vector2 position, Color color)
        {
            _image = image;
            _position = position;
            _color = color;
            hitbox = new Rectangle((int)_position.X,(int) _position.Y, _image.Width, _image.Height);
        }

        public virtual void Update()
        {
            hitbox = new Rectangle((int)_position.X, (int)_position.Y, _image.Width, _image.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Game1.pixel, hitbox, Color.Blue);
            spriteBatch.Draw(_image, _position, _color);
            
        }
    }
}
