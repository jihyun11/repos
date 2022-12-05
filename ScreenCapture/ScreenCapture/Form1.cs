using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace ScreenCapture
{
    public partial class Form1 : Form
    {

        Point oriLocalPoint;
        Size orgLocalSize;

        bool orgbool = true;
        bool capbool = false;

        Graphics ScreenG;
        Bitmap CapWin;

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c')
            {
                orgbool = false;
                capbool = true;

                this.Opacity = 0.0;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Location = new Point(0, 0);
                this.Size = Screen.PrimaryScreen.Bounds.Size;
                var fullScreen = Screen.PrimaryScreen.Bounds;

                CapWin = new Bitmap(fullScreen.Width, fullScreen.Height);

                ScreenG = Graphics.FromImage(CapWin);

                ScreenG.CopyFromScreen(PointToScreen(new Point(0, 0)), new Point(0, 0), fullScreen.Size);

                picbScreen.Image = CapWin;

                player.SoundLocation = @"..\..\wav\capture.wav";
                player.Play();

                this.Opacity = 100.0;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.Location = oriLocalPoint;
                this.Size = orgLocalSize;
                orgbool = true;
            }
            else if (e.KeyChar == 'e')
            {
                player.SoundLocation = @"..\..\wav\ereser.wav";
                player.Play();

                capbool = false;
                picbScreen.Image = null;

            }
            else if (e.KeyChar == 's')
            {
                if (capbool == true)
                {
                    using (var SFile = new SaveFileDialog())
                    {
                        SFile.OverwritePrompt = true;
                        SFile.FileName = "화면캡쳐";
                        SFile.Filter = "이미지 파일(*.jpg)|*.jpg";
                        DialogResult result = SFile.ShowDialog();
                        if(result == DialogResult.OK)
                        {
                            CapWin.Save(SFile.FileName, ImageFormat.Jpeg);
                        }
                    }
                } 
                else
                {
                    MessageBox.Show("캡쳐한 화면이 없습니다.", "알림", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if(orgbool == true)
            {
                oriLocalPoint = Location;
                orgLocalSize = Size;
            }
        }
    }
}
