using System.Collections.Generic;
using System.Linq;

namespace Laga.Geometry
{
    /// <summary>
    /// SimpleConvexhull 2D
    /// </summary>
    public class ConvexHull
    {
        /// <summary>
        /// A simple ConvexHull2D 
        /// </summary>
        /// <param name="vectors">A list of vectors</param>
        /// <returns>list of vectors</returns>
        public static List<Vector> ConvexHull2D(List<Vector> vectors)
        {
            if (vectors == null)
                return null;

            if (vectors.Count() <= 1)
                return vectors;

            int n = vectors.Count(), k = 0;
            List<Vector> H = new List<Vector>(new Vector[2 * n]);

            vectors.Sort((a, b) =>
                 a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));

            // Build lower hull
            for (int i = 0; i < n; ++i)
            {
                while (k >= 2 && Vector.CrossProductLength(H[k - 2], H[k - 1], vectors[i]) <= 0)
                    k--;
                H[k++] = vectors[i];
            }

            // Build upper hull
            for (int i = n - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && Vector.CrossProductLength(H[k - 2], H[k - 1], vectors[i]) <= 0)
                    k--;
                H[k++] = vectors[i];
            }

            return H.Take(k - 1).ToList();
        }
    }
}
