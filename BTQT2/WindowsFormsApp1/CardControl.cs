using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomCards
{
    public partial class CardControl : UserControl
    {
        public int i = 0;
        
        public CardControl()
        {
            i = RandomNumber(0, 51);
            InitializeComponent();
            ResizeRedraw = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(e);

            FontFamily family = new FontFamily("Times New Roman");

            Font font = new Font(family, base.Size.Width/11f);
            // your code using GDI+ API to draw the card
            Graphics g = e.Graphics;
            DrawRoundedRectangle(g, new Rectangle(base.Location.X, base.Location.Y, base.Size.Width, base.Size.Height),
                                      30, new SolidBrush(Color.White));
            Rectangle suitRect = DrawSquare(base.Location.X + base.Size.Width / 2, base.Location.Y + base.Size.Height / 2, base.Size.Height / 6);
            DrawSuit(g, suitRect,i);
            // vẽ 2 hình vuông nhét số vào
            Rectangle SymRect1 = DrawSquare(base.Location.X + base.Width / 6, base.Location.Y + base.Size.Height / 8, base.Size.Width / 6);
            Rectangle SymRect2 = DrawSquare(base.Location.X + base.Size.Width - base.Width / 6, base.Location.Y + base.Size.Height - base.Size.Height / 8, base.Size.Width / 6);

            DrawSym(i, SymRect1, g, font);
            DrawSym(i, SymRect2, g, font);


        }
    



        public static Rectangle DrawSquare(int x, int y,int width)
        {
            return new Rectangle(x-width/2,y-width/2,width,width);
        } // Vẽ một hình chữ nhật cho việc bỏ đối tượng vào

        // vẽ hình chữ nhật tròn góc
        public static void DrawRoundedRectangle(Graphics g,
                                   Rectangle r, int radius, Brush myBrush)
        {
            GraphicsPath gp = new GraphicsPath();

            gp = RoundedRect(r, radius);


            g.FillPath(myBrush, gp);
        }
        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        // vẽ chất bài
        public static void  DrawSuit(Graphics g,Rectangle r,int i)
        {
            Image suit = Image.FromFile("suit-img/clubs.png");
            
            switch(i%4)
            {
                case 1: { suit = Image.FromFile("suit-img/clubs.png"); break; }
                case 2: { suit = Image.FromFile("suit-img/diamonds.png"); break; }
                case 3: { suit = Image.FromFile("suit-img/hearts.png"); break; }
                case 0: { suit = Image.FromFile("suit-img/spades.png"); break; }
            }

            Bitmap su = new Bitmap(suit);

            g.DrawImage(suit, r);
            
            
            
        }

        public static void DrawSym(int i,Rectangle r, Graphics g, Font font)
        {
            int k = i / 4;
            int s = i % 4;

            string Sym = "";

           if(k == 0)
            {
                Sym = "A";
            }
           if(k >= 1 && k <= 9)
            {
                Sym = k.ToString();
            }
           if(k == 10)
            {
                Sym = "J";
            }
           if(k == 11)
            {
                Sym = "Q";
            }
           if(k== 12)
            {
                Sym = "K";
            }

           if(s==0||s==1)
            {
                g.DrawString(Sym, font, new SolidBrush(Color.Black), r);
                return;
            }
           if(s==2||s==3)
            {
                g.DrawString(Sym, font, new SolidBrush(Color.Red), r);
                return;
            }
           
            


        }









        // Instantiate random number generator.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        private void CardControl_Load(object sender, EventArgs e)
        {
            
        }

        private void CardControl_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
     
        }
    }
}
