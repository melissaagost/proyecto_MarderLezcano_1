using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace proyecto_MarderLezcano.Models
{
    public class UsuarioM
    {
        [Key]
        public int id_usuario { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }

        public string status { get; set; }

        // Claves foráneas
        public int id_provincia { get; set; } // Propiedad de clave foránea
        public ProvinciaM Provincia { get; set; } // Relación de navegación hacia la entidad Provincia

        public int id_ciudad { get; set; } // Propiedad de clave foránea
        public CiudadM Ciudad { get; set; } // Relación de navegación hacia la entidad Ciudad

        public int id_perfil { get; set; } // Propiedad de clave foránea
        public PerfilM Perfil { get; set; } // Relación de navegación hacia la entidad Perfil


    }
}
