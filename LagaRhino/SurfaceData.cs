using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace LagaRhino
{
    public class SurfaceData
    {

        /// <summary>
        /// Build a vertical planar surface from a LineCurve axis.
        /// </summary>
        /// <param name="axis">the axis</param>
        /// <param name="height">the height of the surface</param>
        /// <returns>Planar Surface</returns>
        public static Surface PlaneSurfaceAxis(LineCurve axis, double height = 100)
        {
            Point3d ps = axis.PointAtStart;
            Point3d pe = axis.PointAtEnd;

            ps.Z = 0;
            pe.Z = 0;

            Point3d psU = new Point3d(ps.X, ps.Y, height);
            Point3d peU = new Point3d(pe.X, pe.Y, height);

            return NurbsSurface.CreateFromCorners(ps, psU, peU, pe);
        }
    }
}
