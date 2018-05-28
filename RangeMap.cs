using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOD_System
{
    class RangeMap
    {
        public static Bitmap RangeMapGenerator(Bitmap leftImage, Bitmap rightImage)
        {

            Bitmap rangeBitmap = new Bitmap(leftImage.Width, leftImage.Height);

            for (int x = 2; x < leftImage.Width - 2; x++)
            {
                for (int y = 2; y < leftImage.Height - 2; y++)
                {

                    int sad = 0;

                    for (int m = -2; m < 2; m++)
                    {
                        for (int n = -2; n < 2; n++)
                        {
                            sad += Math.Abs(leftImage.GetPixel(x + m, y + n).ToArgb() - rightImage.GetPixel(x + m, y + n).ToArgb());
                        }
                    }

                    rangeBitmap.SetPixel(x, y, Color.FromArgb(calcualteRange(sad) * 2000000000));
                }
            }

            return rangeBitmap;
        }


        public static int calcualteRange(int sad)
        {
            double baseLine = 0.176, focalLength = 887, range;

            range = (40 * baseLine * focalLength / sad) * 10000;

            return (int)range;
        }

    }
}
