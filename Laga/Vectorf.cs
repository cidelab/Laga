using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laga
{
    internal struct Vectorf
    {
        //Geometry Vector properties X,Y,Z
        float X;
        float Y;
        float Z;

        /// <summary>
        /// Create a Vectorf
        /// </summary>
        /// <param name="X">X coordinate</param>
        /// <param name="Y">Y coordinate</param>
        /// <param name="Z">Z coordinate</param>
        public Vectorf(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public static Vectorf OrthogonalTo(Vectorf vector)
        {
            if (vector.Z == 0)
            {
                return new Vectorf(vector.Y * -1, vector.X, 0);
            }
            else
            {
                return Vectorf.CrossProduct(vector, new Vectorf(vector.Z * -1, vector.X, vector.Y));
            }
        }

        public static Vectorf CrossProduct(Vectorf vectorA, Vectorf vectorB)
        {
            float x = vectorA.Y * vectorB.Z - vectorA.Z * vectorB.Y;
            float y = vectorA.Z * vectorB.X - vectorA.X * vectorB.Z;
            float z = vectorA.X * vectorB.Y - vectorA.Y * vectorB.X;

            return new Vectorf(x, y, z);
        }

        /// <summary>
        /// Return the cross product length
        /// | B x BC | = |AB| * |BC| * Sin(theta)
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <param name="vectorC">Vector C</param>
        /// <returns>Z coordinate of the cross product</returns>
        public static double CrossProductLength(Vectorf vectorA, Vectorf vectorB, Vectorf vectorC)
        {
            double ABx = vectorA.X - vectorB.X;
            double ABy = vectorA.Y - vectorB.Y;
            double BCx = vectorC.X - vectorB.X;
            double BCy = vectorC.Y - vectorB.Y;

            return (ABx * BCy - ABy * BCx);
        }

        /// <summary>
        /// Project to vector base B
        /// </summary>
        /// <param name="vectorB">Vector base</param>
        /// <returns>Vector</returns>
        public Vectorf ComponentProjectTo(Vectorf vectorB)
        {
            Vectorf u = new Vectorf(vectorB.X, vectorB.Y, vectorB.Z);
            u.Normalize();
            float mp = DotProduct(this, u);
            return new Vectorf(u.X * mp, u.Y * mp, u.Z * mp);
        }

        /// <summary>
        /// Distance
        /// </summary>
        /// <param name="vector">vector to test</param>
        /// <returns>float</returns>
        public float DistanceTo(Vectorf vector)
        {
            return (float)Math.Sqrt(Math.Pow(this.X - vector.X, 2) + Math.Pow(this.Y - vector.Y, 2) + Math.Pow(this.Z - vector.Z, 2));
        }

        /// <summary>
        /// Normalize the vector to 1
        /// </summary>
        public void Normalize()
        {
            float m = this.DistanceTo(new Vectorf(0, 0, 0));
            _ = new Vectorf(this.X /= m, this.Y /= m, this.Z /= m);
        }

        /// <summary>
        /// Dot product
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>float</returns>
        public static float DotProduct(Vectorf vectorA, Vectorf vectorB)
        {
            return (vectorA.X * vectorB.X + vectorA.Y * vectorB.Y + vectorA.Z * vectorB.Z);
        }

        /// <summary>
        /// Angle
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>double</returns>
        public static float Angle(Vectorf vectorA, Vectorf vectorB)
        {
            float dot = DotProduct(vectorA, vectorB);
            Vectorf v = new Vectorf(0, 0, 0);
            float magA = vectorA.DistanceTo(v);
            float magB = vectorB.DistanceTo(v);
            float div = dot / (magA * magB);
            div = (div < -1.0f) ? -1.0f : (div > 1.0f) ? 1.0f : div;
            return (float)Math.Acos(div); // radianes.
        }

        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vectorf operator +(Vectorf vectorA, Vectorf vectorB)
        {
            float xc = vectorA.X + vectorB.X;
            float yc = vectorA.Y + vectorB.Y;
            float zc = vectorA.Z + vectorB.Z;
            return new Vectorf(xc, yc, zc);
        }

        /// <summary>
        /// Substraction
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vectorf operator -(Vectorf vectorA, Vectorf vectorB)
        {
            float xc = vectorA.X - vectorB.X;
            float yc = vectorA.Y - vectorB.Y;
            float zc = vectorA.Z - vectorB.Z;
            return new Vectorf(xc, yc, zc);
        }

        /// <summary>
        /// Scale multuplication
        /// </summary>
        /// <param name="vector">Vector to scale</param>
        /// <param name="factor">factor</param>
        /// <returns>Vector</returns>
        public static Vectorf operator *(Vectorf vector, float factor)
        {
            float xc = vector.X * factor;
            float yc = vector.Y * factor;
            float zc = vector.Z * factor;
            return new Vectorf(xc, yc, zc);
        }

        /// <summary>
        /// Print vector data
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "vec [" + X + ", " + Y + ", " + Z + "] ";
        }
    }
}
