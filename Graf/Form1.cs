using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graf
{
    public partial class Form1 : Form
    {
        Timer timer;
        Random rand;
        Bitmap surface;
        Graphics device;
        PictureBox pb;
        public void drawLine()
        {
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255);
            Color color = Color.FromArgb(A, R, G, B);
            int width = rand.Next(2, 8);
            Pen pen = new Pen(color, width); //random line ends 
            int x1 = rand.Next(1, Size.Width);
            int y1 = rand.Next(1, Size.Height);
            int x2 = rand.Next(1, Size.Width);
            int y2 = rand.Next(1, Size.Height); //draw the line 
            device.DrawLine(pen, x1, y1, x2, y2); //refresh the drawing surface 
            pictureBox1.Image = surface;
    }
    public void TimerTick(object source, EventArgs e)
    {
        drawLine();
    }

    public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb = pictureBox1;
            pb.Parent = this;
            pb.Dock = DockStyle.Fill;
            pb.BackColor = Color.Black;
            rand = new Random();
            surface = new Bitmap(Size.Width, Size.Height);
            pb.Image = surface;
            device = Graphics.FromImage(surface);

            timer = new Timer();
            timer.Interval = 10;
            timer.Enabled = false;
            timer.Tick += new System.EventHandler(TimerTick);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
