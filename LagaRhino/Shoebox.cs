using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace LagaRhino
{
    /// <summary>
    /// 
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
        /// <summary>
        /// Get the shoebox volume
        /// </summary>
        public double Volume
        {
            get
            {
                return br.GetVolume();
            }
        }
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
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Shoebox(Point3d point, double length, double width, double height)
        {
            pl.Origin = point;
            uw = width * 0.5;
            ul = length * 0.5;
            he = height;

            pa = pl.PointAt(-ul, -uw);
            pb = pl.PointAt(ul, -uw);
            pc = pl.PointAt(ul, uw);
            pd = pl.PointAt(-ul, uw);

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
    }
}
