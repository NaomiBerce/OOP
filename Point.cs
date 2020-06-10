using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp_AbstractPoint
{
    class Point: AbstractPoint
    {
        double p;
        double A;

        public Point(PointRepresentation represenation, double valoarea1, double valoarea2)
        {
            if (represenation == PointRepresentation.Rectangular)
            {
                this.p = Math.Sqrt(Math.Pow(valoarea1, 2) + Math.Pow(valoarea2, 2));
                this.A = Math.Atan2(valoarea2, valoarea1);
            }
            else
            {
                this.p = valoarea1;
                this.A = valoarea2;
            }
        }

        public override double abscissa
        {
            get => GetAbscissa(this.p, this.A);
        }

        public override double ordinate
        {
            get => GetOrdinate(this.p, this.A);
        }

        public override double radius
        {
            get => this.p;
            set => this.p = value;
        }

        public override double angle
        {
            get => this.A;
            set => this.A = value;
        }
    }
}