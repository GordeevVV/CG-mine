using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CompGr1
{
    class Closing:MathMorf
    {
        public override Bitmap procImg(Bitmap sourceImage, bool[,] mask, int MW, int MH/*, BackgroundWorker worker*/)
        {
            MathMorf eros = new Erosion();
            MathMorf dil = new Dilation();
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            result = dil.procImg(sourceImage, mask, MW, MH/*,worker*/);
            result = eros.procImg(result, mask, MW, MH/*,worker*/);
            return result;
        }
    }
}
