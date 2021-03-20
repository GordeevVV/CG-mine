using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CompGr1
{
    class TopHat:MathMorf
    {
        public override Bitmap procImg(Bitmap sourceImage, bool[,] mask, int MW, int MH/*, BackgroundWorker worker*/)
        {
            MathMorf eros1 = new Erosion();
            Object locker = new Object();
            Bitmap res1= new Bitmap(sourceImage.Width, sourceImage.Height);
                 res1 = eros1.procImg(sourceImage, mask, MW, MH/*, worker*/);
                Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
                for (int y = 0; y < sourceImage.Height; y++)
                    for (int x = 0; x < sourceImage.Width; x++)
                    {
                        result.SetPixel(x, y, Color.FromArgb(255, sourceImage.GetPixel(x, y).R - res1.GetPixel(x, y).R, sourceImage.GetPixel(x, y).G - res1.GetPixel(x, y).G, sourceImage.GetPixel(x, y).B - res1.GetPixel(x, y).B));
                    }
                return result;
            
        }
    }
}
