using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.ConsoleApp
{
    class Program
    {
        [DllImport("Project.dll")]
        private static extern int Sum(int y, int b);

        [DllImport("Project.dll")]
        private static extern int SumArr([In] int[] arr, int sz);

        [DllImport("Project.dll")]
        private static extern void ToUpper([In, Out]char[] arr, int sz);

        [DllImport("Project.dll")]
        private static extern void GrayScale([In, Out]int[] redArr, [In, Out]int[] greenArr, [In, Out]int[] blueArr, int size);

        [DllImport("Project.dll")]
        private static extern void AdjustBrightness(int brightnessValue_RA, int size, [In, Out]int[] redArr, [In, Out]int[] greenArr, [In, Out]int[] blueArr);

        static void Main(string[] args)
        {
            int[] x = { 1, 2, 3 };
            char[] c = "How are u?".ToCharArray();
            int[] redArr = { 255, 200, 0, 255, 0 };
            int[] blueArr = { 255, 200, 0, 255, 0 };
            int[] greenArr = { 255, 200, 0, 255, 0 };
            int brightnessValue_RA = 5;

            AdjustBrightness(brightnessValue_RA, redArr.Length, redArr, greenArr, blueArr);

            //GrayScale(redArr,greenArr,blueArr, redArr.Length);

            for (int i = 0; i < redArr.Length; i++)
            {
                Console.Write(redArr[i]);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            ////test SumArr procedure
            //Console.Write(SumArr(x, x.Length));
            //Console.WriteLine();

            ////test ToUpper procedure
            //Console.Write(c, 0, c.Length);
            //Console.WriteLine();

            //ToUpper(c, c.Length);
            //Console.Write(c, 0, c.Length);
            //Console.WriteLine();
            Console.ReadKey();
        }
    }
}
