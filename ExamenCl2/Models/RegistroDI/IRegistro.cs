using Microsoft.AspNetCore.Mvc;

namespace ExamenCl2.Models.RegistroDI
{

    public interface IRegistro
    {

        String Agregar(Registro reg);
    }
}
