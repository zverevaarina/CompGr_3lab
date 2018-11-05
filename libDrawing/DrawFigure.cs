using System.Drawing;

namespace libDrawing
{
    public class DrawFigure
    {
        static int I1 = 0, J1 = 0, I2, J2;
        public static double x1 = -0.1, y1 = -1, x2 = 3.1, y2 = 16;
        public delegate int IJ(double x);

        static int II(double x)
        {
            return I1 + (int)((x - x1) * (I2 - I1) / (x2 - x1));
        }

        public static double XX(int I)
        {
            return x1 + (I - I1) * (x2 - x1) / (I2 - I1);
        }

        static int JJ(double y)
        {
            return J2 + (int)((y - y1) * (J1 - J2) / (y2 - y1));
        }

        public static double YY(int J)
        {
            return y1 + (J - J2) * (y2 - y1) / (J1 - J2);
        }

        public static void DrawCircle(Bitmap bmp, int x, int y, int r, int sAngle, int fAngle)
        {
            int _x = 0;
            int _y = r;

            int d = 1 - 2 * r;
            int e = 0;
            while (_y >= 0)
            {
                /*switch (k)
                {
                    case 1: bmp.SetPixel(x + _x, y - _y, Color.Black); break;
                    case 2: bmp.SetPixel(x - _x, y - _y, Color.Black); break;
                    case 3: bmp.SetPixel(x - _x, y + _y, Color.Black); break;
                    case 4: bmp.SetPixel(x + _x, y + _y, Color.Black); break;
                }*/

                try { 
                    bmp.SetPixel(x + _x, y - _y, Color.Black);
                    bmp.SetPixel(x - _x, y - _y, Color.Black);
                    bmp.SetPixel(x - _x, y + _y, Color.Black);
                    bmp.SetPixel(x + _x, y + _y, Color.Black);

                    e = 2 * (d + _y) - 1;

                    if ((d < 0) && (e <= 0))
                    {
                        _x++;
                        d += 2 * _x + 1;
                        continue;
                    }

                    if ((d > 0) && (e > 0))
                    {
                        _y--;
                        d -= 2 * _y + 1;
                        continue;
                    }

                    _x++;
                    d += 2 * (_x - _y);
                    _y--;
                }
                catch
                {
                    break;
                }

            }
            /*int x := 0
   int y := R
   int delta := 1 - 2 * R
   int error := 0
   while (y >= 0)
       drawpixel(X1 + x, Y1 + y)
       drawpixel(X1 + x, Y1 - y)
       drawpixel(X1 - x, Y1 + y)
       drawpixel(X1 - x, Y1 - y)
       error = 2 * (delta + y) - 1
       if ((delta < 0) && (error <= 0))
           delta += 2 * ++x + 1
           continue
       if ((delta > 0) && (error > 0))
           delta -= 2 * --y + 1
           continue
       delta += 2 * (++x - y--)*/
        }


