using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FirstTryScrolling
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        MouseState ms;
        KeyboardState ks;
        KeyboardState lastks;
        SpriteFont font;
        Sprite mouse;
        Sprite Gateforgifted;
        int movementAmount = 0;
        Texture2D HK;
        bool killslides = false;
        //BUNCH OF SPRITES HERE 

        bool gateShow = false;

        Sprite Back1;
        Sprite Back2;
        Sprite Back3;
        Sprite Back4;
        Sprite Back5;
        Sprite Back6;
        Sprite Back7;
        Sprite Back8;

        //doorrs

        Sprite Doormsg;
        Sprite Doormsg2;
        Sprite Doormsg3;
        bool Doorslides3 = false;
        bool Doorslides2 = false;

        //LOCK PICKING SPRITES
        Sprite Recieve1;
        Sprite Recieve2;
        Sprite Recieve3;
        Sprite Recieve4;

        Sprite LockPickScreen; 

        Sprite Block1;
        Sprite Block2;
        Sprite Block3;
        Sprite Block4;
        Sprite Block5;
        //LOCK PICKING bools
        bool HowtoLockPick = false;
        bool LockPickStart = false;
        bool Rhit1 = false;
        bool Rhit2 = false;
        bool Rhit3 = false;
        bool Rhit4 = false;
        List<Sprite> HealthKit;

        Sprite Door;

        Sprite Gameover;

        List<Bullet> PlayerBullets;

        int mouseX = 0;

        bool doorslides = false;

        bool ShowLightning = false;

        List<Sprite> Blocks;
        List<Sprite> Signs;
        Texture2D ImgBlock;
        Texture2D ImgPol;


        //bools for signs and steff
        bool Showsmsg = false;
        bool Showsmsg1 = false;
        bool Showmsg2 = false;
        bool Showsmsg3 = false;

        Texture2D WpolImg;
        Lightning lightning;
        Lightning Whitepic;

        //sprite pits of LAVA

        //sprite thingy
        Sprite RightSign;


        //pepe Stuff  

        List<Pepe> pepe;



        bool Trumpslides = false;


        Sprite JetPackPowerUp;

        List<Sprite> WPol;
        List<Sprite> Pol;

        bool Trumpjumpcount = false;

        bool GameStopped = false;

        List<Bullet> Bullet;
        Sprite Smsg;
        Sprite Smsg1;
        Sprite Smsg2;
        Sprite Smsg3;
        Sprite Oldman1;
        //flag stuff very cool and important
        List<Sprite> Flags;
        Sprite Flag1;
        // troll stuf
        List<Troll> Trolls;
        bool RIGHT = false;
        bool LEFT = true;
        public static Texture2D pixel;

        TimeSpan damageTimer = new TimeSpan(0, 0, 0, 0, 100);

        TimeSpan activeTimer = new TimeSpan(0);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 700;

            graphics.ApplyChanges();

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = Content.Load<Texture2D>("Thing");
            PlayerBullets = new List<Bullet>();
            Bullet potadoge = new Bullet(Content.Load<Texture2D>("potadoge"), new Vector2(-0, -100), Color.White, new Vector2(20, 0), Direction.Left);
            //PlayerBullets.Add(potadoge);
            player = new Player(Content.Load<Texture2D>("BLOB"), new Vector2(350, 400), Color.White, potadoge);
            //sprite stuffs
            //MOUSEIMG
            mouse = new Sprite(Content.Load<Texture2D>("GreenBlock"), new Vector2(16666, 290), Color.White);


            //LOCKPICK

            LockPickScreen = new Sprite(Content.Load<Texture2D>("LockPickScreen"), new Vector2(0, 0), Color.White);
            Recieve1 = new Sprite(Content.Load<Texture2D>("Recieve1"),new Vector2 (210,105),Color.White);
            Recieve2 = new Sprite(Content.Load<Texture2D>("Recieve1"),new Vector2 (334,603),Color.White);
            Recieve3 = new Sprite(Content.Load<Texture2D>("Recieve1"),new Vector2 (466,104),Color.White);
            Recieve4 = new Sprite(Content.Load<Texture2D>("Recieve1"),new Vector2 (584,600),Color.White);

            Block1 = new Sprite(Content.Load<Texture2D>("GreenBlock"), new Vector2(205, 217), Color.White);
            Block2 = new Sprite(Content.Load<Texture2D>("RedBlock"), new Vector2(310, 268), Color.White);
            Block3 = new Sprite(Content.Load<Texture2D>("YellowBlock"), new Vector2(409,213), Color.White);
            Block4 = new Sprite(Content.Load<Texture2D>("OrangeBlock"), new Vector2(569, 239), Color.White);

            //doors and sutff
            Doormsg = new Sprite(Content.Load<Texture2D>("DoorMsg1"), new Vector2(0, 0), Color.White);

            Doormsg2 = new Sprite(Content.Load<Texture2D>("elmo"), new Vector2(0, 0), Color.White);
            Doormsg3 = new Sprite(Content.Load<Texture2D>("DoorMsg3"), new Vector2(0, 0), Color.White);
            Texture2D backimage = Content.Load<Texture2D>("TRY2");

            RightSign = new Sprite(Content.Load<Texture2D>("GoRightSign"), new Vector2(16666, 290), Color.White);


            Door = new Sprite(Content.Load<Texture2D>("Door"), new Vector2(16450, 167), Color.White);


            ImgBlock = (Content.Load<Texture2D>("block"));

            Whitepic = new Lightning(Content.Load<Texture2D>("WhitePic"), new Vector2(0), Color.White);
            lightning = new Lightning(Content.Load<Texture2D>("Lightning"), new Vector2(0, 0), Color.White);


            Back1 = new Sprite(Content.Load<Texture2D>("TRY#"), new Vector2(0, 200), Color.White);
            Back2 = new Sprite(backimage, new Vector2(4096, 200), Color.White);
            Back3 = new Sprite(Content.Load<Texture2D>("TRY#"), new Vector2(8192, 200), Color.White);
            Back4 = new Sprite(backimage, new Vector2(12288, 200), Color.White);
            Back5 = new Sprite(Content.Load<Texture2D>("TRY#"), new Vector2(16384, 200), Color.White);
            Back6 = new Sprite(backimage, new Vector2(20480, 200), Color.White);
            Back7 = new Sprite(Content.Load<Texture2D>("TRY#"), new Vector2(24576, 200), Color.White);
            Back8 = new Sprite(backimage, new Vector2(28672, 200), Color.White);

            Signs = new List<Sprite>();
            Texture2D SignsIMG = (Content.Load<Texture2D>("Sign"));

            Sprite sign = new Sprite(SignsIMG, new Vector2(929, 440), Color.White);
            Sprite sign2 = new Sprite(SignsIMG, new Vector2(487, 335), Color.White);
            Sprite sign3 = new Sprite(SignsIMG, new Vector2(2440, 440), Color.White);

            Oldman1 = new Sprite(Content.Load<Texture2D>("Oldman1"), new Vector2(8000, 450), Color.White);

            Signs.Add(sign);
            Signs.Add(sign2);
            Signs.Add(sign3);
            Signs.Add(Oldman1);


            //gate :D
            Gateforgifted = new Sprite(Content.Load<Texture2D>("gate"), new Vector2(17225, 335), Color.White);

            //SMSG sprites

            Smsg = new Sprite(Content.Load<Texture2D>("smsg1"), new Vector2(0, 0), Color.White);
            Smsg1 = new Sprite(Content.Load<Texture2D>("smsg2"), new Vector2(0, 0), Color.White);
            Smsg2 = new Sprite(Content.Load<Texture2D>("smsg3"), new Vector2(0, 0), Color.White);
            Smsg3 = new Sprite(Content.Load<Texture2D>("Oldmanmsg1"), new Vector2(0, 0), Color.White);


            //flag steff
            Flags = new List<Sprite>();
            Flag1 = new Sprite(Content.Load<Texture2D>("CheckPointFlag"), new Vector2(7700, 440), Color.White);


            //flag list steff
            Flags.Add(Flag1);


            HealthKit = new List<Sprite>();
            HK = Content.Load<Texture2D>("HEALTH kit");
            HealthKit.Add(new Sprite(HK, new Vector2(11115, 172), Color.White));
            HealthKit.Add(new Sprite(HK, new Vector2(16075, 310), Color.White));



            Blocks = new List<Sprite>();
            Blocks.Add(new Sprite(ImgBlock, new Vector2(484, 403), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(826, 256), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(1200, 300), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(1500, 400), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(1700, 200), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(2000, 300), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(3000, 400), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(3400, 300), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(3800, 250), Color.White));
            //2
            Blocks.Add(new Sprite(ImgBlock, new Vector2(4200, 300), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(5000, 150), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(5400, 250), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(5900, 350), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(6500, 200), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(7500, 200), Color.White));
            //3
            Blocks.Add(new Sprite(ImgBlock, new Vector2(11000, 200), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(11500, 400), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(11900, 300), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(12300, 250), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(12800, 400), Color.White));
            //4
            Blocks.Add(new Sprite(ImgBlock, new Vector2(13278, 411), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(13600, 349), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(14000, 411), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(14500, 285), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(15000, 200), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(15400, 400), Color.White));
            Blocks.Add(new Sprite(ImgBlock, new Vector2(15918, 339), Color.White));


            //power ups

            JetPackPowerUp = new Sprite(Content.Load<Texture2D>("Jetpack Powerup"), new Vector2(7600, 140), Color.White);

            //TROLL STUFF
            Bullet Trollbullet = new Bullet(Content.Load<Texture2D>("Troll Bomb"), new Vector2(-100000, -320), Color.White, new Vector2(0, 10), Direction.Left);
            Trolls = new List<Troll>();
            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(8500, 0), Color.White, Trollbullet));
            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(9000, 900), Color.White, Trollbullet));
            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(9500, 0), Color.White, Trollbullet));
            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(10400, 900), Color.White, Trollbullet));
            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(10900, 0), Color.White, Trollbullet));

            //pepe army
            pepe = new List<Pepe>();
            Bullet pepeBullet = new Bullet(Content.Load<Texture2D>("TEARBULLET"), new Vector2(0, 0), Color.White, new Vector2(-10, 0), Direction.Left);
            Texture2D pepeimage = Content.Load<Texture2D>("pepeFOR REALS");
            pepe.Add(new Pepe(pepeimage, new Vector2(12318, 97), Color.White, pepeBullet));
            pepe.Add(new Pepe(pepeimage, new Vector2(12571, 355), Color.White, pepeBullet));
            pepe.Add(new Pepe(pepeimage, new Vector2(12855, 249), Color.White, pepeBullet));
            pepe.Add(new Pepe(pepeimage, new Vector2(13323, 259), Color.White, pepeBullet));
            pepe.Add(new Pepe(pepeimage, new Vector2(13608, 199), Color.White, pepeBullet));
            pepe.Add(new Pepe(pepeimage, new Vector2(14015, 258), Color.White, pepeBullet));
            pepe.Add(new Pepe(pepeimage, new Vector2(14515, 131), Color.White, pepeBullet));
            pepe.Add(new Pepe(pepeimage, new Vector2(15012, 47), Color.White, pepeBullet));
            pepe.Add(new Pepe(pepeimage, new Vector2(15413, 247), Color.White, pepeBullet));

            //Gameover
            Gameover = new Sprite(Content.Load<Texture2D>("Game Over Screen"), new Vector2(0), Color.White);

            // sprites for Pol
            Pol = new List<Sprite>();
            ImgPol = (Content.Load<Texture2D>("POL"));
            Pol.Add(new Sprite(ImgPol, new Vector2(1000, 650), Color.White));
            Pol.Add(new Sprite(ImgPol, new Vector2(2500, 650), Color.White));
            Pol.Add(new Sprite(ImgPol, new Vector2(4600, 650), Color.White));
            Pol.Add(new Sprite(ImgPol, new Vector2(4800, 650), Color.White));
            Pol.Add(new Sprite(ImgPol, new Vector2(6990, 650), Color.White));
            Pol.Add(new Sprite(ImgPol, new Vector2(7100, 650), Color.White));
            Pol.Add(new Sprite(ImgPol, new Vector2(7290, 650), Color.White));
            //wpolSprites
            WPol = new List<Sprite>();
            WpolImg = (Content.Load<Texture2D>("PolWIMG"));
            WPol.Add(new Sprite(WpolImg, new Vector2(1000, 500), Color.White));
            WPol.Add(new Sprite(WpolImg, new Vector2(2500, 500), Color.White));
            WPol.Add(new Sprite(WpolImg, new Vector2(4600, 500), Color.White));
            WPol.Add(new Sprite(WpolImg, new Vector2(4800, 500), Color.White));
            WPol.Add(new Sprite(WpolImg, new Vector2(6990, 500), Color.White));
            WPol.Add(new Sprite(WpolImg, new Vector2(7100, 500), Color.White));
            WPol.Add(new Sprite(WpolImg, new Vector2(7290, 500), Color.White));


            Bullet = new List<Bullet>();
            Bullet.Add(Trollbullet);


            font = Content.Load<SpriteFont>("MOUSE");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            activeTimer += gameTime.ElapsedGameTime;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.P) && lastks.IsKeyUp(Keys.P))
            {
                GameStopped = !GameStopped;
            }
            if (killslides == false)
            {

                if (ks.IsKeyDown(Keys.C) && lastks.IsKeyUp(Keys.C) && doorslides == true)
                {
                    doorslides = false;
                    Doorslides2 = true;

                }
                else if (ks.IsKeyDown(Keys.C) && lastks.IsKeyUp(Keys.C) && Doorslides2 == true)
                {
                    Doorslides2 = false;
                    Doorslides3 = true;
                }
                else if (ks.IsKeyDown(Keys.C) && lastks.IsKeyUp(Keys.C) && Doorslides3 == true)
                {

                    Doorslides3 = false;
                    Trumpslides = true;
                    killslides = true;
                    GameStopped = false;
                    gateShow = true;
                    Door._position.X -= 140000;

                }
            }

            //LOCKPICKKKKKKKK
            if (player.hitbox.Intersects(Gateforgifted.hitbox))
            {
                GameStopped = true;
                HowtoLockPick = true;
            }
            if (HowtoLockPick == true && ks.IsKeyDown(Keys.C))
            {
                LockPickStart = true;
            }
            if (Rhit1 == false)
            {
                if (LockPickStart == true && ks.IsKeyDown(Keys.Up))
                {

                    Block1._position.Y -= 10;
                }
                if (Rhit1 == false && ks.IsKeyDown(Keys.Down))
                {
                    Block1._position.Y += 10;
                }
            }
            if (Block1.hitbox.Intersects(Recieve1.hitbox))
            {
                Rhit1 = true;
            }
            if (Block2.hitbox.Intersects(Recieve2.hitbox))
            {
                Rhit2 = true;
            }
            if (Block3.hitbox.Intersects(Recieve3.hitbox))
            {
                Rhit3 = true;
            }
            if (Block4.hitbox.Intersects(Recieve4.hitbox))
            {
                Rhit4 = true;
            }

            if (ks.IsKeyDown(Keys.H))
            {
                Gateforgifted._position = new Vector2(player._position.X, player._position.Y - 200);
                Gateforgifted.hitbox.X = (int)Door._position.X;
                Gateforgifted.hitbox.Y = (int)Door._position.Y;
            }

            //if (ks.IsKeyDown(Keys.C) && lastks.IsKeyUp(Keys.C) && Doorslides2 == true)
            //{
            //    Doorslides2 = false;
            //    Doorslides3 = true;

            //}
            if (GameStopped == false)
            {
                ms = Mouse.GetState();

                //Player bullets are destroyed when they hit blocks
                for (int i = 0; i < Bullet.Count; i++)
                {
                    Bullet[i].Update();
                }
                //Update123
                //Trolls take damage from player
                if (Trumpslides == false)
                {

                    if (player.hitbox.Intersects(Door.hitbox))
                    {
                        doorslides = true;
                        GameStopped = true;
                    }
                    else
                    {
                        GameStopped = false;
                        doorslides = false;
                    }
                }
                for (int f = 0; f < Trolls.Count; f++)
                {
                    Trolls[f].hit = false;
                    for (int i = 0; i < PlayerBullets.Count; i++)
                    {


                        if (PlayerBullets[i]._position.X <= 0)
                        {
                            PlayerBullets.RemoveAt(i);
                            i--;
                        }
                        else if (PlayerBullets[i]._position.X >= 900)
                        {
                            PlayerBullets.RemoveAt(i);
                            i--;
                        }
                        else if (PlayerBullets[i].hitbox.Intersects(Trolls[f].hitbox))
                        {
                            Trolls[f].Health -= 7;
                            Trolls[f].hit = true;
                            PlayerBullets.RemoveAt(i);

                            i--;
                        }
                    }

                    for (int i = 0; i < pepe.Count; i++)
                    {
                        //PEPE UPDATE
                        pepe[i].Update(gameTime);
                        //pepe can die now
                        if (pepe[i].Health <= 0)
                        {
                            pepe.Remove(pepe[i]);
                            i--;
                        }
                    }
                    //Player Takes Damage from trolls
                    for (int e = 0; e < Trolls.Count; e++)
                    {

                        for (int j = 0; j < Trolls[e].Bullets.Count; j++)
                        {
                            if (Trolls[e].Bullets[j].hitbox.Intersects(player.hitbox))
                            {
                                player.Health -= 8;
                                player._color = Color.Red;
                                Trolls[e].Bullets.Remove(Trolls[e].Bullets[j]);
                                activeTimer = TimeSpan.Zero;
                                j--;
                            }
                            else if (damageTimer < activeTimer)
                            {
                                player._color = Color.White;
                            }
                        }
                    }
                }
                // trolls can die now
                for (int i = 0; i < Trolls.Count; i++)
                {
                    if (Trolls[i].Health <= 0)
                    {
                        Trolls.Remove(Trolls[i]);
                        i--;
                    }
                }
                //players can die too...
                if (player.Health <= 0)
                {
                    player.lives--;
                    player.Health = 100;
                    if (player.lives <= 0)
                    {
                        GameStopped = true;
                        //show game over screen here!!!!
                    }
                }
                // pepe takes damage
                for (int f = 0; f < pepe.Count; f++)
                {
                    pepe[f].hit = false;
                    for (int i = 0; i < PlayerBullets.Count; i++)
                    {
                        if (PlayerBullets[i]._position.X <= 0)
                        {
                            PlayerBullets.Remove(PlayerBullets[i]);
                            i--;
                        }
                        else if (PlayerBullets[i]._position.X >= 860)
                        {
                            PlayerBullets.Remove(PlayerBullets[i]);
                            i--;
                        }
                        else if (PlayerBullets[i].hitbox.Intersects(pepe[f].hitbox))
                        {
                            pepe[f].Health -= 7;
                            pepe[f].hit = true;
                            PlayerBullets.Remove(PlayerBullets[i]);

                            i--;
                        }
                    }
                }
                // pepe can die


                //players take damage from pepe
                for (int e = 0; e < pepe.Count; e++)
                {

                    for (int j = 0; j < pepe[e].Bullets.Count; j++)
                    {
                        if (pepe[e].Bullets[j].hitbox.Intersects(player.hitbox))
                        {
                            player.Health -= 8;
                            player._color = Color.Red;
                            pepe[e].Bullets.Remove(pepe[e].Bullets[j]);
                            activeTimer = TimeSpan.Zero;
                            j--;
                        }
                        else if (damageTimer < activeTimer)
                        {
                            player._color = Color.White;
                        }
                    }
                }
                for (int i = 0; i < Blocks.Count; i++)
                {
                    for (int e = 0; e < PlayerBullets.Count; e++)
                    {
                        if (PlayerBullets[e].hitbox.Intersects(Blocks[i].hitbox))
                        {
                            PlayerBullets.Remove(PlayerBullets[e]);
                            e--;
                        }
                    }
                }
                //PEPE HITBOX
                for (int e = 0; e < pepe.Count; e++)
                {

                    for (int j = 0; j < pepe[e].Bullets.Count; j++)
                    {
                        if (pepe[e].Bullets[j].hitbox.Intersects(player.hitbox))
                        {
                            player.Health -= 8;
                            player._color = Color.Red;
                            pepe[e].Bullets.Remove(pepe[e].Bullets[j]);

                            activeTimer = TimeSpan.Zero;
                            j--;
                        }
                        else if (damageTimer < activeTimer)
                        {
                            player._color = Color.White;
                        }
                    }
                }



                //next thing
                if (player.hitbox.Intersects(Gateforgifted.hitbox))
                {

                }



                //Condition made for flying
                if (Trumpjumpcount)
                {
                    player.jumpCount = 0;
                }
                mouse._position.X = ms.X;
                mouse._position.Y = ms.Y;
                // lastks = Keyboard.GetState();

                player.Update();



                lightning._position.Y = player._position.Y - 460;
                if (ks.IsKeyDown(Keys.Up) && lastks.IsKeyUp(Keys.Up))
                {
                    player.moveUp();
                }
                int touchCounter = 0;

                if (player.hitbox.Intersects(Signs[0].hitbox))
                {
                    Showsmsg = true;
                }
                else
                {
                    Showsmsg = false;
                }
                if (player.hitbox.Intersects(Signs[1].hitbox))
                {
                    Showsmsg1 = true;
                }
                else
                {
                    Showsmsg1 = false;
                }
                if (player.hitbox.Intersects(Signs[2].hitbox))
                {
                    Showmsg2 = true;
                }
                else
                {
                    Showmsg2 = false;
                }
                if (player.hitbox.Intersects(Signs[3].hitbox))
                {
                    Showsmsg3 = true;
                }
                else
                {
                    Showsmsg3 = false;
                }
                for (int i = 0; i < WPol.Count; i++)
                {
                    if (player.BHitbox.Intersects(WPol[i].hitbox))
                    {
                        player.touchpit = true;

                        if (player._position.Y >= 616)
                        {
                            player.jumpCount = 2;
                        }
                    }
                    else
                    {
                        touchCounter++;
                        if (touchCounter == WPol.Count)
                        {
                            player.touchpit = false;
                        }
                    }

                    if (player._position.X >= WPol[i]._position.X + WPol[i]._image.Width || player.touchpit == true)
                    {
                        //player._position.Y = WPol[i]._position.X + WPol[i]._image.Width;
                    }
                    if (player._position.X <= WPol[i]._position.X || player.touchpit == true)
                    {
                        //player._position.Y = WPol[i]._position.Y;
                    }


                }
                for (int i = 0; i < Trolls.Count; i++)
                {
                    Trolls[i].Update(gameTime, Bullet);
                }

                if (player._position.Y >= 700)
                {
                    player.Health -= 1;
                }

                for (int i = 0; i < PlayerBullets.Count; i++)
                {
                    PlayerBullets[i]._position += PlayerBullets[i]._speed;
                    PlayerBullets[i].Update();

                }

                if (ks.IsKeyDown(Keys.A) && lastks.IsKeyUp(Keys.L))
                {
                    ShowLightning = true;
                }
                else
                {
                    ShowLightning = false;
                }


                //hitbox if statements
                for (int i = 0; i < Blocks.Count; i++)
                {
                    if (Blocks[i].hitbox.Intersects(player.THitbox))
                    {
                        player._position.Y = Blocks[i]._position.Y + player._image.Height;
                        player.jumpSpeed = 0;
                        player.jumpCount = int.MaxValue;
                    }
                    if (Blocks[i].hitbox.Intersects(player.BHitbox))
                    {
                        player._position.Y = Blocks[i]._position.Y - player._image.Height;
                        player.jumpCount = 0;
                    }

                    if (Blocks[i].hitbox.Intersects(player.LHitbox))
                    {
                        float blockSpeed = Blocks[i]._position.X + Blocks[i]._image.Width - player._position.X;
                        LEFT = true;
                        for (int e = 0; e < Blocks.Count; e++)
                        {
                            Blocks[e]._position.X -= blockSpeed;
                        }


                    }
                    else
                    {
                        LEFT = false;
                    }
                    if (Blocks[i].hitbox.Intersects(player.RHitbox))
                    {
                        float blockSpeed = Blocks[i]._position.X - player._image.Width - player._position.X;
                        RIGHT = true;
                        for (int e = 0; e < Blocks.Count; e++)
                        {
                            Blocks[e]._position.X -= blockSpeed;
                        }

                    }
                    else
                    {
                        RIGHT = false;
                    }
                }
                if (ks.IsKeyDown(Keys.Space) && lastks.IsKeyUp(Keys.Space))
                {
                    if (player.effect == SpriteEffects.None)
                    {

                        PlayerBullets.Add(new Bullet(player._Bullet._image, player._position, player._Bullet._color, player._Bullet._speed, player.Direction));
                        for (int i = 0; i < PlayerBullets.Count; i++)
                        {
                            PlayerBullets[i]._position -= PlayerBullets[i]._speed;

                        }
                    }
                    else
                    {
                        PlayerBullets.Add(new Bullet(player._Bullet._image, player._position, player._Bullet._color, -player._Bullet._speed, player.Direction));
                        for (int i = 0; i < PlayerBullets.Count; i++)
                        {
                            PlayerBullets[i]._position -= PlayerBullets[i]._speed;

                        }
                    }

                }
                if (LEFT == false)
                {
                    if (ks.IsKeyDown(Keys.Right))
                    {
                        mouseX += 10;
                        Gateforgifted._position.X -= 10;
                        player.effect = SpriteEffects.None;
                        player.Direction = Direction.Right;
                        RightSign._position.X -= 10;
                        //player.

                        movementAmount++;
                        for (int i = 0; i < Pol.Count; i++)
                        {
                            Pol[i]._position.X -= 10;
                            Pol[i].hitbox = new Rectangle((int)Pol[i]._position.X, (int)Pol[i]._position.Y, Pol[i]._image.Width, Pol[i]._image.Height);
                        }
                        for (int i = 0; i < Blocks.Count; i++)
                        {
                            Blocks[i]._position.X -= 10;
                            Blocks[i].hitbox = new Rectangle((int)Blocks[i]._position.X, (int)Blocks[i]._position.Y, Blocks[i]._image.Width, Blocks[i]._image.Height);
                        }
                        for (int i = 0; i < WPol.Count; i++)
                        {
                            WPol[i]._position.X -= 10;
                            WPol[i].hitbox = new Rectangle((int)WPol[i]._position.X, (int)WPol[i]._position.Y, WPol[i]._image.Width, WPol[i]._image.Height);
                        }
                        for (int i = 0; i < Signs.Count; i++)
                        {
                            Signs[i]._position.X -= 10;
                            Signs[i].hitbox.X -= 10;
                        }
                        for (int i = 0; i < Trolls.Count; i++)
                        {
                            Trolls[i]._position.X -= 10;
                            Trolls[i].hitbox.X -= 10;
                            for (int e = 0; e < Trolls[i].Bullets.Count; e++)
                            {
                                Trolls[i].Bullets[e].hitbox.X -= 10;
                                Trolls[i].Bullets[e]._position.X -= 10;
                            }
                        }
                        for (int i = 0; i < Bullet.Count; i++)
                        {
                            Bullet[i]._position.X -= 10;
                        }
                        for (int i = 0; i < PlayerBullets.Count; i++)
                        {
                            player._Bullet._position.X -= 10;
                        }
                        for (int i = 0; i < pepe.Count; i++)
                        {
                            pepe[i]._position.X -= 10;
                        }
                        for (int i = 0; i < HealthKit.Count; i++)
                        {
                            HealthKit[i]._position.X -= 10;
                        }
                        JetPackPowerUp._position.X -= 10;
                        JetPackPowerUp.hitbox.X -= 10;
                        Door._position.X -= 10;
                        Door.hitbox.X -= 10;
                    }
                    //imphealth
                    for (int i = 0; i < HealthKit.Count; i++)
                    {
                        if (player.hitbox.Intersects(HealthKit[i].hitbox))
                        {
                            player.Health += 20;
                            HealthKit.RemoveAt(i);
                        }

                    }

                    if (player.hitbox.Intersects(JetPackPowerUp.hitbox))
                    {
                        Trumpjumpcount = true;
                        JetPackPowerUp._position.Y = -434;
                        JetPackPowerUp.hitbox.Y = -378;
                    }
                    for (int i = 0; i < HealthKit.Count; i++)
                    {
                        HealthKit[i].Update();
                    }
                    if (RIGHT == false)
                    {
                        if (ks.IsKeyDown(Keys.Left) && movementAmount > 0)
                        {
                            mouseX -= 10;
                            player.effect = SpriteEffects.FlipHorizontally;
                            player.Direction = Direction.Left;
                            movementAmount--;
                            Gateforgifted._position.X += 10;
                            RightSign._position.X += 10;
                            for (int i = 0; i < Pol.Count; i++)
                            {
                                Pol[i]._position.X += 10;
                                Pol[i].hitbox = new Rectangle((int)Pol[i]._position.X, (int)Pol[i]._position.Y, Pol[i]._image.Width, Pol[i]._image.Height);
                            }
                            for (int i = 0; i < Blocks.Count; i++)
                            {
                                Blocks[i]._position.X += 10;
                                Blocks[i].hitbox = new Rectangle((int)Blocks[i]._position.X, (int)Blocks[i]._position.Y, Blocks[i]._image.Width, Blocks[i]._image.Height);
                            }
                            for (int i = 0; i < WPol.Count; i++)
                            {
                                WPol[i]._position.X += 10;
                                WPol[i].hitbox = new Rectangle((int)WPol[i]._position.X, (int)WPol[i]._position.Y, WPol[i]._image.Width, WPol[i]._image.Height);
                            }
                            for (int i = 0; i < Signs.Count; i++)
                            {
                                Signs[i]._position.X += 10;
                                Signs[i].hitbox.X += 10;
                            }
                            for (int i = 0; i < Trolls.Count; i++)
                            {
                                Trolls[i]._position.X += 10;
                                Trolls[i].hitbox.X += 10;
                                for (int e = 0; e < Trolls[i].Bullets.Count; e++)
                                {
                                    Trolls[i].Bullets[e].hitbox.X += 10;
                                    Trolls[i].Bullets[e]._position.X += 10;
                                }

                            }
                            for (int i = 0; i < Bullet.Count; i++)
                            {
                                Bullet[i]._position.X += 10;
                            }
                            for (int i = 0; i < PlayerBullets.Count; i++)
                            {
                                player._Bullet._position.X += 10;
                            }
                            for (int i = 0; i < pepe.Count; i++)
                            {
                                pepe[i]._position.X += 10;
                            }
                            for (int i = 0; i < HealthKit.Count; i++)
                            {
                                HealthKit[i]._position.X += 10;
                            }
                            JetPackPowerUp._position.X += 10;
                            JetPackPowerUp.hitbox.X += 10;
                            Door._position.X += 10;
                            Door.hitbox.X += 10;
                        }
                    }



                    base.Update(gameTime);
                }
            }
            lastks = ks;
        }


        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.White);
            
            //spriteBatch.DrawString(Content.Load<SpriteFont>("MOUSE"), player.jumpCount.ToString(), Vector2.Zero, Color.Black);
            //spriteBatch.DrawString(Content.Load<SpriteFont>("MOUSE"), "X:" + ms.X.ToString() + "Y:" + ms.Y.ToString(),new Vector2(0,0),Color.Black);

            Back1.Draw(spriteBatch);
            Back2.Draw(spriteBatch);
            Back3.Draw(spriteBatch);
            Back4.Draw(spriteBatch);
            Back5.Draw(spriteBatch);
            Back6.Draw(spriteBatch);
            Back7.Draw(spriteBatch);
            Back8.Draw(spriteBatch);

            mouse.Draw(spriteBatch);
            for (int i = 0; i < Signs.Count; i++)
            {
                Signs[i].Draw(spriteBatch);
            }

            if (ShowLightning == true)
            {
                Whitepic.Draw(spriteBatch);
                lightning.Draw(spriteBatch);
            }
            for (int i = 0; i < Blocks.Count; i++)
            {
                Blocks[i].Draw(spriteBatch);

            }

            for (int i = 0; i < WPol.Count; i++)
            {
                WPol[i].Draw(spriteBatch);
            }

            for (int i = 0; i < Pol.Count; i++)
            {
                Pol[i].Draw(spriteBatch);
            }
            if (Showsmsg == true)
            {
                Smsg._position.X = Signs[0]._position.X;
                Smsg._position.Y = Signs[0]._position.Y - Smsg._image.Height;
                Smsg.Draw(spriteBatch);
            }
            if (Showsmsg1 == true)
            {
                Smsg1._position.X = Signs[1]._position.X;
                Smsg1._position.Y = Signs[1]._position.Y - Smsg1._image.Height;
                Smsg1.Draw(spriteBatch);
            }
            if (Showmsg2 == true)
            {
                Smsg2._position.X = Signs[2]._position.X;
                Smsg2._position.Y = Signs[2]._position.Y - Smsg2._image.Height;
                Smsg2.Draw(spriteBatch);
            }
            if (Showsmsg3 == true)
            {
                Smsg3._position.X = Signs[3]._position.X - Oldman1._image.Width;
                Smsg3._position.Y = Signs[3]._position.Y - Smsg3._image.Height;
                Smsg3.Draw(spriteBatch);
            }
            for (int i = 0; i < Flags.Count; i++)
            {
                Flags[i].Draw(spriteBatch);
            }
            for (int i = 0; i < Trolls.Count; i++)
            {
                Trolls[i].Draw(spriteBatch, font);
            }

            for (int i = 0; i < Bullet.Count; i++)
            {
                Bullet[i].Draw(spriteBatch);
            }
            for (int i = 0; i < Trolls.Count; i++)
            {
                Trolls[i].Draw(spriteBatch, font);
            }
            for (int i = 0; i < PlayerBullets.Count; i++)
            {
                PlayerBullets[i].Draw(spriteBatch);
            }
            JetPackPowerUp.Draw(spriteBatch);

            for (int i = 0; i < pepe.Count; i++)
            {
                pepe[i].Draw(spriteBatch, font);
            }
            for (int i = 0; i < HealthKit.Count; i++)
            {
                HealthKit[i].Draw(spriteBatch);
            }
            Door.Draw(spriteBatch);

            player.Draw(spriteBatch, font);
            if (doorslides == true)
            {
                Doormsg.Draw(spriteBatch);
            }
            if (Doorslides2 == true)
            {
                Doormsg2.Draw(spriteBatch);
            }
            if (Doorslides3 == true)
            {
                Doormsg3.Draw(spriteBatch);
            }
            if (gateShow == true)
            {
                Gateforgifted.Draw(spriteBatch);
                RightSign.Draw(spriteBatch);
            }
            if (HowtoLockPick == true)
            {

            }
            LockPickScreen.Draw(spriteBatch);
            Block1.Draw(spriteBatch);
            Block2.Draw(spriteBatch);
            Block3.Draw(spriteBatch);
            Block4.Draw(spriteBatch);
            if (LockPickStart == true)
            {

            }
            mouse.Draw(spriteBatch);

            spriteBatch.DrawString(font, "X:" + (ms.X + mouseX) + "Y:" + ms.Y, new Vector2(0, 0), Color.Black);

            if (GameStopped == true && player.lives == 0)
            {
                Gameover.Draw(spriteBatch);
            }

            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
