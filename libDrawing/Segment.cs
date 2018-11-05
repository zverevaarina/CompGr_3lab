using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDrawing
{
    public class Segment
    {
        public Point Position { get; set; }
        public int R { get; set; }
        public int SAngle { get; set; }
        public int FAngle { get; set; }

        public Segment(Point position, int r, int sAngle, int fAngle)
        {
            Position = position;
            R = r;
            SAngle = sAngle;
            FAngle = fAngle;
        }

        public void Draw(Bitmap targetBitmap, Point worldCenter)
        {
            DrawFigure.DrawPie(targetBitmap, worldCenter.X + Position.X, worldCenter.Y + Position.Y, R, R, SAngle, FAngle);
        }
    }
}
