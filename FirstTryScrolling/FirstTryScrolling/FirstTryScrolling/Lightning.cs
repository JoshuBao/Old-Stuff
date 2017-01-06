using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    class Lightning
    {

        public Texture2D _image;
        public Vector2 _position;
        public Color _color;


        public Lightning(Texture2D image, Vector2 position, Color color)
        {
            _image = image;
            _position = position;
            _color = color;

        }


        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(_image, _position, _color);

        }
    }
}

