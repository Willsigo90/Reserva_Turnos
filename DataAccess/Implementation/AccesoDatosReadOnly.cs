using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class AccesoDatosReadOnly : IAccesoDatosReadOnly
    {

        private readonly IConexionFactory ConexionFactory;

        private readonly IDapperWrapper DapperWrapper;

        public AccesoDatosReadOnly(IConexionFactory conexionFactoryIn, IDapperWrapper dapperWrapper)
        {
            ConexionFactory = conexionFactoryIn;
            DapperWrapper = dapperWrapper;
        }

    }
}
