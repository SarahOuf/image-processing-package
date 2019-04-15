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

    public partial class InvertColors_form : Form
    {
        [DllImport("Project.dll")]
        private static extern int ImageInvert([In, Out]int[] redArr, [In, Out]int[] greenArr, [In, Out]int[] blueArr, int sz);
        
        int[] redArray;
        int[] greenArray;
        int[] blueArray;
        Color[] inverted;
        Bitmap invertedImage;
        int arrSize;

        public InvertColors_form(Image image, Color[] pixelArray)
        {
            InitializeComponent();

            arrSize = pixelArray.Length;
            redArray = new int[arrSize];
            greenArray = new int[arrSize];
            blueArray = new int[arrSize];
            invertedImage = new Bitmap(image);

            for (int i = 0; i < arrSize; i++)
            {
                redArray[i] = pixelArray[i].R;
                greenArray[i] = pixelArray[i].G;
                blueArray[i] = pixelArray[i].B;
            }

            ImageInvert(redArray, greenArray, blueArray, arrSize);

            inverted = new Color[arrSize];

            for (int i = 0; i < inverted.Length; i++)
            {
                inverted[i] = Color.FromArgb(redArray[i], greenArray[i], blueArray[i]);
            }

            int count = 0;

            for (int i = 0; i < invertedImage.Width; i++)
            {
                for (int j = 0; j < invertedImage.Height; j++)
                {
                    invertedImage.SetPixel(i, j, inverted[count]);
                    count++;
                }
            }
            pic_Box_invert.Image = invertedImage;

        }

        private void InvertColors_form_Load(object sender, EventArgs e)
        {

        }

        private void invertSave_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(sfd.FileName))
                {
                    System.IO.File.Delete(sfd.FileName);
                }
                invertedImage.Save(sfd.FileName);
                MessageBox.Show("Image Saved!");
            }
        }
    }
}
