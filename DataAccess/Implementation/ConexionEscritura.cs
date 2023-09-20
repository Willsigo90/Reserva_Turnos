using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess
{
    public class ConexionEscritura : IConexion
    {

        /// <summary>
        /// OBTIENE CONEXION BBDD
        /// </summary>
        /// <returns>CADENA DE CONEXION</returns>
        public string ObtenerConexion()
        {
            string c = Directory.GetCurrentDirectory();
            IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            return _configuration.GetConnectionString("DatabaseNameConnStringDataWrite");
        }
    }
}
