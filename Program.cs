using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_rational
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational();
            Rational r2 = new Rational(2);
            Rational r3 = new Rational(1 , 2);
            Console.WriteLine(r2);

            r3=r3.SimplifyFraction();

            Console.ReadKey();
        }
    }
}
