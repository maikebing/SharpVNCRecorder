using NAudio.Wave;
using SharpAvi;
using SharpAvi.Codecs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VncRecorder.Properties;
using VncSharp;

namespace VncRecorder
{
    public partial class RecorderForm : Form
    {

        private readonly System.Timers.Timer recordingTimer;
        public RecorderForm()
        {
            InitializeComponent();
            recordingTimer = new System.Timers.Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            recordingTimer.Elapsed += RecordingTimer_Elapsed; ;

        }
        public string Elapsed { get; set; }

        private void RecordingTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var elapsed = recordingStopwatch.Elapsed;
            Elapsed = string.Format(
                "{0:00}:{1:00}",
                Math.Floor(elapsed.TotalMinutes),
                elapsed.Seconds);
        }



        private string outputFolder;
        private FourCC encoder;
        private int encodingQuality;
        private int audioSourceIndex;
        private SupportedWaveFormat audioWaveFormat;
        private bool encodeAudio;
        private int audioQuality;
        private void buttonStartRecord_Click(object sender, EventArgs e)
        {



            var exePath = new Uri(System.Reflection.Assembly.GetEntryAssembly().Location).LocalPath;
            outputFolder = System.IO.Path.GetDirectoryName(exePath);

            encoder = KnownFourCCs.Codecs.X264;
            encodingQuality = 70;

            audioSourceIndex = -1;
            audioWaveFormat = SupportedWaveFormat.WAVE_FORMAT_44M16;
            encodeAudio = true;
            audioQuality = (Mp3AudioEncoderLame.SupportedBitRates.Length + 1) / 2;


            // assuming your RemoteDesktop control is named rd
            rd.ConnectComplete +=
                new ConnectCompleteHandler(ConnectComplete);
            rd.ConnectionLost +=
                new EventHandler(ConnectionLost);

            // rd.Authenticate(this.textBoxPassword.Text);
            rd.GetPassword += () => this.textBoxPassword.Text;
            rd.AutoSize = true;
            rd.Connect(this.textBoxVncIp.Text, true, true);
            rd.Paint += Rd_Paint;
            this.buttonStartRecord.Enabled = false;
            this.buttonStop.Enabled = true;


        }

        private void Rd_Paint(object sender, PaintEventArgs e)
        {
            recorder.Desktop = (Image)rd.Desktop.Clone();
        }

        private readonly Stopwatch recordingStopwatch = new Stopwatch();
        private Recorder recorder;
        private string lastFileName;
        protected void ConnectComplete(object sender,
                   ConnectEventArgs e)
        {
            Text = e.DesktopName;

            lastFileName = System.IO.Path.Combine(outputFolder, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".avi");
            var bitRate = Mp3AudioEncoderLame.SupportedBitRates.OrderBy(br => br).ElementAt(audioQuality);
            recorder = new Recorder(lastFileName,
                encoder, encodingQuality,
                audioSourceIndex, audioWaveFormat, encodeAudio, bitRate, new System.Drawing.Size(e.DesktopWidth, e.DesktopHeight));
            recordingStopwatch.Start();
        }

        protected void ConnectionLost(object sender,
                                      EventArgs e)
        {
            recorder.Dispose();
            // Let the user know of lost connection
            MessageBox.Show("Lost Connection to Host!");
        }


        private void buttonStop_Click(object sender, EventArgs e)
        {
            recorder.Dispose();
            rd.Disconnect();

        }



        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }

}
