using System;
using BusinessLayer;
using DataAccess;
using FluentValidation.TestHelper;
using NUnit.Framework;

[TestFixture]
public class TurnoRequestValidatorTests
{
    private TurnoRequestValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new TurnoRequestValidator();
    }

    [Test]
    public void FechaInicio_Empty_ShouldHaveValidationError()
    {
        var model = new TurnoRequest { FechaInicio = "", FechaFin = "01/01/2023", IdServicio = 1 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(request => request.FechaInicio)
              .WithErrorMessage("La fecha de inicio es obligatoria.");
    }

    [Test]
    public void FechaInicio_InvalidFormat_ShouldHaveValidationError()
    {
        var model = new TurnoRequest { FechaInicio = "01-01-2023", FechaFin = "01/01/2023", IdServicio = 1 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(request => request.FechaInicio)
              .WithErrorMessage("La Fecha de Inicio debe tener el formato dd/mm/yyyy.");
    }

    [Test]
    public void FechaFin_Empty_ShouldHaveValidationError()
    {
        var model = new TurnoRequest { FechaInicio = "01/01/2023", FechaFin = "", IdServicio = 1 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(request => request.FechaFin)
              .WithErrorMessage("La fecha de fin es obligatoria.");
    }

    [Test]
    public void FechaFin_InvalidFormat_ShouldHaveValidationError()
    {
        var model = new TurnoRequest { FechaInicio = "01/01/2023", FechaFin = "01-01-2023", IdServicio = 1 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(request => request.FechaFin)
              .WithErrorMessage("La Fecha de Fin debe tener el formato dd/mm/yyyy.");
    }

    [Test]
    public void FechaFin_LessThanFechaInicio_ShouldHaveValidationError()
    {
        var model = new TurnoRequest { FechaInicio = "01/01/2023", FechaFin = "01/01/2022", IdServicio = 1 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(request => request.FechaFin)
              .WithErrorMessage("La Fecha de Fin debe ser posterior a la Fecha de Inicio.");
    }

    [Test]
    public void IdServicio_Empty_ShouldHaveValidationError()
    {
        var model = new TurnoRequest { FechaInicio = "01/01/2023", FechaFin = "02/01/2023", IdServicio = 0 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(request => request.IdServicio)
              .WithErrorMessage("El ID de servicio es obligatorio.");
    }

    [Test]
    public void IdServicio_LessThan1_ShouldHaveValidationError()
    {
        var model = new TurnoRequest { FechaInicio = "01/01/2023", FechaFin = "02/01/2023", IdServicio = -1 };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(request => request.IdServicio)
              .WithErrorMessage("El ID de servicio debe ser mayor que cero.");
    }
}
