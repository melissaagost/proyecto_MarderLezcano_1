using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_MarderLezcano.Models
{
    class MedicoM
    {
        [Key]
        public int id_medico { get; set; }
        public int id_especialidad { get; set; }
        public int id_usuario { get; set; }
        public int id_turno { get; set; }

    }
}
