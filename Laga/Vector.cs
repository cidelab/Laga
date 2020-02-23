using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laga.Geometry
{
    /// <summary>
    /// Vector class made by 3 doubles, Use this class indistinct for vector and points.
    /// </summary>
     public class Vector
    {

        private double Xcord = 0;
        private double Ycord = 0;
        private double Zcord = 0;
        private double Magnitude()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// Return the vector length (magnitude).
        /// </summary>
        public double Length
        {
            get
            {
                return Magnitude();
            }
        }

        /// <summary>
        /// get set X coordiante
        /// </summary>
        public double X
        {
            get
            {
                return Xcord;
            }
            set
            {
                value = Xcord;
            }
        }

        /// <summary>
        /// get set Y coordinate
        /// </summary>
        public double Y
        {
            get
            {
                return Ycord;
            }
            set
            {
                value = Ycord;
            }
        }

        /// <summary>
        /// get set Z coordinate
        /// </summary>
        public double Z
        {
            get
            {
                return Zcord;
            }
            set
            {
                value = Zcord;
            }
        }

        /// <summary>
        /// Constructor a 3d Vector
        /// </summary>
        /// <param name="dblX">X coordinate</param>
        /// <param name="dblY">Y coordinate</param>
        /// <param name="dblZ">Z coordinate</param>
        public Vector(double dblX, double dblY, double dblZ)
        {
            Xcord = dblX;
            Ycord = dblY;
            Zcord = dblZ;
        }

        /// <summary>
        /// Get the distance between 2 vectors.
        /// </summary>
        /// <param name="vec">The point to Test</param>
        /// <returns>a double</returns>
        public double DistanceTo(Vector vec)
        {
            return Math.Sqrt(Math.Pow((X - vec.X), 2) + Math.Pow((Y - vec.Y), 2) + Math.Pow((Z - vec.Z), 2));
        }

        /// <summary>
        /// Calculate the dot Product of 2 Vectors.
        /// </summary>
        /// <param name="vec">The Vector for the operation</param>
        /// <returns>Vector</returns>
        public double Dot(Vector vec)
        {
            return X * vec.X + Y * vec.Y + Z * vec.Z;
        }

        /// <summary>
        /// Calculate the vector in the middle of 2 vectors.
        /// </summary>
        /// <param name="vecA">First vector</param>
        /// <param name="vecB">Second vector</param>
        /// <returns>Vector</returns>
        public Vector MidVector(Vector vecA, Vector vecB)
        {
            return new Vector((vecA.X + vecB.X) / 2, (vecA.Y + vecB.Y) / 2, (vecA.Z + vecB.Z) / 2);
        }

        /// <summary>
        /// Returns the perpendicular vector to the other 2 Vectors.
        /// </summary>
        /// <param name="vecA">First vector</param>
        /// <param name="vecB">Second vector</param>
        /// <returns>Vector</returns>
        public Vector CrossProduct(Vector vecA, Vector vecB)
        {
            double x, y, z;
            x = vecA.Y * vecB.Z - vecB.Y * vecA.Z;
            y = (vecA.X * vecB.Z - vecB.X * vecA.Z) * -1;
            z = vecA.X * vecB.Y - vecB.X * vecA.Y;

            return new Vector(x, y, z);
        }

        /// <summary>
        /// Normalize the Vector Lenght
        /// </summary>
        /// <returns>Vector</returns>
        public Vector Normalize()
        {
            var m = Magnitude();
            return new Vector(X / m, Y / m, Z / m);
        }

        /// <summary>
        /// Vector addition
        /// </summary>
        /// <param name="vec">The vector to add</param>
        /// <returns>Vector</returns>
        public Vector Addition(Vector vec)
        {
            return new Vector(X + vec.X, Y + vec.Y, Z + vec.Z);
        }

        /// <summary>
        /// Substract 2 vectors
        /// </summary>
        /// <param name="vec">The vector to subtract</param>
        /// <returns>Vector</returns>
        public Vector Subtract(Vector vec)
        {
            return new Vector(X - vec.X, Y - vec.Y, Z - vec.Z);
        }

        /// <summary>
        /// Scale a vector by a scalar
        /// </summary>
        /// <param name="factor">the scalar to scale the vector</param>
        /// <returns></returns>
        public Vector Scale(double factor)
        {
            return new Vector(X * factor, Y * factor, Z * factor);
        }


    }
}
