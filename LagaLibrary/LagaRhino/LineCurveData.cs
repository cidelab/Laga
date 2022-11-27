using Rhino.Geometry;

namespace LagaRhino
{
    /// <summary>
    /// Simple manipulations on Rhino LineCurves
    /// </summary>
    public class LineCurveData
    {
        /// <summary>
        /// Transform a LineCurve to an Axis, The origin of the axis is the further point from the (0,0,0)
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
                (pb, pa) = (pa, pb);
            }

            return new LineCurve(pb, pa);
        }
    }
}
