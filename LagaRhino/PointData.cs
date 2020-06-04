using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace LagaRhino
{
    public class PointData
    {
        /// <summary>
        /// return the points sorted according to scrum Quadrants
        /// </summary>
        /// <param name="pt"></param>
        /// <returns>Point3d[]</returns>
        public static Point3d[] SortPointsQuadrant(Point3d pt)
        {
            Point3d[] sortedPts = new Point3d[4];
            double posX = Math.Abs(pt.X);
            double negX = posX * -1;
            double posY = Math.Abs(pt.Y);
            double negY = posY * -1;

            sortedPts[0] = new Point3d(posX, posY, 0);
            sortedPts[1] = new Point3d(posX, negY, 0);
            sortedPts[2] = new Point3d(negX, negY, 0);
            sortedPts[3] = new Point3d(negX, posY, 0);

            return sortedPts;
        }

        /// <summary>
        /// determine in which quadrant is the point. 0:++, 1:+-, 2:--, 3:-+.
        /// </summary>
        /// <param name="pt"></param>
        /// <returns>int</returns>
        public static int PointQuadrant(Point3d pt)
        {
            double x = pt.X;
            double y = pt.Y;

            int Q = 0;

            if (x >= 0 && y >= 0)
            {
                Q = 0;
            }
            else if (x > 0 && y <= 0)
            {
                Q = 1;
            }
            else if (x < 0 && y < 0)
            {
                Q = 2;
            }
            else if (x <= 0 && y > 0)
            {
                Q = 3;
            }
            return Q;
        }

        public static List<Curve> DeepCopy(List<Curve> lstToCopy)
        {
            List<Curve> lstDeepCopy = new List<Curve>();
            Curve deepCrv = null;
            foreach (Curve c in lstToCopy)
            {
                deepCrv = (Curve)c.Duplicate();
                lstDeepCopy.Add(deepCrv);
            }

            return lstDeepCopy;
        }



    }
}