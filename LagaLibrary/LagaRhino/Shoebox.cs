using Rhino.Geometry;

namespace LagaRhino
{
    /// <summary>
    /// Class to build and analize shoeboxes types.
    /// </summary>
    public class Shoebox : Brep
    {
        private Point3d pa, pb, pc, pd, pe, pf, pg, ph;
        private Plane pl = Plane.WorldXY;
        private double uw;
        private double ul;
        private double vol;
        private double area;

        /// <summary>
        /// Get the ShoeBox geometry.
        /// </summary>
        public Brep ShoeBox { get; }

        /// <summary>
        /// Length Shoebox Property
        /// </summary>
        public double Volume
        { get { return vol; } }

        /// <summary>
        /// Width Shoebox property
        /// </summary>
        public double Area
        { get { return area; } }

        /// <summary>
        /// Shoebox by length, width and height
        /// </summary>
        /// <param name="point">Base point location</param>
        /// <param name="rotate">Rotate parameter</param>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Shoebox(Point3d point, double length, double width, double height, double rotate = 0.0)
        {
            PtsTranslate(point, length, width, rotate);

            pe = pa;
            pf = pb;
            pg = pc;
            ph = pd;

            pe.Z = height;
            pf.Z = height;
            pg.Z = height;
            ph.Z = height;

            ShoeBox = Brep.CreateFromBox(new Point3d[] { pa, pb, pc, pd, pe, pf, pg, ph });
            Data();
        }

        /// <summary>
        /// Rotate Shoebox
        /// </summary>
        /// <param name="angle">Rotation angle in radians</param>
        public void Rot(double angle)
        {
            this.ShoeBox.Rotate(angle, Vector3d.ZAxis, pl.Origin);
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
        /// <param name="rotate">Rotate parameter</param>
        public Shoebox(Point3d point, double length, double width, double eHeight, double fHeight, double gHeight, double hHeight, double rotate = 0.0)
        {
            PtsTranslate(point, length, width, rotate);

            pe = pa;
            pf = pb;
            pg = pc;
            ph = pd;

            pe.Z = eHeight;
            pf.Z = fHeight;
            pg.Z = gHeight;
            ph.Z = hHeight;

            ShoeBox = Brep.CreateFromBox(new Point3d[] { pa, pb, pc, pd, pe, pf, pg, ph });
            Data();

        }

        private void Data()
        {
            vol = ShoeBox.GetVolume();
            area = ShoeBox.GetArea();
        }
        private void PtsTranslate(Point3d p, double l, double w, double rot)
        {
            pl.Origin = p;
            pl.Rotate(rot, pl.ZAxis);

            uw = w * 0.5;
            ul = l * 0.5;

            pa = pl.PointAt(-ul, -uw);
            pb = pl.PointAt(ul, -uw);
            pc = pl.PointAt(ul, uw);
            pd = pl.PointAt(-ul, uw);
        }
    }
}
