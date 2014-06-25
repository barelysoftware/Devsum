using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFixture
{
    public struct Complex
    {
        private int _real;
        private int _imaginary;

        // Constructor. 
        public Complex(int real, int imaginary)
        {
            this._real = real;
            this._imaginary = imaginary;
        }

        public int Real
        {
            get { return _real; }
            set { _real = value; }
        }

        public int Imaginary
        {
            get { return _imaginary; }
            set { _imaginary = value; }
        }
        
        // Specify which operator to overload (+),  
        // the types that can be added (two Complex objects), 
        // and the return type (Complex). 
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1._real + c2._real, c1._imaginary + c2._imaginary);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex((c1._real * c2._real) - (c1._imaginary * c2._imaginary),(c1._real*c2._imaginary)+(c1._imaginary*c2._real));
        }

        // Override the ToString() method to display a complex number  
        // in the traditional format: 
        public override string ToString()
        {
            return (System.String.Format("{0} + {1}i", _real, _imaginary));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Complex))
                return false;

            var complex = (Complex) obj;

            return complex.Real == Real && complex.Imaginary == Imaginary && GetHashCode() == complex.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Real + Imaginary;
        }
    }
}
