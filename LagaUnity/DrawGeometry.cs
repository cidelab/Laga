using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LagaUnity
{
    /// <summary>
    /// Basic class for drawing geometry
    /// </summary>
    public class DrawGeometry
    {

        private LineRenderer lnRender;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LineRender"></param>
        public DrawGeometry(LineRenderer LineRender)
        {
            this.lnRender = LineRender;
        }
        /// <summary>
        /// Draw a point
        /// </summary>
        /// <param name="point">The vector to display</param>
        /// <param name="width">The width of the point</param>
        /// <param name="color">The color to display</param>
        static public void DrawPoint(Vectorf point, float width, Color color)
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
        }
    }
}
