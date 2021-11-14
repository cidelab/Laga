using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace LagaRhino
{
    /// <summary>
    /// Line curve data
    /// </summary>
    public class LineCurveData
    {
     
        /// <summary>
        /// Transform a LineCurve to an Axis object.
        /// </summary>
        /// <param name="axis">LineCurve</param>
        /// <returns>LineCurve</returns>
        public static LineCurve Axis(LineCurve axis)
        {
            Point3d pa = axis.PointAtStart;
            Point3d pb = axis.PointAtEnd;

            pa.Z = 0;
            pb.Z = 0;

            if (pb.DistanceTo(Point3d.Origin) < pa.DistanceTo(Point3d.Origin))
            {
                Point3d temp = pa;
                pa = pb;
                pb = temp;
            }

            return new LineCurve(pb, pa);
        }
    }
}
