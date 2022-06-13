using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using UnityEngine;
using Laga.Geometry;

namespace LagaUnity
{
    /// <summary>
    /// Basic class for drawing geometry
    /// </summary>
    public static class Draw
    {
        /*
        /// <summary>
        /// Draw a Vector
        /// </summary>
        /// <param name="point">The vector to display</param>
        /// <param name="width">The width of the point</param>
        /// <param name="color">The color to display</param>
        static public LineRenderer Point(Vectorf point, float width, Color color)
        {
            GameObject line = new GameObject(point.ToString());
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"))
            {
                color = color
            };
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, new Vector3(point.X - width / 3.0f, point.Y - width / 3.0f, point.Z));
            lineRenderer.SetPosition(1, new Vector3(point.X + width / 3.0f, point.Y + width / 3.0f, point.Z));
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;

            return lineRenderer;
        }

        /// <summary>
        /// Draw a Line
        /// </summary>
        /// <param name="pointA">First point</param>
        /// <param name="pointB">Second Point</param>
        /// <param name="width">Line Width</param>
        /// <param name="color">Color Line</param>
        static public LineRenderer Line(Vectorf pointA, Vectorf pointB, float width, Color color)
        {
            GameObject line = new GameObject("Line " + pointA.ToString() + " - " + pointB.ToString());
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"))
            {
                color = color
            };
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, Draw.ToVector3(pointA));
            lineRenderer.SetPosition(1, Draw.ToVector3(pointB));
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;

            return lineRenderer;
        }

        private static Vector3 ToVector3(Vectorf vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }
         */
    }

}
