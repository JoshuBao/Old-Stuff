using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FirstTryScrolling
{
    class MegaBoss : Enemies
    {
        TimeSpan _activeTimer2 = new TimeSpan(0);
        TimeSpan _SwitchMove = new TimeSpan(0, 0, 7);
        Random numgen = new Random();
        
        bool Blink = false;
        public MegaBoss(Texture2D image, Vector2 position, Color color, Bullet bullet, Direction direction)
            : base(image, position, color, bullet, direction)
        {
            _activeTimer = new TimeSpan(0);
            _damageTimer = new TimeSpan(0, 0, 0,6);
            _delayControl = TimeSpan.Zero;
            _bulletDelay = new TimeSpan(0, 0, 0,6);
            

            _bullet = bullet;
            _Health = 100;

        }
        
        public void Update(GameTime gameTime, Player player,GraphicsDevice g)
        {
            _activeTimer2 += gameTime.ElapsedGameTime;
           
            if (_activeTimer2 > _SwitchMove)
            {
               Blink  = true;
                _activeTimer2 = TimeSpan.Zero;
            }
            else
            {
                Blink = false;
            }
            if (Blink == true)
            {
                
                Position.X = numgen.Next(0, g.Viewport.Width - Image.Width);
                Position.Y = numgen.Next(0, g.Viewport.Height - Image.Height * 2);
            }
            if (hit)
            {
                Color = Color.Red;
                _activeTimer = TimeSpan.Zero;
                hit = false;
            }
            else if (_damageTimer < _activeTimer)
            {
                Color = Color.White;
            }
            if (Blink == false)
            {
                _delayControl += gameTime.ElapsedGameTime;
                _activeTimer += gameTime.ElapsedGameTime;
                if (_delayControl > _bulletDelay)
                {
                    _bullet._speed = new Vector2(5);
                    _delayControl = TimeSpan.Zero;
                    Vector2 bulletSpawn = new Vector2(Position.X + (Image.Width + _bullet.Image.Width) / 2, Position.Y);
                    Bullet boom = new Bullet(_bullet.Image, bulletSpawn, _bullet.Color, _bullet._speed, Direction.Right);
                    boom.Target(new Vector2(player.Position.X + (player.Image.Width + _bullet.Image.Width) / 2, player.Position.Y));
                    // + (player.Image.Width + _bullet.Image.Width) / 2
                    _Bullets.Add(boom);
                    //where we shoot a bullet
                }
                //Bullet Update
                foreach (Bullet bullet in _Bullets)
                {
                    bullet.Update();
                }
                //hit conditions to turn red
               
                //if bullets go off screen
                for (int i = 0; i < _Bullets.Count; i++)
                {
                    if (_Bullets[i].Position.X <= 0)
                    {
                        _Bullets.Remove(_Bullets[i]);
                        i--;
                    }
                    else if (_Bullets[i].Position.X >= 900)
                    {
                        _Bullets.Remove(_Bullets[i]);
                        i--;
                    }
                }
            }
        }



        public void Draw(SpriteBatch spritebatch,SpriteFont e)
        {
            //spriteBatch.Draw(Game1.pixel, Hitbox, Color.Blue);
            spritebatch.Draw(Image, Position, Color);
            for (int i = 0; i < _Bullets.Count; i++)
            {
                _Bullets[i].Draw(spritebatch);
            }

            spritebatch.DrawString(e, ("Health:" + _Health), new Vector2(Position.X + (Image.Width / 4), Position.Y - 25), Color.Black);
        }
    }
}



