using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagaRhino
{
    public class PointData
    {
        /// <summary>
        /// Mirror a point by the 4 quadrants
        /// </summary>
        /// <param name="point">point to mirror</param>
        /// <returns>Point3d[]</returns>
        public static Point3d[] MirrorPointQuadrant(Point3d point)
        {
            Point3d[] sortedPts = new Point3d[4];
            double posX = Math.Abs(point.X);
            double negX = posX * -1;
            double posY = Math.Abs(point.Y);
            double negY = posY * -1;

            sortedPts[0] = new Point3d(posX, posY, 0);
            sortedPts[1] = new Point3d(posX, negY, 0);
            sortedPts[2] = new Point3d(negX, negY, 0);
            sortedPts[3] = new Point3d(negX, posY, 0);

            return sortedPts;
        }

        /// <summary>
        /// determine in which quadrant is the point, if 0:++, 1:+-, 2:--, 3:-+.
        /// </summary>
        /// <param name="point">Test point</param>
        /// <returns>int</returns>
        public static int PointQuadrant(Point3d point)
        {
            double x = point.X;
            double y = point.Y;

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

        /// <summary>
        /// Sort points by Z coordinate
        /// </summary>
        /// <param name="points">The points to sort</param>
        /// <returns>point3d[]</returns>
        public static Point3d[] SortPointsByZ(Point3d[] points)
        {
            return points.OrderBy(p => p.Z).ToArray();
        }

        /// <summary>
        /// Sort points by the coordinate X and then by the coordinate Y.
        /// </summary>
        /// <param name="points">The points to sort</param>
        /// <returns>point3d[]</returns>
        public static Point3d[] SortPointsByXY(Point3d[] points)
        {
            return points.OrderBy(item => item.X)
                         .ThenBy(item => item.Y).ToArray();

        }

        /// <summary>
        /// Group points by Z coordinate.
        /// </summary>
        /// <param name="points">the array of points to group</param>
        /// <returns>List<Point3d[]></returns>
        public static List<Point3d[]> GroupByZ(Point3d[] points)
        {
            points = points.OrderBy(p => p.Z).ToArray();

            List<Point3d[]> lstArrGroup = new List<Point3d[]>();
            try
            {
                var groupedResult = points.GroupBy(p => p.Z);

                foreach (var zGroup in groupedResult)
                {
                    lstArrGroup.Add(zGroup.ToArray());
                }
            }
            catch (Exception)
            {
                return null;
            }

            return lstArrGroup;
        }
    }
}
