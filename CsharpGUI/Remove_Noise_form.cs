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
    public partial class Remove_Noise_form : Form
    {
        [DllImport("Project.dll")]
        private static extern void computeConst(int width, int height, int border);

        [DllImport("Project.dll")]
        private static extern int getWindow([In] int[] pixelArray, [In, Out] int[] resultArray);


        public int[] red_color_3_RE;
        public int[] blue_color_3_RE;
        public int[] green_color_3_RE;

        public int[] redArrayResult;
        public int[] blueArrayResult;
        public int[] greenArrayResult;

        int width, height;
        Bitmap resultImage;

        public Remove_Noise_form(Bitmap bitmap3, Color[] color3, int border, Image imageB)
        {
            InitializeComponent();

            width = bitmap3.Width;
            height = bitmap3.Height;

            int size = imageB.Width * imageB.Height;
            Bitmap imagebit = new Bitmap(imageB);
            int count1 = 0;
            Color[] colorPixel = new Color[size];

            for (int i = 0; i < imagebit.Width; i++)
            {
                for (int j = 0; j < imagebit.Height; j++)
                {
                    colorPixel[count1] = imagebit.GetPixel(i, j);
                    count1++;
                }
            }

            int size_3 = color3.Length;
            red_color_3_RE = new int[size_3];
            blue_color_3_RE = new int[size_3];
            green_color_3_RE = new int[size_3];
            for (int i = 0; i < color3.Length; i++)
            {
                red_color_3_RE[i] = color3[i].R;
                blue_color_3_RE[i] = color3[i].B;
                green_color_3_RE[i] = color3[i].G;
            }

            redArrayResult = new int[size_3];
            greenArrayResult = new int[size_3];
            blueArrayResult = new int[size_3];


            computeConst(width, height, border);

            getWindow(red_color_3_RE, redArrayResult);
            getWindow(green_color_3_RE, greenArrayResult);
            getWindow(blue_color_3_RE, blueArrayResult);

            int index = border / 2;

            int startIndex = height;
            int endIndex = size_3 - (startIndex + 1);

            Color[] newPixels = new Color[size_3];
            int count = 0;
            resultImage = new Bitmap(width, height);

            for (int i = 0; i < size_3; i++)
            {
                newPixels[i] = Color.FromArgb(redArrayResult[i], greenArrayResult[i], blueArrayResult[i]);
                
            }

            int H_size = imageB.Height + (2 * index);
            int W_size = imageB.Width + (2 * index);

            //for (int i = 0; i < index; i++)
            //{
            //    for (int j = 0; j < H_size; j++)
            //    {
            //        rn_bitmap.SetPixel(i, j, color);//i is height
            //        rn_bitmap.SetPixel(W_size - i - 1, j, color);//W_size - j - 1,
            //    }
            //}

            //for (int i = 0; i < W_size; i++)
            //{
            //    for (int j = 0; j < ext; j++)
            //    {
            //        rn_bitmap.SetPixel(i, j, color);
            //        rn_bitmap.SetPixel(i, H_size - j - 1, color);   //H_size - i - 1, j
            //    }
            //}

            //for (int i = ext; i < W_size - ext; i++)
            //{
            //    for (int j = ext; j < H_size - ext; j++)
            //    {
            //        rn_bitmap.SetPixel(i, j, bitmap.GetPixel(i - ext, j - ext));
            //    }
            //}

            count = 0;

            for (int i = 0; i < resultImage.Width; i++) //height
            {
                for (int j = 0; j < resultImage.Height; j++)    //width
                {
                    resultImage.SetPixel(i, j, newPixels[count]);
                    count++;
                }
            }
            
            Bitmap resultimg = new Bitmap(imageB.Width, imageB.Height);


            for (int i = index; i < resultimg.Width - (2*index); i++)
            {
                for (int j = index; j < resultimg.Height - (2*index); j++)
                {
                    resultimg.SetPixel(i - index, j-index, resultImage.GetPixel(i + index , j +index));
                    
                }
                
            }

            //for (int i = index; i < resultimg.Width; i++)
            //{
            //    for (int j = index; j < resultimg.Height; j++)
            //    {
            //        resultimg.SetPixel(i - index, j - index, resultImage.GetPixel(i - index, j));

            //    }

            //}

            

            //Color[] array = new Color[resultImage.Width * resultImage.Height];
            //count = 0;
            //for (int i = 0; i < resultImage.Width; i++)
            //{
            //    for (int j = 0; j < resultImage.Height; j++)
            //    {
            //        array[count] = resultImage.GetPixel(i, j);
            //        count++;
            //    }
            //}

            pictureBox1.Image = resultimg;
        }

        private void Remove_Noise_form_Load(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
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
    }
}
