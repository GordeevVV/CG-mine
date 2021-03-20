using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CompGr1
{
    class Gradient:MathMorf
    {
        public override Bitmap procImg(Bitmap sourceImage, bool[,] mask, int MW, int MH/*, BackgroundWorker worker*/)
        {
            MathMorf eros = new Erosion();
            MathMorf dil = new Dilation();
            Bitmap res1 = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap res2 = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            res1 = dil.procImg(sourceImage, mask, MW, MH/*,worker*/);
            res2 = eros.procImg(sourceImage, mask, MW, MH/*,worker*/);
            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {                                      
                    result.SetPixel(x, y, Color.FromArgb(255, res1.GetPixel(x,y).R-res2.GetPixel(x,y).R, res1.GetPixel(x, y).G - res2.GetPixel(x, y).G, res1.GetPixel(x, y).B - res2.GetPixel(x, y).B));
                }
            return result;
        }
    }
}
