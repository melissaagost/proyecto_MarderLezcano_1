using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_MarderLezcano.Models
{
    class CitaM
    {
        [Key]
        public int id_cita { get; set; }
        public DateTime fecha { get; set; }
        public DateTime hora { get; set; }
        public string motivo { get; set; }
        public int id_paciente { get; set; }
        public int id_medico { get; set; }
    }
}
