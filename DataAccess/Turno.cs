using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public int IdServicio { get; set; }
        public string NomServicio { get; set; }
        public int IdComercio { get; set; }
        public string NomComercio { get; set; }
        public string FechaTurno { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int Duracion { get; set; }
    }
}
