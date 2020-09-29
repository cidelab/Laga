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

        /// <summary>
        /// Align Perpendicular frames in the Curve
        /// </summary>
        /// <param name="crv">the curve in the analysis</param>
        /// <param name="t">the t param on the curve</param>
        /// <returns></returns>
        public static Plane PlaneCorrectOnCurveByParam(Curve crv, double t)
        {
            crv.PerpendicularFrameAt(t, out Plane pl);

            //check the direction of the plane
            Point3d plOrigin = pl.Origin;
            Vector3d vecX = pl.XAxis;
            Point3d testPt = plOrigin + vecX;

            double dist = Point3d.Origin.DistanceTo(testPt);
            double dist2 = Point3d.Origin.DistanceTo(plOrigin);

            if (dist > dist2)
            {
                vecX.Reverse();
                Point3d ptX, ptY;
                ptX = pl.Origin + vecX;
                ptY = pl.Origin + pl.YAxis;

                pl = new Plane(pl.Origin, ptX, ptY);
            }

            return pl;
        }
    }
}
