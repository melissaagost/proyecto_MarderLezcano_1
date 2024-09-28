using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_MarderLezcano.Models
{
    class PerfilM
    {
        [Key]
        public int id_perfil { get; set; } // Propiedad para el identificador del perfil
        public string nombre { get; set; } // Propiedad para el nombre del perfil

        // Método para obtener los perfiles desde la base de datos
        public static List<PerfilM> ObtenerPerfiles()
        {
            List<PerfilM> perfiles = new List<PerfilM>();

            using (SqlConnection conn = new SqlConnection("Server=localhost;Port=3307;Database=medilink;User=root;Password=;\""))
            {
                SqlCommand cmd = new SqlCommand("SELECT id_perfil, nombre FROM perfil", conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    perfiles.Add(new PerfilM
                    {
                        id_perfil = reader.GetInt32(0),
                        nombre = reader.GetString(1)
                    });
                }
            }

            return perfiles;
        }
    }
}
