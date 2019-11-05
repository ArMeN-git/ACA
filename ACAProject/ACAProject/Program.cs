using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAProject
{
    class Program
    {
        static int[] CopyArray(double[] nums) 
        {
            int[] newnums;
            if (nums == null)
                return null;
            newnums = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                newnums[i] = (int)nums[i];
            return newnums;
        }
        static object[] RemoveElement(object[] array, int index)
        {
            object[] resizedarray;
            if (array == null)
                return null;
            for (int i = index; i < array.Length-1; i++)
            {
                array[i] = array[i + 1];
            }
            resizedarray = new object[array.Length - 1];
            for (int i = 0; i < resizedarray.Length; i++)
                resizedarray[i] = array[i];
            return resizedarray;
        }
        static void MatrixTriangle(int[,] mm)
        {
            for (int i = 0; i < mm.GetLength(0); i++)
            {
                for (int j = 0; j < mm.GetLength(1); j++)
                {
                    if (j < i)
                        mm[i, j] = 0;
                    Console.Write(mm[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            double[] numbers = { 5.5, 2.6, 3.07, 9.8, 4.22 };
            int[] result = CopyArray(numbers);
            for (int i = 0; i < result?.Length; i++)
                Console.Write(result[i] + " ");
            Console.WriteLine();
            object[] arr = { "text", true, 5.6, 2.1f, 7, 0.5 };
            object[] res = RemoveElement(arr, 3);
            for (int i = 0; i < res?.Length; i++)
                Console.Write(res[i] + " ");
            Console.WriteLine();
            int size = 7;
            int[,] matrix = new int[size, size];
            Random rd = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = rd.Next(10);
            MatrixTriangle(matrix);
            Console.ReadKey();
        }
    }
}
