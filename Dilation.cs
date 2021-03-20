using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace CompGr1
{
    class Dilation:MathMorf
    {
        public override Bitmap procImg(Bitmap sourceImage,bool [,]mask,int MW, int MH/*, BackgroundWorker worker*/)
        {
            Bitmap result= new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int y = MH / 2; y < sourceImage.Height - MH/2 ; y++)
                  for (int x = MW / 2; x < sourceImage.Width - MW / 2; x++)
             {
                   /* worker.ReportProgress((int)((float)y / result.Width * 100));
                    if (worker.CancellationPending)
                        return null;*/
                    int maxR= 0;
                    int maxG = 0;
                    int maxB = 0;
                    for (int j = -MH / 2; j <= MH / 2; j++)
                        for (int i = -MW / 2; i <= MW / 2; i++)
                        {
                            if ((mask[i + MW / 2, j + MH / 2]) && (sourceImage.GetPixel(x + i, y + j).R > maxR))
                            {
                                maxR = sourceImage.GetPixel(x + i, y + j).R;
                            }
                            if ((mask[i + MW / 2, j + MH / 2]) && (sourceImage.GetPixel(x + i, y + j).G > maxG))
                            {
                                maxG = sourceImage.GetPixel(x + i, y + j).G;
                            }
                            if ((mask[i + MW / 2, j + MH / 2]) && (sourceImage.GetPixel(x + i, y + j).B > maxB))
                            {
                                maxB = sourceImage.GetPixel(x + i, y + j).B;
                            }
                        }
                    result.SetPixel(x,y, Color.FromArgb(255, maxR, maxG, maxB));
            }
            return result;
        }
    }
}
