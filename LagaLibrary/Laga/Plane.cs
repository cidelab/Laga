using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laga.Geometry
{
    /// <summary>
    /// Plane class and operations
    /// </summary>
    public class Plane
    {
        private Vector origin;
        private Vector vecX;
        private Vector vecY;
        private Vector norm;
        private double det;
        private double B;
        private readonly double consD;

        /// <summary>
        /// Get the Cz term
        /// </summary>
        public double Cz { get; }
        /// <summary>
        /// Get the By Term
        /// </summary>
        public double By
        {
            get { return B; }
        }

        /// <summary>
        /// Get the Ax term
        /// </summary>
        public double Ax { get; }

        /// <summary>
        /// Plane origin
        /// </summary>
        public Vector Origin
        {
            get
            {
                return origin;
            }
        }

        /// <summary>
        /// Vector normal
        /// </summary>
        public Vector Norm
        {
            get
            {
                return norm;
            }
        }

        /// <summary>
        /// Vector U (X direction)
        /// </summary>
        public Vector VectorU
        {
            get { return vecX; }
        }

        /// <summary>
        /// Vector V (Y direction)
        /// </summary>
        public Vector VectorV
        {
            get { return vecY; }
        }

        /// <summary>
        /// Plane constant term
        /// </summary>
        public double ConstantTerm
        {
            get { return consD; }
        }

        /// <summary>
        /// Vector equation plane, form: X = P+tU+sV
        /// </summary>
        /// <param name="OriginPoint">Point in the plane, considered the origin point</param>
        /// <param name="VectorU">First vector in the plane (U)</param>
        /// <param name="VectorV">Second vector in the plane (V)</param>
        public Plane(Vector OriginPoint, Vector VectorU, Vector VectorV)
        {
            origin = OriginPoint;
            vecX = VectorU - OriginPoint;
            vecY = VectorV - OriginPoint;
            norm = Vector.CrossProduct(vecX, vecY);
            norm.Normalize();
            determinant();
        }

        /// <summary>
        /// General Equation plane, form: Ax + By + Cz + D = 0
        /// </summary>
        /// <param name="Ax">Coeficient Ax</param>
        /// <param name="By">Coeficient By</param>
        /// <param name="Cz">Coeficient Cz</param>
        /// <param name="D">Constant D</param>
        public Plane(double Ax, double By, double Cz, double D)
        {
            norm = new Vector(Ax, By, Cz);
            norm.Normalize();

            this.Ax = Ax;
            B = By;
            this.Cz = Cz;
            consD = D;

            double abc = (Ax * Ax) + (By * By) + (Cz * Cz);
            origin = new Vector((Ax * -D) / abc, (By * -D) / abc, (Cz * -D) / abc);

            vecX = new Vector(Cz - By, Ax - Cz, By - Ax);
            vecX.Normalize();

            vecY = new Vector((Ax * (By + Cz)) - (By * By) - (Cz * Cz),
                              (By * (Ax + Cz)) - (Ax * Ax) - (Cz * Cz),
                              (Cz * (Ax + By)) - (Ax * Ax) - (By * By));
            vecY.Normalize();

            determinant();
        }

        /// <summary>
        /// Plane normal equation, form: PX·N = 0
        /// </summary>
        /// <param name="VectorPX">Vector from plane origin to a point X in the plane</param>
        /// <param name="VectorNormal">Normal vector to plane</param>
        public Plane(Vector VectorPX, Vector VectorNormal)
        {
            norm = VectorNormal;
            norm.Normalize();
            origin = VectorPX.ComponentProjectTo(VectorNormal);
            vecX = VectorPX;
            vecY = Vector.CrossProduct(VectorNormal, VectorPX);
            determinant();
        }

        /// <summary>
        /// Print plane data
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "Orig: (" + origin.X + ", " + origin.Y + ", " + origin.Z + "), Norm: " + norm.ToString();
        }

        private void determinant()
        {
            det = -(norm.X * origin.X) - (norm.Y * origin.Y) - (norm.Z * origin.Z);
        }

        /// <summary>
        /// Distance plane point. If negative, the point is behind the plane.
        /// </summary>
        /// <param name="point">point to test</param>
        /// <returns>double</returns>
        public double DistanceTo(Vector point)
        {
            double d = (norm.X * point.X) + (norm.Y * point.Y) + (norm.Z * point.Z) + det;
            return d / Math.Sqrt(norm.X * norm.X + norm.Y * norm.Y + norm.Z * norm.Z);
        }

        /// <summary>
        /// Locate a point in the plane
        /// </summary>
        /// <param name="U">U parameter</param>
        /// <param name="V">V parameter</param>
        /// <returns>Vector</returns>
        public Vector PointAt(double U, double V)
        {
            double x = origin.X + vecX.X * U + vecY.X * V;
            double y = origin.Y + vecX.Y * U + vecY.Y * V;
            double z = origin.Z + vecX.Z * U + vecY.Z * V;
            return new Vector(x, y, z);
        }

        /// <summary>
        /// Check if the plane is parallel
        /// </summary>
        /// <param name="plane">Plane to test</param>
        /// <param name="tolerance">Default tolerance: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsParallelTo(Plane plane, double tolerance = 1e-3)
        {
            Vector vec1 = plane.norm;
            Vector vec2 = this.norm;

            return vec1.IsParallelTo(vec2, tolerance);
        }

        /// <summary>
        /// Check if 2 planes are coicident
        /// </summary>
        /// <param name="plane">Plane to test</param>
        /// <param name="tolerance">Default tolerance: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsCoincidentTo(Plane plane, double tolerance = 1e-3)
        {
            if (this.IsParallelTo(plane, tolerance))
            {
                Vector vCon = plane.origin - this.origin;
                return vCon.IsOrthogonalTo(this.norm, tolerance) && vCon.IsOrthogonalTo(plane.norm, tolerance);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Plane line intersection
        /// </summary>
        /// <param name="line">Line</param>
        /// <param name="intersection">ref Vector Intersection</param>
        /// <returns>bool</returns>
        public bool IntersectTo(Line line, ref Vector intersection)
        {
            try
            {
                Vector diff = line.EndPoint - this.origin;
                double dotA = Vector.DotProduct(diff, this.norm);
                double dotB = Vector.DotProduct(line.Direction, this.norm);
                double t = dotA / dotB;
                intersection = line.EndPoint - line.Direction * t;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        /// <summary>
        /// Find the intersection between 2 planes
        /// </summary>
        /// <param name="plane">Plane to test</param>
        /// <param name="intersection">ref line intersection</param>
        /// <param name="tolerance">Default tolerance: 1e-3</param>
        /// <returns>bool</returns>
        public bool IntersectTo(Plane plane, ref Line intersection, double tolerance = 1e-3)
        {
            if (!this.IsParallelTo(plane, tolerance) && !this.IsCoincidentTo(plane, tolerance))
            {
                Vector vecOrigin = new Vector();
                Vector p3_norm = Vector.CrossProduct(this.norm, plane.norm);
                double det = p3_norm.DistanceTo(vecOrigin) * p3_norm.DistanceTo(vecOrigin);

                Vector v1 = Vector.CrossProduct(p3_norm, plane.norm);
                Vector v2 = Vector.CrossProduct(this.norm, p3_norm);

                double d1 = this.DistanceTo(vecOrigin);
                double d2 = plane.DistanceTo(vecOrigin);

                Vector ptL = (v1 * d1) + (v2 * d2);
                intersection = new Line(new Vector(ptL.X / det, ptL.Y / det, ptL.Z / det), p3_norm, 1.00);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
