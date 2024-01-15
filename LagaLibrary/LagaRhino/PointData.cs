using Laga.Geometry;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LagaRhino
{
    /// <summary>
    /// Simple Manipulations on Rhino Points
    /// </summary>
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
        /// Sort a list of points clockwise
        /// </summary>
        /// <param name="points">the list of points</param>
        /// <returns><![CDATA[List<Point3d>]]></returns>
        public static List<Point3d> SortPointsClockwise(List<Point3d> points)
        {
            List<Point3d> list = points.OrderBy<Point3d, double>((Func<Point3d, double>)(pt => Math.Atan2(pt.X, pt.Y))).ToList<Point3d>();
            Point3d point3d1 = list[0];
            int num;
            if (point3d1.X < 0.0)
            {
                Point3d point3d2 = list[1];
                if (point3d2.X > 0.0)
                {
                    Point3d point3d3 = list[0];
                    if (point3d3.Y < 0.0)
                    {
                        Point3d point3d4 = list[1];
                        num = point3d4.Y < 0.0 ? 1 : 0;
                    }
                    else
                    {
                        num = 0;
                    }
                }
            }
            num = 0;
            if (num != 0)
                list.Reverse();
            return list;
        }

        /// <summary>
        /// Group points by Z coordinate.
        /// </summary>
        /// <param name="points">the array of points to group</param>
        /// <returns><![CDATA[List<Point3d[]>]]></returns>
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

        /// <summary>
        /// Interpolate 2 points by span distance
        /// </summary>
        /// <param name="pointA">Start point</param>
        /// <param name="pointB">End point</param>
        /// <param name="span">span distance</param>
        /// <returns>Point3d[]</returns>
        public static Point3d[] TwoPointsInterpolation(Point3d pointA, Point3d pointB, double span)
        {
            Vector va = Point3dToVector(pointA);
            Vector vb = Point3dToVector(pointB);

            List<Vector> lstVectors = Vector.Interpolation(va, vb, span);
            Point3d[] arrPts = new Point3d[lstVectors.Count];

            for (int i = 0; i < lstVectors.Count; i++)
                arrPts[i] = VectorToPoint3d(lstVectors[i]);

            return arrPts;
        }

        /// <summary>
        /// Convert Laga Vector to Rhino Point3d
        /// </summary>
        /// <param name="vector">The Vector to convert</param>
        /// <returns>Point3d</returns>
        public static Point3d VectorToPoint3d(Vector vector)
        {
            return new Point3d(vector.X, vector.Y, vector.Z);

        }

        /// <summary>
        /// Convert Laga Vectors to Rhino Point3ds
        /// </summary>
        /// <param name="arrVector">The arry of Vectors to convert</param>
        /// <returns>Point3d[]</returns>
        public static Point3d[] VectorToPoint3d(Vector[] arrVector)
        {
            Point3d[] arrPt3d = new Point3d[arrVector.Length];
            for(int i = 0;i < arrVector.Length;i++)
                arrPt3d[i] = new Point3d(VectorToPoint3d(arrVector[i]));

            return arrPt3d;

        }

        /// <summary>
        /// Convert Rhino Point3d to Laga Vector
        /// </summary>
        /// <param name="point">The point to convert</param>
        /// <returns>Vector</returns>
        public static Vector Point3dToVector(Point3d point)
        {
            if (point != null)
            {
                return new Vector(point.X, point.Y, point.Z);
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }

        /// <summary>
        /// list of Z values... not really...
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="test"></param>
        /// <param name="stand"></param>
        /// <returns>double</returns>
        public static double FindZDifference(List<double> pattern, double test, double stand = 0.35)
        {
            int index1 = 0;
            for (int index2 = 0; index2 < pattern.Count; ++index2)
            {
                if (pattern[index2] == test)
                {
                    index1 = index2;
                    break;
                }
            }
            return index1 == pattern.Count - 1 ? stand : pattern[index1 + 1] - pattern[index1];
        }
    }
}
