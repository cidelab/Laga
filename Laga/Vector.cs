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
    public class Vector
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
        public Vector(double X, double Y)
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
        public Vector(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        /// <summary>
        /// Creates the vector zero
        /// </summary>
        public Vector()
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
        public static Vector OrthogonalTo(Vector vector)
        {
            if (vector.z == 0)
            {
                return new Vector(vector.y * -1, vector.x);
            }
            else
            {
                return Vector.CrossProduct(vector, new Vector(vector.z * -1, vector.x, vector.y));
            }
        }

        /// <summary>
        /// Cross Product
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vector CrossProduct(Vector vectorA, Vector vectorB)
        {
            double x = vectorA.y * vectorB.z - vectorA.z * vectorB.y;
            double y = vectorA.z * vectorB.x - vectorA.x * vectorB.z;
            double z = vectorA.x * vectorB.y - vectorA.y * vectorB.x;

            return new Vector(x, y, z);
        }

        /// <summary>
        /// Project to vector base B
        /// </summary>
        /// <param name="vectorB">Vector base</param>
        /// <returns>Vector</returns>
        public Vector ComponentProjectTo(Vector vectorB)
        {
            Vector u = new Vector(vectorB.x, vectorB.y, vectorB.z);
            u.Normalize();
            double mp = DotProduct(this, u);
            return new Vector(u.x * mp, u.y * mp, u.z * mp);
        }

        /// <summary>
        /// Creates the orthogonal component to vector base B
        /// </summary>
        /// <param name="vectorB">Vector base</param>
        /// <returns>Vector</returns>
        public Vector ComponentOrthogonalTo(Vector vectorB)
        {
            Vector cpt = ComponentProjectTo(vectorB);
            return this - cpt;
        }

        /// <summary>
        /// Test if is vector zero
        /// </summary>
        /// <param name="tolerance">Default tolerance: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsVectorCero(double tolerance = 1e-3)
        {
            return DistanceTo(new Vector(0, 0, 0)) < tolerance;
        }

        /// <summary>
        /// Test if vector is orthogonal
        /// </summary>
        /// <param name="vector">Vector to test</param>
        /// <param name="tolerance">Default tolerance: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsOrthogonalTo(Vector vector, double tolerance = 1e-3)
        {
            return (Math.Abs(DotProduct(this, vector)) < tolerance);
        }

        /// <summary>
        /// Test if 2 vectors are parallel
        /// </summary>
        /// <param name="vector">The vector to test</param>
        /// <param name="tolerance">Default tolerance: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsParallelTo(Vector vector, double tolerance = 1e-3)
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
        public static double DotProduct(Vector vectorA, Vector vectorB)
        {
            return (vectorA.x * vectorB.x + vectorA.y * vectorB.y + vectorA.z * vectorB.z);
        }

        /// <summary>
        /// Angle
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>double</returns>
        public static double Angle(Vector vectorA, Vector vectorB)
        {
            double dot = DotProduct(vectorA, vectorB);
            Vector v = new Vector(0, 0, 0);
            double magA = vectorA.DistanceTo(v);
            double magB = vectorB.DistanceTo(v);
            double div = dot / (magA * magB);
            div = (div < -1.0) ? -1.0 : (div > 1.0) ? 1.0 : div;
            return Math.Acos(div); // radianes.
        }

        /// <summary>
        /// Distance
        /// </summary>
        /// <param name="vector">vector to test</param>
        /// <returns>double</returns>
        public double DistanceTo(Vector vector)
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
            double m = this.DistanceTo(new Vector(0, 0, 0));
            _ = new Vector(this.x /= m, this.y /= m, this.z /= m);
        }

        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vector operator +(Vector vectorA, Vector vectorB)
        {
            double xc = vectorA.x + vectorB.x;
            double yc = vectorA.y + vectorB.y;
            double zc = vectorA.z + vectorB.z;
            return new Vector(xc, yc, zc);
        }

        /// <summary>
        /// Substraction
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vector operator -(Vector vectorA, Vector vectorB)
        {
            double xc = vectorA.x - vectorB.x;
            double yc = vectorA.y - vectorB.y;
            double zc = vectorA.z - vectorB.z;
            return new Vector(xc, yc, zc);
        }

        /// <summary>
        /// Scale multuplication
        /// </summary>
        /// <param name="vector">Vector to scale</param>
        /// <param name="factor">factor</param>
        /// <returns>Vector</returns>
        public static Vector operator *(Vector vector, double factor)
        {
            double xc = vector.x * factor;
            double yc = vector.y * factor;
            double zc = vector.z * factor;
            return new Vector(xc, yc, zc);
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
        public bool EqualTo(Vector vector)
        {
            return this.x == vector.x && this.y == vector.y && this.z == vector.z;
        }
    }
}
