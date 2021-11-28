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
    public class Lne : Laga.Geometry.Line
    {
        private Vec pa;
        private Vec pb;

        /// <summary>
        /// First point in the Line
        /// </summary>
        public Vec PointA
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
        public Vec PointB
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
        public Lne(Vec pointA, Vec pointB)
        {
            pa = pointA;
            pb = pointB;
        }

        /// <summary>
        /// Returns the mid point.
        /// </summary>
        /// <returns>Laga Point</returns>
        public Vec MidPoint()
        {
            return new Vec((float)(pa.X + pb.X) / 2, (float)(pa.Y + pb.Y) / 2, (float)(pa.Z + pa.Z) / 2);
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
        static public void DrawLine(Vec pointA, Vec pointB, float width, Color color)
        {
            GameObject line = new GameObject("Line " + pointA.ToString() + " - " + pointB.ToString());
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
            lineRenderer.material.color = color;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, new Vector3((float)pointA.X, (float)pointA.Y, (float)pointA.Z));
            lineRenderer.SetPosition(1, new Vector3((float)pointB.X, (float)pointB.Y, (float)pointB.Z));
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }
    }
}