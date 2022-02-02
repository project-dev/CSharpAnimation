using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation
{
    internal class ChannelOpening : AbstractAnimation
    {

        Dictionary<String, List<Image>> chOpAnime = null;
        int opCnt = 0;
        int kmX = 0;
        int kmY = 0;

        int tX = 0;
        int tY = 0;

        int optState = 0;

        public ChannelOpening(System.Windows.Forms.Form owner):base(owner, "Channel Opening")
        {
        }

        public override void Initalize()
        {
            // SVGから黒髭和熊のアニメーションを読み込む
            //var magickImage = new ImageMagick.MagickImage("");
            if (chOpAnime == null)
            {
                chOpAnime = new Dictionary<String, List<Image>>();
                chOpAnime.Add("walk", new List<Image>());
                chOpAnime.Add("stand", new List<Image>());
                chOpAnime.Add("title", new List<Image>());

                var curDir = AppDomain.CurrentDomain.BaseDirectory;
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w001.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w002.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w003.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w004.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w003.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w002.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w001.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w005.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w006.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w007.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w006.png", true));
                chOpAnime["walk"].Add(Image.FromFile(curDir + "/ch_opening/w005.png", true));

                chOpAnime["stand"].Add(Image.FromFile(curDir + "/ch_opening/s001.png", true));
                chOpAnime["stand"].Add(Image.FromFile(curDir + "/ch_opening/s002.png", true));
                chOpAnime["stand"].Add(Image.FromFile(curDir + "/ch_opening/s003.png", true));
                chOpAnime["stand"].Add(Image.FromFile(curDir + "/ch_opening/s004.png", true));
                chOpAnime["stand"].Add(Image.FromFile(curDir + "/ch_opening/s003.png", true));
                chOpAnime["stand"].Add(Image.FromFile(curDir + "/ch_opening/s002.png", true));

                chOpAnime["title"].Add(Image.FromFile(curDir + "/ch_opening/title.png", true));
            }
            kmX = (chOpAnime["walk"][0].Width / 2) * -1;
            kmY = (AnimationConfig.bmpHeight - chOpAnime["walk"][0].Height) / 2;
            tX = (AnimationConfig.bmpWidth - chOpAnime["title"][0].Width) / 2;
            tY = chOpAnime["title"][0].Height * -1;
            opCnt = 0;
            optState = 0;
        }

        public override void OnDraw(Graphics g)
        {
            using (Brush bkBrush = new SolidBrush(Color.White))
            {

                int bmpWidth = AnimationConfig.bmpWidth;
                int bmpHeight = AnimationConfig.bmpHeight;

                g.FillRectangle(bkBrush, 0, 0, bmpWidth, bmpHeight);


                switch (optState)
                {
                    case 0:
                        g.DrawImage(chOpAnime["walk"][opCnt / 2], kmX, 100);
                        kmX += 10;
                        if (kmX >= bmpWidth)
                        {
                            kmY = bmpHeight;
                            opCnt = 1;
                            optState = 1;
                        }
                        else
                        {
                            opCnt++;
                            if (chOpAnime["walk"].Count * 2 <= opCnt)
                            {
                                opCnt = 0;
                            }
                        }
                        break;
                    case 1:
                        g.DrawImage(chOpAnime["stand"][0], 50, kmY);
                        g.DrawImage(chOpAnime["title"][0], tX, tY);
                        kmY -= 15;
                        tY += 10;
                        if (kmY <= bmpHeight - (chOpAnime["stand"][0].Height / 3 * 2))
                        {
                            opCnt = 1;
                            optState = 2;
                        }
                        break;
                    case 2:
                        opCnt++;
                        g.DrawImage(chOpAnime["stand"][(opCnt / 6) + 1], 50, kmY);
                        g.DrawImage(chOpAnime["title"][0], tX, tY);
                        if ((chOpAnime["stand"].Count - 2) * 6 <= opCnt)
                        {
                            opCnt = 0;
                        }
                        tY += 10;
                        if (tY >= (bmpHeight - chOpAnime["title"][0].Height) / 3)
                        {
                            tY = (bmpHeight - chOpAnime["title"][0].Height) / 3;
                        }
                        break;
                }

                // 黒髭和熊チャンネルのタイトルを表示

            }
        }
    }
}
