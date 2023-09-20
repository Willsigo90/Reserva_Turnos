using BusinessLayer.Interface;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Reserva_Turnos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Turnos.ApiTest
{
    [TestFixture]
    public class TurnosControllerTests
    {
        private TurnosController _controller;
        private Mock<ITurnoService> _mockTurnoService;
        private Mock<ILogger<TurnosController>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockTurnoService = new Mock<ITurnoService>();
            _mockLogger = new Mock<ILogger<TurnosController>>();
            _controller = new TurnosController(_mockTurnoService.Object, _mockLogger.Object);
        }

        [Test]
        public void CrearTurno_ValidTurnoRequest_ReturnsOkResult()
        {
            // Arrange
            var turnoRequest = new TurnoRequest
            {
                FechaInicio = "01/01/2023",
                FechaFin = "02/01/2023",
                IdServicio = 1
            };

            var mockTurnos = new List<TurnoDto>(); // Simular una lista de turnos creados

            _mockTurnoService.Setup(x => x.CreateTurnos(turnoRequest)).Returns(mockTurnos);

            // Act
            var result = _controller.CrearTurno(turnoRequest);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void CrearTurno_ExceptionOccurs_ReturnsBadRequestResultWithErrorMessage()
        {
            // Arrange
            var turnoRequest = new TurnoRequest
            {
                FechaInicio = "01/01/2023",
                FechaFin = "02/01/2023",
                IdServicio = 1
            };

            var exceptionMessage = "An error occurred while creating Turns";
            _mockTurnoService.Setup(x => x.CreateTurnos(turnoRequest)).Throws(new Exception(exceptionMessage));

            // Act
            var result = _controller.CrearTurno(turnoRequest);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.AreEqual(exceptionMessage, badRequestResult.Value);
        }
    }
}
