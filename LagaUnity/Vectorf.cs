using System;
//using UnityEngine;

namespace LagaUnity
{
    /*
    /// <summary>
    /// Vector struct
    /// </summary>
    public struct Vectorf
    {
        //Geometry Vector properties X,Y,Z
        /// <summary>
        /// X coordinate
        /// </summary>
        public float X;
        /// <summary>
        /// Y coordinate
        /// </summary>
        public float Y;
        /// <summary>
        /// Z coordinate
        /// </summary>
        public float Z;

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

        /// <summary>
        /// Cast Vectorf to Vector3
        /// </summary>
        /// <returns></returns>
        public Vector3 ToVector3
        {
            get { return new Vector3(X, Y, Z); }
        }

        /// <summary>
        /// Creates a orthogonal vector
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <returns>Vector</returns>
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

        /// <summary>
        /// Vector CrossProduct operation
        /// </summary>
        /// <param name="vectorA">vector A</param>
        /// <param name="vectorB">vector B</param>
        /// <returns>The vector</returns>
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
        public static float CrossProductLength(Vectorf vectorA, Vectorf vectorB, Vectorf vectorC)
        {
            float ABx = vectorA.X - vectorB.X;
            float ABy = vectorA.Y - vectorB.Y;
            float BCx = vectorC.X - vectorB.X;
            float BCy = vectorC.Y - vectorB.Y;

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
        /// Dot Product AB · BC
        /// </summary>
        /// <param name="vectorA"></param>
        /// <param name="vectorB"></param>
        /// <param name="vectorC"></param>
        /// <returns></returns>
        public static float DotProduct(Vectorf vectorA, Vectorf vectorB, Vectorf vectorC)
        {
            float ABx = vectorA.X - vectorB.X;
            float ABy = vectorA.Y - vectorB.Y;
            float BCx = vectorC.X - vectorB.Y;
            float BCy = vectorC.Y - vectorB.Y;

            return (ABx * BCx + ABy * BCy);
        }

        /// <summary>
        /// Angle
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>float</returns>
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
        /// ABC angle between PI and -PI
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <param name="vectorC">Vector C</param>
        /// <returns>double</returns>
        public static float Angle(Vectorf vectorA, Vectorf vectorB, Vectorf vectorC)
        {
            //dot
            float dot = DotProduct(vectorA, vectorB, vectorC);

            //crossLength 
            float crossPL = CrossProductLength(vectorA, vectorB, vectorC);

            //angle
            return (float)Math.Atan2(crossPL, dot);
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
            return "vecf [" + X + ", " + Y + ", " + Z + "] ";
        }
    }
    */
}
