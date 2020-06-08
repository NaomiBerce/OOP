using System;
namespace OOP_rational
{
    internal class Rational
    {
        private int numitor;
        private int numarator;

        private int v;

        public Rational()
        {
            this.numarator = 0;
        }

        public Rational(int numarator)
        {
            this.numarator = numarator;
            this.numitor = 1;
        }
        public Rational(int numarator, int numitor)
        {
            this.numarator = numarator;
            this.numitor = numitor;

            if (this.numitor == 0)
            {
                throw new ArgumentException("Numitorul nu poate fi 0");
            }
                
        }

        public static Rational operator +(Rational a, Rational b)
        {
            //Rational c= new Rational();
            // c.numarator=b.numitor*a.numarator+a.numitor*b.numarator;
            // c.numitor=a.numitor*b.numarator
            // return c;
            return new Rational((b.numitor * a.numarator + a.numitor * b.numarator), a.numitor * b.numitor);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            return new Rational((b.numitor * a.numarator - a.numitor * b.numarator), a.numitor * b.numitor);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational((a.numarator * b.numarator), (a.numitor * b.numitor));
        }

        public static Rational operator /(Rational a, Rational b)
        {
            return new Rational((a.numarator * b.numitor), (a.numitor * b.numarator));
        }

        public static Rational operator ^(Rational a, int n)
        {
            return new Rational(((int)Math.Pow(a.numarator, n)), ((int)Math.Pow(a.numitor, n)));
        }

        public static bool operator <(Rational a, Rational b)
        {
            if (a.numarator * b.numitor < a.numitor * b.numarator)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public static bool operator >(Rational a, Rational b)
        {
            return (!(a < b));
        }

        public static bool operator >=(Rational a, Rational b)
        {
            if (a.numarator * b.numitor >= a.numitor * b.numarator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <=(Rational a, Rational b)
        {
            return (!(a >= b));
        }

        public static bool operator !=(Rational a, Rational b)
        {
            if (a.numarator * b.numitor != a.numitor * b.numarator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return (!(a != b));
        }

        public Rational SimplifyFraction()
        {
            int gcd = Util.gcd(this.numarator, this.numitor);
           
            return new Rational(this.numarator/gcd,this.numitor/gcd);
        }
        public override string ToString()
        {
            if (this.numarator == 0)
            {
                Console.WriteLine("0");
            }
            
            return $"{this.numarator}/{this.numitor}";       
        }      

       
    }
}