using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixProject
{
    class Matrix
    {
        private double[,] matrix;

        private int numofrows;
        public int NumOfRows
        {
            get => this.numofrows;
            private set => numofrows = value;
        }

        private int numofcolumns;
        public int NumOfColumns
        {
            get => this.numofcolumns;
            private set => numofcolumns = value;
        }

        public Matrix(int n, int m)
        {
            this.NumOfRows = n;
            this.NumOfColumns = m;
            matrix = new double[this.NumOfRows, this.NumOfColumns];
            GenerateRandomMatrix(matrix);
        }

        private void GenerateRandomMatrix(double[,] matrix)
        {
            Random r = new Random();
            for (int i = 0; i < this.NumOfRows; i++)
                for (int j = 0; j < this.NumOfColumns; j++)
                    matrix[i, j] = r.Next(10);
        }

        /*
        public Matrix Addition(Matrix mt)
        {
            if(this.NumOfColumns == mt.NumOfColumns && this.NumOfRows == mt.NumOfRows)
            {
                Matrix newmt = new Matrix(this.NumOfRows, this.NumOfColumns);
                for(int i=0; i < this.NumOfRows; i++)
                {
                    for(int j = 0; j < this.NumOfColumns; j++)
                    {
                        newmt.matrix[i, j] = this.matrix[i, j] + mt.matrix[i, j];
                    }
                }
                return newmt;
            }
            Console.WriteLine("The matrixes must have the same size");
            return null;
        }
        */

        public static Matrix operator + (Matrix mt, Matrix mt2)
        {
            if (mt.NumOfColumns == mt2.NumOfColumns && mt.NumOfRows == mt2.NumOfRows)
            {
                Matrix newmt = new Matrix(mt.NumOfRows, mt.NumOfColumns);
                for (int i = 0; i < mt.NumOfRows; i++)
                {
                    for (int j = 0; j < mt.NumOfColumns; j++)
                    {
                        newmt.matrix[i, j] = mt.matrix[i, j] + mt2.matrix[i, j];
                    }
                }
                return newmt;
            }
            Console.WriteLine("The matrixes must have the same size");
            return null;
        }

        public void MultiplyByConst(int k)
        {
            for (int i = 0; i < this.NumOfRows; i++)
                for (int j = 0; j < this.NumOfColumns; j++)
                    this.matrix[i, j] *= k;
        }

        /*
        public Matrix ScalarMultiplication(Matrix mt)
        {
            if(this.NumOfColumns == mt.NumOfRows)
            {
                Matrix newmt = new Matrix(this.NumOfRows, mt.NumOfColumns);
                for(int i=0;i < newmt.NumOfRows; i++)
                {
                    for(int j=0; j< newmt.NumOfColumns; j++)
                    {
                        newmt.matrix[i, j] = 0;
                        for(int k=0; k < this.NumOfColumns; k++)
                        {
                            newmt.matrix[i, j] += this.matrix[i, k] * mt.matrix[k, j];
                        }
                    }
                }
                return newmt;
            }
            Console.WriteLine("The number of columns in the first matrix must be equal to the number of rows in the second matrix");
            return null;
        }
        */

        public static Matrix operator * (Matrix mt, Matrix mt2)
        {
            if (mt.NumOfColumns == mt2.NumOfRows)
            {
                Matrix newmt = new Matrix(mt.NumOfRows, mt2.NumOfColumns);
                for (int i = 0; i < newmt.NumOfRows; i++)
                {
                    for (int j = 0; j < newmt.NumOfColumns; j++)
                    {
                        newmt.matrix[i, j] = 0;
                        for (int k = 0; k < mt.NumOfColumns; k++)
                        {
                            newmt.matrix[i, j] += mt.matrix[i, k] * mt2.matrix[k, j];
                        }
                    }
                }
                return newmt;
            }
            Console.WriteLine("The number of columns in the first matrix must be equal to the number of rows in the second matrix");
            return null;
        }

        public Matrix Transpose()
        {
            Matrix transp_mt = new Matrix(this.NumOfColumns, this.NumOfRows);
            for(int i=0; i< this.NumOfRows; i++)
            {
                for(int j=0; j < this.NumOfColumns; j++)
                {
                    transp_mt.matrix[j, i] = this.matrix[i, j];
                }
            }
            return transp_mt;
        }

        public Matrix Inverse()
        {
            if(this.NumOfRows == this.NumOfColumns)
            {
                if(NumOfRows == 3)
                {
                    double a = this.matrix[0, 0], b = this.matrix[0, 1],
                        c = this.matrix[0, 2], d = this.matrix[1, 0],
                        e = this.matrix[1, 1], f = this.matrix[1, 2],
                        g = this.matrix[2, 0], h = this.matrix[2, 1],
                        i = this.matrix[2, 2];
                    double det = a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);
                    if(det == 0)
                    {
                        Console.WriteLine("The matrix is Unitary");
                        return null;
                    }
                    double m = 1 / det;
                    Matrix inv_mt = new Matrix(3, 3);
                    inv_mt.matrix[0, 0] = m * (e * i - f * h);
                    inv_mt.matrix[0, 1] = m * (c * h - b * i);
                    inv_mt.matrix[0, 2] = m * (b * f - c * e);
                    inv_mt.matrix[1, 0] = m * (f * g - d * i);
                    inv_mt.matrix[1, 1] = m * (a * i - c * g);
                    inv_mt.matrix[1, 2] = m * (c * d - a * f);
                    inv_mt.matrix[2, 0] = m * (d * h - e * g);
                    inv_mt.matrix[2, 1] = m * (b * g - a * h);
                    inv_mt.matrix[2, 2] = m * (a * e - b * d);
                    return inv_mt;

                }
                else if(NumOfRows == 2)
                {
                    double a = this.matrix[0, 0], b = this.matrix[0, 1],
                        c = this.matrix[1, 0], d = this.matrix[1, 1];
                    double det = a * d - b * c;
                    if (det == 0)
                    {
                        Console.WriteLine("The matrix is Unitary");
                        return null;
                    }
                    double m = 1 / det;
                    Matrix inv_mt = new Matrix(2, 2);
                    inv_mt.matrix[0, 0] = +m * d;
                    inv_mt.matrix[0, 1] = -m * b;
                    inv_mt.matrix[1, 0] = -m * c;
                    inv_mt.matrix[1, 1] = +m * a;
                    return inv_mt;
                }
                else
                {
                    Console.WriteLine("Please make matrix with 2 or 3 length of side");
                    return null;
                }
            }
            Console.WriteLine("Matrix must be square");
            return null;
        }

        public bool IsOrthogonal()
        {
            if(this.NumOfRows == this.NumOfColumns)
            {
                Matrix transp_mt = this.Transpose();
                transp_mt.ShowMatrix();
                Matrix mult_mt = this * transp_mt;
                mult_mt.ShowMatrix();
                for(int i = 0; i < mult_mt.NumOfRows; i++)
                {
                    for(int j=0; j < mult_mt.NumOfColumns; j++)
                    {
                        if (i == j && mult_mt.matrix[i, j] != 1)
                            return false;
                        else if(i != j)
                        {
                            if (mult_mt.matrix[i, j] != 0)
                                return false;
                        }
                    }
                }
                return true;
            }
            Console.WriteLine("Matrix must be square");
            return false;
        }

        public void MaxAndMinValues(out double min, out double max)
        {
            min = max = this.matrix[0, 0];
            for(int i = 0; i < this.NumOfRows; i++)
            {
                for(int j = 0; j < this.NumOfColumns; j++)
                {
                    if (this.matrix[i, j] < min)
                        min = this.matrix[i, j];
                    if (this.matrix[i, j] > max)
                        max = this.matrix[i, j];
                }
            }
        }

        public void ShowMatrix()
        {
            for (int i = 0; i < this.NumOfRows; i++)
            {
                for (int j = 0; j < this.NumOfColumns; j++)
                {
                    Console.Write(this.matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
