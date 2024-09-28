using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace proyecto_MarderLezcano.Models
{
    class ContextoBD : DbContext
    {
        public DbSet<PerfilM> Perfiles { get; set; } // Propiedad para la tabla Perfiles

        public DbSet<UsuarioM> Usuarios { get; set; } // Propiedad para la tabla usuarios?
        public DbSet<ProvinciaM> Provincias { get; set; } // Definir el DbSet de ProvinciaM

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aquí debes especificar tu cadena de conexión a la base de datos
            optionsBuilder.UseMySql("Server=localhost;Port=3307;Database=medilink;User=root;Password=;", new MySqlServerVersion(new Version(8, 0, 21)));
        }
    }
}
