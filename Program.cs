using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_NumarMare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Clasa NumarMare");
            NumarMare n1 = new NumarMare("1204");
            NumarMare n2 = new NumarMare("202");
            Console.WriteLine();

            NumarMare n3 = n1 + n2;
            Console.WriteLine($"{n1} + {n2} = {n3}");
            Console.WriteLine();
            Console.ReadKey();
        }

        private static NumarMare GetFibonacciNumber(int n)
        {
            NumarMare F0 = new NumarMare("0");
            NumarMare F1 = new NumarMare("1");
            NumarMare Fn = new NumarMare("0");

            for (int i = 2; i <= n; i++)
            {
                Fn = F0 + F1;
                F0 = F1;
                F1 = Fn;
            }

            return Fn;
        }
    }
}
