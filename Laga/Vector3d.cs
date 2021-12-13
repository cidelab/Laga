using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laga.Geometry
{
    /// <summary>
    /// Vector class and operations
    /// </summary>
    public class Vector3d
    {
        //Geometry Vector properties X,Y,Z
        private double x;
        private double y;
        private double z;

        /// <summary>
        /// X coordinate
        /// </summary> 
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Y Coordinate
        /// </summary>
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// Z Coordinate
        /// </summary>
        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        /// <summary>
        /// Create a 2D vector in XY plane 
        /// </summary>
        /// <param name="X">X coordinate</param>
        /// <param name="Y">Y coordinate</param>
        public Vector3d(double X, double Y)
        {
            x = X;
            y = Y;
            z = 0;
        }

        /// <summary>
        /// Create a 3D Vector
        /// </summary>
        /// <param name="X">X coordinate</param>
        /// <param name="Y">Y coordinate</param>
        /// <param name="Z">Z coordinate</param>
        public Vector3d(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        /// <summary>
        /// Creates the vector zero
        /// </summary>
        public Vector3d()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        /// <summary>
        /// Creates a orthogonal vector
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <returns>Vector</returns>
        public static Vector3d OrthogonalTo(Vector3d vector)
        {
            if (vector.z == 0)
            {
                return new Vector3d(vector.y * -1, vector.x);
            }
            else
            {
                return Vector3d.CrossProduct(vector, new Vector3d(vector.z * -1, vector.x, vector.y));
            }
        }

        /// <summary>
        /// Cross Product
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vector3d CrossProduct(Vector3d vectorA, Vector3d vectorB)
        {
            double x = vectorA.y * vectorB.z - vectorA.z * vectorB.y;
            double y = vectorA.z * vectorB.x - vectorA.x * vectorB.z;
            double z = vectorA.x * vectorB.y - vectorA.y * vectorB.x;

            return new Vector3d(x, y, z);
        }

        /// <summary>
        /// Return the cross product length
        /// | B x BC | = |AB| * |BC| * Sin(theta)
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <param name="vectorC">Vector C</param>
        /// <returns>Z coordinate of the cross product</returns>
        public static double CrossProductLength(Vector3d vectorA, Vector3d vectorB, Vector3d vectorC)
        {
            double ABx = vectorA.x - vectorB.x;
            double ABy = vectorA.y - vectorB.y;
            double BCx = vectorC.x - vectorB.x;
            double BCy = vectorC.y - vectorB.y;

            return (ABx * BCy - ABy * BCx);
        }

        /// <summary>
        /// Project to vector base B
        /// </summary>
        /// <param name="vectorB">Vector base</param>
        /// <returns>Vector</returns>
        public Vector3d ComponentProjectTo(Vector3d vectorB)
        {
            Vector3d u = new Vector3d(vectorB.x, vectorB.y, vectorB.z);
            u.Normalize();
            double mp = DotProduct(this, u);
            return new Vector3d(u.x * mp, u.y * mp, u.z * mp);
        }

        /// <summary>
        /// Creates the orthogonal component to vector base B
        /// </summary>
        /// <param name="vectorB">Vector base</param>
        /// <returns>Vector</returns>
        public Vector3d ComponentOrthogonalTo(Vector3d vectorB)
        {
            Vector3d cpt = ComponentProjectTo(vectorB);
            return this - cpt;
        }

        /// <summary>
        /// Test if is vector zero
        /// </summary>
        /// <param name="tolerance">Default tolerance: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsVectorCero(double tolerance = 1e-3)
        {
            return DistanceTo(new Vector3d(0, 0, 0)) < tolerance;
        }

        /// <summary>
        /// Test if vector is orthogonal
        /// </summary>
        /// <param name="vector">Vector to test</param>
        /// <param name="tolerance">Default tolerance: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsOrthogonalTo(Vector3d vector, double tolerance = 1e-3)
        {
            return (Math.Abs(DotProduct(this, vector)) < tolerance);
        }

        /// <summary>
        /// Test if 2 vectors are parallel
        /// </summary>
        /// <param name="vector">The vector to test</param>
        /// <param name="tolerance">Default tolerance: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsParallelTo(Vector3d vector, double tolerance = 1e-3)
        {
            double a = Angle(this, vector);
            double b = Math.Abs(a - Math.PI);

            return (this.IsVectorCero() || vector.IsVectorCero() || a < tolerance || b < tolerance);

        }

        /// <summary>
        /// Dot product
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>double</returns>
        public static double DotProduct(Vector3d vectorA, Vector3d vectorB)
        {
            return (vectorA.x * vectorB.x + vectorA.y * vectorB.y + vectorA.z * vectorB.z);
        }

        /// <summary>
        /// Dot Product AB · BC
        /// </summary>
        /// <param name="vectorA"></param>
        /// <param name="vectorB"></param>
        /// <param name="vectorC"></param>
        /// <returns></returns>
        public static double DotProduct(Vector3d vectorA, Vector3d vectorB, Vector3d vectorC)
        {
            double ABx = vectorA.x - vectorB.x;
            double ABy = vectorA.y - vectorB.y;
            double BCx = vectorC.x - vectorB.x;
            double BCy = vectorC.y - vectorB.y;

            return (ABx * BCx + ABy * BCy);
        }

        /// <summary>
        /// Angle
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>double</returns>
        public static double Angle(Vector3d vectorA, Vector3d vectorB)
        {
            double dot = DotProduct(vectorA, vectorB);
            Vector3d v = new Vector3d(0, 0, 0);
            double magA = vectorA.DistanceTo(v);
            double magB = vectorB.DistanceTo(v);
            double div = dot / (magA * magB);
            div = (div < -1.0) ? -1.0 : (div > 1.0) ? 1.0 : div;
            return Math.Acos(div); // radianes.
        }

        /// <summary>
        /// ABC angle between PI and -PI
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <param name="vectorC">Vector C</param>
        /// <returns>double</returns>
        public static double Angle(Vector3d vectorA, Vector3d vectorB, Vector3d vectorC)
        {
            //dot
            double dot = DotProduct(vectorA, vectorB, vectorC);

            //crossLength 
            double crossPL = CrossProductLength(vectorA, vectorB, vectorC);

            //angle
            return Math.Atan2(crossPL, dot);
        }

        /// <summary>
        /// Distance
        /// </summary>
        /// <param name="vector">vector to test</param>
        /// <returns>double</returns>
        public double DistanceTo(Vector3d vector)
        {
            double dist;
            dist = Math.Sqrt(Math.Pow(this.x - vector.x, 2) + Math.Pow(this.y - vector.y, 2) + Math.Pow(this.z - vector.z, 2));
            return dist;
        }

        /// <summary>
        /// Normalize the vector to 1
        /// </summary>
        public void Normalize()
        {
            double m = this.DistanceTo(new Vector3d(0, 0, 0));
            _ = new Vector3d(this.x /= m, this.y /= m, this.z /= m);
        }

        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vector3d operator +(Vector3d vectorA, Vector3d vectorB)
        {
            double xc = vectorA.x + vectorB.x;
            double yc = vectorA.y + vectorB.y;
            double zc = vectorA.z + vectorB.z;
            return new Vector3d(xc, yc, zc);
        }

        /// <summary>
        /// Substraction
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vector3d operator -(Vector3d vectorA, Vector3d vectorB)
        {
            double xc = vectorA.x - vectorB.x;
            double yc = vectorA.y - vectorB.y;
            double zc = vectorA.z - vectorB.z;
            return new Vector3d(xc, yc, zc);
        }

        /// <summary>
        /// Scale multuplication
        /// </summary>
        /// <param name="vector">Vector to scale</param>
        /// <param name="factor">factor</param>
        /// <returns>Vector</returns>
        public static Vector3d operator *(Vector3d vector, double factor)
        {
            double xc = vector.x * factor;
            double yc = vector.y * factor;
            double zc = vector.z * factor;
            return new Vector3d(xc, yc, zc);
        }

        /// <summary>
        /// Print vector data
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "vec [" + x + ", " + y + ", " + z + "] ";
        }

        /// <summary>
        /// test if 2 vectors are equal
        /// </summary>
        /// <param name="vector">Vector to test</param>
        /// <returns>bool</returns>
        public bool EqualTo(Vector3d vector)
        {
            return this.x == vector.x && this.y == vector.y && this.z == vector.z;
        }
    }
}
