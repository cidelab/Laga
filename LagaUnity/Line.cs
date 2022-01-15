using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace LagaUnity
{
    /// <summary>
    /// Draw a line in Unity
    /// </summary>
    public class Line : Laga.Geometry.Line
    {
        private Vectorf pa;
        private Vectorf pb;

        /// <summary>
        /// First point in the Line
        /// </summary>
        public Vectorf PointA
        {
            get
            {
                return pa;
            }
            set
            {
                pa = value;
            }
        }

        /// <summary>
        /// Second Point in the Line
        /// </summary>
        public Vectorf PointB
        {
            get
            {
                return pb;
            }
            set
            {
                pb = value;
            }
        }

        /// <summary>
        /// Construct a laga line object by 2 points.
        /// </summary>
        /// <param name="pointA">First Point</param>
        /// <param name="pointB">Second Point</param>
        public Line(Vectorf pointA, Vectorf pointB)
        {
            pa = pointA;
            pb = pointB;
            //StartPoint = pointA;
            //EndPoint = pointB;
        }

        /// <summary>
        /// Returns the mid point.
        /// </summary>
        /// <returns>Laga Point</returns>
        public Vectorf MidPoint()
        {
            return new Vectorf((pa.X + pb.X) / 2, (pa.Y + pb.Y) / 2, (pa.Z + pa.Z) / 2);
        }

        /// <summary>
        /// Draw a Unity Line
        /// </summary>
        /// <param name="width">Line width</param>
        /// <param name="color">Color line</param>
        public void Draw(float width, Color color)
        {
            DrawLine(pa, pb, width, color);
        }

        /// <summary>
        /// Draw a Unity line
        /// </summary>
        /// <param name="pointA">First point</param>
        /// <param name="pointB">Second Point</param>
        /// <param name="width">Line Width</param>
        /// <param name="color">Color Line</param>
        static public LineRenderer DrawLine(Vectorf pointA, Vectorf pointB, float width, Color color)
        {
            GameObject line = new GameObject("Line " + pointA.ToString() + " - " + pointB.ToString());
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"))
            {
                color = color
            };
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, pointA.ToVector3);
            lineRenderer.SetPosition(1, pointB.ToVector3);
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;

            return lineRenderer;
        }
    }
}