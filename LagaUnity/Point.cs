using System;
using UnityEngine;

namespace LagaUnity
{
    public class Point
    {

        private float x;
        private float y;
        private float z;

        /// <summary>
        /// The X coordinate
        /// </summary>
        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// The Y coordinate
        /// </summary>
        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// The Z coordinate
        /// </summary>
        public float Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        /// <summary>
        /// Build a laga point object by 3 coordinates.
        /// </summary>
        /// <param name="X">X coordinate</param>
        /// <param name="Y">Y coordinate</param>
        /// <param name="Z">z coordinate</param>
        public Point(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        /// <summary>
        /// Override string method, Print point coordinates
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }

        /// <summary>
        /// Draw the point
        /// </summary>
        /// <param name="width">width for the point, 2.0</param>
        /// <param name="color">the color's point to draw</param>
        public void Draw(float width, Color color)
        {
            DrawPoint(this, width, color);
        }

        /// <summary>
        /// Calculate the distance to the second point.
        /// </summary>
        /// <param name="pointB"></param>
        /// <returns></returns>
        public float DistanceTo(Point pointB)
        {
            return (float)Math.Sqrt(Math.Pow((X - pointB.X), 2) + Math.Pow((Y - pointB.Y), 2) + Math.Pow((Z - pointB.Z), 2));

        }

        /// <summary>
        /// Draw a point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        static public void DrawPoint(Point point, float width, Color color)
        {
            GameObject line = new GameObject("Point " + point.ToString());
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
            lineRenderer.material.color = color;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, new Vector3(point.x - width / 3.0f, point.y - width / 3.0f, point.z));
            lineRenderer.SetPosition(1, new Vector3(point.x + width / 3.0f, point.y + width / 3.0f, point.z));
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }

    }
}
