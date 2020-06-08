using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.Numbers
{
    /// <summary>
    /// Mathematics and statistics operations
    /// </summary>
    public class Maths
    {

        /// <summary>
        /// Degrees to Radians
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns>double</returns>
        public static double Deg2Rad(double degrees)
        {
            double radians = (Math.PI / 180.0) * degrees;
            return (radians);
        }

        /// <summary>
        /// Radians to Degree
        /// </summary>
        /// <param name="radians"></param>
        /// <returns>double</returns>
        public static double Rad2Deg(double radians)
        {
            double degrees = (180.0 / Math.PI) * radians;
            return (degrees);
        }
    }
}
