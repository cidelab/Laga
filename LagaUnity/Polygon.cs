using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LagaUnity
{
    public class Polygon : ICollection<Point>
    {

        #region implements
        public int Count => lstPts.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Point point)
        {
            lstPts.Add(point);
        }

        public void Clear()
        {
            lstPts.Clear();
        }

        public bool Contains(Point point)
        {
            return lstPts.Contains(point);
        }

        public void CopyTo(Point[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Point> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Point point)
        {
            return lstPts.Remove(point);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion

        List<Point> lstPts;
        public Polygon(List<Point> ListPoints)
        {
            lstPts = ListPoints;
        }

        public void DrawPolygon(float width, Color color, bool loop)
        {

            GameObject line = new GameObject("Polygon " + lstPts[0].ToString());
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
            lineRenderer.material.color = color;
            lineRenderer.positionCount = lstPts.Count;
            lineRenderer.loop = loop;

            for(int i =0; i < lstPts.Count; i++)
                lineRenderer.SetPosition(i, new Vector3(lstPts[i].X, lstPts[i].Y, lstPts[i].Z));
            
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;

        }

        public float Length
        {
            get
            {
                if (lstPts.Count < 2) { return 0.0f; }

                float L = 0.0f;

                for (int i = 0; i < (lstPts.Count - 1); i++)
                {
                    L += lstPts[i].DistanceTo(lstPts[i + 1]);
                }

                return L;
            }
        }

        public Line SegmentAt(int index)
        {
            if (index < 0) { return null; }
            if (index >= Count - 1) { return null; }

            return new Line(lstPts[index], lstPts[index + 1]);
        }

        public Polygon SortPolygonPoints()
        {
           return new Polygon(lstPts.OrderBy(p => p.X).ThenBy(p => p.Y).ToList());
        }
    }
}
