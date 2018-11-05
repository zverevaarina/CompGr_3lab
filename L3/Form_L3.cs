using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L3
{
    public partial class Form_L3 : Form
    {
        public Form_L3()
        {
            InitializeComponent();
        }

        private void Form_L3_Paint(object sender, PaintEventArgs e)
        {

            try
            {
                Draw(e.Graphics, new Rectangle(0, 0, Width, Height));
            }
            catch
            {
                MessageBox.Show("Введены неверные данные!");
            }
        }

        public void Draw(Graphics g, Rectangle r)
        {
            Bitmap bmp = new Bitmap(r.Width, r.Height);
            DrawF(bmp, Convert.ToInt32(textBoxR.Text));
            g.DrawImage(bmp, r);
            bmp.Dispose();
        }

        public void DrawF(Bitmap bmp, int r)
        {
            DrawFigure.DrawCircle(bmp, bmp.Width / 2, bmp.Height / 2, r, 30, 60);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form_L3_Load(object sender, EventArgs e)
        {
            
        }
    }
}
