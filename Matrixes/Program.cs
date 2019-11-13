using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix mt = new Matrix(3, 5);
            Matrix mt2 = new Matrix(3, 5);
            mt.ShowMatrix();
            mt2.ShowMatrix();
            Matrix sum = mt + mt2;
            sum?.ShowMatrix();
            mt.MultiplyByConst(3);
            mt.ShowMatrix();
            Matrix m1 = new Matrix(2, 3);
            Matrix m2 = new Matrix(3, 2);
            m1.ShowMatrix();
            m2.ShowMatrix();
            Matrix scalar = m1 * m2;
            scalar?.ShowMatrix();
            Matrix trmt = m1.Transpose();
            trmt.ShowMatrix();
            Matrix o = new Matrix(3, 3);
            o.ShowMatrix();
            if (o.IsOrthogonal())
                Console.WriteLine("Matrix is Orthogonal");
            else
                Console.WriteLine("Matrix is not Orthogonal");
            Console.WriteLine();
            o.MaxAndMinValues(out double min, out double max);
            Console.WriteLine("min = " + min + " max = " + max + "\n");
            Matrix inv = o.Inverse();
            inv?.ShowMatrix();
            Console.ReadKey();
        }
    }
}
