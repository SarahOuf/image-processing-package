namespace CsharpGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.open_img = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.brightness_btn = new System.Windows.Forms.Button();
            this.buttonInvertImage = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_removeNois = new System.Windows.Forms.TextBox();
            this.removeNoise_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(561, 375);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // open_img
            // 
            this.open_img.Location = new System.Drawing.Point(12, 412);
            this.open_img.Name = "open_img";
            this.open_img.Size = new System.Drawing.Size(102, 30);
            this.open_img.TabIndex = 1;
            this.open_img.Text = "Open image";
            this.open_img.UseVisualStyleBackColor = true;
            this.open_img.Click += new System.EventHandler(this.open_img_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "GrayScale";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // brightness_btn
            // 
            this.brightness_btn.Location = new System.Drawing.Point(628, 64);
            this.brightness_btn.Name = "brightness_btn";
            this.brightness_btn.Size = new System.Drawing.Size(120, 30);
            this.brightness_btn.TabIndex = 3;
            this.brightness_btn.Text = "Brightness";
            this.brightness_btn.UseVisualStyleBackColor = true;
            this.brightness_btn.Click += new System.EventHandler(this.brightness_btn_Click);
            // 
            // buttonInvertImage
            // 
            this.buttonInvertImage.Location = new System.Drawing.Point(628, 136);
            this.buttonInvertImage.Name = "buttonInvertImage";
            this.buttonInvertImage.Size = new System.Drawing.Size(120, 30);
            this.buttonInvertImage.TabIndex = 5;
            this.buttonInvertImage.Text = "Invert Colors";
            this.buttonInvertImage.UseVisualStyleBackColor = true;
            this.buttonInvertImage.Click += new System.EventHandler(this.buttonInvertImage_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(628, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Image Arithmatic";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_removeNois
            // 
            this.textBox_removeNois.Location = new System.Drawing.Point(579, 106);
            this.textBox_removeNois.Name = "textBox_removeNois";
            this.textBox_removeNois.Size = new System.Drawing.Size(43, 20);
            this.textBox_removeNois.TabIndex = 7;
            // 
            // removeNoise_btn
            // 
            this.removeNoise_btn.Location = new System.Drawing.Point(628, 100);
            this.removeNoise_btn.Name = "removeNoise_btn";
            this.removeNoise_btn.Size = new System.Drawing.Size(120, 30);
            this.removeNoise_btn.TabIndex = 8;
            this.removeNoise_btn.Text = "Remove noise";
            this.removeNoise_btn.UseVisualStyleBackColor = true;
            this.removeNoise_btn.Click += new System.EventHandler(this.removeNoise_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Border:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 462);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeNoise_btn);
            this.Controls.Add(this.textBox_removeNois);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonInvertImage);
            this.Controls.Add(this.brightness_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.open_img);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button open_img;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button brightness_btn;
        private System.Windows.Forms.Button buttonInvertImage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_removeNois;
        private System.Windows.Forms.Button removeNoise_btn;
        private System.Windows.Forms.Label label1;
    }
}

