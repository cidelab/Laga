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
    public class SurfaceData
    {
        private Interval interval = new Interval(0, 1);
        private readonly List<Point3d> mPts;
        private int uDivs;
        private int vDivs;
        /// <summary>
        /// The points on the surface
        /// </summary>
        public List<Point3d> SurfacePoints
        {
            get { return mPts; }
        }

        /// <summary>
        /// Construct a SurfaceData object
        /// </summary>
        /// <param name="surface">The base surface</param>
        /// <param name="uCount">number of points in u direction</param>
        /// <param name="vCount">number of points in v direction</param>
        public SurfaceData(Surface surface, int uCount, int vCount)
        {
            uDivs= uCount;
            vDivs= vCount;

            surface.SetDomain(0, interval);
            surface.SetDomain(1, interval);

            mPts = new List<Point3d>();
            double uSpan = 1.00 / (uCount - 1);
            double vSpan = 1.00 / (vCount - 1);
            for (int i = 0; i < uCount; i++)
            {
                for (int j = 0; j < vCount; j++)
                {
                    mPts.Add(surface.PointAt(i * uSpan, j * vSpan));
                }
            }

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
        /// To develop Hexagon Pattern
        /// </summary>
        public void HexagonPattern()
        {
            
        }

        /// <summary>
        /// Return a Quad Pattern division
        /// </summary>
        /// <returns>List<Polyline></returns>
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
