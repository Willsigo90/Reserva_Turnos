using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DataAccess
{
    public class ConexionFactory : IConexionFactory
    {
        private IDbConnection conexion;

        public IDbConnection CrearConexion(EnumConexion enumConexion)
        {
            string c = Directory.GetCurrentDirectory();
            IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            
            switch (enumConexion)
            {
                case EnumConexion.ReadOnly:
                    conexion = new SqlConnection(_configuration.GetConnectionString("DatabaseNameConnStringReadOnly"));
                    break;
                case EnumConexion.Write:
                    conexion = new SqlConnection(_configuration.GetConnectionString("DatabaseNameConnStringDataWrite"));
                    break;
                
                default:
                    throw new Exception("No existe la conexión");
            }

            return conexion;
        }
    }
}
