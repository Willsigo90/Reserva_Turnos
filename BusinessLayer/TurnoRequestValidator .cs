using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using FluentValidation;

namespace BusinessLayer
{
    public class TurnoRequestValidator : AbstractValidator<TurnoRequest>
    {
        public TurnoRequestValidator()
        {
            RuleFor(request => request.FechaInicio)
                .NotEmpty().WithMessage("La fecha de inicio es obligatoria.")
                .Must(BeValidDate).WithMessage("La Fecha de Inicio debe tener el formato dd/mm/yyyy.");
            //.LessThanOrEqualTo(request => request.FechaFin).WithMessage("La fecha de inicio debe ser menor o igual a la fecha de fin.");

            RuleFor(request => request.FechaFin)
                .NotEmpty().WithMessage("La fecha de fin es obligatoria.")
                .Must(BeValidDate).WithMessage("La Fecha de Fin debe tener el formato dd/mm/yyyy.")
                .GreaterThanOrEqualTo(request => request.FechaInicio).WithMessage("La Fecha de Fin debe ser posterior a la Fecha de Inicio.");

            RuleFor(request => request.IdServicio)
                .NotEmpty().WithMessage("El ID de servicio es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de servicio debe ser mayor que cero.");
        }

        private bool BeValidDate(string fecha)
        {
            if (string.IsNullOrWhiteSpace(fecha))
            {
                return false;
            }

            // Intenta analizar la fecha en el formato dd/mm/yyyy
            if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return true;
            }

            return false;
        }


    }
}