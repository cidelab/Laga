using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laga
{
    /// <summary>
    /// Basic operations on bit string level.
    /// </summary>
    public class Bitwise
    {
        /// <summary>
        /// Convierte numero entero en un string secuencia de bytes.
        /// </summary>
        /// <param name="n">Numero entero para convertir</param>
        /// <returns>string</returns>
        public static string Int2Bytes(int n)
        {
            return Convert.ToString(n, 2); //convierte un entero en secuencia de bytes.
        }
    }
}
