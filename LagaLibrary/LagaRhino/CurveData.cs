using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagaRhino
{
    /// <summary>
    /// Simple Manipulations on Rhino Curves
    /// </summary>
    public class CurveData
    {
        private static Interval param = new Interval(0.0, 1.0);

        /// <summary>
        /// Reparametrize Curve
        /// </summary>
        /// <param name="curve">Curve to modify</param>
        public static void Reparam(Curve curve)
        {
            curve.Domain = param;
        }

        /// <summary>
        /// Apply the same t parameter to a list of curves to return an array of points
        /// </summary>
        /// <param name="lstCurves">The list of curves</param>
        /// <param name="t">t param</param>
        /// <returns>Point3d[]</returns>
        /// <example>
        /// Shows how to get the same point parameter from a list of curves.
        /// <code>
        /// using LagaRhino;
        /// {
        ///     A = CurveData.GetPointFromCurves(lstCurves, y);
        /// }
        /// </code>
        /// </example>
        public static Point3d[] GetPointFromCurves(List<Curve> lstCurves, double t)
        {
            Point3d[] arrPts = new Point3d[lstCurves.Count];
            Curve c;
            for (int i = 0; i < lstCurves.Count; i++)
            {
                c = lstCurves[i];
                c.Domain = param;
                arrPts[i] = c.PointAt(t);

            }

            return arrPts;
        }

        /// <summary>
        /// Makes a deep copy from a list of curves.
        /// </summary>
        /// <param name="lstToCopy">The list to copy</param>
        /// <returns><![CDATA[List<Curve>]]></returns>
        public static List<Curve> DeepCopyListCurve(List<Curve> lstToCopy)
        {
            List<Curve> lstDeepCopy = new List<Curve>();
            foreach (Curve c in lstToCopy)
            {
                Curve deepCrv = (Curve)c.Duplicate();
                lstDeepCopy.Add(deepCrv);
            }

            return lstDeepCopy;
        }
        /// <summary>
        /// Align Perpendicular frames in the Curve
        /// </summary>
        /// <param name="curve">the curve in the analysis</param>
        /// <param name="t">the t param on the curve</param>
        /// <returns>Plane</returns>
        public static Plane CorrectPlaneOnCurveByParam(Curve curve, double t)
        {
            curve.PerpendicularFrameAt(t, out Plane pl);

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

        public static Curve MirrorCurve( Curve curve, Plane plane)
        {
            Curve c = (Curve)curve.DuplicateCurve();
            Transform xform = Transform.Mirror(plane);
            if(c.Transform(xform))
            {
                Curve[] arrC = Curve.JoinCurves(new Curve[] { c, curve });
                return arrC[0];
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Returns the Z values from a list of curves
        /// </summary>
        /// <param name="lstCrvs">lstCrv</param>
        /// <returns><![CDATA[List<double>]]></returns>
        public static List<double> CurvesZValues(List<Curve> lstCrvs)
        {
            List<double> source = new List<double>();
            foreach (Curve lstCrv in lstCrvs)
            {
                List<double> doubleList = source;
                Point3d pointAtStart = lstCrv.PointAtStart;
                double num = Math.Round(pointAtStart.Z, 8);
                doubleList.Add(num);
            }
            List<double> list = source.Distinct<double>().ToList<double>();
            list.Sort();
            return list;
        }
    }
}
