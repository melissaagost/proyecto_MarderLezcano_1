using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace proyecto_MarderLezcano.Models
{
    class ContextoBD : DbContext
    {

        public DbSet<PerfilM> Perfil { get; set; } // Propiedad para la tabla Perfiles


        public DbSet<UsuarioM> Usuario { get; set; } // Propiedad para la tabla usuarios
        public DbSet<ProvinciaM> Provincia { get; set; } // Definir el DbSet de ProvinciaM

        public DbSet<CiudadM> Ciudad { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aquí debes especificar tu cadena de conexión a la base de datos
            optionsBuilder.UseMySql("Server=localhost;Port=3307;Database=medilink;User=root;Password=;AllowZeroDateTime=True;", new MySqlServerVersion(new Version(8, 0, 21)));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            // Configuración de la relación entre Usuario y Ciudad
            modelBuilder.Entity<UsuarioM>()
                .HasOne(u => u.Ciudad) // Relación con CiudadM
                .WithMany(c => c.Usuarios) // Una ciudad tiene muchos usuarios
                .HasForeignKey(u => u.id_ciudad) // Clave foránea en UsuarioM
                .HasConstraintName("FK_Usuario_Ciudad"); // Puedes darle un nombre a la FK si lo deseas

            modelBuilder.Entity<UsuarioM>()
        .HasOne(u => u.Provincia)  // Relación con ProvinciaM
        .WithMany(p => p.Usuarios)  // Una provincia tiene muchos usuarios
        .HasForeignKey(u => u.id_provincia)  // Clave foránea en UsuarioM
        .HasConstraintName("FK_Usuario_Provincia");  // Nombre personalizado para la FK

            // Configuración de la relación entre Usuario y Perfil
            modelBuilder.Entity<UsuarioM>()
                .HasOne(u => u.Perfil)  // Relación con PerfilM
                .WithMany(p => p.Usuarios)  // Un perfil puede tener muchos usuarios
                .HasForeignKey(u => u.id_perfil)  // Clave foránea en UsuarioM
                .HasConstraintName("FK_Usuario_Perfil");  // Nombre personalizado para la FK

            // Resto de las configuraciones de otras relaciones
        }

    }
}
