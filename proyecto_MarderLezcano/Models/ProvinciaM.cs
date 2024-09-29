using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_MarderLezcano.Models
{
    public class ProvinciaM
    {
            [Key]
            public int id_provincia { get; set; }
            public string nombre { get; set; }

        //una provincia puede tener muchos usuarios
        public ICollection<UsuarioM> Usuarios { get; set; }

    }
}
