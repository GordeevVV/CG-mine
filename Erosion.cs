using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CompGr1
{
    class Erosion: MathMorf
    {
        public override Bitmap procImg(Bitmap sourceImage, bool[,] mask, int MW, int MH/*, BackgroundWorker worker*/)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int y = MH / 2; y < sourceImage.Height - MH / 2; y++)
                 for (int x = MW / 2; x < sourceImage.Width - MW / 2; x++)
                {
                    /* worker.ReportProgress((int)((float)y / result.Width * 100));
                    if (worker.CancellationPending)
                        return null;*/
                    int minR = 255;
                int minG = 255;
                int minB = 255;
                    for (int j = -MH / 2; j <= MH / 2; j++)
                        for (int i = -MW / 2; i <= MW / 2; i++)
                        {
                            if ((mask[i + MW / 2, j + MH / 2]) && (sourceImage.GetPixel(x + i, y + j).R < minR))
                            {
                                minR = sourceImage.GetPixel(x + i, y + j).R;
                            }
                            if ((mask[i + MW / 2, j + MH / 2]) && (sourceImage.GetPixel(x + i, y + j).B < minB))
                            {
                                minB = sourceImage.GetPixel(x + i, y + j).B;
                            }
                            if ((mask[i + MW / 2, j + MH / 2]) && (sourceImage.GetPixel(x + i, y + j).G < minG))
                            {
                                minG = sourceImage.GetPixel(x + i, y + j).G;
                            }
                        }
                result.SetPixel(x, y, Color.FromArgb(255, minR, minG, minB));
            }
            return result;
        }
    }
}
