
//using Incapacidades.Core.QueryFilters;

using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ITurnoRepository
    {
        IEnumerable<Turno> CreateTurnos(TurnoParameters filters);
    }
}
