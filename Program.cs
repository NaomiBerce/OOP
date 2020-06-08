using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_complexe
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex();
            Complex c2 = new Complex(2);
            Complex c3 = new Complex(2,1);

            Console.WriteLine(c3);

            Console.ReadKey();
        }
    }
}
