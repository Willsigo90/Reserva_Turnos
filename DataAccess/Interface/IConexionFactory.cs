using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public interface IConexionFactory
    {
        IDbConnection CrearConexion(EnumConexion enumConexion);
    }
}
