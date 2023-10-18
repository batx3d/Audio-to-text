using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vosk;
using System.Security.Cryptography.X509Certificates;
using System.Net.WebSockets;

namespace AudioToText
{
    public partial class Form1 : Form
    {

        public string audioPath = null;
        public string savePath = null;
        public string fileExtension = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void PathAudio_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                audioPath = openFileDialog1.FileName;
                fileExtension =Path.GetExtension(audioPath).ToLower();
            }

            textBox1.Text = audioPath;





        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savePath = saveFileDialog1.FileName;
            }
            ConvertAudiotoText convertAudiotoText = new ConvertAudiotoText();
            convertAudiotoText.SaveText(savePath);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (audioPath != null)
                {
                    Thread threadInput = new Thread(DisplayData);
                    threadInput.Start();
                }
                else { MessageBox.Show("Файл не выбран!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            catch (Exception ex) { }

        }

        private void DisplayData()
        {
            SetLoading(true);

            ConvertAudiotoText ConvertAudiotoText = new ConvertAudiotoText();
            ConvertAudiotoText.Translate(audioPath);

            SetLoading(false);
        }

        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = true;
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = false;
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                });
            }
        }
    }
}