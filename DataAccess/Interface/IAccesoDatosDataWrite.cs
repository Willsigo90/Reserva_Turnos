namespace DataAccess
{
    public interface IAccesoDatosDataWrite 
    {
        public IEnumerable<Turno> CreateTurnos(TurnoParameters filters);
    }
}
