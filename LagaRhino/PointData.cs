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

        /// <summary>
        /// Crates a DeepCopy from the existing list of curves
        /// </summary>
        /// <param name="lstToCopy">The curves to perform the deep copy</param>
        /// <returns>List<Curve></Curve></returns>
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

        /// <summary>
        /// Sort points by Z coordinate
        /// </summary>
        /// <param name="arrPts">The points to sort</param>
        /// <returns>point3d[]</returns>
        public static Point3d[] SortPointsByZ(Point3d[] arrPts)
        {
            return arrPts.OrderBy(p => p.Z).ToArray();
        }

        public static List<Point3d[]> GroupByZ(Point3d[] arrPts)
        {
            List<Point3d[]> lstArrGroup = new List<Point3d[]>();
            try
            {
                var groupedResult = arrPts.GroupBy(p => p.Z);

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
        /// Sort points by the coordinate X and then by the coordinate Y.
        /// </summary>
        /// <param name="arrPts">The points to sort</param>
        /// <returns>point3d[]</returns>
        public static Point3d[] SortPointsByXY(Point3d[] arrPts)
        {
            return arrPts.OrderBy(item => item.X)
                         .ThenBy(item => item.Y).ToArray();

        }
        /// <summary>
        /// Sort the Z point coordinate
        /// </summary>
        /// <param name="arrPts">The points to evaluate</param>
        /// <returns>double[]</returns>
        public static double[] SortCoordinateZ(Point3d[] arrPts)
        {
            return arrPts.Select(pt => pt.Z).OrderBy(Z => Z).ToArray();
        }

        /// <summary>
        /// WIP, create an interpolate point matrix between 2 points.
        /// The method does not control exceptions for the point positions.
        /// </summary>
        /// <param name="ptStart">The start point, bottom left</param>
        /// <param name="ptEnd">The end point, top right</param>
        /// <param name="span">the aproximate point separation</param>
        /// <returns>List<Point3d>()</Point3d></returns>
        public static List<Point3d> TwoPointsInterpolation(Point3d ptStart, Point3d ptEnd, double span)
        {
            List<Point3d> ptList = new List<Point3d>();

            Point3d pt_2 = new Point3d(ptEnd.X, ptStart.Y, ptStart.Z);
            Point3d pt_4 = new Point3d(ptStart.X, ptEnd.Y, ptStart.Z);
            int u = (int)(ptStart.DistanceTo(pt_2) / span);
            int v = (int)(ptStart.DistanceTo(pt_4) / span);
            double xSize = ptStart.DistanceTo(pt_2) / u;
            double ySize = ptStart.DistanceTo(pt_4) / v;

            Point3d pt;

            for (int i = 0; i <= u; i++)
            {
                for (int j = 0; j <= v; j++)
                {
                    pt = new Point3d(ptStart.X + (i * xSize), ptStart.Y + (j * ySize), ptStart.Z);
                    ptList.Add(pt);
                }
            }

            return ptList;

        }
    }
}