using System;
using UnityEngine;
using Laga;

namespace LagaUnity
{
    /// <summary>
    /// Unity Point
    /// </summary>
    public class UPoint : Laga.Geometry.Vector
    {
        private float x;
        private float y;
        private float z;

        /// <summary>
        /// The X coordinate
        /// </summary>
        public float XCoord
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
        public float YCoord
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
        public float ZCoord
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
        public UPoint(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        /// <summary>
        /// Construct the Laga Point through Unity Vector3
        /// </summary>
        /// <param name="vector"></param>
        public UPoint(Vector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        /// <summary>
        /// Transform a Laga Point to Unity Vector
        /// </summary>
        /// <returns></returns>
        public Vector3 ToVector3()
        {
            return new Vector3(x, y, z);
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
        /// <returns>float</returns>
        public float DistanceTo(UPoint pointB)
        {
            double d = this.DistanceTo(pointB);
            return (float)d;
            //return (float)Math.Sqrt(Math.Pow((X - pointB.X), 2) + Math.Pow((Y - pointB.Y), 2) + Math.Pow((Z - pointB.Z), 2));
        }

        /// <summary>
        /// Draw a point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        static public void DrawPoint(UPoint point, float width, Color color)
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
        #region
        /*
        /// <summary>
        /// Normalize a Point
        /// </summary>
        /// <param name="vector">the Vector to normalize</param>
        /// <returns></returns>
        static public Point GetNormal(Point vector)
        {
            Point pt = new Point(0, 0, 0);
            float dist = pt.DistanceTo(vector);
            return new Point(vector.X /= dist, vector.Y /= dist, vector.Z /= dist);
        }

        static public float Dot(Point vec1, Point vec2 )
        {
            return (vec1.x * vec2.x + vec1.y * vec2.y + vec1.z * vec2.z);
        }

        static public float Angle(Point vec1, Point vec2)
        {
            Point ptO = new Point(0, 0, 0);
            float dotDivide = Dot(vec1, vec2) / (ptO.DistanceTo(vec1) * ptO.DistanceTo(vec2));
            return (float)Math.Acos(dotDivide);
        }

        static public Point Rotate(Point vector, float angle)
        {
            float xV = (float)(vector.x * Math.Cos(angle) - vector.y * Math.Sin(angle));
            float yV = (float)(vector.x * Math.Sin(angle) + vector.y * Math.Cos(angle));
            return new Point(xV, yV, 0);
        }
        static public Point CrossProduct(Point vec1, Point vec2)
        {
            float xMult = vec1.y * vec2.z - vec1.z * vec2.y;
            float yMult = vec1.z * vec2.x - vec1.x * vec2.z;
            float zMult = vec1.X * vec2.Y - vec1.y * vec2.x;
            return new Point(xMult, yMult, zMult);
        }
        */
        #endregion
    }
}
