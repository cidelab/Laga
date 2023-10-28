using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LagaRhino
{
    /// <summary>
    /// Simple Manipulations on Rhino Surfaces
    /// </summary>
    public class SurfaceAnalysis
    {
        private static Interval interval = new Interval(0, 1);
        private readonly List<Point3d> mPts;
        private Surface srf;
        private readonly int uDivs;
        private readonly int vDivs;


        /// <summary>
        /// Subdivide a surface by a list of points.
        /// </summary>
        /// <returns>List<Point3d></Point3d></returns>
        public List<Point3d> SubdividebyPoints()
        {
            List<Point3d> mPts = new List<Point3d>();
            double uSpan = 1.00 / (uDivs - 1);
            double vSpan = 1.00 / (vDivs - 1);
            for (int i = 0; i < uDivs; i++)
            {
                for (int j = 0; j < vDivs; j++)
                {
                    mPts.Add(srf.PointAt(i * uSpan, j * vSpan));
                }
            }

            return mPts;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surface">The base surface</param>
        /// <param name="uCount">number of points in u direction</param>
        /// <param name="vCount">number of points in v direction</param>
        public SurfaceAnalysis(Surface surface, int uCount, int vCount)
        {
            srf = surface;
            srf.SetDomain(0, interval);
            srf.SetDomain(1, interval);

            uDivs = uCount;
            vDivs = vCount;
        }
        /// <summary>
        /// Subdivide surface by planes.
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="uCount">The number of divisions in u direction</param>
        /// <param name="vCount">The number of divisions in v direction</param>
        /// <param name="uSpan">The offset span from u direction</param>
        /// <param name="vSpan">the offset span from v direction</param>
        /// <returns>List<Plane></Plane></returns>
        public static List<Plane> SubdividebyPlanes(Surface surface, int uCount, int vCount, double uSpan = 0.0, double vSpan = 0.0)
        {
            surface.SetDomain(0, interval);
            surface.SetDomain(1, interval);

            List<Plane> lstPlanes = new List<Plane>();
            double maxU = 1.00 - uSpan;
            double maxV = 1.00 - vSpan;

            for (int i = 0; i < uCount + 1; i++)
            {
                for (int j = 0; j < vCount + 1; j++)
                {
                    if (surface.FrameAt(uSpan + i * ((maxU - uSpan) / uCount), vSpan + j * ((maxV - vSpan) / vCount), out Plane pl))
                        lstPlanes.Add(pl);
                }
            }

            return lstPlanes;

        }

        /// <summary>
        /// To develop a custom pattern on surface
        /// </summary>
        public void CustomPattern()
        { }

        /// <summary>
        /// To develop Triangular Pattern
        /// </summary>
        public void TriangularPatter()
        {

        }

        /// <summary>
        /// Return a Quad Pattern division
        /// </summary>
        /// <returns><![CDATA[List<Polyline>]]></returns>
        public List<Polyline> QuadPattern()
        {
            List<Polyline> polList = new List<Polyline>();
            Point3d[] arrPts;

            int span = mPts.Count / uDivs;

            for (int i = 0; i < mPts.Count - span; i += span)
            {
                arrPts = new Point3d[5];
                for (int j = 0; j < vDivs - 1; j++)
                {
                    arrPts[0] = mPts[j + i];
                    arrPts[1] = mPts[j + (i + span)];
                    arrPts[2] = mPts[j + 1 + (i + span)];
                    arrPts[3] = mPts[j + 1 + i];
                    arrPts[4] = mPts[j + i];

                    polList.Add(new Polyline(arrPts));
                }
            }
            return polList;
        }

        /// <summary>
        /// Build a vertical planar surface from a LineCurve axis.
        /// </summary>
        /// <param name="axis">the axis</param>
        /// <param name="height">the height of the surface</param>
        /// <returns>Surface</returns>
        public static Surface PlaneSurfaceAxis(LineCurve axis, double height = 100)
        {
            LineCurve lc = LineCurveData.Axis(axis);

            Point3d ps = lc.PointAtStart;
            Point3d pe = lc.PointAtEnd;

            ps.Z = 0;
            pe.Z = 0;

            Point3d psU = new Point3d(ps.X, ps.Y, height);
            Point3d peU = new Point3d(pe.X, pe.Y, height);

            return NurbsSurface.CreateFromCorners(ps, psU, peU, pe);
        }
    }
}
