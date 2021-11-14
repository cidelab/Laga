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
    public class ULine
    {
        #region
        /*
        private UPoint pa;
        private UPoint pb;

        /// <summary>
        /// First point in the Line
        /// </summary>
        public Point PointA
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
        public Point PointB
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
        public ULine(Point pointA, Point pointB)
        {
            pa = pointA;
            pb = pointB;
        }

        /// <summary>
        /// Returns the mid point.
        /// </summary>
        /// <returns>Laga Point</returns>
        public Point MidPoint()
        {
            return new Point((pa.X + pb.X) / 2, (pa.Y + pb.Y) / 2, (pa.Z + pa.Z) / 2);
        }

        /// <summary>
        ///  Overrides ToString() Line point coordinates
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "Line_" + PointA.ToString() + " - " + PointB.ToString(); 
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
        static public void DrawLine(Point pointA, Point pointB, float width, Color color)
        {
            GameObject line = new GameObject("Line " + pointA.ToString() + " - " + pointB.ToString());
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
            lineRenderer.material.color = color;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, new Vector3(pointA.X, pointA.Y, pointA.Z));
            lineRenderer.SetPosition(1, new Vector3(pointB.X, pointB.Y, pointB.Z));
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }
        */
        #endregion
    }
}