using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

class Rectanglee
{
    public int X, Y;
    public Bitmap Img;

    public Rectanglee(int x, int y, Bitmap img)
    {
        X = x;
        Y = y;
        Img = img;
    }
}
class Plane
{
    public int X, Y, W, H;
    public int OriginalX;
    public Bitmap Img;
    public string Type;
    public int Life,MaxHealth, HealthBarWidth;
    Rectangle HealthBar;
    Boolean HasBar;
    public HealthBar HealthBarr;
    public Plane(int x, int y, Bitmap img, string type, int life, int maxhealth, int barwidth, Rectangle healthbar, bool hasbar)
    {
        X = x;
        Y = y;
        Img = img;
        W = img.Width;  
        H = img.Height; 
        Type = type;
        OriginalX = x;
        Life = life;
        MaxHealth = maxhealth;
        HealthBarWidth = barwidth;
        HasBar = hasbar;
        if (HasBar)
        {
            HealthBarr = new HealthBar(healthbar.X, healthbar.Y, healthbar.Width, healthbar.Height, maxhealth);
        }
    }
}
class Bullets
{
    public int X, Y, W, H;
    public string type;
    public Bitmap Img;
    public Bullets(int x, int y, string T )
    {
        X = x;
        Y = y;
        type = T;
        switch (type)
        {
            case "L":
                Img = new Bitmap("Lbullet.png");
                W = new Bitmap("bullet.png").Width;
                H = new Bitmap("bullet.png").Height;
                break;
            case "M":
                Img = new Bitmap("bullet.png");
                W = new Bitmap("bullet.png").Width;
                H = new Bitmap("bullet.png").Height;
                break;
            case "R":
                Img = new Bitmap("Rbullet.png");
                W = new Bitmap("bullet.png").Width;
                H = new Bitmap("bullet.png").Height;
                break;
            case "enemy3L": case "enemy3M": case "enemy3R":
                Img = new Bitmap("redBullet.png");
                W = new Bitmap("redBullet.png").Width;
                H = new Bitmap("redBullet.png").Height;
                break;
            case "SuperBulletsL1":
                Img = new Bitmap("SuperBulletsL1.png");
                W = new Bitmap("SuperBulletsL1.png").Width/2;
                H = new Bitmap("SuperBulletsL1.png").Height;
                break;
            case "SuperBulletsL2":
                Img = new Bitmap("SuperBulletsL2.png");
                W = new Bitmap("SuperBulletsL2.png").Width/2;
                H = new Bitmap("SuperBulletsL2.png").Height;
                break;
            case "SuperBulletsR1":
                Img = new Bitmap("SuperBulletsR1.png");
                W = new Bitmap("SuperBulletsR1.png").Width / 2;
                H = new Bitmap("SuperBulletsR1.png").Height;
                break;
            case "SuperBulletsR2":
                Img = new Bitmap("SuperBulletsR1.png");
                W = new Bitmap("SuperBulletsR1.png").Width / 2;
                H = new Bitmap("SuperBulletsR1.png").Height;
                break;
            case "SuperBulletsMid":
                Img = new Bitmap("SuperBulletsMid.png");
                W = new Bitmap("SuperBulletsMid.png").Width/ 2;
                H = new Bitmap("SuperBulletsMid.png").Height;
                break;
        }

    }
}
class Coin
{
    public int X, Y;
    public Bitmap Img;
    public Coin(int x, int y, Bitmap img)
    {
        X = x; Y = y; Img = img;
    }
}
class HealthBar
{
    public int X, Y, Width, Height;
    public int MaxHealth;
    public int CurrentHealth;

    public HealthBar(int x, int y, int width, int height, int maxHealth)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth; 
    }
}
class Explosion
{
    public int X, Y, W, H,iframe;
    public List<Bitmap> Imgs;
    public string Type;
    public Explosion(int x,int y, string type)
    {
        Type = type;
        Imgs = new List<Bitmap>(); iframe = 0;
        for (int i = 0; i < 8; i++)
        {
            Bitmap monem = new Bitmap("explosion/"+i+".png");
            Imgs.Add(monem);
        }
        X = x;Y = y;
    }
}
class AdvancedImage
{
    public int W, H;
    public Rectangle Rects, Rectd;
    public Bitmap Img;
    public AdvancedImage(int w, int h, Rectangle rects, Rectangle rectd, Bitmap img)
    {
        W = w;
        H = h;
        Rects = rects;
        Rectd = rectd;
        Img = img;
    }
}
class Helicopter
{
    public int X, Y, W, H, iframe;
    public List<Bitmap> Imgs;
    public string Type;
    Rectangle HealthBar;
    public int Life, MaxHealth, HealthBarWidth;
    Boolean HasBar;
    public HealthBar HealthBarr;

    public Helicopter(int x, int y, string type ,int lifee, int maxhealth, int barwidth, Rectangle healthbar, bool hasbar)
    {
        X = x; Y = y;
        Type = type;
        Imgs = new List<Bitmap>(); iframe = 0;
        Life = lifee;
        MaxHealth = maxhealth;
        HealthBarWidth = barwidth;
        HasBar = hasbar;
        if (HasBar)
        {
            HealthBarr = new HealthBar(healthbar.X, healthbar.Y, healthbar.Width, healthbar.Height, maxhealth);
        }
        for (int i = 1; i < 3; i++)
        {
            Bitmap monem = new Bitmap("Helicopter/h" + i + ".png");
            Imgs.Add(monem);
        }
        
    }
}


namespace _1945_Air_Force
{
    public partial class Form1 : Form
    {
        
