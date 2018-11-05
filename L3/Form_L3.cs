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
        private Segment s = new Segment(new Point(0, 0), 50, 0, 300);

        public Form_L3()
        {
            InitializeComponent();
            drawer = new Drawer(pictureBox.Width, pictureBox.Height, new Point(pictureBox.Width / 2, pictureBox.Height / 2));
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            s = new Segment(new Point(0, 0), int.Parse(textBoxR.Text), 0, 300);
            var bmp = drawer.Draw(s, true);
            pictureBox.Image = bmp;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            //мировые
            if (e.Button == MouseButtons.Middle)
            {
                s.Position = new Point(-e.Location.X + drawer.WorldCenter.X + s.Position.X, -e.Location.Y + drawer.WorldCenter.Y + s.Position.Y);
                drawer.WorldCenter = e.Location;
                pictureBox.Image = drawer.Draw(s, true);
            }

            //локальные
            if (e.Button == MouseButtons.Left)
            {
                s.Position = new Point(-drawer.WorldCenter.X + e.Location.X, -drawer.WorldCenter.Y + e.Location.Y);
                pictureBox.Image = drawer.Draw(s, true);
            }
        }
    }
}
