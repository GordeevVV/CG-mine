using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CompGr1
{
    abstract class MathMorf
    {
        protected bool[,] mask = null;
        protected MathMorf() { }
        public MathMorf(bool[,] mask1)
        {

            this.mask = mask1;
        }
        public abstract Bitmap procImg(Bitmap sourceImage, bool[,] mask,int MW,int MH/*,BackgroundWorker worker*/);
        
    }
}
