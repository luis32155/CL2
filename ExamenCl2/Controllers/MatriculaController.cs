using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using ExamenCl2.Models;
using ExamenCl2.Models.HorarioDI;
namespace ExamenCl2.Controllers
{
    public class MatriculaController : Controller
    {
        IHorario inyector;

        public async Task<IActionResult> Horario( string fecha1 = "" , string fecha2 ="")
        {
    

            fecha1 = ViewBag.fecha1;
            fecha2 = ViewBag.fecha2;

            IEnumerable<Horario> temporal = inyector.GetFechaHorario(fecha1, fecha2);

            return View(await Task.Run(() => temporal));
        }
    }
}
