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
    public partial class Grayscale_form : Form
    {
        [DllImport("Project.dll")]
        private static extern int GrayScale([In, Out]int[] redArr, [In, Out]int[] greenArr, [In, Out]int[] blueArr, int sz);

        //Color[] graysc_RE;
        Form1 form1 = new Form1();
        Bitmap Image;
        Bitmap grayImage;
        public Grayscale_form(Image image, Color[] graysc_RE)
        {
            //Color[] graysc_RE;
            InitializeComponent();
            //graysc_RE = form1.pixels_arr_RE;
            int size = graysc_RE.Length;
            Color[] grayss = new Color[graysc_RE.Length];
            int [] redArr_S = new int[graysc_RE.Length];
            int [] blueArr_S = new int[graysc_RE.Length];
            int [] greenArr_S = new int[graysc_RE.Length];            

            for (int i = 0; i < graysc_RE.Length; i++)
            {
                redArr_S[i] = graysc_RE[i].R;
                blueArr_S[i] = graysc_RE[i].B;
                greenArr_S[i] = graysc_RE[i].G;
                
            }

            GrayScale(redArr_S, greenArr_S, blueArr_S, size);

            for (int i = 0; i < graysc_RE.Length; i++)
            {
                //int pixel = redArr_S[i];
                grayss[i] = Color.FromArgb( redArr_S[i], greenArr_S[i], blueArr_S[i]);
            }
            
            Image = new Bitmap(image);
            grayImage = new Bitmap(Image.Width, Image.Height);
            int count = 0;

            for (int i = 0; i < Image.Width; i++)
            {
                for (int j = 0; j < Image.Height; j++)
                {
                    grayImage.SetPixel(i, j, grayss[count]);
                    count++;
                }
            }

            pic_Box_graysc.Image = grayImage;

            //greyscale func. call
            


        }

        private void graysc_save_btn_Click(object sender, EventArgs e)
        {
            // save grayscale image
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(sfd.FileName))
                {
                    System.IO.File.Delete(sfd.FileName);
                }
                grayImage.Save(sfd.FileName);
                MessageBox.Show("Image Saved!");
            }
            
            
        }

        private void Grayscale_form_Load(object sender, EventArgs e)
        {

        }
    }
}
