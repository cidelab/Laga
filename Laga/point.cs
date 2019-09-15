using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laga.Geometry
{
    /// <summary>
    /// generic point class made by 3 doubles.
    /// </summary>
     public class point
    {

        private double Xcord = 0;
        private double Ycord = 0;
        private double Zcord = 0;

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
        /// Constructor a point
        /// </summary>
        /// <param name="dblX">X coordinate</param>
        /// <param name="dblY">Y coordinate</param>
        /// <param name="dblZ">Z coordinate</param>
        public point(double dblX, double dblY, double dblZ)
        {
            Xcord = dblX;
            Ycord = dblY;
            Zcord = dblZ;
        }

        /// <summary>
        /// Get the distance between 2 points.
        /// </summary>
        /// <param name="pt">The point to Test</param>
        /// <returns>a double</returns>
        public double distanceTo(point pt)
        {
            return Math.Sqrt(Math.Pow((X - pt.X), 2) + Math.Pow((Y - pt.Y), 2) + Math.Pow((Z - pt.Z), 2));
        }
    }
}
