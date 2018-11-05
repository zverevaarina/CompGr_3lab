using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libDrawing;

namespace L3
{
    public partial class Form_L3 : Form
    {
        private Drawer drawer;
        private Segment s = new Segment(new Point(0, 0), 50, 30, 60);
        public Form_L3()
        {
            InitializeComponent();
            drawer = new Drawer(pictureBox.Width, pictureBox.Height, new Point(pictureBox.Width / 2, pictureBox.Height / 2));
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            var bmp = drawer.Draw(s, true);
            pictureBox.Image = bmp;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                drawer.WorldCenter = e.Location;
                pictureBox.Image = drawer.Draw(s, true);
            }

            if (e.Button == MouseButtons.Left)
            {
                s.Position = new Point(-drawer.WorldCenter.X + e.Location.X, -drawer.WorldCenter.Y + e.Location.Y);
                pictureBox.Image = drawer.Draw(s, true);
            }
        }
    }
}
