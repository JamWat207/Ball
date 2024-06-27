using System;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Metrics;



namespace Ballbouncing
{
    public partial class Form1 : Form
    {
        Mover mover;
        static Random r = new Random();
        List<Mover> movers = new List<Mover>();


        public Form1()
        {
            InitializeComponent();
        }
        struct Changelisttype
        {
            public int row;
            public int col;
        }

        Color colour;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.DoubleBuffered = true;
            for (int i = 0; i < 500; i++)
            {
                mover = new Mover(this.Width, this.Height, this);
                movers.Add(mover);
            }


        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Color colo = colour;
            foreach (var item in movers)
            {
                item.Update();
                item.Display(e.Graphics);

            }


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            
        }

       
    }
}

