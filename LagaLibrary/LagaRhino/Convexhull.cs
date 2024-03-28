using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Laga.Geometry;
using System.Reflection.Emit;

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
            List<Vector> lstVec = Laga.Geometry.ConvexHull.ConvexHull2D(PointData.Point3DToVector(points));
            return PointData.VectorToPoint3D(lstVec);
        }
    }
}
