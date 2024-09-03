using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laga.Rhino
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
        /// Build a perpendicular line at specific point of a curve
        /// </summary>
        /// <param name="curve">The curve</param>
        /// <param name="t">The parameter between 0 to 1</param>
        /// <param name="length">The length for the segment, default 1</param>
        /// <returns>LineCurve</returns>
        public static LineCurve PerpendicularSegment(Curve curve, double t, double length = 1)
        {
            LineCurve ln = new LineCurve();
            CurveData.Reparam(curve);

            if(curve.PerpendicularFrameAt(t, out Plane plane))
            {
                Vector3d vecDir = plane.ZAxis;
                Vector3d vecLeft = Vector3d.CrossProduct(vecDir, Vector3d.ZAxis);
                vecLeft.Unitize();
                vecLeft *= (length * 0.5);
                Vector3d vecRight = vecLeft;
                vecRight.Reverse();
                Point3d pa = plane.Origin + vecLeft;
                Point3d pb = plane.Origin + vecRight;

                ln = new LineCurve(pa, pb);
                
            }


            return ln;
        }

        /// <summary>
        /// from the curve end points build an axis.
        /// </summary>
        /// <param name="curve">the curve to convert</param>
        /// <returns>LineCurve</returns>
        public static LineCurve Axis(Curve curve)
        {
            LineCurve lc = new LineCurve(curve.PointAtStart, curve.PointAtEnd);
            return LineCurveData.Axis(lc);
        }

        /// <summary>
        /// Evaluate a curve based on array of parameters
        /// </summary>
        /// <param name="curve">The curve to evaluate</param>
        /// <param name="arrT">the array of parameters</param>
        /// <returns>Point3d[]</returns>
        public static Point3d[] Evaluate(Curve curve, double[] arrT)
        {
            Point3d[] arrpoints = new Point3d[arrT.Length];
            for(int i = 0; i < arrpoints.Length; i++)
                arrpoints[i] = curve.PointAt(arrT[i]);

            return arrpoints;
        }

        /// <summary>
        /// Apply the same t parameter to a list of curves to return an array of points
        /// </summary>
        /// <param name="curves">The list of curves</param>
        /// <param name="t">t param</param>
        /// <returns>Point3d[]</returns>
        /// <example> Shows how to get the same point parameter from a list of curves:
        /// <code>
        /// using LagaRhino;
        /// {
        ///     A = CurveData.GetPointFromCurves(curves, t);
        /// }
        /// </code>
        /// </example>
        public static Point3d[] GetPointFromCurves(IEnumerable<Curve> curves, double t)
        {
            Point3d[] arrPts = new Point3d[curves.Count()];
            int i = 0;
            foreach(Curve c in curves)
            {
                arrPts[i] = c.PointAt(t);
                i++;            
            }
            return arrPts;
        }

        /// <summary>
        /// Makes a deep copy from a list of curves.
        /// </summary>
        /// <param name="curves">The list to copy</param>
        /// <returns><![CDATA[List<Curve>]]></returns>
        public static List<Curve> DeepCopyListCurve(IEnumerable<Curve> curves)
        {
            List<Curve> lstDeepCopy = new List<Curve>();
            foreach (Curve c in curves)
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

        /// <summary>
        /// Mirror a curve from a plane
        /// </summary>
        /// <param name="curve">The curve to mirror</param>
        /// <param name="plane">The plane</param>
        /// <returns>Curve</returns>
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
                return null;
        }

        /// <summary>
        /// Group a collection of curves by their Z Value.
        /// </summary>
        /// <param name="curves">lstCrv</param>
        /// <returns><![CDATA[List<double>]]></returns>
        public static List<double> CurvesZCoordinate(IEnumerable<Curve> curves)
        {
            List<double> source = new List<double>();
            foreach (Curve lstCrv in curves)
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
