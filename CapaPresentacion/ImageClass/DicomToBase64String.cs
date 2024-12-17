using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace CapaPresentacion.ImageClass
{
    public class DicomToBase64String
    {
        public static string DicomToBase64Image(Bitmap bmp)
        {
            string strBase64ImageDicm = "";
            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            //    if ((pix8.Count > 0) || (pix16.Count > 0) || (pix24.Count > 0))
            //    {
            //        g.DrawImage(bmp, hOffset, vOffset);
            //    }
            //    //====draw patient information=======
            //    Font fontText = new Font("Arial", 8);
            //    SolidBrush brushColor = new SolidBrush(Color.Yellow);
            //    StringFormat strFormat = new StringFormat();
            //    //strFormat.LineAlignment //alinea verticalmente,near:top,center:middle,far:bottom(abajo) 
            //    //strFormat.Alignment //alinea Horizontalmente,near:left,center:middle,far:right 
            //    strFormat.Alignment = StringAlignment.Near;// left
            //    g.DrawString("Id: " + tagPatientId, fontText, brushColor, 0, 5, strFormat);
            //    g.DrawString("BirthDay: " + tagPatienBirthDay, fontText, brushColor, 0, 20, strFormat);
            //    strFormat.Alignment = StringAlignment.Far;//rigth
            //    g.DrawString("Name: " + tagPatienName, fontText, brushColor, 512, 5, strFormat);
            //    g.DrawString("Age: " + tagPatienAge, fontText, brushColor, 512, 20, strFormat);
            //    strFormat.Alignment = StringAlignment.Center;//center
            //    g.DrawString("3B Solution", fontText, brushColor, 256, 500, strFormat);
            //    //==============fin==================
            //    //save bitmap into Memory
            //    byte[] imageBytes = null;
            //    using (MemoryStream mStream = new MemoryStream())
            //    {
            //        bmp.Save(mStream, ImageFormat.Png);
            //        imageBytes = mStream.ToArray();
            //        strBase64ImageDicm = Convert.ToBase64String(imageBytes);
            //    }
            //}

            return strBase64ImageDicm;
        }
    }
}