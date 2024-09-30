using Microsoft.EntityFrameworkCore;
using proyecto_MarderLezcano.Commands;
using proyecto_MarderLezcano.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace proyecto_MarderLezcano.ViewModels.User
{
    public class ListadoUsuariosVM : BaseViewModel
    {
        public ObservableCollection<UsuarioM> UsuariosActivos { get; set; }
        public ObservableCollection<UsuarioM> UsuariosInactivos { get; set; }
        public ICommand EliminarUsuarioCommand { get; private set; }


        public ListadoUsuariosVM()
        {
            CargarUsuariosInactivos();
            CargarUsuariosActivos();
            EliminarUsuarioCommand = new EliminarUsuarioCommand(this);

        }

        private void CargarUsuariosActivos()
        {
            using (var context = new ContextoBD()) // Tu DbContext
            {
                var usuarios = context.Usuario
                    .Include(u => u.Provincia) // Cargar la provincia
                    .Include(u => u.Perfil)    // Cargar el perfil
                    .Include(u => u.Ciudad)    // Cargar la ciudad (si la necesitas)
                    .Where(u => u.status == "si") // Filtramos por usuarios activos
                    .Select(u => new UsuarioM
                    {
                        id_usuario = u.id_usuario,
                        dni = u.dni,
                        nombre = u.nombre,
                        apellido = u.apellido,
                        usuario = u.usuario,
                        correo = u.correo,
                        id_ciudad = u.id_ciudad,
                        id_perfil = u.id_perfil,
                        status = u.status,

                        // Acceder a los nombres relacionados
                        Provincia = u.Provincia, // Propiedad de navegación
                        Perfil = u.Perfil,       // Propiedad de navegación
                        Ciudad = u.Ciudad        // Propiedad de navegación
                    })
                    .ToList();

                UsuariosActivos = new ObservableCollection<UsuarioM>(usuarios);
            }
        }

        private void CargarUsuariosInactivos()
        {
            using (var context = new ContextoBD()) // Tu DbContext
            {
                var usuarios = context.Usuario
                    .Include(u => u.Provincia) // Cargar la provincia
                    .Include(u => u.Perfil)    // Cargar el perfil
                    .Include(u => u.Ciudad)    // Cargar la ciudad (si la necesitas)
                    .Where(u => u.status == "no") // Filtramos por usuarios activos
                    .Select(u => new UsuarioM
                    {
                        id_usuario = u.id_usuario,
                        dni = u.dni,
                        nombre = u.nombre,
                        apellido = u.apellido,
                        usuario = u.usuario,
                        correo = u.correo,
                        id_ciudad = u.id_ciudad,
                        id_perfil = u.id_perfil,
                        status = u.status,

                        // Acceder a los nombres relacionados
                        Provincia = u.Provincia, // Propiedad de navegación
                        Perfil = u.Perfil,       // Propiedad de navegación
                        Ciudad = u.Ciudad        // Propiedad de navegación
                    })
                    .ToList();

                UsuariosInactivos = new ObservableCollection<UsuarioM>(usuarios);
            }
        }


        public void CambiarStatusUsuario(UsuarioM usuario)
        {
            using (var context = new ContextoBD())
            {
                var usuarioDb = context.Usuario.Find(usuario.id_usuario);
                if (usuarioDb != null)
                {
                    string mensaje = "";

                    if (usuarioDb.status == "si")
                    {
                        usuarioDb.status = "no";
                        mensaje = $"El usuario {usuario.nombre} ha sido dado de baja.";
                    }
                    
                    else if (usuarioDb.status == "no")
                    {
                        usuarioDb.status = "si";
                        mensaje = $"El usuario {usuario.nombre} ha sido reactivado.";
                    }

                    context.SaveChanges(); 

                    MessageBox.Show(mensaje, "Estado del Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            CargarUsuariosInactivos();
            CargarUsuariosActivos();
        }



    }
}

