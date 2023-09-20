using BusinessLayer.Interface;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Implementation
{
    public class TurnoService : ITurnoService
    {
        readonly ITurnoRepository turnosRepositorio;
        private readonly ILogger<TurnoService> _logger;

        public TurnoService(ITurnoRepository turnosRepositoriy, ILogger<TurnoService> logger)
        {
            turnosRepositorio = turnosRepositoriy;
            _logger = logger;
        }

        public IEnumerable<TurnoDto> CreateTurnos(TurnoRequest filters)
        {
            try
            {
                var parameters = new TurnoParameters();

                DateTime fechaInicio;
                DateTime.TryParseExact(filters.FechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicio);

                DateTime fechaFin;
                DateTime.TryParseExact(filters.FechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFin);

                parameters.FechaInicio = fechaInicio;
                parameters.FechaFin = fechaFin;
                parameters.IdServicio = filters.IdServicio;

                var listaTurno = turnosRepositorio.CreateTurnos(parameters);
                _logger.LogInformation($"Turns created");
                //var turnoDto = new List<TurnoDto>();

                List<TurnoDto> listaTurnoDto = new List<TurnoDto>();

                foreach (var turno in listaTurno)
                {
                    // Realiza la conversión de cada elemento
                    var turnoDto = new TurnoDto
                    {
                        FechaTurno = DateTime.Parse(turno.FechaTurno), // Convierte la fecha a DateTime
                        HoraInicio = TimeSpan.Parse(turno.HoraInicio), // Convierte la hora a TimeSpan
                        HoraFin = TimeSpan.Parse(turno.HoraFin), // Convierte la hora a TimeSpan
                        NombreServicio = turno.NomServicio,
                        NombreComercio = turno.NomComercio
                    };

                    listaTurnoDto.Add(turnoDto);
                }

                return listaTurnoDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating Turns (Service): {ex.Message}");
                throw; // Re-throw the exception to propagate it to the caller
            }
            


        }
    }
}
