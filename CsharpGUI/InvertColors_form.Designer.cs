namespace CsharpGUI
{
    partial class InvertColors_form
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
            this.pic_Box_invert = new System.Windows.Forms.PictureBox();
            this.invertSave_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Box_invert)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Box_invert
            // 
            this.pic_Box_invert.Location = new System.Drawing.Point(50, 5);
            this.pic_Box_invert.Name = "pic_Box_invert";
            this.pic_Box_invert.Size = new System.Drawing.Size(680, 382);
            this.pic_Box_invert.TabIndex = 3;
            this.pic_Box_invert.TabStop = false;
            // 
            // invertSave_btn
            // 
            this.invertSave_btn.Location = new System.Drawing.Point(315, 393);
            this.invertSave_btn.Name = "invertSave_btn";
            this.invertSave_btn.Size = new System.Drawing.Size(108, 29);
            this.invertSave_btn.TabIndex = 2;
            this.invertSave_btn.Text = "Save";
            this.invertSave_btn.UseVisualStyleBackColor = true;
            this.invertSave_btn.Click += new System.EventHandler(this.invertSave_btn_Click);
            // 
            // InvertColors_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 427);
            this.Controls.Add(this.pic_Box_invert);
            this.Controls.Add(this.invertSave_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InvertColors_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InvertColors";
            this.Load += new System.EventHandler(this.InvertColors_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Box_invert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Box_invert;
        private System.Windows.Forms.Button invertSave_btn;
    }
}