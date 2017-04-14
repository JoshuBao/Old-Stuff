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
        Sprite preLockMsg;
        int movementAmount = 0;
        Texture2D HK;
        bool killslides = false;
        //BUNCH OF SPRITES HERE 

        bool gateShow = false;


        Sprite backblack;

        Sprite Back1;
        Sprite Back2;
        Sprite Back3;
        Sprite Back4;
        Sprite Back5;
        Sprite Back6;
        Sprite Back7;
        Sprite Back8;

        bool LOLiggy = true;
        //sprite :> fight me irl and ill kill u :) :D :D :D: D:D :D::D:D :D:D:: :D::D:D;

        Sprite GREYB;

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
        Sprite Recieve5;
        Sprite Recieve6;
        Sprite LockPickScreen;

        Sprite Block1;
        Sprite Block2;
        Sprite Block3;
        Sprite Block4;
        Sprite Block5;

        Sprite bp;
        //LOCK PICKING bools
        bool HowtoLockPick = false;
        bool LockPickStart = false;
        bool Rhit1 = false;
        bool Rhit2 = false;
        bool Rhit3 = false;
        bool Rhit4 = false;
        bool Rhit5 = false;
        bool GZm8 = false;
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

        //PLSal
        bool SMSG = false;
        bool BMSG = false;



        Texture2D WpolImg;
        Lightning lightning;
        Lightning Whitepic;

        //sprite pits of LAVA

        //sprite thingy
        Sprite RightSign;



        //pepe Stuff  

        List<Pepe> pepe;

        bool CastlebitStart = false;

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

        bool killslides2 = false;

        //plsLUK
        Sprite Blobmsg;
        Sprite Megabossmsg;

        //flag stuff very cool and important
        List<Sprite> Flags;
        Sprite Flag1;
        // troll stuf
        List<Troll> Trolls;
        bool RIGHT = false;
        bool LEFT = true;
        public static Texture2D pixel;
        //mega boss :>
        MegaBoss rrp;

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
            mouse = new Sprite(Content.Load<Texture2D>("dot"), new Vector2(16666, 290), Color.White);
            //GREBY and mashed potatoes
            GREYB = new Sprite(Content.Load<Texture2D>("NOTACULT"), new Vector2(17732, 18), Color.White);

            //mer fire :>
            Bullet DerFire = new Bullet(Content.Load<Texture2D>("daFire"), new Vector2(-10, -10), Color.White, new Vector2(20, 20), Direction.Right);
            //first boss eva fam 4.1savage
            rrp = new MegaBoss(Content.Load<Texture2D>("Megaboss"), new Vector2(17643, 10), Color.White, DerFire, Direction.Right);


            //msges i!

            Blobmsg = new Sprite(Content.Load<Texture2D>("BlobMsg"), new Vector2(0, 0), Color.White);
            Megabossmsg = new Sprite(Content.Load<Texture2D>("MegaMsg"), Vector2.Zero, Color.White);
            //LOCKPICK

            LockPickScreen = new Sprite(Content.Load<Texture2D>("LockPickScreen"), new Vector2(0, 0), Color.White);
            Recieve1 = new Sprite(Content.Load<Texture2D>("Recieve1"), new Vector2(210, 105), Color.White);
            Recieve2 = new Sprite(Content.Load<Texture2D>("Recieve1"), new Vector2(334, 603), Color.White);
            Recieve3 = new Sprite(Content.Load<Texture2D>("Recieve1"), new Vector2(466, 104), Color.White);
            Recieve4 = new Sprite(Content.Load<Texture2D>("Recieve1"), new Vector2(584, 600), Color.White);
            Recieve5 = new Sprite(Content.Load<Texture2D>("Recieve1"), new Vector2(590, 103), Color.White);
            Recieve6 = new Sprite(Content.Load<Texture2D>("Recieve2"), new Vector2(200, 301), Color.White);

            backblack = new Sprite(Content.Load<Texture2D>("Building Back"), Vector2.Zero, Color.White);

            //grey stuff :(


            Block1 = new Sprite(Content.Load<Texture2D>("GreenBlock"), new Vector2(205, 217), Color.White);
            Block2 = new Sprite(Content.Load<Texture2D>("RedBlock"), new Vector2(304, 270), Color.White);
            Block3 = new Sprite(Content.Load<Texture2D>("YellowBlock"), new Vector2(403, 212), Color.White);
            Block4 = new Sprite(Content.Load<Texture2D>("OrangeBlock"), new Vector2(502, 238), Color.White);
            Block5 = new Sprite(Content.Load<Texture2D>("BlueBlock"), new Vector2(597, 280), Color.White);
            bp = new Sprite(Content.Load<Texture2D>("bp"), new Vector2(828, 323), Color.White);
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
            Gateforgifted = new Sprite(Content.Load<Texture2D>("gate"), new Vector2(17225, 0), Color.White);
            preLockMsg = new Sprite(Content.Load<Texture2D>("prelockbookmsg"), new Vector2(0, 0), Color.White);
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

            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(8500, 0), Color.White, Trollbullet, Direction.Right));
            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(9000, 900), Color.White, Trollbullet, Direction.Right));
            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(9500, 0), Color.White, Trollbullet, Direction.Right));
            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(10400, 900), Color.White, Trollbullet, Direction.Right));
            Trolls.Add(new Troll(Content.Load<Texture2D>("Troll"), new Vector2(10900, 0), Color.White, Trollbullet, Direction.Right));
            for (int i = 0; i < Trolls.Count; i++)
            {
                Trolls[i].Settimespan(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(100));
            }

            //pepe army
            pepe = new List<Pepe>();
            Bullet pepeBullet = new Bullet(Content.Load<Texture2D>("TEARBULLET"), new Vector2(0, 0), Color.White, new Vector2(-10, 0), Direction.Left);
            Texture2D pepeimage = Content.Load<Texture2D>("pepeFOR REALS");
            pepe.Add(new Pepe(pepeimage, new Vector2(12318, 97), Color.White, pepeBullet, Direction.Right));
            pepe.Add(new Pepe(pepeimage, new Vector2(12571, 355), Color.White, pepeBullet, Direction.Right));
            pepe.Add(new Pepe(pepeimage, new Vector2(12855, 249), Color.White, pepeBullet, Direction.Right));
            pepe.Add(new Pepe(pepeimage, new Vector2(13323, 259), Color.White, pepeBullet, Direction.Right));
            pepe.Add(new Pepe(pepeimage, new Vector2(13608, 199), Color.White, pepeBullet, Direction.Right));
            pepe.Add(new Pepe(pepeimage, new Vector2(14015, 258), Color.White, pepeBullet, Direction.Right));
            pepe.Add(new Pepe(pepeimage, new Vector2(14515, 131), Color.White, pepeBullet, Direction.Right));
            pepe.Add(new Pepe(pepeimage, new Vector2(15012, 47), Color.White, pepeBullet, Direction.Right));
            pepe.Add(new Pepe(pepeimage, new Vector2(15413, 247), Color.White, pepeBullet, Direction.Right));
            for (int i = 0; i < pepe.Count; i++)
            {
                pepe[i].Settimespan(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(1));
            }
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
                    Door.Position.X -= 140000;

                }
            }

            //LOCKPICKKKKKKKK
            if (player.Hitbox.Intersects(Gateforgifted.Hitbox))
            {
                GameStopped = true;
                HowtoLockPick = true;

            }

            if (HowtoLockPick == true && ks.IsKeyDown(Keys.C))
            {
                LockPickStart = true;
            }
            if (LockPickStart == true)
            {
                if (Rhit1 == false)
                {
                    if (Rhit1 == false && ks.IsKeyDown(Keys.Up))
                    {
                        Block1.Position.Y -= 10;
                    }
                    if (Rhit1 == false && ks.IsKeyDown(Keys.Down))
                    {
                        Block1.Position.Y += 10;
                    }
                }
                else if (Rhit1 == true && Rhit2 == false)
                {
                    if (ks.IsKeyDown(Keys.Up))
                    {
                        Block2.Position.Y -= 10;
                    }
                    if (ks.IsKeyDown(Keys.Down))
                    {
                        Block2.Position.Y += 10;
                    }
                }
                else if (Rhit2 == true && Rhit3 == false)
                {
                    if (ks.IsKeyDown(Keys.Up))
                    {
                        Block3.Position.Y -= 10;
                    }
                    if (ks.IsKeyDown(Keys.Down))
                    {
                        Block3.Position.Y += 10;
                    }
                }
                else if (Rhit3 == true && Rhit4 == false)
                {
                    if (ks.IsKeyDown(Keys.Up))
                    {
                        Block4.Position.Y -= 10;
                    }
                    if (ks.IsKeyDown(Keys.Down))
                    {
                        Block4.Position.Y += 10;
                    }
                }
                else if (Rhit4 == true && Rhit5 == false)
                {
                    if (ks.IsKeyDown(Keys.Up))
                    {
                        Block5.Position.Y -= 10;
                    }
                    if (ks.IsKeyDown(Keys.Down))
                    {
                        Block5.Position.Y += 10;
                    }

                }
                else if (Rhit5 == true && GZm8 == false)
                {
                    if (ks.IsKeyDown(Keys.Left))
                    {
                        bp.Position.X -= 10;
                    }
                    if (ks.IsKeyDown(Keys.Right))
                    {
                        bp.Position.X += 10;
                    }
                }

                if (Block1.Hitbox.Intersects(Recieve1.Hitbox))
                {
                    Rhit1 = true;
                }
                if (Block2.Hitbox.Intersects(Recieve2.Hitbox))
                {
                    Rhit2 = true;
                }
                if (Block3.Hitbox.Intersects(Recieve3.Hitbox))
                {
                    Rhit3 = true;
                }
                if (Block4.Hitbox.Intersects(Recieve4.Hitbox))
                {
                    Rhit4 = true;
                }
                if (Block5.Hitbox.Intersects(Recieve5.Hitbox))
                {
                    Rhit5 = true;
                }
                if (bp.Hitbox.Intersects(Recieve6.Hitbox))
                {
                    GZm8 = true;
                }
            }
            if (GZm8 == true)
            {
                LockPickStart = false;
                HowtoLockPick = false;
                GameStopped = false;
                killslides2 = false;
                Gateforgifted.Position.Y -= 9000;
                //Need a better way of walking through a gate
            }
            if (player.Hitbox.Intersects(GREYB.Hitbox))
            {
                GameStopped = true;
                LOLiggy = false;
                SMSG = true;
                CastlebitStart = true;

                GREYB.Position.Y += 9000;   //Hmmm.. maybe think of a better method of "getting rid of it"

            }
            if (killslides2 == false)
            {
                if (ks.IsKeyDown(Keys.C) && lastks.IsKeyUp(Keys.C) && BMSG == false && CastlebitStart == true)
                {
                    SMSG = false;
                    BMSG = true;
                }


                else if (ks.IsKeyDown(Keys.C) && lastks.IsKeyUp(Keys.C) && BMSG == true && killslides2 == false)
               {
                    SMSG = false;
                    BMSG = false;
                    GZm8 = false;
                    killslides2 = true;
                    GameStopped = false;
                }



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

                //CastlebitStart = true;

                //Trolls take damage from player
                if (Trumpslides == false)
                {

                    if (player.Hitbox.Intersects(Door.Hitbox))
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


                        if (PlayerBullets[i].Position.X <= 0)
                        {
                            PlayerBullets.RemoveAt(i);
                            i--;
                        }
                        else if (PlayerBullets[i].Position.X >= 900)
                        {
                            PlayerBullets.RemoveAt(i);
                            i--;
                        }
                        else if (PlayerBullets[i].Hitbox.Intersects(Trolls[f].Hitbox))
                        {
                            Trolls[f]._Health -= 7;
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
                        if (pepe[i]._Health <= 0)
                        {
                            pepe.Remove(pepe[i]);
                            i--;
                        }
                    }
                    //Player Takes Damage from trolls
                    for (int e = 0; e < Trolls.Count; e++)
                    {

                        for (int j = 0; j < Trolls[e]._Bullets.Count; j++)
                        {
                            if (Trolls[e]._Bullets[j].Hitbox.Intersects(player.Hitbox))
                            {
                                player.Health -= 8;
                                player.Color = Color.Red;
                                Trolls[e]._Bullets.Remove(Trolls[e]._Bullets[j]);
                                activeTimer = TimeSpan.Zero;
                                j--;
                            }
                            else if (damageTimer < activeTimer)
                            {
                                player.Color = Color.White;
                            }
                        }
                    }
                }
                // trolls can die now
                for (int i = 0; i < Trolls.Count; i++)
                {
                    if (Trolls[i]._Health <= 0)
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
                        if (PlayerBullets[i].Position.X <= 0)
                        {
                            PlayerBullets.Remove(PlayerBullets[i]);
                            i--;
                        }
                        else if (PlayerBullets[i].Position.X >= 860)
                        {
                            PlayerBullets.Remove(PlayerBullets[i]);
                            i--;
                        }
                        else if (PlayerBullets[i].Hitbox.Intersects(pepe[f].Hitbox))
                        {
                            pepe[f]._Health -= 7;
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

                    for (int j = 0; j < pepe[e]._Bullets.Count; j++)
                    {
                        if (pepe[e]._Bullets[j].Hitbox.Intersects(player.Hitbox))
                        {
                            player.Health -= 8;
                            player.Color = Color.Red;
                            pepe[e]._Bullets.Remove(pepe[e]._Bullets[j]);
                            activeTimer = TimeSpan.Zero;
                            j--;
                        }
                        else if (damageTimer < activeTimer)
                        {
                            player.Color = Color.White;
                        }
                    }
                }
                for (int i = 0; i < Blocks.Count; i++)
                {
                    for (int e = 0; e < PlayerBullets.Count; e++)
                    {
                        if (PlayerBullets[e].Hitbox.Intersects(Blocks[i].Hitbox))
                        {
                            PlayerBullets.Remove(PlayerBullets[e]);
                            e--;
                        }
                    }
                }
                //PEPE HITBOX
                for (int e = 0; e < pepe.Count; e++)
                {

                    for (int j = 0; j < pepe[e]._Bullets.Count; j++)
                    {
                        if (pepe[e]._Bullets[j].Hitbox.Intersects(player.Hitbox))
                        {
                            player.Health -= 8;
                            player.Color = Color.Red;
                            pepe[e]._Bullets.Remove(pepe[e]._Bullets[j]);

                            activeTimer = TimeSpan.Zero;
                            j--;
                        }
                        else if (damageTimer < activeTimer)
                        {
                            player.Color = Color.White;
                        }
                    }
                }
                //Condition made for flying
                if (Trumpjumpcount)
                {
                    player.jumpCount = 0;
                }
                mouse.Position.X = ms.X;
                mouse.Position.Y = ms.Y;
                // lastks = Keyboard.GetState();

                player.Update();
                lightning.Position.Y = player.Position.Y - 460;

                if (ks.IsKeyDown(Keys.Up) && lastks.IsKeyUp(Keys.Up))
                {
                    player.moveUp();
                }

                int touchCounter = 0;

                if (player.Hitbox.Intersects(Signs[0].Hitbox))
                {
                    Showsmsg = true;
                }
                else
                {
                    Showsmsg = false;
                }
                if (player.Hitbox.Intersects(Signs[1].Hitbox))
                {
                    Showsmsg1 = true;
                }
                else
                {
                    Showsmsg1 = false;
                }
                if (player.Hitbox.Intersects(Signs[2].Hitbox))
                {
                    Showmsg2 = true;
                }
                else
                {
                    Showmsg2 = false;
                }
                if (player.Hitbox.Intersects(Signs[3].Hitbox))
                {
                    Showsmsg3 = true;
                }
                else
                {
                    Showsmsg3 = false;
                }
                for (int i = 0; i < WPol.Count; i++)
                {
                    if (player.BHitbox.Intersects(WPol[i].Hitbox))
                    {
                        player.touchpit = true;

                        if (player.Position.Y >= 616)
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

                    if (player.Position.X >= WPol[i].Position.X + WPol[i].Image.Width || player.touchpit == true)
                    {
                        //player._position.Y = WPol[i]._position.X + WPol[i]._image.Width;
                    }
                    if (player.Position.X <= WPol[i].Position.X || player.touchpit == true)
                    {
                        //player._position.Y = WPol[i]._position.Y;
                    }


                }
                for (int i = 0; i < Trolls.Count; i++)
                {
                    Trolls[i].Update(gameTime, Bullet);
                }

                if (player.Position.Y >= 700)
                {
                    player.Health -= 1;
                }

                for (int i = 0; i < PlayerBullets.Count; i++)
                {
                    PlayerBullets[i].Position += PlayerBullets[i]._speed;
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
                    if (Blocks[i].Hitbox.Intersects(player.THitbox))
                    {
                        player.Position.Y = Blocks[i].Position.Y + player.Image.Height;
                        player.jumpSpeed = 0;
                        player.jumpCount = int.MaxValue;
                    }
                    if (Blocks[i].Hitbox.Intersects(player.BHitbox))
                    {
                        player.Position.Y = Blocks[i].Position.Y - player.Image.Height;
                        player.jumpCount = 0;
                    }

                    if (Blocks[i].Hitbox.Intersects(player.LHitbox))
                    {
                        float blockSpeed = Blocks[i].Position.X + Blocks[i].Image.Width - player.Position.X;
                        LEFT = true;
                        for (int e = 0; e < Blocks.Count; e++)
                        {
                            Blocks[e].Position.X -= blockSpeed;
                        }


                    }
                    else
                    {
                        LEFT = false;
                    }
                    if (Blocks[i].Hitbox.Intersects(player.RHitbox))
                    {
                        float blockSpeed = Blocks[i].Position.X - player.Image.Width - player.Position.X;
                        RIGHT = true;
                        for (int e = 0; e < Blocks.Count; e++)
                        {
                            Blocks[e].Position.X -= blockSpeed;
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

                        PlayerBullets.Add(new Bullet(player._Bullet.Image, player.Position, player._Bullet.Color, player._Bullet._speed, player.Direction));
                        for (int i = 0; i < PlayerBullets.Count; i++)
                        {
                            PlayerBullets[i].Position -= PlayerBullets[i]._speed;

                        }
                    }
                    else
                    {
                        PlayerBullets.Add(new Bullet(player._Bullet.Image, player.Position, player._Bullet.Color, -player._Bullet._speed, player.Direction));
                        for (int i = 0; i < PlayerBullets.Count; i++)
                        {
                            PlayerBullets[i].Position -= PlayerBullets[i]._speed;

                        }
                    }

                }
                if (CastlebitStart == true)
                {
                    if (ks.IsKeyDown(Keys.Space) && lastks.IsKeyUp(Keys.Space))
                    {
                        if (player.effect == SpriteEffects.None)
                        {

                            PlayerBullets.Add(new Bullet(player._Bullet.Image, player.Position, player._Bullet.Color, player._Bullet._speed, player.Direction));
                            for (int i = 0; i < PlayerBullets.Count; i++)
                            {
                                PlayerBullets[i].Position -= PlayerBullets[i]._speed;

                            }
                        }
                        else
                        {
                            PlayerBullets.Add(new Bullet(player._Bullet.Image, player.Position, player._Bullet.Color, -player._Bullet._speed, player.Direction));
                            for (int i = 0; i < PlayerBullets.Count; i++)
                            {
                                PlayerBullets[i].Position -= PlayerBullets[i]._speed;

                            }
                        }

                    }
                    if (player.Position.X <= 0)
                    {
                        player.Position.X = 0;
                    }
                    if (player.Position.Y <= 0)
                    {
                        player.Position.Y = 0;
                    }
                    if (player.Position.X + player.Image.Width >= GraphicsDevice.Viewport.Width)
                    {
                        player.Position.X = GraphicsDevice.Viewport.Width - player.Image.Width;
                    }
                }
                if (ks.IsKeyDown(Keys.Left) && CastlebitStart == true)
                {
                    player.effect = SpriteEffects.FlipHorizontally;
                    player.Direction = Direction.Left;
                    player.Position.X -= 10;
                }
                if (ks.IsKeyDown(Keys.Right) && CastlebitStart == true)
                {
                    player.effect = SpriteEffects.None;
                    player.Direction = Direction.Right;
                    player.Position.X += 10;
                }
                if (CastlebitStart == false)
                {
                    if (LEFT == false)
                    {
                        if (ks.IsKeyDown(Keys.Right))
                        {
                            mouseX += 10;
                            Gateforgifted.Position.X -= 10;
                            player.effect = SpriteEffects.None;
                            player.Direction = Direction.Right;
                            RightSign.Position.X -= 10;
                            //player.
                            rrp.Position.X -= 10;
                            GREYB.Position.X -= 10;
                            movementAmount++;
                            for (int i = 0; i < Pol.Count; i++)
                            {
                                Pol[i].Position.X -= 10;
                            }
                            for (int i = 0; i < Blocks.Count; i++)
                            {
                                Blocks[i].Position.X -= 10;
                            }
                            for (int i = 0; i < WPol.Count; i++)
                            {
                                WPol[i].Position.X -= 10;
                            }
                            for (int i = 0; i < Signs.Count; i++)
                            {
                                Signs[i].Position.X -= 10;
                            }
                            for (int i = 0; i < Trolls.Count; i++)
                            {
                                Trolls[i].Position.X -= 10;
                                for (int e = 0; e < Trolls[i]._Bullets.Count; e++)
                                {
                                    Trolls[i]._Bullets[e].Position.X -= 10;
                                }
                            }
                            for (int i = 0; i < Bullet.Count; i++)
                            {
                                Bullet[i].Position.X -= 10;
                            }
                            for (int i = 0; i < PlayerBullets.Count; i++)
                            {
                                player._Bullet.Position.X -= 10;
                            }
                            for (int i = 0; i < pepe.Count; i++)
                            {
                                pepe[i].Position.X -= 10;
                            }
                            for (int i = 0; i < HealthKit.Count; i++)
                            {
                                HealthKit[i].Position.X -= 10;
                            }
                            JetPackPowerUp.Position.X -= 10;
                            Door.Position.X -= 10;
                        }
                        //imphealth
                        for (int i = 0; i < HealthKit.Count; i++)
                        {
                            if (player.Hitbox.Intersects(HealthKit[i].Hitbox))
                            {
                                player.Health += 20;
                                HealthKit.RemoveAt(i);
                            }

                        }

                        if (player.Hitbox.Intersects(JetPackPowerUp.Hitbox))
                        {
                            Trumpjumpcount = true;
                            JetPackPowerUp.Position.Y = -434;
                            //JetPackPowerUp.Hitbox.Y = -378;       //Hitbox position differs from sprite position (!!!) for some reason (???)
                        }
                    }

                    if (CastlebitStart == false)
                    {
                        if (RIGHT == false)
                        {
                            if (ks.IsKeyDown(Keys.Left) && movementAmount > 0)
                            {
                                mouseX -= 10;
                                player.effect = SpriteEffects.FlipHorizontally;
                                player.Direction = Direction.Left;
                                movementAmount--;
                                GREYB.Position.X += 10;
                                rrp.Position.X += 10;
                                Gateforgifted.Position.X += 10;
                                RightSign.Position.X += 10;
                                for (int i = 0; i < Pol.Count; i++)
                                {
                                    Pol[i].Position.X += 10;
                                }
                                for (int i = 0; i < Blocks.Count; i++)
                                {
                                    Blocks[i].Position.X += 10;
                                }
                                for (int i = 0; i < WPol.Count; i++)
                                {
                                    WPol[i].Position.X += 10;
                                }
                                for (int i = 0; i < Signs.Count; i++)
                                {
                                    Signs[i].Position.X += 10;
                                }
                                for (int i = 0; i < Trolls.Count; i++)
                                {
                                    Trolls[i].Position.X += 10;

                                    for (int e = 0; e < Trolls[i]._Bullets.Count; e++)
                                    {
                                        Trolls[i]._Bullets[e].Position.X += 10;
                                    }

                                }
                                for (int i = 0; i < Bullet.Count; i++)
                                {
                                    Bullet[i].Position.X += 10;
                                }
                                for (int i = 0; i < PlayerBullets.Count; i++)
                                {
                                    player._Bullet.Position.X += 10;
                                }
                                for (int i = 0; i < pepe.Count; i++)
                                {
                                    pepe[i].Position.X += 10;
                                }
                                for (int i = 0; i < HealthKit.Count; i++)
                                {
                                    HealthKit[i].Position.X += 10;
                                }
                                JetPackPowerUp.Position.X += 10;
                                Door.Position.X += 10;
                            }
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
                Smsg.Position.X = Signs[0].Position.X;
                Smsg.Position.Y = Signs[0].Position.Y - Smsg.Image.Height;
                Smsg.Draw(spriteBatch);
            }
            if (Showsmsg1 == true)
            {
                Smsg1.Position.X = Signs[1].Position.X;
                Smsg1.Position.Y = Signs[1].Position.Y - Smsg1.Image.Height;
                Smsg1.Draw(spriteBatch);
            }
            if (Showmsg2 == true)
            {
                Smsg2.Position.X = Signs[2].Position.X;
                Smsg2.Position.Y = Signs[2].Position.Y - Smsg2.Image.Height;
                Smsg2.Draw(spriteBatch);
            }
            if (Showsmsg3 == true)
            {
                Smsg3.Position.X = Signs[3].Position.X - Oldman1.Image.Width;
                Smsg3.Position.Y = Signs[3].Position.Y - Smsg3.Image.Height;
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
            
            if (CastlebitStart == true)
            {               
                backblack.Draw(spriteBatch);
                rrp.Draw(spriteBatch);
            }
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
            if (gateShow == true && CastlebitStart == false)
            {
                Gateforgifted.Draw(spriteBatch);
                RightSign.Draw(spriteBatch);
            }

            if (HowtoLockPick == true)
            {
                preLockMsg.Draw(spriteBatch);
            }
            if (LockPickStart == true)
            {
                Recieve1.Draw(spriteBatch);
                Recieve2.Draw(spriteBatch);
                Recieve3.Draw(spriteBatch);
                Recieve4.Draw(spriteBatch);
                Recieve5.Draw(spriteBatch);
                Recieve6.Draw(spriteBatch);
                LockPickScreen.Draw(spriteBatch);
                Block1.Draw(spriteBatch);
                Block2.Draw(spriteBatch);
                Block3.Draw(spriteBatch);
                Block4.Draw(spriteBatch);
                Block5.Draw(spriteBatch);
                bp.Draw(spriteBatch);
            }

            if (LOLiggy == true)
            {
                GREYB.Draw(spriteBatch);
            }
            if (SMSG == true)
            {
                Megabossmsg.Draw(spriteBatch);
            }
            else if (BMSG == true)
            {
                Blobmsg.Draw(spriteBatch);
            }
            mouse.Draw(spriteBatch);
            for (int i = 0; i < Bullet.Count; i++)
            {
                Bullet[i].Draw(spriteBatch);
            }
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
