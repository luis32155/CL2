using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ExamenCl2.Models.HorarioDI
{
    public class HorarioRepositorio : IHorario
    {

        string cadena = @"server=localhost;database=Negocios2022;Trusted_Connection=True;" +
           "MultipleActiveResultSets = True;TrustServerCertificate = False;Encrypt = False";

        public IEnumerable<Horario> GetFechaHorario(string fecha1, string fecha2)
        {

            List<Horario> temporal = new List<Horario>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("exec sp_listar_fechas_registro @fecha1,@fecha2", cn);
                cmd.Parameters.AddWithValue("@fecha1", fecha1);
                cmd.Parameters.AddWithValue("@fecha2", fecha2);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Horario()
                    {
                        idhorario = dr.GetInt32(0),
                        nombrecurso = dr.GetString(1),
                        idcurso = dr.GetInt32(2),
                        FechaInicio = dr.GetDateTime(3),
                        Fechafin = dr.GetDateTime(4),
                        vacantes = dr.GetInt32(5),
                    });
                }
            }
            return temporal;
        }
    }

        
    }

