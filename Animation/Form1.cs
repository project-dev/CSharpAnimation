using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using AForge.Video.FFMPEG;

namespace Animation
{
    public partial class Form : System.Windows.Forms.Form
    {

        private delegate void NoParamDelegate();
        
        
        private VideoFileWriter videoWriter = null;

        private Thread thread = null;
        private Bitmap bmp = null;

        private AbstractAnimation currentAnime = null;

        public Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            cmbAnime.Items.Add(new AnimeTest(this));
            cmbAnime.Items.Add(new IngressHyperion(this));
            cmbAnime.Items.Add(new ChannelOpening(this));

            cmbAnime.SelectedIndex = 0;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (AnimationConfig.isWriteMode == false && bmp != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.None;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.None;
                e.Graphics.InterpolationMode = InterpolationMode.Low;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                e.Graphics.DrawImage(bmp, 0, 0);
            }
            else
            {
                base.OnPaint(e);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            AnimationConfig.isWriteMode = cbWriteMode.Checked;
            AnimationConfig.isOutCopyrighte = chkOutCopyright.Checked;
            if (currentAnime == null)
            {
                return;
            }

            if (bmp == null)
            {
                bmp = new Bitmap(AnimationConfig.bmpWidth, AnimationConfig.bmpHeight);

                // アニメーション初期化
                currentAnime.Initalize();

                if (AnimationConfig.isWriteMode == true)
                {
                    var text = txtLength.Text;
                    var movieLength = AnimationConfig.movieLength;
                    if (!Regex.IsMatch(text, "^[0-9]+$") || !int.TryParse(text, out movieLength))
                    {
                        MessageBox.Show("正しい時間を設定してください", "エラー");
                        return;
                    }
                    AnimationConfig.movieLength = movieLength;

                    AnimationConfig.writeFrameCnt = 0;
                    int bitRate = (AnimationConfig.bmpWidth * AnimationConfig.bmpHeight) * Bitmap.GetPixelFormatSize(bmp.PixelFormat) * AnimationConfig.framerate / 1000;
                    videoWriter = new VideoFileWriter();
                    if (chkOutAVI.Checked)
                    {
                        videoWriter.Open(@"C:\data\test4.avi", bmp.Width, bmp.Height, AnimationConfig.framerate, VideoCodec.Raw);
                    }
                    else
                    {
                        videoWriter.Open(@"C:\data\test4.mp4", bmp.Width, bmp.Height, AnimationConfig.framerate, VideoCodec.MPEG4);
                    }
                    //videoWriter.Open(@"C:\data\test4.mp4", bmp.Width, bmp.Height, framerate, VideoCodec.MPEG4, bitRate);

                }
                else
                {
                    if (videoWriter != null)
                    {
                        videoWriter.Close();
                        videoWriter.Dispose();
                    }
                    videoWriter = null;
                }


                thread = new Thread((ThreadStart)delegate ()
                {
                    long tm = 0;
                    long frm = 0;
                    while (thread != null)
                    {
                        tm = DateTime.Now.Ticks;
                        draw();
                        frm++;
                        if (AnimationConfig.isWriteMode == false)
                        {
                            Invoke((NoParamDelegate)delegate ()
                            {
                                Invalidate();
                                Update();
                            });
                            long wait = (DateTime.Now.Ticks - tm) / TimeSpan.TicksPerMillisecond;
                            Thread.Sleep((int)wait);
                            Console.WriteLine("---");
                        }
                        else
                        {
                            AnimationConfig.writeFrameCnt++;
                            if(AnimationConfig.writeFrameCnt >= AnimationConfig.framerate * AnimationConfig.movieLength)
                            {
                                // 動画の作成終了
                                thread = null;
                                this.Invoke((NoParamDelegate)delegate ()
                                {
                                    btnExecute.Enabled = true;
                                    cmbAnime.Enabled = true;

                                    if (videoWriter != null)
                                    {
                                        try
                                        {
                                            videoWriter.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);

                                        }
                                    }
                                    videoWriter = null;

                                });
                            }
                        }

                        Invoke((NoParamDelegate)delegate()
                        {
                            Console.WriteLine("Frame " + frm.ToString());
                        });
                    }
                });
                cmbAnime.Enabled = false;
                thread.Start();
            }
            else
            {
                bmp.Dispose();
                if (videoWriter != null)
                {
                    videoWriter.Close();
                }
                videoWriter = null;

                bmp = null;

                thread = null;

                cmbAnime.Enabled = true;

            }
        }

        private void draw()
        {
            if (bmp == null)
            {
                return;
            }
            try
            {

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    currentAnime.OnDraw(g);

                    if (AnimationConfig.isOutCopyrighte)
                    {
                        using (Font f = new Font("Agent Prime", 14, FontStyle.Bold, GraphicsUnit.Point, 18))
                        using (Brush bkBrush = new SolidBrush(Color.Black))
                        using (Brush whiteBrush = new SolidBrush(Color.White))
                        {
                            var fX = AnimationConfig.bmpWidth - g.MeasureString("Copyright krohigewagma", f).Width - 16;
                            var fY = AnimationConfig.bmpHeight - g.MeasureString("Copyright krohigewagma", f).Height - 8;

                            g.DrawString("Copyright krohigewagma", f, whiteBrush, fX - 2, fY - 2);
                            g.DrawString("Copyright krohigewagma", f, whiteBrush, fX - 2, fY - 0);
                            g.DrawString("Copyright krohigewagma", f, whiteBrush, fX - 2, fY + 2);

                            g.DrawString("Copyright krohigewagma", f, whiteBrush, fX - 0, fY - 2);
                            g.DrawString("Copyright krohigewagma", f, whiteBrush, fX - 0, fY - 0);
                            g.DrawString("Copyright krohigewagma", f, whiteBrush, fX - 0, fY + 2);

                            g.DrawString("Copyright krohigewagma", f, whiteBrush, fX + 2, fY - 2);
                            g.DrawString("Copyright krohigewagma", f, whiteBrush, fX + 2, fY - 0);
                            g.DrawString("Copyright krohigewagma", f, whiteBrush, fX + 2, fY + 2);

                            g.DrawString("Copyright krohigewagma", f, bkBrush, fX, fY);
                        }
                    }

                    if (AnimationConfig.isWriteMode == true && videoWriter != null)
                    {
                        videoWriter.WriteVideoFrame(bmp);
                    }
                }
                //this.Invalidate();
                //this.Invoke((NoParamDelegate)delegate()
                //{
                //    this.Update();
                //});
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private void cmbAnime_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentAnime = cmbAnime.SelectedItem as AbstractAnimation;
        }

    }

}
