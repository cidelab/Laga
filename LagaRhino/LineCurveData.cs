using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace LagaRhino
{
    public class LineCurveData
    {
        public static LineCurve Axis(LineCurve axis)
        {
            Point3d pa = axis.PointAtStart;
            Point3d pb = axis.PointAtEnd;

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
