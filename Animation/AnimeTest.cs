using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation
{
    internal class AnimeTest : AbstractAnimation
    {

        float[] x = new float[AnimationConfig.maxSprite];
        float[] y = new float[AnimationConfig.maxSprite];
        float[] zx = new float[AnimationConfig.maxSprite];
        float[] zy = new float[AnimationConfig.maxSprite];

        public AnimeTest(System.Windows.Forms.Form owner) : base(owner, "テスト")
        {
        }

        public override void Initalize()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < AnimationConfig.maxSprite; i++)
            {
                x[i] = rnd.Next(AnimationConfig.bmpWidth);
                y[i] = rnd.Next(AnimationConfig.bmpHeight);
                zx[i] = rnd.Next(10) + 1;
                zy[i] = rnd.Next(10) + 1;
            }
        }

        public override void OnDraw(Graphics g)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            using (Brush bkBrush = new SolidBrush(Color.Black))
            using (Brush whiteBrush = new SolidBrush(Color.White))
            using (Pen whitePen = new Pen(Color.White))
            {
                int bmpWidth = AnimationConfig.bmpWidth;
                int bmpHeight = AnimationConfig.bmpHeight;

                g.FillRectangle(bkBrush, 0, 0, bmpWidth, bmpHeight);
                g.DrawString("test", Owner.Font, whiteBrush, new Point(100, 100));
                for (int i = 0; i < AnimationConfig.maxSprite; i++)
                {
                    x[i] += zx[i];
                    if (x[i] < 0)
                    {
                        x[i] = 0;
                        zx[i] = rnd.Next(10) + 1;
                    }
                    else if (x[i] > bmpWidth)
                    {
                        x[i] = bmpWidth;
                        zx[i] = -1 * rnd.Next(10) + 1;
                    }

                    y[i] += zy[i];
                    if (y[i] < 0)
                    {
                        y[i] = 0;
                        zy[i] = rnd.Next(10) + 1;
                    }
                    else if (y[i] > bmpHeight)
                    {
                        y[i] = bmpHeight;
                        zy[i] = -1 * rnd.Next(10) + 1;
                    }

                    g.DrawRectangle(whitePen, x[i], y[i], 10f, 10f);
                }
            }
        }
    }
}
