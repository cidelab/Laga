using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace LagaRhino
{
    public class CurveData
    {
        private static Interval param = new Interval(0, 1);

        public static Point3d[] GetPointFromCurves(List<Curve> lstCrvs, double t)
        {
            Point3d[] arrPts = new Point3d[lstCrvs.Count];
            Curve c;
            for(int i = 0; i < lstCrvs.Count; i++)
            {
                c = lstCrvs[i];
                c.Domain = param;
                arrPts[i] = c.PointAt(t);

            }

            return arrPts;
        }
    }
}
