using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace proyecto_MarderLezcano.Models
{
    public class UsuarioM
    {
        public int id_usuario { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public Date fecha_nacimiento { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public int id_provincia { get; set; }
        public int id_ciudad { get; set; }
        public int id_perfil { get; set; }

    

    }
}
