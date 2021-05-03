using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laga.Geometry
{
    /// <summary>
    /// Vector class for 2D and 3D
    /// </summary>
    public class Vector
    {
        float x;
        float y;
        float z;

        /// <summary>
        /// Generic Vector 2D Constructor
        /// </summary>
        /// <param name="X">X coordinate</param>
        /// <param name="Y">Y coordinate</param>
        public Vector(float X, float Y)
        {
            x = X;
            y = Y;
            z = 0;
        }
        /// <summary>
        /// Generic Vector 3D Constructor
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public Vector(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "vec [" + x + ", " + y + ", " + z + "]";
        }

        /// <summary>
        /// Test if the vector is equal.
        /// </summary>
        /// <param name="vector">Vector to test</param>
        /// <returns>bool</returns>
        public bool EqualTo(Vector vector)
        {
            return this.x == vector.x && this.y == vector.y && this.z == vector.z;
        }

        /// <summary>
        /// Vector Addition
        /// </summary>
        /// <param name="vectorA">First Vector</param>
        /// <param name="vectorB">Second Vector</param>
        /// <returns>Vector</returns>
        public static Vector operator +(Vector vectorA, Vector vectorB)
        {
            float xc = vectorA.x + vectorB.x;
            float yc = vectorA.y + vectorB.y;
            float zc = vectorA.z + vectorB.z;
            Vector v = new Vector(xc, yc, zc);
            return v;
        }

        /// <summary>
        /// Vector Substraction
        /// </summary>
        /// <param name="vectorA">First Vector</param>
        /// <param name="vectorB">Second Vector</param>
        /// <returns>Vector</returns>
        public static Vector operator -(Vector vectorA, Vector vectorB)
        {
            float xc = vectorA.x - vectorB.x;
            float yc = vectorA.y - vectorB.y;
            float zc = vectorA.z - vectorB.z;
            Vector v = new Vector(xc, yc, zc);
            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static Vector operator *(Vector vector, float scalar)
        {
            return new Vector(vector.x * scalar, vector.y * scalar, vector.z * scalar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vectorA"></param>
        /// <param name="vectorB"></param>
        /// <returns></returns>
        public static Vector operator *(Vector vectorA, Vector vectorB)
        {
            return new Vector(vectorA.x * vectorB.x, vectorA.y * vectorB.z, vectorA.z * vectorB.z);
        }
    }
}
