using Rhino.Geometry;

namespace LagaRhino
{
    /// <summary>
    /// Simple manipulations on Rhino LineCurves
    /// </summary>
    public class LineCurveData
    {
        /// <summary>
        /// Build a plane from the axis, it's not a perpendicular plane.
        /// </summary>
        /// <param name="axis">The LineCurve base</param>
        /// <returns>Plane</returns>
        public static Plane BuildPlane(LineCurve axis)
        {
            LineCurve lc = Axis(axis);
            CurveData.Reparam(lc);

            Point3d pa = lc.PointAtEnd;
            Point3d pb = lc.PointAtStart;

            Vector3d vecX = pa - pb;
            
            Point3d ptOrigin = lc.PointAt(0.5);

            return new Plane(ptOrigin, vecX, Vector3d.ZAxis);
        }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Surface PlaneSurfaceAxis(LineCurve axis, double height = 100.0)
        {
            Point3d pointAtStart = ((Curve)axis).PointAtStart;
            Point3d pointAtEnd = ((Curve)axis).PointAtEnd;
            pointAtStart.Z = 0.0;
            pointAtEnd.Z = 0.0;
            Point3d point3d1 = new Point3d(pointAtStart.X, pointAtStart.Y, height);
           Point3d point3d2 = new Point3d(pointAtEnd.X, pointAtEnd.Y, height);

            return NurbsSurface.CreateFromCorners(pointAtStart, point3d1, point3d2, pointAtEnd);
        }
    }
}
