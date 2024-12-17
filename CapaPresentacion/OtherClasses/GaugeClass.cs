using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace CapaPresentacion.OtherClasses
{
    public class GaugeClass
    {
        public static string strbase64Guage(double Value_Indicator_Gauge)
        {
            string base64String = "";

            //declare parameters for the indicator
            double PI = 3.1416;
            double IncrementoAngulo = (3*PI/2)/100;// value of increment of the angle
            double angle1 = 3*PI/4 + ((Value_Indicator_Gauge - 10) * IncrementoAngulo);
            double angle0 = 3*PI/4 + (Value_Indicator_Gauge * IncrementoAngulo);
            double angle2 = 3*PI/4 + ((Value_Indicator_Gauge + 10) * IncrementoAngulo);

            //Creatring a Bitmap for the GAUGE
            int width_bmp = 260, height_bmp = 260;
            Bitmap bmp = new Bitmap(width_bmp, height_bmp);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.WhiteSmoke);

            SolidBrush BrushGray = new SolidBrush(Color.Gray);
            SolidBrush BrushBlack = new SolidBrush(Color.Black);
            SolidBrush BrushYellow = new SolidBrush(Color.YellowGreen);

            Pen PenGray = new Pen(Color.Gray, 5);
            Pen PenYellowDealHD = new Pen(Color.Yellow, 25);
            Pen PenYellowDealLW = new Pen(Color.Yellow, 15);

            Pen ColorGreen = new Pen(Color.Green, 30);
            Pen ColorYellow = new Pen(Color.Yellow, 30);
            Pen ColorRed = new Pen(Color.Red, 30);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.FillEllipse(BrushBlack, 10, 10, 240, 240);

            g.DrawArc(ColorRed, 30, 30, width_bmp - 60, height_bmp - 60, 135, 81);
            g.DrawArc(ColorYellow, 30, 30, width_bmp - 60, height_bmp - 60, 216, 108);
            g.DrawArc(ColorGreen, 30, 30, width_bmp - 60, height_bmp - 60, 324, 81);

            g.FillEllipse(BrushGray, (width_bmp / 2) - 15.0f, (height_bmp / 2) - 15.0f, 30, 30);

            //Drawing the points 10 per 10
            for (int i = 135; i <= 405; i += 27)
            {
                   g.DrawArc(PenYellowDealLW, 60, 60, 140, 140, i, 1);
            }

            //advanced needle
            int intX0 = width_bmp / 2;
            int intY0 = height_bmp / 2;
            double distance = 90;//size needle
            double x1 = intX0 + Math.Cos(angle1) * (distance / 3.5);
            double y1 = intY0 + Math.Sin(angle1) * (distance / 3.5);
            double x2 = intX0 + Math.Cos(angle0) * distance;
            double y2 = intY0 + Math.Sin(angle0) * distance;
            double x3 = intX0 + Math.Cos(angle2) * (distance / 3.5);
            double y3 = intY0 + Math.Sin(angle2) * (distance / 3.5);

            int intX1 = Convert.ToInt32(x1);
            int intY1 = Convert.ToInt32(y1);
            int intX2 = Convert.ToInt32(x2);
            int intY2 = Convert.ToInt32(y2);
            int intX3 = Convert.ToInt32(x3);
            int intY3 = Convert.ToInt32(y3);

            Point[] NeedlePoint = new Point[4];
            NeedlePoint[0] = new Point(intX0, intY0);//base
            NeedlePoint[1] = new Point(intX1, intY1);// side left
            NeedlePoint[2] = new Point(intX2, intY2);
            NeedlePoint[3] = new Point(intX3, intY3);//side right
            g.FillPolygon(BrushGray, NeedlePoint);

            //drawing the value of the points.
            Font FontText = new Font("Arial", 10);
            g.DrawString("0", FontText, BrushYellow, 90, 160);
            g.DrawString("20", FontText, BrushYellow, 70, 115);
            g.DrawString("50", FontText, BrushYellow, 120, 75);
            g.DrawString("80", FontText, BrushYellow, 170, 115);
            g.DrawString("100", FontText, BrushYellow, 145, 160);
            g.DrawString(String.Concat(Value_Indicator_Gauge.ToString(), "%"), FontText, BrushYellow, 120, height_bmp - 60);

            //save the gauge into Memory
            byte[] imageBytes = null;
            using (var Mstream = new MemoryStream())
            {
                bmp.Save(Mstream, ImageFormat.Png);
                // Convert the image to byte[]
                imageBytes = Mstream.ToArray();
                // Convert byte[] to Base64String
                base64String = Convert.ToBase64String(imageBytes);
            }
            g.Dispose();
            bmp.Dispose();

            return base64String;
        }
    }
}