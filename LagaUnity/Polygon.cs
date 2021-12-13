using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Laga.Geometry;

namespace LagaUnity
{
    /// <summary>
    /// Polygon class
    /// </summary>
    public class Polygon : ICollection<Vec>
    {
        #region
        /// <summary>
        /// Polygon lenght
        /// </summary>
        public int Count => lstVectorPolygon.Count;

        /// <summary>
        /// IsReadOnly boolean
        /// </summary>
        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Add a Vector to the poylgon
        /// </summary>
        /// <param name="vec">The Vector to add in the list</param>
        public void Add(Vec vec)
        {
            lstVectorPolygon.Add(vec);
        }

        /// <summary>
        /// Clear all data in the polygon
        /// </summary>
        public void Clear()
        {
            lstVectorPolygon.Clear();
        }

        /// <summary>
        /// Check if the vec is in the polygon
        /// </summary>
        /// <param name="vec"></param>
        /// <returns>True if the vector belongs to the polygon</returns>
        public bool Contains(Vec vec)
        {
            return lstVectorPolygon.Contains(vec);
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void CopyTo(Vec[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented yet.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerator<Vec> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove a vec from the polygon
        /// </summary>
        /// <param name="vec">the Vector to remove</param>
        /// <returns>true if all went ok</returns>
        public bool Remove(Vec vec)
        {
            return lstVectorPolygon.Remove(vec);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        private LineRenderer lineRenderer;
        private GameObject line;
        private List<Vec> lstVectorPolygon;

        /// <summary>
        /// Polygon constructor by a list / array of vectors
        /// </summary>
        /// <param name="VectorList">the list of vectors</param>
        public Polygon(IEnumerable<Vec> VectorList)
        {
            lstVectorPolygon = VectorList.ToList<Vec>();
            line = new GameObject("Polygon :" + lstVectorPolygon[0].ToString());
            lineRenderer = line.AddComponent<LineRenderer>();
        }

        /// <summary>
        /// get the list of vectors in the polygon
        /// </summary>
        public List<Vec> VectorList
        {
            get { return lstVectorPolygon; }
        }

        /// <summary>
        /// Draw all the segments in the polygon
        /// </summary>
        /// <param name="width">The width of the segment</param>
        /// <param name="color">The Color</param>
        /// <param name="loop">True if closed, false is not</param>
        public void DrawPolygon(float width, Color color, bool loop)
        {
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"))
            {
                color = color
            };
            lineRenderer.numCornerVertices = 5;
            lineRenderer.numCapVertices = 5;
            lineRenderer.positionCount = lstVectorPolygon.Count;
            lineRenderer.loop = loop;

            for(int i = 0; i < lstVectorPolygon.Count; i++)
                lineRenderer.SetPosition(i, new Vector3((float)lstVectorPolygon[i].X, (float)lstVectorPolygon[i].Y, (float)lstVectorPolygon[i].Z));
            
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }

        /// <summary>
        /// Update the polygon drawing
        /// </summary>
        public void UpdateDraw()
        {
            for (int i = 0; i < lstVectorPolygon.Count; i++)
                lineRenderer.SetPosition(i, new Vector3((float)lstVectorPolygon[i].X, (float)lstVectorPolygon[i].Y, (float)lstVectorPolygon[i].Z));
        }

        /// <summary>
        /// Calculate the area of the polygon
        /// </summary>
        /// <returns>the area in float flavor</returns>
        /// <exception cref="Exception"></exception>
        public float Area()
        {
            int size = lstVectorPolygon.Count;
            if (size < 3)
            { throw new Exception("you need more vertices"); }

            lstVectorPolygon.Add(lstVectorPolygon[0]);
            float area = 0;
            for (int i = 0; i < size; i++)
            {
                float width = (float)(lstVectorPolygon[i + 1].X - lstVectorPolygon[i].X);
                area += width * (float)(lstVectorPolygon[i + 1].Y + lstVectorPolygon[i].Y);
            }
            lstVectorPolygon.RemoveAt(size);

            return Math.Abs(area);
        }

        /// <summary>
        /// The length of the polygon
        /// </summary>
        public float Length
        {
            get
            {
                if (lstVectorPolygon.Count < 2) { return 0.0f; }

                float L = 0.0f;

                for (int i = 0; i < (lstVectorPolygon.Count - 1); i++)
                {
                    L += (float)lstVectorPolygon[i].DistanceTo(lstVectorPolygon[i + 1]);
                }

                return L;
            }
        }

        /// <summary>
        /// Centroid
        /// </summary>
        /// <returns></returns>
        public Vec Centroid()
        {
            float x = 0;
            float y = 0;
            float z = 0;

            foreach (var item in lstVectorPolygon)
            {
                x += (float)item.X;
                y += (float)item.Y;
                z += (float)item.Z;
            }

            return new Vec(x / Length, y / Length, z / Length);
        }

        /// <summary>
        /// Check if the polygon is Convex
        /// </summary>
        /// <param name="vecs">The points in the polygon</param>
        /// <returns>true if convex</returns>
        /// <exception cref="Exception"></exception>
        public static bool IsConvex(IEnumerable<Vec> vecs)
        {
            List<Vec> lstPts = vecs.ToList();

            int size = lstPts.Count;
            if (size < 3)
                throw new Exception("You need at least 3 vertices");

            lstPts.Add(lstPts[0]);
            lstPts.Add(lstPts[1]);

            int sign = Math.Sign(Vector3d.Angle(lstPts[0], lstPts[1], lstPts[2]));
            bool isConvex = true;

            for(int i = 0; i < size; i++)
            {
                if(Math.Sign(Vector3d.Angle(lstPts[i], lstPts[i + 1], lstPts[ i + 2])) != sign)
                {
                    isConvex = false;
                    break;
                }    
            }

            return isConvex;
        }

        /// <summary>
        /// Draw a specific segment in the polygon
        /// </summary>
        /// <param name="index">the segment index in the polygon, if out of range is null</param>
        /// <returns>The segment as Line</returns>
        public Lne SegmentAt(int index)
        {
            if (index < 0) { return null; }
            if (index >= Count - 1) { return null; }

            return new Lne(lstVectorPolygon[index], lstVectorPolygon[index + 1]);
        }

        /// <summary>
        /// Sort the points in the polygon
        /// </summary>
        /// <returns>Sorted list of vectors in the polygon by X, then Y</returns>
        public Polygon SortPolygonPoints()
        {
           return new Polygon(lstVectorPolygon.OrderBy(p => p.X).ThenBy(p => p.Y).ToList());
        }
        
       

    }
}
