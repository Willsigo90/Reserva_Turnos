using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TurnoRequest
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int IdServicio { get; set; }
    }
}
