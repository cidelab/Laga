using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LagaUnity
{
    public class Line
    {
        private Point pa;
        private Point pb;

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        public Line(Point pointA, Point pointB)
        {
            pa = pointA;
            pb = pointB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point MidPoint()
        {
            return new Point((pa.X + pb.X) / 2, (pa.Y + pb.Y) / 2, (pa.Z + pa.Z) / 2);
        }

        /// <summary>
        ///  Line point coordinates
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "Line_" + PointA.ToString() + " - " + PointB.ToString(); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="color"></param>
        public void Draw(float width, Color color)
        {
            DrawLine(pa, pb, width, color);
        }

        /// <summary>
        /// Draw a line
        /// </summary>
        /// <param name="pointA">The first point</param>
        /// <param name="pointB"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
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
    }
}
