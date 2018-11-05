using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDrawing
{
    public class Drawer
    {
        public Point WorldCenter { get; set; }

        private int _width;
        private int _height;

        public Drawer(int width, int height, Point worldCenter)
        {
            WorldCenter = worldCenter;
            _width = width;
            _height = height;
        }

        public Bitmap Draw(Segment s, bool drawObj = false)
        {
            var bmp = new Bitmap(_width, _height);
            s.Draw(bmp, WorldCenter);
            if (drawObj)
                Graphics.FromImage(bmp).DrawEllipse(new Pen(Color.Aqua, 2), WorldCenter.X - 5, WorldCenter.Y - 5, 10, 10);
            return bmp;
        }
    }
}
