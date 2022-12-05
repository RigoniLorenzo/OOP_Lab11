using System;
using System.Text;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public Complex(double real, double img)
        {
            this.Real = real;
            this.Imaginary = img;
        }

        public double Real
        {
            get;
        }

        public double Imaginary
        {
            get;
        }

        public double Modulus
        {
            get { return Math.Sqrt((Math.Pow(Real, 2) + Math.Pow(Imaginary, 2))); }
        }

        public double Phase
        {
            get {
                if(Real != 0)
                    return Math.Atan2(Imaginary, Real);
                else
                    return 0;
            }
        }

        public Complex Complement()
        {
            return new Complex(Real, -Imaginary); 
        }

        public Complex Plus(Complex num)
        {
            return new Complex(Real + num.Real, Imaginary + num.Imaginary);
        }

        public Complex Minus(Complex num)
        {
            return new Complex(Real - num.Real, Imaginary - num.Imaginary); 
        }

        public override string ToString()
        {
            double imAbs = Math.Abs(Imaginary);
            string imValue = imAbs == 1.0 ? "" : imAbs.ToString();
            string sign = Imaginary > 0 ? "+" : "-";

            StringBuilder sB = new StringBuilder();
            if(Imaginary == 0.0 || Real == 0d)
            {
                if (Imaginary == 0.0)
                    sB.Append(Real.ToString());
                else if (Real == 0d)
                    sB.Append(sign + "i" + imValue);
            }
            else
                sB.Append(Real.ToString() + " " + sign + " i" + imValue);
            return sB.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
    }
}