using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laga.Geometry
{
    public class Line
    {
        private Vector startPt;
        private Vector endPt;
        private Vector dir;
        private double tParam;

        public Vector StartPoint
        {
            get
            {
                return startPt;
            }
        }
        public Vector EndPoint
        {
            get
            {
                return endPt;
            }
        }
        public Vector Direction
        {
            get
            {
                return dir;
            }
        }

        public Line(Vector StartPoint, Vector Direction, double t)
        {
            startPt = StartPoint;
            dir = Direction;
            endPt = startPt + dir;
            tParam = t;
        }

        public Line(Vector StartPoint, Vector EndPoint)
        {
            startPt = StartPoint;
            endPt = EndPoint;
            dir = EndPoint - StartPoint;
        }

        public bool IsParallelTo(Line line, double tolerance = 1e-3)
        {
            Vector vec1 = line.dir;
            Vector vec2 = this.dir;

            return vec1.IsParallelTo(vec2, tolerance);
        }
        public bool IsCoincidentTo(Line line, double tolerance = 1e-3)
        {
            if (this.IsParallelTo(line, tolerance))
            {
                Vector vConnector = line.startPt - this.startPt;
                Vector vec1 = Vector.OrthogonalTo(line.dir);
                return vConnector.IsOrthogonalTo(vec1);
            }
            else
            {
                return false;
            }
        }
        public Vector PointAt(double t)
        {
            double x = startPt.X + dir.X * t;
            double y = startPt.Y + dir.Y * t;
            double z = startPt.Z + dir.Z * t;

            return new Vector(x, y, z);
        }

        public bool IntersectTo(Line line, ref Vector intersection, double tolerance = 1e-3)
        {
            double A = this.startPt.Y - this.endPt.Y;
            double B = this.endPt.X - this.startPt.X;
            double K1 = A * this.startPt.X + B * this.startPt.Y;

            double C = line.startPt.Y - line.endPt.Y;
            double D = line.endPt.X - line.startPt.X;
            double K2 = C * line.startPt.X + D * line.startPt.Y;

            double delta = A * D - B * C;
            if (Math.Abs(delta) < tolerance)
            {
                intersection = new Vector(double.NaN, double.NaN, double.NaN);
                return false;
            }
            else
            {
                double X = (D * K1 - B * K2) / delta;
                double Y = (A * K2 - C * K1) / delta;
                intersection = new Vector(X, Y);
                return true;
            }
        }

        public bool ClosestTo(Line line, ref Vector pointA, ref Vector pointB)
        {
            if (!this.IsParallelTo(line) && !this.IsCoincidentTo(line))
            {
                Vector uConn = line.startPt - this.startPt;
                Vector vecL = line.dir; // line.endPt - line.startPt;
                Vector vecT = this.dir; // this.endPt - this.startPt;
                Vector xProd = Vector.CrossProduct(vecT, vecL);

                double norm = xProd.X * xProd.X + xProd.Y * xProd.Y + xProd.Z * xProd.Z;
                double t = Vector.DotProduct(Vector.CrossProduct(uConn, vecL), xProd) / norm;
                double s = Vector.DotProduct(Vector.CrossProduct(uConn, vecT), xProd) / norm;

                if ((s >= 0 && s <= 1) && (t >= 0 && t <= 1))
                {
                    pointA = this.PointAt(t);
                    pointB = line.PointAt(s); //new Vector(this.startPt.X + vecT.X * t, this.startPt.Y + vecT.Y * t, this.startPt.Z + vecT.Z * t);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "line: S" + startPt.ToString() + "-E" + endPt.ToString();
        }

    }
}