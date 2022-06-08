using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace LagaRhino
{
    /// <summary>
    /// Shoebox
    /// </summary>
    public class Shoebox : Brep
    {
        private Plane pl = Plane.WorldXY;
        Brep br;
        private double uw;
        private double ul;
        private double he;

        /// <summary>
        /// Get the ShoeBox geometry.
        /// </summary>
        public Brep ShoeBox
            { get { return br; } }

        private Point3d pa, pb, pc, pd, pe, pf, pg, ph;

        /// <summary>
        /// Length Shoebox Property
        /// </summary>
        public double Length
        {
            get
            {
                return ul;
            }
            set
            {
                ul = value;
                ul = ul * 2;
            }
        }
        /// <summary>
        /// Width Shoebox property
        /// </summary>
        public double Width
        {
            get
            {
                return uw * 2;
            }
            set
            {
                uw = value;
                uw = uw * 2;
            }
        }

        /// <summary>
        /// Height Shoebox property
        /// </summary>
        public double Heigth
        {
            get { return he; }
            set { he = value;}
        }

        /// <summary>
        /// Shoebox by length, width and height
        /// </summary>
        /// <param name="point">Base point location</param>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Shoebox(Point3d point, double length, double width, double height)
        {
            PtsTranslate(point, length, width);

            pe = pa;
            pf = pb;
            pg = pc;
            ph = pd;

            pe.Z = he;
            pf.Z = he;
            pg.Z = he;
            ph.Z = he;

            br = Brep.CreateFromBox(new Point3d[] { pa, pb, pc, pd, pe, pf, pg, ph });
        }

        /// <summary>
        /// Shoebox with the free Z top points
        /// </summary>
        /// <param name="point">Base point location</param>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        /// <param name="eHeight">Z parameter for e point</param>
        /// <param name="fHeight">Z parameter for f point</param>
        /// <param name="gHeight">Z parameter for g point</param>
        /// <param name="hHeight">Z parameter for h point</param>
        public Shoebox(Point3d point, double length, double width, double eHeight, double fHeight, double gHeight, double hHeight)
        {
            PtsTranslate(point, length, width);

            pe = pa;
            pf = pb;
            pg = pc;
            ph = pd;

            pe.Z = eHeight;
            pf.Z = fHeight;
            pg.Z = gHeight;
            ph.Z = hHeight;

            br = Brep.CreateFromBox(new Point3d[] { pa, pb, pc, pd, pe, pf, pg, ph });
        }

        private void PtsTranslate(Point3d p, double l, double w)
        {
            pl.Origin = p;
            uw = w * 0.5;
            ul = l * 0.5;

            pa = pl.PointAt(-ul, -uw);
            pb = pl.PointAt(ul, -uw);
            pc = pl.PointAt(ul, uw);
            pd = pl.PointAt(-ul, uw);
        }
    }
}
