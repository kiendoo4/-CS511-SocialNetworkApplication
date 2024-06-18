using AForge.Video.DirectShow;
using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Camera : Form
    {
        public event EventHandler imgButton;
        public Camera()
        {
            InitializeComponent();
            InitializeCamera();
            panel4.Click += button1_Click;
            takepic.Click += button1_Click;
            label3.Click += button1_Click;
        }

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private void InitializeCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("No video sources found");
            }
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Display the frame in the PictureBox
            takepic.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (takepic.Image != null)
            {
                string path = @"..\\..\\Data\\TakePicture\\";
                string[] files = Directory.GetFiles(path);
                int fileCount = files.Length;
                string savePath = path + Convert.ToString(fileCount + 1) + ".jpg";
                takepic.Image.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show($"Đã gửi hình", "Thông báo", MessageBoxButtons.OK);
                imgButton?.Invoke(savePath, e);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            base.OnFormClosing(e);
        }

        private void takepic_Click(object sender, EventArgs e)
        {

        }
    }
}