        int heroMaxHealth = 400; int healthBarWidth = 200; float monemmm;
        int Xplane = 700, Yplane = 600, SpeedHeroBullets = 20, SpeedEnmy1 = 30, SpeedEnmyBullets = 20, SpeedEnmy3 = 20, spdEnmy4 = 7;
        List<Plane> P = new List<Plane>(); List<Bullets> B = new List<Bullets>();
        List<Plane> EP = new List<Plane>(); List<Rectanglee> R = new List<Rectanglee>();
        List<Coin> C = new List<Coin>(); List<Bullets> EB = new List<Bullets>(); List<Helicopter> H = new List<Helicopter>();
        List<Explosion> E = new List<Explosion>(); List<AdvancedImage> L1 = new List<AdvancedImage>();
        Bitmap off; Timer tt = new Timer(); Bitmap AirForce = new Bitmap("AirForce.jpg");
        bool Flag_Super_Bullets_Appear = true, Flag_Super_Bullets = false;
        int Ct_CreateHeroBullets = 0, ct = 0, CtCreateEnemy = 0, ctCoins = 0, ctttt = 0, Ct_Enmy3Bullets = 0, CtEnemies = 91, ctKilled = 0, ctsuperBullets = 0;
        int border1, border2, BrdrA = 500, BrdrC = 1040, BrdrB = 770, flagend = 0;int Brdrstart= 500;
        //Damge 
        int Dmg_fromenmy1 = 5, Dmg_fromenmy3 = 10;
        //Life
        Coin coin3;
        //helicopter flag
        int moveDistance = 60;
        int movedPixels = 0;
        int speedH = 6;
        string currentDirection = "right";
        int DistancetoCollectCoins = 40 ,speedCollect=28;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.KeyDown += Form1_KeyDown;
            tt.Tick += Tt_Tick; tt.Interval = 100;
            border1 = 450; border2 = 1100;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.R:
                    InitializeGame();
                    break;
                case Keys.Space:
                    if (Flag_Super_Bullets_Appear)
                    {
                        Flag_Super_Bullets=true;
                        Flag_Super_Bullets_Appear = false;
                        ctsuperBullets = 0;
                    }
                    break;
            }
            Tick();
            DrawDubb(CreateGraphics());
        }
        private void Tt_Tick(object sender, EventArgs e)
        {
            Tick();
            DrawDubb(CreateGraphics());
        }
        void Tick()
        {
            CtCreateEnemy++;
            if (CtCreateEnemy % 50 == 0)
            {
                CreateEnemyPlane();
            }
            monemmm = ((float)ctKilled / CtEnemies) * 100;
            MoveEnmy();
            MoveCoins();
            CreateHeroBullets();
            MoveHeroBullets();
            CheckCollectCoins();
            CreateEnmyBullets();
            MoveEnmyBullets();
            MangeExplosion();

            DamgeHero();
            MoveBackground();
            MangeSuperBullets();
        }
        void MangeSuperBullets()
        {
            
            if (Flag_Super_Bullets)
                {
                    if (ctsuperBullets > 101)
                    {
                        Flag_Super_Bullets = false;
                        ctsuperBullets = -100;
                    }
                    ctsuperBullets++;
                }
                else if (!Flag_Super_Bullets_Appear)
                {
                    ctsuperBullets++;
                    if (ctsuperBullets > 0)
                    {
                        Flag_Super_Bullets_Appear = true;
                        ctsuperBullets = 0;
                    }
                }

            }
        
        void MoveBackground()
        {
            if(L1[0].Rects.Y>0)
            L1[0].Rects.Y--;

        }
        void CreateEnemyPlane()
        {
            ct++;
            switch (ct)
            {
                case 1:
                    CreateEnmyLogic(4, 10);
                    break;
                case 2:
                    CreateEnmyLogic(5, 12);
                    break;
                case 3:
                    break;
                case 4:

                    break;
                case 5:
                  CreateEnmyLogic(3, 1);

                    break;
                case 6:
                   CreateEnmyLogic(1, 5);
                    break;
                case 7:
                    CreateEnmyLogic(2, 5);
                    break;
                case 8:
                    CreateEnmyLogic(4, 10);
                    CreateEnmyLogic(5, 12);
                    break;
                case 9:
                    break;
                case 10:
                    CreateEnmyLogic(3, 1);
                    CreateEnmyLogic(7, 1);
                   // flagtayrteen = 1;
                    break;
                case 11:
                    CreateEnmyLogic(7, 1);
                   
                    break;
                case 12:
                    CreateEnmyLogic(8, 1);

                    break;
                case 17:
                    CreateEnmyLogic(6, 1);
                    break;
                case 20:
                    GameOver();
                    break;
            }

        }
        void CreateEnmyLogic(int enmyType,int ct)
        {
            switch(enmyType)
            {
                case 1:

                    int x = border1 + 300, y = 20;
                    for (int i = 0; i < ct; i++)
                    {
                        Plane plaane = new Plane(x, y, new Bitmap("planes/EWhite.png"), "enemy1", 15, 15, 0, new Rectangle(0, 0, 0, 0), false);
                        EP.Add(plaane);
                        y += new Bitmap("planes/EWhite.png").Height;
                        x += 25; y -= 150;
                        if (i % 5==0) { x=border1 + 300; y = 20; }
                    }
                    break;
                case 2:
                    int xx = border2 - 430, yy = 50;
                    for (int i = 0; i < ct; i++)
                    {
                        Plane planew = new Plane(xx, yy, new Bitmap("planes/EWhite.png"), "enemy2", 15, 15, 0, new Rectangle(0, 0, 0, 0), false);
                        EP.Add(planew);
                        xx -= 25;
                        yy -= 150;
                        if (i % 5==0) { xx = border2 - 460; yy = 50; }
                    }
                    break;
                case 3:
                    {
                        int xxx = 700, yyy = -20;
                        for (int i = 0; i < ct; i++)
                        {
                            Plane planeq = new Plane(xxx, yyy, new Bitmap("planes/plane4.png"), "enemy3", 350, 350, 100, new Rectangle(800, 0, 50, 5), true);
                            EP.Add(planeq);
                            //if (i % 1==0) { xxx = 550;yyy = -80; }
                            yyy -= new Bitmap("planes/plane4.png").Height;
                        }
                    }
                    break;
                case 4:
                    x = BrdrB; y = 20;
                    for (int i = 0; i < ct; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                y -= new Bitmap("planes/plane2.png").Height * 3;
                                break;
                            case 2:
                                y += new Bitmap("planes/plane2.png").Height * 2;
                                x = BrdrB + 40;
                                break;
                            case 3:
                                y -= new Bitmap("planes/plane2.png").Height;
                                x = BrdrB + 40;
                                break;
                            case 4:
                                y = 20;
                                x = BrdrB + 180;
                                break;
                            case 5:
                                y -= new Bitmap("planes/plane2.png").Height * 3;
                                break;  
                            case 6:
                                y += new Bitmap("planes/plane2.png").Height * 2;
                                x = BrdrB + 160;
                                break;
                            case 7:
                                y -= new Bitmap("planes/plane2.png").Height;
                                x = BrdrB + 160;
                                break;
                            case 8:
                                y = -70;
                                x = (BrdrB + BrdrC )/ 2 -30;
                                break;
                            case 9:
                                y = -20;
                                x =( BrdrB + BrdrC )/ 2-30;
                                break;
                        }
                        Plane plaane = new Plane(x, y, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB+10, 0, 35, 5), true);
                        EP.Add(plaane);
                    }
                    break;
                case 5:
                    x = BrdrA+7; y = 0;
                    for (int i = 0; i < ct; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                y -= new Bitmap("planes/plane2.png").Height * 3-20;
                                break;
                            case 2:
                                y -= new Bitmap("planes/plane2.png").Height * 2 - 20;
                                x = BrdrA+7 ;
                                break;
                            case 3:
                                y -= new Bitmap("planes/plane2.png").Height - 20;
                                x = BrdrA+7 + 20;
                                break;
                            case 4:
                                y = 0 - 20;
                                x = BrdrA +87;
                                break;
                           
                            case 5:
                                y -= new Bitmap("planes/plane2.png").Height * 3 - 20;
                                x = BrdrA + 7;
                                break;
                            case 7:
                                y -= new Bitmap("planes/plane2.png").Height +100;
                                x = BrdrA + 97;
                                break;
                            case 8:
                                y = 20;
                                x = (BrdrA + BrdrB) / 2 - 83;
                                break;
                            case 9:
                                y = -505;
                                x =  BrdrB;
                                break;
                            case 10:
                                y = -505;
                                x = BrdrB-53;
                                break;
                        }
                        Plane plaane = new Plane(x, y, new Bitmap("planes/Eyellow.png"), "enemy4", 15, 15, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                        EP.Add(plaane);
                    }
                    break;
                case 6:
                    x = BrdrA - 20;
                    for (int i=0;i<ct;i++)
                    {
                        Helicopter monem = new Helicopter(BrdrA-40,250,"1", 570,570, 100, new Rectangle(800, 0, 50, 5), true);
                        H.Add(monem);
                        x = BrdrC + 40;
                    }
                    break;
                case 7:
                    {
                        int xxx = 700, yyy =-20- new Bitmap("planes/plane4.png").Height;
                        for (int i = 0; i < ct; i++)
                        {
                            Plane planeq = new Plane(xxx, yyy, new Bitmap("planes/plane5.png"), "h", 350, 350, 100, new Rectangle(800, 0, 50, 5), true);
                            EP.Add(planeq);
                            //if (i % 1==0) { xxx = 550;yyy = -80; }
                            yyy -= new Bitmap("planes/plane4.png").Height;
                        }
                    }
                    break;
                case 8:
                    {
                        int xxx = Brdrstart;
                        int yyy = 0;
                        //  0
                        {
                            Plane plaane = new Plane(Brdrstart+(50 * 5), yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                            EP.Add(plaane);
                        }
                        //   1
                        {
                            yyy -= new Bitmap("planes/EWhite.png").Height;
                            xxx = Brdrstart += 50;
                            for (int i = 0; i < 4; i++)
                            {
                                Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                                EP.Add(plaane);
                                xxx += 228 * 2;
                            }
                        }
                        // 2
                        {
                            yyy -= 140;
                            xxx = Brdrstart;
                            for (int i = 0; i < 4; i++)
                            {
                                Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                                EP.Add(plaane);
                                xxx += 50 * 2;
                            }
                        }
                        // 4
                        {
                            yyy -= 140 * 2;
                            xxx = Brdrstart+(50 * 4);
                            for(int i = 0; i < 3; i++)
                            {
                                Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                                EP.Add(plaane);
                                xxx += 50;
                            }
                        }
                        // 7
                        {
                            yyy -= 140 * 2;
                            xxx = Brdrstart+(50*3);
                            for (int i = 0; i < 5; i++)
                            {
                                Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                                EP.Add(plaane);
                                xxx += 50;
                            }
                        }
                        //8
                        {
                            yyy -= 140 ;
                            xxx = Brdrstart+50;
                            for (int i = 0; i < 4; i++)
                            {
                                Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                                EP.Add(plaane);
                                xxx += (50*2);
                            }
                        }
                        //11
                        {
                            yyy -= 140 * 3;
                            xxx = Brdrstart + (228 * 5);
                            Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                            EP.Add(plaane);
                        }
                        //12
                        {
                            yyy -= 140;
                            xxx = Brdrstart + (3 * 50);
                            for (int i = 0; i < 2; i++)
                            {
                                Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                                EP.Add(plaane);
                                xxx += (50 * 4);
                            }
                        }
                        // 13
                        {
                            yyy -= 140;
                            xxx = Brdrstart;
                            for (int i = 0; i < 2; i++)
                            {
                                Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                                EP.Add(plaane);
                                xxx += (50 * 8);
                            }
                        }
                        // 14
                        {
                            yyy -= 140;
                            xxx = Brdrstart+(50*3);
                            for (int i = 0; i < 3; i++)
                            {
                                Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                                EP.Add(plaane);
                                xxx += (50 * 2);
                            }
                        }
                        // 15
                        {
                            yyy -= 140;
                            xxx = Brdrstart + (50 * 4);
                            for (int i = 0; i < 2; i++)
                            {
                                Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                                EP.Add(plaane);
                                xxx += (50 * 2);
                            }
                        }
                        // 16
                        {
                            yyy -= 140;
                            xxx = Brdrstart+(50 * 5);
                            Plane plaane = new Plane(xxx, yyy, new Bitmap("planes/EWhite.png"), "enemy4", 20, 20, 40, new Rectangle(BrdrB + 10, 0, 35, 5), true);
                            EP.Add(plaane);
                        }
                    }

                    break;
            }
        }
        void MoveEnmy()
        {
            for (int i = 0; i < EP.Count; i++)
            {
                Plane plane = EP[i];
                if (plane.Type == "enemy1")
                {
                    plane.Y += SpeedEnmy1;
                    if ((plane.Y / 400) % 2 == 0)
                    {
                        plane.X -= SpeedEnmy1 / 2;
                    }
                    else
                    {
                        plane.X += SpeedEnmy1 / 2;
                    }
                }
                if (plane.Type == "enemy2")
                {
                    plane.Y += SpeedEnmy1;
                    if (plane.Y < 400)
                    {
                        plane.X += SpeedEnmy1 / 2;
                    }
                    else if (plane.Y >= 400)
                    {
                        plane.X -= SpeedEnmy1 / 2;
                    }
                }
                if (plane.Type == "enemy3" || plane.Type== "h")
                {
                    plane.Y += SpeedEnmy3 / 2;
                    if (plane.HealthBarr != null)
                    {
                        plane.HealthBarr.X = plane.X + (plane.Img.Width - plane.HealthBarr.Width) / 2;
                        plane.HealthBarr.Y = plane.Y + plane.Img.Height + 2;
                    }

                }
                if (plane.Type == "enemy4")
                {
                    plane.Y += spdEnmy4;
                    if (plane.HealthBarr != null)
                    {
                        plane.HealthBarr.X = plane.X + (plane.Img.Width - plane.HealthBarr.Width) / 2;
                        plane.HealthBarr.Y = plane.Y + plane.Img.Height + 2;
                    }
                }
                // Remove if the plane has gone off the screen
                if (plane.Y > this.ClientSize.Height + plane.Img.Height)
                {
                    EP.RemoveAt(i);
                    i--;
                }
            }
            for(int i=0; i < H.Count; i++) 
            {
                Helicopter plane = H[i];
                if (H[i].Type == "1")
                {
                    switch (currentDirection)
                    {
                        case "right":
                            H[i].X+= speedH;
                            break;

                        case "up":
                            H[i].Y-= speedH/2;
                            break;

                        case "left":
                            H[i].X-= speedH;
                            break;

                        case "down":
                            H[i].Y+= speedH;
                            break;
                    }

                    if (plane.HealthBarr != null)
                    {
                        plane.HealthBarr.X = plane.X + (plane.Imgs[0].Width - plane.HealthBarr.Width) / 2;
                        plane.HealthBarr.Y = plane.Y + plane.Imgs[0].Height + 2;
                    }

                    movedPixels++;
                    if (movedPixels >= moveDistance)
                    {
                        movedPixels = 0;
                        switch (currentDirection)
                        {
                            case "right":
                                currentDirection = "up";
                                break;
                            case "up":
                                currentDirection = "left";
                                break;
                            case "left":
                                currentDirection = "down";
                                break;
                            case "down":
                                currentDirection = "right";
                                break;
                        }
                    }                    
                    H[i].iframe++;
                    if (H[i].iframe == 2)
                    {
                        H[i].iframe = 0;
                    }

                }
            }
        }
        void MoveCoins()
        {
            for (int i = 0; i < C.Count; i++)
            {
                if (P[0].Y - C[i].Y < DistancetoCollectCoins || (C[i].Y-P[0].Y< DistancetoCollectCoins && C[i].Y - P[0].Y>0))
                {
                    if (P[0].X - C[i].X < DistancetoCollectCoins || C[i].X - P[0].X< DistancetoCollectCoins)
                    {
                        if (P[0].X   < C[i].X)
                        {
                            C[i].X-= speedCollect;
                        }
                        if (C[i].X < P[0].X + P[0].Img.Width / 2)
                        {
                            C[i].X+= speedCollect;
                        }
                        if (C[i].Y < P[0].Y)
                        {
                            C[i].Y+= speedCollect;
                        }
                    }
                }
                C[i].Y += SpeedEnmy1/2;
                if (C[i].Y > 800)
                {
                    C.RemoveAt(i);
                }
            }
        }
        void CheckCollectCoins()
        {
            if (P.Count > 0)
            {
                for (int i = 0; i < C.Count; i++)
                {
                    int cx = C[i].X + C[i].Img.Width / 2;
                    if (cx > P[0].X && cx < P[0].X + P[0].Img.Width)
                    {
                        if (C[i].Y > P[0].Y && C[i].Y < P[0].Y + P[0].Img.Height)
                        {
                            C.RemoveAt(i);
                            ctCoins++;
                        }
                    }
                }
            }
        }
        void CreateHeroBullets()
        {

            if (P.Count > 0)
            {
                if (Flag_Super_Bullets && Ct_CreateHeroBullets == 5)
                {
                    CreateSuperBullets();
                    Ct_CreateHeroBullets = 0;
                }
                else if (!Flag_Super_Bullets && Ct_CreateHeroBullets == 5)
                {
                    CreateNormalBullets();
                    Ct_CreateHeroBullets = 0;
                }
            }

            Ct_CreateHeroBullets++;
        }

        void CreateNormalBullets()
        {
            int xfist = P[0].X - 5, xlast = P[0].X + P[0].W - 15, xmiddle = P[0].X + P[0].W / 2 - 5, y = P[0].Y - 50;
            // Create normal bullets
            B.Add(new Bullets(xfist, y, "L"));
            B.Add(new Bullets(xfist - 20, y, "L"));
            B.Add(new Bullets(xmiddle - 10, y, "M"));
            B.Add(new Bullets(xmiddle + 10, y, "M"));
            B.Add(new Bullets(xlast, y, "R"));
            B.Add(new Bullets(xlast + 20, y, "R"));
        }

        void CreateSuperBullets()
        {
            int xfist = P[0].X - 5, xlast = P[0].X + P[0].W - 15, xmiddle = P[0].X + P[0].W / 2 - 5, y = P[0].Y - 50;
            // Create super bullets
            B.Add(new Bullets(xfist, y, "SuperBulletsL1"));
            B.Add(new Bullets(xfist - 20, y, "SuperBulletsL1"));
            B.Add(new Bullets(xfist - 40, y, "SuperBulletsL2"));
            B.Add(new Bullets(xfist - 60, y, "SuperBulletsL2"));
            B.Add(new Bullets(xmiddle - 10, y, "SuperBulletsMid"));
            B.Add(new Bullets(xmiddle + 10, y, "SuperBulletsMid"));
            B.Add(new Bullets(xmiddle - 30, y, "SuperBulletsMid"));
            B.Add(new Bullets(xmiddle + 30, y, "SuperBulletsMid"));
            B.Add(new Bullets(xlast, y, "SuperBulletsR1"));
            B.Add(new Bullets(xlast + 20, y, "SuperBulletsR1"));
            B.Add(new Bullets(xlast + 40, y, "SuperBulletsR2"));
            B.Add(new Bullets(xlast + 60, y, "SuperBulletsR2"));
        }
        void MoveHeroBullets()
        {
            for (int i = 0; i < B.Count; i++)
            {
                if (!Flag_Super_Bullets)
                {
                    B[i].Y -= SpeedHeroBullets;
                    switch (B[i].type)
                    {
                        case "L":
                            B[i].X -= 5;
                            break;
                        case "R":
                            B[i].X += 5;
                            break;
                    }
                }
                else
                {
                    B[i].Y -= SpeedHeroBullets*(3/2)-4;
                    switch (B[i].type)
                    {
                        case "SuperBulletsL1":
                            B[i].X -= 3;
                            break;
                        case "SuperBulletsL2":
                            B[i].X-= 3;
                            break;
                        case "SuperBulletsR1":
                            B[i].X += 3;
                            break;
                        case "SuperBulletsR2":
                            B[i].X += 3;
                            break;
                    }

                }
                //check if hit enemy plane
                for (int k = 0; k < EP.Count; k++)
                {
                    int Xb = B[i].X + B[i].Img.Width, Yb = B[i].Y;
                    if (Xb > EP[k].X && Xb < EP[k].X + EP[k].Img.Width)
                    {
                        if (Yb > EP[k].Y && Yb < EP[k].Y + EP[k].Img.Height)
                        {
                            if (EP[k].HealthBarr != null)
                                EP[k].HealthBarr.CurrentHealth--;
                            EP[k].Life--;
                            if (EP[k].Life <= 0)
                            {
                                string s;
                                if (EP[k].Type == "enemy3")
                                {
                                    s = "big";
                                }
                                else { s = "small"; }
                                MakeExplosion(EP[k].X, EP[k].Y,s);

                                EP.RemoveAt(k);
                                ctKilled++;
                                Coin monem = new Coin(Xb, Yb, new Bitmap("coin2.png")); C.Add(monem);
                               
                            }
                        }
                    }
                }
                //For Helicopter 
                for (int k = 0; k < H.Count; k++)
                {
                    int Xb = B[i].X + B[i].Img.Width, Yb = B[i].Y;
                    if (Xb > H[k].X && Xb < H[k].X + H[k].Imgs[H[k].iframe].Width)
                    {
                        if (Yb > H[k].Y && Yb < H[k].Y + H[k].Imgs[H[k].iframe].Height)
                        {
                            if (H[k].HealthBarr != null)
                                H[k].HealthBarr.CurrentHealth--;
                            H[k].Life--;
                            if (H[k].Life <= 0)
                            {
                                string s;
                                if (H[k].Type == "1")
                                {
                                    s = "big";
                                }
                                else { s = "small"; }
                                MakeExplosion(H[k].X, H[k].Y, s);

                                H.RemoveAt(k);
                                ctKilled++;
                                Coin monem = new Coin(Xb, Yb, new Bitmap("coin2.png")); C.Add(monem);

                            }
                        }
                    }
                }

                //check if exeed screen height delete
                if (B[i].Y < 1)
                {
                    B.RemoveAt(i);
                }
            }

        }
        void CreateEnmyBullets()
        {
            for(int i=0;i<EP.Count;i++)
            {
                if (EP[i].Type == "enemy3")
                {
                    if (EP.Count > 0 && Ct_Enmy3Bullets == 7)
                    {
                        int xfist = EP[i].X+70 , xlast = EP[i].X + EP[i].W - 90, xmiddle = EP[i].X + EP[i].W / 2 - 5, y = EP[i].Y+EP[i].Img.Height;
                        //2 Left Bullets
                        {
                            Bullets monem = new Bullets(xfist, y, "enemy3L"); EB.Add(monem);
                            Bullets monem2 = new Bullets(xfist - 20, y, "enemy3L"); EB.Add(monem2);
                        }
                        //2 Middle Bullets
                        {
                            Bullets monem = new Bullets(xmiddle - 10, y, "enemy3M"); EB.Add(monem);
                            Bullets monem2 = new Bullets(xmiddle + 10, y, "enemy3M"); EB.Add(monem2);
                        }
                        //2 Right Bullets
                        {
                            Bullets monem = new Bullets(xlast, y, "enemy3R"); EB.Add(monem);
                            Bullets monem2 = new Bullets(xlast + 20, y, "enemy3R"); EB.Add(monem2);
                        }

                        Ct_Enmy3Bullets = 0;
                    }
                    Ct_Enmy3Bullets++;
                }
            }
            for (int i = 0; i < H.Count; i++)
            {
                if (H[i].Type == "1")
                {
                    if (H.Count > 0 && Ct_Enmy3Bullets == 7)
                    {
                        int xfist = H[i].X + 50, xlast = xfist + 70, xmiddle = xlast-35, y = H[i].Y + H[i].Imgs[0].Height;
                        //2 Left Bullets
                        {
                            Bullets monem = new Bullets(xfist, y, "enemy3L"); EB.Add(monem);
                            Bullets monem2 = new Bullets(xfist - 20, y, "enemy3L"); EB.Add(monem2);
                        }
                        //2 Middle Bullets
                        {
                            Bullets monem = new Bullets(xmiddle - 10, y, "enemy3M"); EB.Add(monem);
                            Bullets monem2 = new Bullets(xmiddle + 10, y, "enemy3M"); EB.Add(monem2);
                        }
                        //2 Right Bullets
                        {
                            Bullets monem = new Bullets(xlast, y, "enemy3R"); EB.Add(monem);
                            Bullets monem2 = new Bullets(xlast + 20, y, "enemy3R"); EB.Add(monem2);
                        }

                        Ct_Enmy3Bullets = 0;
                    }
                    Ct_Enmy3Bullets++;
                }
            }

        }
        void MoveEnmyBullets()
        {
            for (int i = 0; i < EB.Count; i++)
            {
                EB[i].Y += SpeedEnmyBullets;
                switch (EB[i].type)
                {
                    case "enemy3L":
                        EB[i].X -= SpeedEnmyBullets/3;
                        break;
                    case "enemy3R":
                        EB[i].X += SpeedEnmyBullets/3;
                        break;
                }
                
               
                //check if exeed screen height delete
                if (EB[i].Y > 800)
                {
                    EB.RemoveAt(i);
                }
            }
        }
        void MakeExplosion(int x, int y,string type)
        {
            Explosion monem=new Explosion(x,y,type);
            E.Add(monem);
        }
        void MangeExplosion()
        {
            for(int i = 0; i < E.Count; i++)
            {
                if (E[i].iframe == 7)
                {
                    E.RemoveAt(i);
                }
                else
                {
                    E[i].iframe++;
                }
            }
        }
        
        void DamgeHero()
        {
            //Check if hero crash with enemy plane
            for (int i = 0; i < EP.Count; i++)
            {
                if (P.Count > 0)
                {
                    //Here Mon3em split the Enemy plane into 3 points on the x-axis and 3 points on the y-axis 
                    //Then check if any of this points crashed with the hero plane then decrease the hero health
                  
                    int monemx1 = EP[i].X + 2, monemx2 = EP[i].X + EP[i].Img.Width / 2, monemx3 = EP[i].X + EP[i].Img.Width - 2;
                    int monemy1 = EP[i].Y + +2, monemy2 = EP[i].Y + EP[i].Img.Height / 2, monemy3 = EP[i].Y + EP[i].Img.Height - 2;
                    if (monemx1 > P[0].X && monemx1 < P[0].X + P[0].Img.Width || monemx2 > P[0].X && monemx2 < P[0].X + P[0].Img.Width || monemx3 > P[0].X && monemx3 < P[0].X + P[0].Img.Width)
                    {
                        if (monemy1 > P[0].Y && monemy1 < P[0].Y + P[0].Img.Height || monemy2 > P[0].Y && monemy2 < P[0].Y + P[0].Img.Height || monemy3 > P[0].Y && monemy3 < P[0].Y + P[0].Img.Height)
                        {
                            switch (EP[i].Type)
                            {
                                case "enemy1":
                                    P[0].HealthBarr.CurrentHealth -= Dmg_fromenmy1;
                                    break;
                                case "enemy2":
                                    P[0].HealthBarr.CurrentHealth -= Dmg_fromenmy1;
                                    break;
                                case "enemy3":
                                    P[0].HealthBarr.CurrentHealth -= Dmg_fromenmy3;
                                    break;
                                case "enemy4":
                                    P[0].HealthBarr.CurrentHealth -= Dmg_fromenmy3;
                                    break;
                            }
                        }
                    }
                }
            }
            // check if hero shooted from enemy plane
            if (P.Count > 0)
            {
                for (int i = 0; i < EB.Count; i++)
                {
                    int Xb = EB[i].X + EB[i].Img.Width, Yb = EB[i].Y;
                    if (Xb > P[0].X && Xb < P[0].X + P[0].Img.Width)
                    {
                        if (Yb > P[0].Y && Yb < P[0].Y + P[0].Img.Height)
                        {
                            if (P[0].HealthBarr != null)
                                P[0].HealthBarr.CurrentHealth -= Dmg_fromenmy3 / 2;
                            P[0].Life -= Dmg_fromenmy3 / 2;
                        }
                    }
                }
                if (P[0].HealthBarr.CurrentHealth < 0 || P[0].Life <= 0) 
                {
                    P.RemoveAt(0);
                    GameOver();
                }
            }
        }
        void GameOver()
        {
            if (P.Count == 0 || (EP.Count == 0 && monemmm < 75))
            {
                tt.Stop();

                GameOverForm gameOverForm = new GameOverForm();
                gameOverForm.StartPosition = FormStartPosition.Manual;
                gameOverForm.Location = new Point(550, 250);
                gameOverForm.ShowDialog();

                this.Close();
            }
            if(monemmm > 75)
            {
                tt.Stop();

                VictoryForm Victory = new VictoryForm();
                Victory.StartPosition = FormStartPosition.Manual;
                Victory.Location = new Point(550, 250);
                Victory.ShowDialog();
            }
            
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > border1 && e.X < border2)
            {
                if (P.Count > 0)
                {
                    P[0].X = e.X - P[0].W / 2; P[0].Y = e.Y - P[0].H / 2;
                }
                Tick();
                DrawDubb(CreateGraphics());
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            InitializeGame();
        }
        void InitializeGame()
        {

            //Initializing When Pressing R
            string currentDirection = "right"; int movedPixels = 0;
            tt.Stop(); tt.Start(); ctsuperBullets = 0;flagend = 0;H.Clear();H.Clear();
            P.Clear(); B.Clear(); EP.Clear(); C.Clear(); ct = 0;L1.Clear(); CtCreateEnemy = 0; ctttt = 0; CtEnemies = 91;  ctCoins = 0; int heroHealth = heroMaxHealth; ctKilled=0; Flag_Super_Bullets = false;Flag_Super_Bullets_Appear = true;
            //Advanced Image
            int w = BrdrC - BrdrB;int h = ClientSize.Height; int y = new Bitmap("backk.jpg").Height / 2;
            Rectangle s = new Rectangle(0, y, w, h); Rectangle d = new Rectangle(BrdrA, 0, w+280, h+200);
            AdvancedImage Mon3em = new AdvancedImage(w,h,s,d,new Bitmap("backk.jpg"));
            L1.Add(Mon3em);
            //Left and Right Img
            Rectanglee monem = new Rectanglee(0, 0, AirForce); R.Add(monem);
            Rectanglee monem2 = new Rectanglee(1040, 0, AirForce); R.Add(monem2);
            //Hero Plane
            Rectangle healthBar = new Rectangle(border1 + 90, 20, healthBarWidth, 20);
            Plane plane = new Plane(Xplane, Yplane, new Bitmap("planes/plane1.png"), "Hero", heroHealth,400,200,healthBar,true);
            P.Add(plane);
            //Lifes
            coin3 = new Coin(border2 - 100, 10, new Bitmap("coin3.png"));
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            for (int i = 0; i < L1.Count; i++)
            {
                g.DrawImage(L1[i].Img, L1[i].Rectd, L1[i].Rects, GraphicsUnit.Pixel);

            }
            //Enmy planes
            for (int i = 0; i < EP.Count; i++)
            {
                g.DrawImage(EP[i].Img, EP[i].X, EP[i].Y);
            }
            for (int i = 0; i < H.Count; i++)
            {
                g.DrawImage(H[i].Imgs[H[i].iframe], H[i].X, H[i].Y);
            }
            //coins
            for (int i = 0; i < C.Count; i++)
            {
                g.DrawImage(C[i].Img, C[i].X, C[i].Y);
            }
            //Bullets
            for (int i = 0; i < B.Count; i++)
            {
                g.DrawImage(B[i].Img, B[i].X, B[i].Y, B[i].W, B[i].H);
            }
            //Enmy Bullets
            for (int i = 0; i < EB.Count; i++)
            {
                g.DrawImage(EB[i].Img, EB[i].X, EB[i].Y);
            }
            //Lifes
            {
                //Life Bar
                //Herooo Life Bar
                if (P.Count > 0)
                {
                    Plane hero = P[0];
                    int currentHealthWidth = (int)((double)hero.HealthBarr.CurrentHealth / hero.HealthBarr.MaxHealth * hero.HealthBarr.Width);
                    Brush healthBrush = Brushes.Red;
                    if (hero.HealthBarr.CurrentHealth > hero.HealthBarr.MaxHealth * 0.5)
                        healthBrush = Brushes.Yellow;
                    if (hero.HealthBarr.CurrentHealth > hero.HealthBarr.MaxHealth * 0.75)
                        healthBrush = Brushes.Green;
                    g.FillRectangle(healthBrush, hero.HealthBarr.X + 10, hero.HealthBarr.Y, currentHealthWidth, hero.HealthBarr.Height);
                    g.DrawRectangle(Pens.White, hero.HealthBarr.X + 10, hero.HealthBarr.Y, hero.HealthBarr.Width, hero.HealthBarr.Height);
                }
                g.DrawImage(new Bitmap("tank3.png"), border1 + 95, 6, 218, 47);
                g.DrawImage(new Bitmap("tank2.png"), border1 + 65, 10);

                //El A3daaa2 Life Bar
                for (int i = 0; i < EP.Count; i++)
                {
                    Plane enemy = EP[i];
                    if ((enemy.Type == "enemy3" || enemy.Type == "enemy4") && enemy.HealthBarr != null)
                    {
                        g.FillRectangle(Brushes.Gray, enemy.HealthBarr.X, enemy.HealthBarr.Y, enemy.HealthBarr.Width, enemy.HealthBarr.Height);
                        int currentHealthWidth = (int)((double)enemy.HealthBarr.CurrentHealth / enemy.HealthBarr.MaxHealth * enemy.HealthBarr.Width);
                        Brush healthBrush = Brushes.Red;
                        if (enemy.HealthBarr.CurrentHealth > enemy.HealthBarr.MaxHealth * 0.75)
                            healthBrush = Brushes.Green;
                        else if (enemy.HealthBarr.CurrentHealth > enemy.HealthBarr.MaxHealth * 0.5)
                            healthBrush = Brushes.Yellow;
                        else
                            healthBrush = Brushes.Red;

                        g.FillRectangle(healthBrush, enemy.HealthBarr.X, enemy.HealthBarr.Y, currentHealthWidth, enemy.HealthBarr.Height);
                        g.DrawRectangle(Pens.White, enemy.HealthBarr.X, enemy.HealthBarr.Y, enemy.HealthBarr.Width, enemy.HealthBarr.Height);
                    }
                }
                for (int i = 0; i < H.Count; i++)
                {
                    Helicopter enemy = H[i];
                    if (enemy.Type == "1" && enemy.HealthBarr != null)
                    {
                        g.FillRectangle(Brushes.Gray, enemy.HealthBarr.X, enemy.HealthBarr.Y, enemy.HealthBarr.Width, enemy.HealthBarr.Height);
                        int currentHealthWidth = (int)((double)enemy.HealthBarr.CurrentHealth / enemy.HealthBarr.MaxHealth * enemy.HealthBarr.Width);
                        Brush healthBrush = Brushes.Red;
                        if (enemy.HealthBarr.CurrentHealth > enemy.HealthBarr.MaxHealth * 0.75)
                            healthBrush = Brushes.Green;
                        else if (enemy.HealthBarr.CurrentHealth > enemy.HealthBarr.MaxHealth * 0.5)
                            healthBrush = Brushes.Yellow;
                        else
                            healthBrush = Brushes.Red;

                        g.FillRectangle(healthBrush, enemy.HealthBarr.X, enemy.HealthBarr.Y, currentHealthWidth, enemy.HealthBarr.Height);
                        g.DrawRectangle(Pens.White, enemy.HealthBarr.X, enemy.HealthBarr.Y, enemy.HealthBarr.Width, enemy.HealthBarr.Height);
                    }
                }

            }
            for (int i = 0; i < R.Count; i++)
            {
                g.DrawImage(R[i].Img, R[i].X, R[i].Y);
            }
            //super Bullets icon
            if (Flag_Super_Bullets_Appear)
            {
                g.DrawImage(new Bitmap("superBullets.png"), 520, 650,50,50);
            }
            else
            {
                g.DrawImage(new Bitmap("superBullets2.png"), 520, 650,50,50);
            }
            //Left and right img
            //Hero
            for (int i = 0; i < P.Count; i++)
            {
                g.DrawImage(P[i].Img, P[i].X, P[i].Y);
            }
            //Explosion
            for(int i = 0; i < E.Count; i++)
            {
                int X = E[i].iframe;
                if (E[i].Type == "big")
                {
                    g.DrawImage(E[i].Imgs[X], E[i].X, E[i].Y);
                }
                else
                {
                    g.DrawImage(E[i].Imgs[X], E[i].X, E[i].Y,E[i].Imgs[X].Width/3, E[i].Imgs[X].Height / 3);
                }
                
                
            }
            
            //Hold button
            g.DrawImage(new Bitmap("holdbutton.png"), coin3.X-16, coin3.Y+10,50,33);

            //be5
            {
                g.DrawImage(new Bitmap("be5.png"), coin3.X - 110, coin3.Y + 10, 35, 35);
                Font font = new Font("Arial", 16, FontStyle.Bold);
                Brush brush = Brushes.White;
                string monemString = monemmm.ToString("F0") + "%";
                g.DrawString(monemString, font, brush, coin3.X - 75, coin3.Y + 15);
            }

            //Collected Coins
            {
                g.DrawImage(coin3.Img, coin3.X, coin3.Y+50);
                Font font = new Font("Arial", 16, FontStyle.Bold);
                Brush brush = Brushes.White;
                g.DrawString(ctCoins.ToString(), font, brush, coin3.X - coin3.Img.Width-5, coin3.Y + 52);
            }

        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}