using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_4
{
    public struct complex
    {
        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }
        public readonly double Mod
        {
            get
            {
                return Math.Sqrt(Math.Pow(RealPart, 2) + Math.Pow(ImaginaryPart, 2));
            }
        }
       
        public complex(double real, double imaginary)
        {
            RealPart = real;
            ImaginaryPart = imaginary;
        }

        public static complex operator +(complex complex1, complex complex2)
        {
            return new complex(complex1.RealPart + complex2.RealPart, complex1.ImaginaryPart + complex2.ImaginaryPart);
        }
        public static complex operator -(complex complex1, complex complex2)
        {
            return new complex(complex1.RealPart - complex2.RealPart, complex1.ImaginaryPart - complex2.ImaginaryPart);
        }
        public static complex operator *(complex complex1, complex complex2)
        {
            var realPart = complex1.RealPart * complex2.RealPart - complex1.ImaginaryPart * complex2.ImaginaryPart;
            var imaginaryPart = complex1.RealPart * complex2.ImaginaryPart + complex1.ImaginaryPart * complex2.RealPart;
            return new complex(realPart, imaginaryPart);
        }


        public static bool operator ==(complex complex1, complex complex2)
        {
            return complex1.RealPart == complex2.RealPart && complex1.ImaginaryPart == complex2.ImaginaryPart;
        }
        public static bool operator !=(complex complex1, complex complex2)
        {
            return !(complex1.RealPart == complex2.RealPart && complex1.ImaginaryPart == complex2.ImaginaryPart);
        }
        public override string ToString()
        {
            var imaginarySign = ImaginaryPart > 0 ? '+' : '-';
            return $"{RealPart} {imaginarySign} {Math.Abs(ImaginaryPart)}i";
        }
    }
}
