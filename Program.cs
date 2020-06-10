using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp_AbstractPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractPoint.PointRepresentation rep1 = AbstractPoint.PointRepresentation.Rectangular;
            Point A = new Point(rep1, 1, 1);
            Console.WriteLine("Punctul A de coordonate: cartesian(x, y) : polar[r, A] : ");
            Console.WriteLine(A);
            Console.WriteLine();

            Console.WriteLine("Translate A by (19, 19): ");
            A.Move(19, 19);
            Console.WriteLine(A);
            Console.WriteLine();

            AbstractPoint.PointRepresentation rep2 = AbstractPoint.PointRepresentation.Polar;
            Point B = new Point(rep2, -4, (2 * Math.PI / 3));
            Console.WriteLine("Punctul B de coordonate: cartesian(x, y) : polar[r, A] : ");
            Console.WriteLine(B);
            Console.WriteLine();

            Point C = new Point(rep2, 2, Math.PI / 2);
            Console.WriteLine("Punctul C de corodoonate: cartesian(x, y) : polar[r, A] : ");
            Console.WriteLine(C);
            Console.WriteLine("Rotirea lui C la 90 de garde: ");
            C.Rotate(Math.PI / 2);
            Console.WriteLine(C);

            Console.ReadKey();
        }
    }
}
