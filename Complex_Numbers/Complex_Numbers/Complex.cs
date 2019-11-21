using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex_Numbers
{
    class Complex
    {
        public double RealPart { get; private set; }
        public double ImaginaryPart { get; private set; }

        public Complex(double real, double imaginary)
        {
            this.RealPart = real;
            this.ImaginaryPart = imaginary;
        }

        // Addition of two complex numbers ...
        public static Complex operator +(Complex n1, Complex n2)
        {
            Complex res = new Complex(n1.RealPart + n2.RealPart, n1.ImaginaryPart + n2.ImaginaryPart);
            return res; 
        }

        // Subtraction of two complex numbers ...
        public static Complex operator -(Complex n1, Complex n2)
        {
            Complex res = new Complex(n1.RealPart - n2.RealPart, n1.ImaginaryPart - n2.ImaginaryPart);
            return res;
        }

        // Multiplication of two complex numbers ...
        public static Complex operator *(Complex n1, Complex n2)
        {
            double real = n1.RealPart * n2.RealPart - n1.ImaginaryPart * n2.ImaginaryPart;
            double imaginary = n1.ImaginaryPart * n2.RealPart + n1.RealPart * n2.ImaginaryPart;
            Complex res = new Complex(real, imaginary);
            return res;
        }

        // Division of two complex numbers ...
        public static Complex operator /(Complex n1, Complex n2)
        {
            if(n2.RealPart !=0 && n2.ImaginaryPart != 0)
            {
                double real = (n1.RealPart * n2.RealPart + n1.ImaginaryPart * n2.ImaginaryPart) / (Math.Pow(n2.RealPart, 2) + Math.Pow(n2.ImaginaryPart, 2));
                double imaginary = (n1.ImaginaryPart * n2.RealPart - n1.RealPart * n2.ImaginaryPart) / (Math.Pow(n2.RealPart, 2) + Math.Pow(n2.ImaginaryPart, 2));
                Complex res = new Complex(real, imaginary);
                return res;
            }
            Console.WriteLine("The 2-nd complex number cannot be zero");
            return null;
        }

        // Absolute value of complex number ...
        public double AbsoluteValue()
        {
            double z = Math.Sqrt(Math.Pow(this.RealPart, 2) + Math.Pow(this.ImaginaryPart, 2));
            return z;
        }

        // Argument of complex number ...
        public double Argument()
        {
            return Math.Atan2(this.ImaginaryPart, this.RealPart) * 180 / Math.PI;
        }

        public override string ToString()
        {
            return $"{this.RealPart} + {this.ImaginaryPart}i \n";
        }
    }
}
