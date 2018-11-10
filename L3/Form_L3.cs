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
        private float curScale = 1;
        private Segment s = new Segment(new Point(0, 0), 50, 0, 300);

        public Form_L3()
        {
            InitializeComponent();
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBox.MouseWheel += PictureBox_MouseWheel;
            drawer = new Drawer(pictureBox.Width, pictureBox.Height, new Point(pictureBox.Width / 2, pictureBox.Height / 2));
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            s = new Segment(new Point(0, 0), int.Parse(textBoxR.Text), 0, 300);
            var bmp = drawer.Draw(s, curScale);
            pictureBox.Image = bmp;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            //мировые
            if (e.Button == MouseButtons.Middle)
            {
                s.Position = new Point(-e.Location.X + drawer.WorldCenter.X + s.Position.X, -e.Location.Y + drawer.WorldCenter.Y + s.Position.Y);
                drawer.WorldCenter = e.Location;
                pictureBox.Image = drawer.Draw(s, curScale);
            }

            //локальные
            if (e.Button == MouseButtons.Left)
            {
                s.Position = new Point(-drawer.WorldCenter.X + e.Location.X, -drawer.WorldCenter.Y + e.Location.Y);
                pictureBox.Image = drawer.Draw(s, curScale);
            }
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (curScale + e.Delta / 120f / 10f >= 0)
            {
                curScale += e.Delta / 120f / 10f;
                pictureBox.Image = drawer.Draw(s, curScale);
            }
        }
    }
}
