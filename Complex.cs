using System;

namespace OOP_complexe
{
    internal class Complex
    {
        private int partea_reala;
        private int partea_imaginara;

        private int v;
        
        public Complex()
        {
            this.partea_reala = 0;
        }

        public Complex(int partea_reala)
        {
            this.partea_reala = partea_reala;
            this.partea_imaginara = 0;
        }

        public Complex(int partea_reala, int partea_imaginara)
        {
            this.partea_reala = partea_reala;
            this.partea_imaginara = partea_imaginara;

            if(this.partea_imaginara==0)
            {
                throw new ArgumentException("Numarul este real");
            }
        }

        public static Complex operator +(Complex x, Complex y)
        {
            return new Complex((x.partea_reala + y.partea_reala), (x.partea_imaginara + y.partea_imaginara));
        }

        public static Complex operator -(Complex x, Complex y)
        {
            return new Complex((x.partea_reala - y.partea_reala), (x.partea_imaginara - y.partea_imaginara));
        }

        public static Complex operator *(Complex x, Complex y)
        {
            return new Complex(((x.partea_reala * x.partea_imaginara) - (y.partea_reala * y.partea_imaginara)),((x.partea_reala * y.partea_imaginara) + (x.partea_imaginara * y.partea_reala)));
        }

        public static Complex operator ^(Complex x, int n)
        {
            return new Complex((int)Math.Pow(x.partea_reala, n), ((int)Math.Pow(x.partea_imaginara, n)));
        }

       
        public void GetTrigonometricFormAndPow(double n)
        {

            double r = Math.Sqrt(Math.Pow(this.partea_reala, 2) + Math.Pow(this.partea_imaginara, 2));
            double argz;

            try
            {
                argz = Math.Atan(this.partea_imaginara / this.partea_reala);
            }
            catch (Exception)
            {
                throw new DenominatorIsZero(this.partea_reala);
            }

            Console.WriteLine($"z = {r} (cos({argz}) + isin({argz}))");

            Console.WriteLine($"z = {r}^{n}(cos({n}*{argz}) + isin({n}*{argz}))");
        }
    }
}