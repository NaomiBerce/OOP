using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp_AbstractPoint
{
    public abstract class AbstractPoint
    {
        public enum PointRepresentation
        {
            Polar,
            Rectangular
        }
        // Cartesian coordinates
        public abstract double abscissa { get; }
        public abstract double ordinate { get; }
        // Polar coordinates 
        public abstract double radius { get; set; } // radial coordinate = the distance from the pole
        public abstract double angle { get; set; } // angular coordinate

        // returns radius using coordinates (x, y)
        protected static double GetRadius(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }
        // returns angle depending on coordinates (x, y), angle = arctg(y/x)
        protected static double GetAngle(double x, double y)
        {
            return Math.Atan2(y, x);
        }
        // returns abscissa depending on radius and angle
        protected static double GetAbscissa(double p, double fi)
        {
            return p * Math.Cos(fi);
        }
        // returns ordinate depending on radius and angle
        protected static double GetOrdinate(double r, double fi)
        {
            return r * Math.Sin(fi);
        }

        // translate the point
        public void Move(double dx, double dy)
        {
            double abscissa = GetAbscissa(this.radius, this.angle);
            double ordinate = GetOrdinate(this.radius, this.angle);

            abscissa += dx;
            ordinate += dy;

            this.radius = GetRadius(abscissa, ordinate);
            this.angle = GetAngle(abscissa, ordinate);
        }

        // rotate the point
        public void Rotate(double angle)
        {
            this.angle += angle;
        }

        public override string ToString()
        {
            return $"({abscissa}, {ordinate}):[{radius}, {angle}]";
        }
    }
}