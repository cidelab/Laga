using Rhino.Geometry;
using System.Collections.Generic;
using Laga.GeneticAlgorithm;

namespace Laga.Rhino
{
    /// <summary>
    /// Simple Manipulations on Rhino Surfaces
    /// </summary>
    public class SurfaceAnalysis
    {
        private static Interval interval = new Interval(0, 1);
        private Population<Point3d> popGrid;
        readonly private Surface srf;
        private readonly int uDivs;
        private readonly int vDivs;

        /// <summary>
        /// Get access to all points on the surface.
        /// </summary>
        public Population<Point3d> PointsOnSurface { get {  return popGrid; } }

        /// <summary>
        /// Load the grid of points on the surface.
        /// </summary>
        private void SubdividebyPoints()
        {
            double uSpan = 1.00 / (uDivs - 1);
            double vSpan = 1.00 / (vDivs - 1);

            popGrid = new Population<Point3d>();
            List<Point3d> mPts;

            for (int i = 0; i < uDivs; i++)
            {
                mPts = new List<Point3d>();
                for (int j = 0; j < vDivs; j++)
                {
                    mPts.Add(srf.PointAt(i * uSpan, j * vSpan));
                }
                popGrid.Add(new Chromosome<Point3d>(mPts));
            }
        }

        private void SubdividebySpan()
        {
            Curve crvU = srf.IsoCurve(0, 0);
            Curve crvV = srf.IsoCurve(1, 0);

            //binary search...
        }
        /// <summary>
        /// Constructor, Subdivide the surface by u and v numbers.
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

            SubdividebyPoints();
        }

        /// <summary>
        /// Constructor, Subdivide the surface by uspan length and vspan length.
        /// </summary>
        /// <param name="surface">The base surface</param>
        /// <param name="uSpan">the span length for u direction</param>
        /// <param name="vSpan">the span length for v direction</param>
        public SurfaceAnalysis(Surface surface, double uSpan, double vSpan)
        {
            srf = surface;
            srf.SetDomain(0, interval);
            srf.SetDomain(1, interval);

            SubdividebySpan();
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
        public void CustomPattern(string grammar)
        { 
            _ = grammar.Length;
        }

        /// <summary>
        /// To develop Triangular Pattern
        /// </summary>
        public void TriangularPattern()
        {

        }

        /// <summary>
        /// Return a Quad Pattern division
        /// </summary>
        /// <returns><![CDATA[List<Polyline>]]></returns>
        public Population<Polyline> QuadPattern()
        {
            Population<Polyline> pop = new Population<Polyline>();
            Chromosome<Polyline> chrRow;
            Point3d pa, pb, pc, pd;

            for (int i = 0; i < uDivs - 1; i ++)
            {
                chrRow = new Chromosome<Polyline>();
                for (int j = 0; j < vDivs - 1; j++)
                {
                    pa = popGrid.GetChromosome(i).GetDNA(j);
                    pb = popGrid.GetChromosome(i + 1).GetDNA(j);
                    pc = popGrid.GetChromosome(i + 1).GetDNA(j + 1);
                    pd = popGrid.GetChromosome(i).GetDNA(j + 1);

                    chrRow.Add(new Polyline(new Point3d[] {pa, pb, pc, pd, pa}));
                }
                pop.Add(chrRow);
            }
            return pop;
        }
    }
}
