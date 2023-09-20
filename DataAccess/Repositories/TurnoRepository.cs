using DataAccess;
//using Incapacidades.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class TurnoRepository : ITurnoRepository
    {
        readonly IAccesoDatosDataWrite turnosRepositorio;

        public TurnoRepository(IAccesoDatosDataWrite turnosRepositorioIn)
        {
            turnosRepositorio = turnosRepositorioIn;
        }

        public IEnumerable<Turno> CreateTurnos(TurnoParameters filters)
        {
            var afiliados = turnosRepositorio.CreateTurnos(filters);
            return afiliados;
         
        }

    }
}
