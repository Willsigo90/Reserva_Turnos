using System;
using System.Collections.Generic;
using System.Globalization;
using BusinessLayer.Implementation;
using BusinessLayer.Interface;
using DataAccess;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

[TestFixture]
public class TurnoServiceTests
{
    private TurnoService _turnoService;
    private Mock<ITurnoRepository> _mockTurnoRepository;
    private Mock<ILogger<TurnoService>> _mockLogger;

    [SetUp]
    public void Setup()
    {
        _mockTurnoRepository = new Mock<ITurnoRepository>();
        _mockLogger = new Mock<ILogger<TurnoService>>();

        _turnoService = new TurnoService(_mockTurnoRepository.Object, _mockLogger.Object);
    }

    [Test]
    public void CreateTurnos_ValidRequest_ReturnsListOfTurnoDto()
    {
        // Arrange
        var filters = new TurnoRequest
        {
            FechaInicio = "01/01/2023",
            FechaFin = "02/01/2023",
            IdServicio = 1
        };

        var fakeTurnos = new List<Turno>
        {
            new Turno
            {
                FechaTurno = "01/01/2023",
                HoraInicio = "08:00:00",
                HoraFin = "09:00:00",
                NomServicio = "Servicio1",
                NomComercio = "Comercio1"
            }
        };

        _mockTurnoRepository.Setup(r => r.CreateTurnos(It.IsAny<TurnoParameters>())).Returns(fakeTurnos);

        // Act
        var result = _turnoService.CreateTurnos(filters);

        // Assert
        Assert.IsInstanceOf<IEnumerable<TurnoDto>>(result);
        Assert.AreEqual(1, result.Count());
    }

}
