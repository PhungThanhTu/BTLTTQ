using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in panel1.Controls)
            {
                
                    panel1.Controls.Remove(item);
                    break; //important step
                
            }

            RandomCards.CardControl card = new RandomCards.CardControl();
            card.Dock = DockStyle.Fill;
            
            
            panel1.Controls.Add(card);
            
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            foreach(Control item in panel1.Controls)
            {
                item.Size = panel1.Size;
                item.Location = panel1.Location;
            }
            panel1.Location =
    new Point(ClientSize.Width / 2 - panel1.Size.Width / 2,
              ClientSize.Height / 2 - panel1.Size.Height / 2);

            panel1.Anchor = AnchorStyles.None;
        }

       
        
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            //resize panel
            panel1.Width = this.Width / 3;
            panel1.Height = this.Height * 2 / 3;

        }

        public static void SetResizeRedraw(Control control)
        {
            typeof(Control).InvokeMember("ResizeRedraw",
              BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
              null, control, new object[] { true });
        }
        

    }
}
