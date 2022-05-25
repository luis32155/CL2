namespace ExamenCl2.Models.HorarioDI
{
    public interface IHorario
    {
        IEnumerable<Horario> GetFechaHorario(string fecha1, string fecha2);
    }
}
