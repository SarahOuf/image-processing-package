using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CsharpGUI
{
    public partial class Brightness_form : Form
    {
        //Color[] brightness_RE;
        //Image image_brt;
        Form1 form1 = new Form1();
        [DllImport("Project.dll")]
        private static extern void AdjustBrightness(int brightnessValue_RA, int size, [In, Out]int[] redArr, [In, Out]int[] greenArr, [In, Out]int[] blueArr);

        Color[] brightened;
        Color[] brightness;
        int[] redArr_RA;
        int[] blueArr_RA;
        int[] greenArr_RA;
        static public int brightnessValue=0;
        int size;
        //Bitmap Image;
        Bitmap brightImage;
        //int trackValue = 0;

        public Brightness_form(Image image, Color[] brightness_RE)
        {
            InitializeComponent();
            //brightness_RE = form1.pixels_arr_RE;
            pictureBox_brt.Image = image;
            brightness = brightness_RE;
            
            brightImage = (Bitmap)pictureBox_brt.Image;

        }

        private void brightness_save_btn_Click(object sender, EventArgs e)
        {
            // save func.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(sfd.FileName))
                {
                    System.IO.File.Delete(sfd.FileName);
                }
                pictureBox_brt.Image.Save(sfd.FileName);
                MessageBox.Show("Image Saved!");
            }
        }

        private void brightness_slider_Scroll(object sender, EventArgs e)
        {
            //brightness func. call
            
            brightnessValue = Convert.ToInt32(brightness_slider.Value);
            brightnessValueLabel.Text = brightness_slider.Value.ToString();
            pictureBox_brt.Image = brightnessAdjustment(brightImage, brightnessValue);
        }

        private Bitmap brightnessAdjustment(Bitmap img, int brightnessVA)
        {
            brightened = new Color[brightness.Length];
            redArr_RA = new int[brightness.Length];
            blueArr_RA = new int[brightness.Length];
            greenArr_RA = new int[brightness.Length];

            for (int i = 0; i < brightness.Length; i++)
            {
                redArr_RA[i] = brightness[i].R;
                blueArr_RA[i] = brightness[i].B;
                greenArr_RA[i] = brightness[i].G;

            }

            size = brightness.Length - 1;

            AdjustBrightness(brightnessValue, size, redArr_RA, greenArr_RA, blueArr_RA);

            for (int i = 0; i < brightened.Length; i++)
            {
                //int pixel = redArr_S[i];
                brightened[i] = Color.FromArgb(redArr_RA[i], greenArr_RA[i], blueArr_RA[i]);
            }

            int count = 0;

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    img.SetPixel(i, j, brightened[count]);
                    count++;
                }
            }

            return img;
        }
    }
}