        /*public static void DrawPie(Bitmap bmp, int x, int y, int a, int b, int sAngle, int fAngle)//, Rectangle ClientRectangle)
        {
            DrawArc(bmp, x, y, a, b, sAngle, fAngle);//, ClientRectangle);

            //кординаты начала сектора
            int xs = Math.Abs((int)(a * Math.Cos((sAngle * (Math.PI / 180)))));
            int ys = Math.Abs((int)(b * Math.Sin((sAngle * (Math.PI / 180)))));
            int k = x + xs, l = y - ys;

            //DrawLine2(bmp, Color.Red, x, y, 486, 206);
            
            if (sAngle < 90) DrawLine(bmp, Color.Black, x, y, x + xs, y - ys);
            else if (sAngle >= 90 && sAngle < 180) DrawLine(bmp, Color.Black, x, y, x - xs, y - ys);
            else if (sAngle >= 180 && sAngle < 270) DrawLine(bmp, Color.Black, x, y, x - xs, y + ys);
            else if (sAngle >= 270) DrawLine(bmp, Color.Black, x, y, x + xs, y + ys);

            //координаты конца сектора
            int xf = Math.Abs((int)(a * Math.Cos((fAngle * (Math.PI / 180)))));
            int yf = Math.Abs((int)(b * Math.Sin((fAngle * (Math.PI / 180)))));

            if (fAngle < 90) DrawLine(bmp, Color.Black, x, y, x + xf, y - yf);
            else if (fAngle >= 90 && fAngle < 180) DrawLine(bmp, Color.Black, x, y, x - xf, y - yf);
            else if (fAngle >= 180 && fAngle < 270) DrawLine(bmp, Color.Black, x, y, x - xf, y + yf);
            else if (fAngle >= 270) DrawLine(bmp, Color.Black, x, y, x + xf, y + yf);
        }

        public static void DrawArc(Bitmap bmp, int x, int y, int a, int b, int sAngle, int fAngle)//, Rectangle ClientRectangle)
        {
            /*I2 = ClientRectangle.Width;
            J2 = ClientRectangle.Height;

            int sAngleCopy, fAngleCopy, _x, _y, max;
            if (fAngle > 360)
            {
                fAngle = fAngle - 360;
                int t = sAngle; sAngle = fAngle; fAngle = t;
            }
            //int sQ = (int)sAngle / 90;
            //int l = sQ;
            //1
            if (sAngle <= 90)
            {
                sAngleCopy = sAngle;

                if (fAngle > 90) fAngleCopy = 90;
                else fAngleCopy = fAngle;

                _x = Math.Abs((int)(a * Math.Cos((fAngleCopy * (Math.PI / 180)))));
                _y = Math.Abs((int)(b * Math.Sin((fAngleCopy * (Math.PI / 180)))));
                max = Math.Abs((int)(b * Math.Sin((sAngleCopy * (Math.PI / 180)))));
                DrawAll(bmp, x, y, 1, max, a, b, _x, _y);
            }
            //2
            if ((sAngle > 90 && sAngle < 180) || (sAngle <= 90 && fAngle > 90))
            {
                if (fAngle > 180) fAngleCopy = 180;
                else fAngleCopy = fAngle;

                if (sAngle < 90) sAngleCopy = 90;
                else sAngleCopy = sAngle;

                _x = Math.Abs((int)(a * Math.Cos((sAngleCopy * (Math.PI / 180)))));
                _y = Math.Abs((int)(b * Math.Sin((sAngleCopy * (Math.PI / 180)))));
                max = Math.Abs((int)(b * Math.Sin((fAngleCopy * (Math.PI / 180)))));
                DrawAll(bmp, x, y, 2, max, a, b, _x, _y);
            }
            //3
            if ((sAngle > 180 && sAngle < 270) || (sAngle <= 180 && fAngle > 180))
            {
                if (fAngle > 270) fAngleCopy = 270;
                else fAngleCopy = fAngle;

                if (sAngle < 180) sAngleCopy = 180;
                else sAngleCopy = sAngle;

                _x = Math.Abs((int)(a * Math.Cos((fAngleCopy * (Math.PI / 180)))));
                _y = Math.Abs((int)(b * Math.Sin((fAngleCopy * (Math.PI / 180)))));
                max = Math.Abs((int)(b * Math.Sin((sAngleCopy * (Math.PI / 180)))));
                DrawAll(bmp, x, y, 3, max, a, b, _x, _y);
            }
            //4
            if ((sAngle > 270 && sAngle < 360) || (sAngle <= 270 && fAngle > 270))
            {
                if (fAngle > 360) fAngleCopy = 360;
                else fAngleCopy = fAngle;

                if (sAngle < 270) sAngleCopy = 270;
                else sAngleCopy = sAngle;

                _x = Math.Abs((int)(a * Math.Cos((sAngleCopy * (Math.PI / 180)))));
                _y = Math.Abs((int)(b * Math.Sin((sAngleCopy * (Math.PI / 180)))));
                max = Math.Abs((int)(b * Math.Sin((fAngleCopy * (Math.PI / 180)))));
                DrawAll(bmp, x, y, 4, max, a, b, _x, _y);
            }
        }
        
        private static void DrawAll(Bitmap bmp, int x, int y, int k, int max, int a, int b, int _x, int _y)
        {
            int a_sqr = a * a;
            int b_sqr = b * b;
            int d = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr * ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr;

            while ((a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) && (_y >= max))
            {
                switch (k)
                {
                    case 1: bmp.SetPixel(x + _x, y - _y, Color.Black); break;
                    case 2: bmp.SetPixel(x - _x, y - _y, Color.Black); break;
                    case 3: bmp.SetPixel(x - _x, y + _y, Color.Black); break;
                    case 4: bmp.SetPixel(x + _x, y + _y, Color.Black); break;
                }
                if (d < 0)
                {
                    _x++;
                    d += 4 * b_sqr * (2 * _x + 3);
                }
                else
                {
                    _x++; _y--;
                    d = d - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                }
            }

            d = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr;

            while ((_y + 1 != 0) && (_y >= max))
            {
                switch (k)
                {
                    case 1: bmp.SetPixel(x + _x, y - _y, Color.Black); break;
                    case 2: bmp.SetPixel(x - _x, y - _y, Color.Black); break;
                    case 3: bmp.SetPixel(x - _x, y + _y, Color.Black); break;
                    case 4: bmp.SetPixel(x + _x, y + _y, Color.Black); break;
                }
                if (d < 0)
                {
                    _y--;
                    d += 4 * a_sqr * (2 * _y + 3);
                }
                else
                {
                    _y--; _x++;
                    d = d - 8 * b_sqr * (_x + 1) + 4 * a_sqr * (2 * _y + 3);
                }
            }
        }

        public static void DrawLine(Bitmap bmp, Color color, int x1, int y1, int x2, int y2)
        {
            if (x1 > x2)
            {
                int tmp = x1; x1 = x2; x2 = tmp;
                tmp = y1; y1 = y2; y2 = tmp;
            }

            double L = Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            double dy = (y2 - y1) / L;
            double dx = (x2 - x1) / L;
            double x = x1, y = y1;
            for (int i = 0; i <= L; i++)
            {
                x += dx;
                y += dy;
                bmp.SetPixel((int)x, (int)y, color);
            }
        }*/
        }
    }
