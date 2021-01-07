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
        /// Generic Vector Constructor
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
        /// Override ToString() method
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "vec[" + x + ", " + y + "," + z + "]";
        }

        /// <summary>
        /// Test if the vector is equal.
        /// </summary>
        /// <param name="vector">Vector test</param>
        /// <returns>bool</returns>
        public bool EqualTo(Vector vector)
        {
            return this.x == vector.x && this.y == vector.y && this.z == vector.z;
        }
    }
}
