using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ExamenCl2.Models.RegistroDI
{
    public class RegistroRepositorio : IRegistro

    {
        string cadena = @"server=localhost;database=Negocios2022;Trusted_Connection=True;" +
   "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False";

      public  string Agregar(Registro reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "insert into tb_registro values (@codhorario,@fregistro,@alumno,@email) ", cn, tr);
                    cmd.Parameters.AddWithValue("@codhorario", reg.codhorario);
                    cmd.Parameters.AddWithValue("@fregistro", reg.fecharegistro);
                    cmd.Parameters.AddWithValue("@alumno", reg.alumno);
                    cmd.Parameters.AddWithValue("@email", reg.email);
                    cmd.ExecuteNonQuery(); //ejecutar
                    tr.Commit();
                    mensaje = "Se ha Matriculado al Alumno ";
                }
                catch (Exception ex) { mensaje = ex.Message; tr.Rollback(); }
                cn.Close();
            }
            return mensaje;
        
    }
    }
}
