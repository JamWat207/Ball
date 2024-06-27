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
        const int numberofballs = 200;
        Color[,] grid = new Color[(int)Math.Sqrt(numberofballs), (int)Math.Sqrt(numberofballs)];
        List<Changelisttype> changelist = new List<Changelisttype>();
        int lastArray;
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
            for (int i = 0; i < 5000; i++)
            {
                mover = new Mover(this.Width, this.Height, this);
                movers.Add(mover);
            }


        }
        public void timer2_Tick(object sender, EventArgs e)
        {
            Color colour = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Color colo = colour;
            foreach (var item in movers)
            {
                item.Update();
                item.Display(e.Graphics , colo);

            }


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
        

    }
}

