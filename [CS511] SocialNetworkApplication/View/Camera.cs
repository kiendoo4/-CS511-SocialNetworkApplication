using Accord.Video.VFW;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class Camera : Form
    {
        public event EventHandler imgButton, vidButton;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private AVIWriter aviWriter;
        private bool isRecording = false;
        public Camera()
        {
            InitializeComponent();
            InitializeCamera();
            panel4.Click += button1_Click;
            takepic.Click += button1_Click;
            label3.Click += button1_Click;
        }

        public Camera(string role)
        {
        }

        private void InitializeCamera2()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += Video_NewFrame2;
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("No video sources found");
            }
        }

        private void Video_NewFrame2(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            // Display the frame in the PictureBox
            takepic.Image = (Bitmap)eventArgs.Frame.Clone();

            // Write the frame to the AVI file if recording
            if (aviWriter != null && isRecording)
            {
                aviWriter.AddFrame((Bitmap)eventArgs.Frame.Clone());
            }
        }


        private void InitializeCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += Video_NewFrame;
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("No video sources found");
            }
        }

        private void Video_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
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
