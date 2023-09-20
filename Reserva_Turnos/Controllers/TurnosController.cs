using BusinessLayer.Interface;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Reserva_Turnos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurnosController : Controller
    {
        private readonly ITurnoService _turnoService;
        private readonly ILogger<TurnosController> _logger;
        public TurnosController(ITurnoService turnoService, ILogger<TurnosController> logger)
        {
            _turnoService = turnoService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CrearTurno([FromBody] TurnoRequest turnoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _logger.LogInformation("Start creating Turns");
                var turnos = _turnoService.CreateTurnos(turnoRequest);
                
                return Ok(turnos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating Turns");
                return BadRequest(ex.Message);
            }
        }

    }
}
