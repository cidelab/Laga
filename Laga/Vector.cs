using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laga.Geometry
{
    /// <summary>
    /// Clase Vector
    /// </summary>
    public class Vector
    {
        //Propiedades del vector, coordenadas X,Y,Z
        private double x;
        private double y;
        private double z;

        /// <summary>
        /// Coordenada X Nuevo
        /// </summary> 
        public double X
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
        /// Coordenada Y Nuevo
        /// </summary>
        public double Y
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
        /// Coordenada Z Nuevo
        /// </summary>
        public double Z
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
        /// Crea vector 2D
        /// </summary>
        /// <param name="X">Coordenada X</param>
        /// <param name="Y">Coordenada Y</param>
        public Vector(double X, double Y)
        {
            x = X;
            y = Y;
            z = 0;
        }

        /// <summary>
        /// Crea Vector 3D
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public Vector(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }


        /// <summary>
        /// Nuevo
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector OrthogonalTo(Vector vector)
        {
            if (vector.z == 0)
            {
                return new Vector(vector.y * -1, vector.x);
            }
            else
            {
                return Vector.CrossProduct(vector, new Vector(vector.z * -1, vector.x, vector.y));
            }
        }

        /// <summary>
        /// Cross Product entre vectores, retorna un vector perpendicular a los 2 vectores
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vector CrossProduct(Vector vectorA, Vector vectorB)
        {
            double x = vectorA.y * vectorB.z - vectorA.z * vectorB.y;
            double y = vectorA.z * vectorB.x - vectorA.x * vectorB.z;
            double z = vectorA.x * vectorB.y - vectorA.y * vectorB.x;

            return new Vector(x, y, z);
        }

        /// <summary>
        /// Proyecta el vector sobre el vector base B
        /// </summary>
        /// <param name="vectorB">Vector base</param>
        /// <returns>Vector</returns>
        public Vector ComponentProjectTo(Vector vectorB)
        {
            Vector u = new Vector(vectorB.x, vectorB.y, vectorB.z);
            u.Normalize();
            double mp = DotProduct(this, u);
            return new Vector(u.x * mp, u.y * mp, u.z * mp);
        }

        /// <summary>
        /// Crea el componente ortogonal al vector base B
        /// </summary>
        /// <param name="vectorB">Vector base</param>
        /// <returns>Vector</returns>
        public Vector ComponentOrthogonalTo(Vector vectorB)
        {
            Vector cpt = ComponentProjectTo(vectorB);
            return this - cpt;
        }

        /// <summary>
        /// Comprueba si es vector cero
        /// </summary>
        /// <param name="tolerance">Tolerancia en el calculo valor: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsVectorCero(double tolerance = 1e-3)
        {
            return DistanceTo(new Vector(0, 0, 0)) < tolerance;
        }

        /// <summary>
        /// Comprueba si el vector es ortogonal
        /// </summary>
        /// <param name="vector">El vector a comparar</param>
        /// <param name="tolerance">Tolerancia en el calculo valor: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsOrthogonalTo(Vector vector, double tolerance = 1e-3)
        {
            return (Math.Abs(DotProduct(this, vector)) < tolerance);
        }

        /// <summary>
        /// Comprueba si el vector es paralelo
        /// </summary>
        /// <param name="vector">El vector a comparar</param>
        /// <param name="tolerance">Tolerancia en el calculo valor: 1e-3</param>
        /// <returns>bool</returns>
        public bool IsParallelTo(Vector vector, double tolerance = 1e-3)
        {
            double a = Angle(this, vector);
            double b = Math.Abs(a - Math.PI);

            return (this.IsVectorCero() || vector.IsVectorCero() || a < tolerance || b < tolerance);

        }

        /// <summary>
        /// Calcula el dot product entre 2 vectores
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns></returns>
        public static double DotProduct(Vector vectorA, Vector vectorB)
        {
            return (vectorA.x * vectorB.x + vectorA.y * vectorB.y + vectorA.z * vectorB.z);
        }

        /// <summary>
        /// Calcula el angulo entre 2 vectores
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>double</returns>
        public static double Angle(Vector vectorA, Vector vectorB)
        {
            double dot = DotProduct(vectorA, vectorB);
            Vector v = new Vector(0, 0, 0);
            double magA = vectorA.DistanceTo(v);
            double magB = vectorB.DistanceTo(v);
            double div = dot / (magA * magB);
            div = (div < -1.0) ? -1.0 : (div > 1.0) ? 1.0 : div;
            return Math.Acos(div); // radianes.
        }

        /// <summary>
        /// Distancia entre vectores
        /// </summary>
        /// <param name="vector">vector a calcular la distancia</param>
        /// <returns>double</returns>
        public double DistanceTo(Vector vector)
        {
            double dist;
            dist = Math.Sqrt(Math.Pow(this.x - vector.x, 2) + Math.Pow(this.y - vector.y, 2) + Math.Pow(this.z - vector.z, 2));
            return dist;
        }

        /// <summary>
        /// Normaliza el vector
        /// </summary>
        public void Normalize()
        {
            double m = this.DistanceTo(new Vector(0, 0, 0));
            _ = new Vector(this.x /= m, this.y /= m, this.z /= m);
        }

        /// <summary>
        /// Suma de vectores
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vector operator +(Vector vectorA, Vector vectorB)
        {
            double xc = vectorA.x + vectorB.x;
            double yc = vectorA.y + vectorB.y;
            double zc = vectorA.z + vectorB.z;
            return new Vector(xc, yc, zc);
        }

        /// <summary>
        /// Resta de vectores
        /// </summary>
        /// <param name="vectorA">Vector A</param>
        /// <param name="vectorB">Vector B</param>
        /// <returns>Vector</returns>
        public static Vector operator -(Vector vectorA, Vector vectorB)
        {
            double xc = vectorA.x - vectorB.x;
            double yc = vectorA.y - vectorB.y;
            double zc = vectorA.z - vectorB.z;
            return new Vector(xc, yc, zc);
        }

        /// <summary>
        /// Multuplicacion escalar
        /// </summary>
        /// <param name="vector">Vector a escalar</param>
        /// <param name="scale">escala</param>
        /// <returns>Vector</returns>
        public static Vector operator *(Vector vector, double scale)
        {
            double xc = vector.x * scale;
            double yc = vector.y * scale;
            double zc = vector.z * scale;
            return new Vector(xc, yc, zc);
        }

        /// <summary>
        /// Sobre escribe ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "vec [" + x + ", " + y + ", " + z + "] ";
        }

        /// <summary>
        /// Compara dos vectores si son iguales
        /// </summary>
        /// <param name="vector">vector a comparar</param>
        /// <returns>bool</returns>
        public bool EqualTo(Vector vector)
        {
            return this.x == vector.x && this.y == vector.y && this.z == vector.z;
        }
    }
}
