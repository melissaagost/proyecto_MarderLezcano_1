﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_MarderLezcano.Models
{
    class CiudadM
    {
        [Key]
        public int id_ciudad { get; set; }

        public string nombre { get; set; }
    }
}
