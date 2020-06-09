using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_matrici
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrice m1 = new Matrice(2, 2);
            Matrice m2 = new Matrice(2, 3);
            Matrice m3 = new Matrice(3, 3);
            Matrice m4 = new Matrice(3, 3);
            Matrice m5, m6, m7, m8, m9, m10, m11;

            Console.WriteLine(m1);

            Console.WriteLine("Initializare și afisare: ");
            m1.RandomInitMatrix();
            Console.WriteLine(m1);
            m2.RandomInitMatrix();
            Console.WriteLine(m2);
            m3.RandomInitMatrix();
            Console.WriteLine(m3);
            m4.RandomInitMatrix();
            Console.WriteLine(m4);

            Console.WriteLine("Adunare: ");
            m5 = m3.Add(m4);
            Console.WriteLine(m5);

            Console.WriteLine("Scadere: ");
            m6 = m3.Subtract(m4);
            Console.WriteLine(m6);

            Console.WriteLine("Inmultire: ");
            m7 = m1.Multiply(m2);
            Console.WriteLine(m7);

            Console.WriteLine("Ridicare la putere: ");
            m8 = m1.Pow(3);
            Console.WriteLine(m8);

            float det = m3.GetDeterminant();
            Console.WriteLine("Determinant: ");
            Console.WriteLine(det);
            m9 = m3.GetInverseMatrix(det);
            Console.WriteLine(m9);

            Console.ReadKey();
        }
    }
}
