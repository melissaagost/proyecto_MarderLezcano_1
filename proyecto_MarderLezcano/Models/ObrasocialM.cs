using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_MarderLezcano.Models
{
    class ObrasocialM
    {
        [Key]
        public int id_obra_social { get; set; }
        public string nombre { get; set; }

    }
}
