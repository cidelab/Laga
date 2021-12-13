using System;
using UnityEngine;
using Laga.Geometry;

namespace LagaUnity
{
    /// <summary>
    /// Unity Point
    /// </summary>
    public class Vec : Vector3d
    {
        private float x;
        private float y;
        private float z;

        /// <summary>
        /// Build a UVector object by 3 coordinates.
        /// </summary>
        /// <param name="Xcoord">X coordinate</param>
        /// <param name="Ycoord">Y coordinate</param>
        /// <param name="Zcoord">z coordinate</param>
        public Vec(float Xcoord, float Ycoord, float Zcoord)
        {
            x = Xcoord;
            y = Ycoord;
            z = Zcoord;
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Construct the Laga Point through Unity Vector3
        /// </summary>
        /// <param name="vector"></param>
        public Vec(Vector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        /// <summary>
        /// Cast Laga Vector to Unity Vector
        /// </summary>
        /// <returns></returns>
        public Vector3 ToVector3()
        {
            return new Vector3(x, y, z);
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
        /// Draw a point
        /// </summary>
        /// <param name="point">The vector to display</param>
        /// <param name="width">The width of the point</param>
        /// <param name="color">The color to display</param>
        static public void DrawPoint(Vec point, float width, Color color)
        {
            GameObject line = new GameObject(point.ToString());
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"))
            {
                color = color
            };
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, new Vector3(point.x - width / 3.0f, point.y - width / 3.0f, point.z));
            lineRenderer.SetPosition(1, new Vector3(point.x + width / 3.0f, point.y + width / 3.0f, point.z));
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }

    }
}
