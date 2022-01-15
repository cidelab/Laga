using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LagaUnity
{
    /// <summary>
    /// Polygon class
    /// </summary>
    public class Polygon : ICollection<Vectorf>
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
        /// <param name="vector">The Vector to add in the list</param>
        public void Add(Vectorf vector)
        {
            lstVectorPolygon.Add(vector);
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
        /// <param name="vector"></param>
        /// <returns>True if the vector belongs to the polygon</returns>
        public bool Contains(Vectorf vector)
        {
            return lstVectorPolygon.Contains(vector);
        }

        /// <summary>
        /// Copy the vectors of the polygon to a new array.
        /// </summary>
        /// <param name="array">The array to copy</param>
        /// <param name="arrayIndex">Index to start the array</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void CopyTo(Vectorf[] array, int arrayIndex)
        {
            if(array == null)
            throw new ArgumentNullException("array");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("not enough elements after index in the destination array");
            
            lstVectorPolygon.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Enumerator can be used to read the data in the collection, but cannot be used to modify the collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Vectorf> GetEnumerator()
        {
            return (IEnumerator<Vectorf>)GetEnumerator();
        }

        /// <summary>
        /// Remove a vector from the polygon
        /// </summary>
        /// <param name="vector">the Vector to remove</param>
        /// <returns>true if all went ok</returns>
        public bool Remove(Vectorf vector)
        {
            return lstVectorPolygon.Remove(vector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        private LineRenderer lineRenderer;
        private GameObject line;
        private List<Vectorf> lstVectorPolygon;

        /// <summary>
        /// Polygon constructor by a list / array of vectors
        /// </summary>
        /// <param name="VectorList">the list of vectors</param>
        public Polygon(IEnumerable<Vectorf> VectorList)
        {
            lstVectorPolygon = VectorList.ToList<Vectorf>();
            line = new GameObject("Polygon :" + lstVectorPolygon[0].ToString());
            lineRenderer = line.AddComponent<LineRenderer>();
        }

        /// <summary>
        /// get the list of vectors in the polygon
        /// </summary>
        public List<Vectorf> VectorList
        {
            get { return lstVectorPolygon; }
        }



        /// <summary>
        /// Update the polygon drawing
        /// </summary>
        public void UpdateDraw()
        {
            for (int i = 0; i < lstVectorPolygon.Count; i++)
                lineRenderer.SetPosition(i, new Vector3(lstVectorPolygon[i].X, lstVectorPolygon[i].Y, lstVectorPolygon[i].Z));
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
            float width;
            for (int i = 0; i < size; i++)
            {
                width = lstVectorPolygon[i + 1].X - lstVectorPolygon[i].X;
                area += width * (lstVectorPolygon[i + 1].Y + lstVectorPolygon[i].Y) / 2f;
            }
            lstVectorPolygon.RemoveAt(size);

            return Math.Abs(area);
        }

        /// <summary>
        /// Get the length of Polygon
        /// </summary>
        /// <returns>the length</returns>
        public float Length()
        {
            float len = 0.0f;
            if (lstVectorPolygon.Count < 2) 
            { 
                return len; 
            }
            else
            {
                for (int i = 0; i < lstVectorPolygon.Count - 1; i++)
                {
                    len += lstVectorPolygon[i].DistanceTo(lstVectorPolygon[i + 1]);
                }
                len += lstVectorPolygon[Count - 1].DistanceTo(lstVectorPolygon[0]);
                return len;
            }
        }

        /// <summary>
        /// Average center point
        /// </summary>
        /// <returns>Vectorf</returns>
        public Vectorf Center()
        {
            float x = 0;
            float y = 0;
            float z = 0;
            float l = Count;
            foreach(Vectorf v in lstVectorPolygon)
            {
                x += v.X;
                y += v.Y;
                z += v.Z;
            }

            return new Vectorf(x / l, y / l, z / l);
        }

        /// <summary>
        /// Check if polygon is convex
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool IsConvex()
        {
            List<Vectorf> lstPts = lstVectorPolygon;

            int size = lstPts.Count;
            if (size < 3)
                throw new Exception("You need at least 3 vertices");

            lstPts.Add(lstPts[0]);
            lstPts.Add(lstPts[1]);

            int sign = Math.Sign(Vectorf.Angle(lstPts[0], lstPts[1], lstPts[2]));
            bool isConvex = true;

            for(int i = 0; i < size; i++)
            {
                if(Math.Sign(Vectorf.Angle(lstPts[i], lstPts[i + 1], lstPts[ i + 2])) != sign)
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
        public Line SegmentAt(int index)
        {
            if (index < 0) { return null; }
            if (index >= Count - 1) { return null; }

            return new Line(lstVectorPolygon[index], lstVectorPolygon[index + 1]);
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
