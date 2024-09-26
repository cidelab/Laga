using System.Collections.Generic;
using Rhino.Geometry;
using Laga.Geometry;

namespace LagaRhino
{
    /// <summary>
    /// Convexhull Class
    /// </summary>
    public class Convexhull
    {
        /// <summary>
        /// ConvexHull2d
        /// </summary>
        /// <param name="points">The points</param>
        /// <returns>convexhull points</returns>
        public static List<Point3d> ConvexHull2D(List<Point3d> points)
        {
            List<Vector> lstVec = Laga.Geometry.ConvexHull.ConvexHull2D(PointData.Points2Vectors(points));
            return PointData.Vectors2Points(lstVec);
        }
    }
}
