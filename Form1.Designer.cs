namespace AudioToText
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            openFileDialog1 = new OpenFileDialog();
            PathAudio = new Button();
            saveFileDialog1 = new SaveFileDialog();
            Save = new Button();
            textBox1 = new TextBox();
            button1 = new Button();
            picLoader = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLoader).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Audio Files|*.mp3;*.wav";
            // 
            // PathAudio
            // 
            PathAudio.Location = new Point(12, 29);
            PathAudio.Name = "PathAudio";
            PathAudio.Size = new Size(151, 23);
            PathAudio.TabIndex = 0;
            PathAudio.Text = "Открыть айудио файл";
            PathAudio.UseVisualStyleBackColor = true;
            PathAudio.Click += PathAudio_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = ".txt|";
            saveFileDialog1.Tag = ".txt";
            saveFileDialog1.Title = "Browse Text Files";
            // 
            // Save
            // 
            Save.Location = new Point(169, 123);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 1;
            Save.Text = "Сохранить";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(169, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(197, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(137, 82);
            button1.Name = "button1";
            button1.Size = new Size(136, 23);
            button1.TabIndex = 3;
            button1.Text = "Расшифровать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // picLoader
            // 
            picLoader.Image = (Image)resources.GetObject("picLoader.Image");
            picLoader.Location = new Point(30, 123);
            picLoader.Name = "picLoader";
            picLoader.Size = new Size(336, 23);
            picLoader.SizeMode = PictureBoxSizeMode.StretchImage;
            picLoader.TabIndex = 4;
            picLoader.TabStop = false;
            picLoader.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 192);
            Controls.Add(picLoader);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(Save);
            Controls.Add(PathAudio);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picLoader).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button PathAudio;
        private SaveFileDialog saveFileDialog1;
        private Button Save;
        private TextBox textBox1;
        private Button button1;
        private PictureBox picLoader;
    }
}