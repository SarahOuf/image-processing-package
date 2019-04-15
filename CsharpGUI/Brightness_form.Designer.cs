namespace CsharpGUI
{
    partial class Brightness_form
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
            this.pictureBox_brt = new System.Windows.Forms.PictureBox();
            this.brightness_save_btn = new System.Windows.Forms.Button();
            this.brightness_slider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.brightnessValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_brt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightness_slider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_brt
            // 
            this.pictureBox_brt.Location = new System.Drawing.Point(18, 16);
            this.pictureBox_brt.Name = "pictureBox_brt";
            this.pictureBox_brt.Size = new System.Drawing.Size(406, 298);
            this.pictureBox_brt.TabIndex = 0;
            this.pictureBox_brt.TabStop = false;
            // 
            // brightness_save_btn
            // 
            this.brightness_save_btn.Location = new System.Drawing.Point(331, 402);
            this.brightness_save_btn.Name = "brightness_save_btn";
            this.brightness_save_btn.Size = new System.Drawing.Size(93, 31);
            this.brightness_save_btn.TabIndex = 1;
            this.brightness_save_btn.Text = "Save";
            this.brightness_save_btn.UseVisualStyleBackColor = true;
            this.brightness_save_btn.Click += new System.EventHandler(this.brightness_save_btn_Click);
            // 
            // brightness_slider
            // 
            this.brightness_slider.Location = new System.Drawing.Point(45, 351);
            this.brightness_slider.Maximum = 255;
            this.brightness_slider.Minimum = -255;
            this.brightness_slider.Name = "brightness_slider";
            this.brightness_slider.Size = new System.Drawing.Size(344, 45);
            this.brightness_slider.TabIndex = 2;
            this.brightness_slider.TickFrequency = 15;
            this.brightness_slider.Scroll += new System.EventHandler(this.brightness_slider_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Adjust Brightness";
            // 
            // brightnessValueLabel
            // 
            this.brightnessValueLabel.AutoSize = true;
            this.brightnessValueLabel.Location = new System.Drawing.Point(389, 361);
            this.brightnessValueLabel.Name = "brightnessValueLabel";
            this.brightnessValueLabel.Size = new System.Drawing.Size(13, 13);
            this.brightnessValueLabel.TabIndex = 4;
            this.brightnessValueLabel.Text = "0";
            // 
            // Brightness_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 445);
            this.Controls.Add(this.brightnessValueLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.brightness_slider);
            this.Controls.Add(this.brightness_save_btn);
            this.Controls.Add(this.pictureBox_brt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Brightness_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brightness_form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_brt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightness_slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_brt;
        private System.Windows.Forms.Button brightness_save_btn;
        private System.Windows.Forms.TrackBar brightness_slider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label brightnessValueLabel;
    }
}