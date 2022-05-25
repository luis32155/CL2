using System.ComponentModel.DataAnnotations;

namespace ExamenCl2.Models
{
    public class Horario
    {
        [Display(Name = "Codigo Horario")] public int idhorario { get; set; }
        [Display(Name = "Codigo Curso")] public int idcurso { get; set; }
        [Display(Name = "NombreCurso")] public string nombrecurso { get; set; }
        [Display(Name = "Fecha Inicio")] public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha Fin")] public DateTime Fechafin { get; set; }
        [Display(Name = "Vacantes")] public int vacantes { get; set; }
    }
}
