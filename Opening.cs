using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CompGr1
{
    class Opening:MathMorf
    {
        public override Bitmap procImg(Bitmap sourceImage, bool[,] mask, int MW, int MH/*, BackgroundWorker worker*/)
        {
            MathMorf eros = new Erosion();
            MathMorf dil = new Dilation();
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            result =eros.procImg(sourceImage, mask, MW, MH/*,worker*/);
            result = dil.procImg(result, mask, MW, MH/*,worker*/);
            return result;
        }
    }
}
