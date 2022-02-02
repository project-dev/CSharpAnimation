using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation
{
    internal class IngressHyperion : AbstractAnimation
    {
        int wCnt = 0;
        int[] lineY = new int[9];
        float[] lineY2 = new float[9];
        int moveoffset = 200;

        public IngressHyperion(System.Windows.Forms.Form owner) : base(owner, "Ingress Hyperion")
        {
        }


        public override void Initalize()
        {
            moveoffset = 200;
            int addY = (int)(90 / lineY.Length);

            for (int i = 0; i < lineY.Length; i++)
            {
                lineY[i] = i * addY;
                lineY2[i] = i * addY;
            }
        }

        public override void OnDraw(Graphics g)
        {

            var bmpWidth = AnimationConfig.bmpWidth;
            var bmpHeight = AnimationConfig.bmpHeight;

            using (Brush bkBrush = new SolidBrush(Color.Black))
            using (Brush whiteBrush = new SolidBrush(Color.White))
            using (Pen whitePen = new Pen(Color.White))
            using (Pen blackPen1 = new Pen(Color.Black, 8))
            using (Pen blackPen2 = new Pen(Color.Black, 7))
            using (Pen blackPen3 = new Pen(Color.Black, 6))
            using (Pen blackPen4 = new Pen(Color.Black, 5))
            using (Pen blackPen5 = new Pen(Color.Black, 4))
            using (Pen blackPen6 = new Pen(Color.Black, 3))
            {
                g.FillRectangle(bkBrush, 0, 0, bmpWidth, bmpHeight);

                int baseY = bmpHeight / 2;

                int addY = (int)(90 / lineY.Length);

                var r = baseY / 4;
                g.FillPie(whiteBrush, new Rectangle(bmpWidth / 2 - r, baseY / 2 - r + moveoffset, r * 2, r * 2), 0, 360);

                for (int i = 0; i < lineY.Length; i++)
                {

                    double rad = (lineY2[i] + 270) * Math.PI / 180;
                    double addYPos = 1.0 + Math.Sin(rad);

                    //円の内部用
                    var posY = (baseY / 2 - r) + ((int)((r * 2) * addYPos)) - 8 + moveoffset;
                    if (0.0 <= lineY2[i] && lineY2[i] < 15.0)
                    {
                        g.DrawLine(blackPen1, new Point(bmpWidth / 2 - r, posY), new Point(bmpWidth / 2 + r, posY));
                    }
                    else if (15.0 <= lineY2[i] && lineY2[i] < 30.0)
                    {
                        g.DrawLine(blackPen2, new Point(bmpWidth / 2 - r, posY), new Point(bmpWidth / 2 + r, posY));
                    }
                    else if (30.0 <= lineY2[i] && lineY2[i] < 45.0)
                    {
                        g.DrawLine(blackPen3, new Point(bmpWidth / 2 - r, posY), new Point(bmpWidth / 2 + r, posY));
                    }
                    else if (45.0 <= lineY2[i] && lineY2[i] < 60.0)
                    {
                        g.DrawLine(blackPen4, new Point(bmpWidth / 2 - r, posY), new Point(bmpWidth / 2 + r, posY));
                    }
                    else if (60.0 <= lineY2[i] && lineY2[i] < 75.0)
                    {
                        g.DrawLine(blackPen5, new Point(bmpWidth / 2 - r, posY), new Point(bmpWidth / 2 + r, posY));
                    }
                    else
                    {
                        g.DrawLine(blackPen6, new Point(bmpWidth / 2 - r, posY), new Point(bmpWidth / 2 + r, posY));
                    }
                    rad = (lineY[i] + 270) * Math.PI / 180;
                }

                g.FillRectangle(bkBrush, new Rectangle(bmpWidth / 2 - r, baseY, r * 2, r * 2));
                g.DrawLine(whitePen, new Point(0, baseY), new Point(1024, baseY));

                for (int i = 0; i < lineY.Length; i++)
                {
                    double rad = (lineY2[i] + 270) * Math.PI / 180;
                    double addYPos = 1.0 + Math.Sin(rad);
                    // 下のアニメーション用
                    int posY = baseY + ((int)(baseY * addYPos));
                    g.DrawLine(whitePen, new Point(0, posY), new Point(1024, posY));

                    lineY[i]++;
                    if (lineY[i] > 90)
                    {
                        lineY[i] = 0;
                    }

                    lineY2[i] += 0.5f;
                    if (lineY2[i] > 92.0)
                    {
                        lineY2[i] = 0;
                    }

                    wCnt = 0;
                }
                moveoffset--;
                if (moveoffset <= 0)
                {
                    moveoffset = 0;
                }
                wCnt++;
            }
        }
    }
}
