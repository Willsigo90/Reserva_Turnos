using Dapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DataAccess
{
    public class AccesoDatosDataWrite : IAccesoDatosDataWrite
    {
        private readonly IConexionFactory ConexionFactory;

        private readonly IDapperWrapper DapperWrapper;

        private readonly ILogger<AccesoDatosDataWrite> _logger;

        public AccesoDatosDataWrite(IConexionFactory ConexionFactoryIn, IDapperWrapper dapperWrapper, ILogger<AccesoDatosDataWrite> logger)
        {
            ConexionFactory = ConexionFactoryIn;
            DapperWrapper = dapperWrapper;
            _logger = logger;
        }

        public IEnumerable<Turno> CreateTurnos(TurnoParameters filters)
        {
            try
            {
                _logger.LogInformation("Start invoking SP GenerarTurnos");
                using (var connection = ConexionFactory.CrearConexion(EnumConexion.Write))
                {
                    var turnosGenerados = connection.Query<Turno>("dbo.GenerarTurnos",
                        new
                        {
                            FechaInicio = filters.FechaInicio,
                            FechaFin = filters.FechaFin,
                            IdServicio = filters.IdServicio
                        },
                                        commandType: CommandType.StoredProcedure);
                    return turnosGenerados.ToList();
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while invoking SP GenerarTurnos: {ex.Message}");
                throw;
            }
            
        }

    }
}
