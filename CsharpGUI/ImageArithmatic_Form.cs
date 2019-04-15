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
    public partial class ImageArithmatic_Form : Form
    {
        [DllImport("Project.dll")]
        private static extern int ImageAddition([In, Out]int[] array1, [In, Out]int[] array2, int sz);

        [DllImport("Project.dll")]
        private static extern int ImageSubtraction([In, Out]int[] array1, [In, Out]int[] array2, int sz);

        public Image image1;
        public Image image2;
        public Bitmap bitmap1;
        public Bitmap bitmap2;
        public Color[] pixelsArray1;
        public Color[] pixelsArray2;
        int size1;
        int size2;
        Bitmap resultImage;

        public ImageArithmatic_Form()
        {
            InitializeComponent();
        }

        private void open_img_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Files|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                image1 = Image.FromFile(fileDialog.FileName);
                bitmap1 = new Bitmap(fileDialog.FileName);
                size1 = getPixels(bitmap1).Length;                
                pixelsArray1 = new Color[size1];         
                pixelsArray1 = getPixels(bitmap1);
                pictureBox1.Image = image1;
            }

        }

        private void open_img2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Files|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                image2 = Image.FromFile(fileDialog.FileName);
                bitmap2 = new Bitmap(fileDialog.FileName);
                size2 = getPixels(bitmap2).Length;
                pixelsArray2 = new Color[size2];
                pixelsArray2 = getPixels(bitmap2);
                pictureBox2.Image = image2;
            }

            
        }

        private void AddImages_btn_Click(object sender, EventArgs e)
        {
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                MessageBox.Show("Please enter images with the same width and height!");
            }
            else
            {
                int[] redArray1 = new int[size1];
                int[] greenArray1 = new int[size1];
                int[] blueArray1 = new int[size1];

                int[] redArray2 = new int[size2];
                int[] greenArray2 = new int[size2];
                int[] blueArray2 = new int[size2];

                pixelToInt(redArray1, greenArray1, blueArray1, pixelsArray1, size1);
                pixelToInt(redArray2, greenArray2, blueArray2, pixelsArray2, size2);

                ImageAddition(redArray1, redArray2, size1);
                ImageAddition(greenArray1, greenArray2, size1);
                ImageAddition(blueArray1, blueArray2, size1);

                pictureBox3.Image = setPixels(image1.Width, image1.Height, redArray1, greenArray1, blueArray1, size1);
            }
        }
        

        private void subtractImages_btn_Click(object sender, EventArgs e)
        {
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                MessageBox.Show("Please enter images with the same width and height!");
            }

            else
            {
                int[] redArray1 = new int[size1];
                int[] greenArray1 = new int[size1];
                int[] blueArray1 = new int[size1];

                int[] redArray2 = new int[size2];
                int[] greenArray2 = new int[size2];
                int[] blueArray2 = new int[size2];

                pixelToInt(redArray1, greenArray1, blueArray1, pixelsArray1, size1);
                pixelToInt(redArray2, greenArray2, blueArray2, pixelsArray2, size2);

                ImageSubtraction(redArray1, redArray2, size1);
                ImageSubtraction(greenArray1, greenArray2, size1);
                ImageSubtraction(blueArray1, blueArray2, size1);

                pictureBox3.Image = setPixels(image1.Width, image1.Height, redArray1, greenArray1, blueArray1, size1);
                
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(sfd.FileName))
                {
                    System.IO.File.Delete(sfd.FileName);
                }
                resultImage.Save(sfd.FileName);
                MessageBox.Show("Image Saved!");
            }
        }

        public static Color[] getPixels(Bitmap bitmap)
        {
            int size = bitmap.Height * bitmap.Width;
            int k = 0;
            Color[] pixels = new Color[size];


            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixels[k] = bitmap.GetPixel(i, j);
                    k++;
                }
            }

            return pixels;
        }

        public void pixelToInt(int[] redArray, int[] greenArray, int[] blueArray, Color[] pixelArray, int arrSize)
        {
            for (int i = 0; i < arrSize; i++)
            {
                redArray[i] = pixelArray[i].R;
                greenArray[i] = pixelArray[i].G;
                blueArray[i] = pixelArray[i].B;
            }
        }

        public Bitmap setPixels(int width, int height, int[] redArray, int[] greenArray, int[] blueArray, int arrSize)
        {
            Color[] colorArray = new Color[arrSize];
            resultImage = new Bitmap(width, height);

            for (int i = 0; i < colorArray.Length; i++)
            {
                colorArray[i] = Color.FromArgb(redArray[i], greenArray[i], blueArray[i]);
            }

            int count = 0;

            for (int i = 0; i < resultImage.Width; i++)
            {
                for (int j = 0; j < resultImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, colorArray[count]);
                    count++;
                }
            }

            return resultImage;
        }
    }
}
