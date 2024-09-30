using proyecto_MarderLezcano.Commands;
using proyecto_MarderLezcano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace proyecto_MarderLezcano.ViewModels.User
{
    public class PerfilVM : BaseViewModel
    {
        private string _usuario;
        public string usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    OnPropertyChanged(nameof(usuario));
                }
            }
        }

        private string _contraseña;
        public string contraseña
        {
            get { return _contraseña; }
            set
            {
                if (_contraseña != value)
                {
                    _contraseña = value;
                    OnPropertyChanged(nameof(contraseña));
                }
            }
        }
        public RelayCommand GuardarCommand { get; }

        public RelayCommand CancelarCommand { get; }
        public PerfilVM()
        {
            GuardarCommand = new RelayCommand(Guardar);
            CancelarCommand = new RelayCommand(Cancelar);
        }

        // Método para cargar la información del usuario
        public void CargarDatosUsuario(int idUsuario)
        {
            using (var context = new ContextoBD())
            {
                var usuario = context.Usuario.Find(idUsuario);

                if (usuario != null)
                {
                    Usuario = usuario.usuario;
                    Correo = usuario.correo;
                    Telefono = usuario.telefono;
                    Direccion = usuario.direccion;
                    // No cargamos la contraseña por seguridad
                }
            }
        }

       
        private void Guardar()
        {
            using (var context = new ContextoBD())
            {
                var usuario = context.Usuario.FirstOrDefault(u => u.usuario == Usuario);

                if (usuario != null)
                {
                    usuario.correo = Correo;
                    usuario.telefono = Telefono;
                    usuario.direccion = Direccion;

                    if (!string.IsNullOrWhiteSpace(Contrasena))
                    {
                        usuario.contraseña = Contrasena; 
                    }

                    context.SaveChanges();

                    MessageBox.Show("Cambios guardados correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Cancelar()
        {
            // Limpiar los campos
            Correo = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Contrasena = string.Empty;

            // Notificar a la vista que los valores han cambiado
            OnPropertyChanged(nameof(Correo));
            OnPropertyChanged(nameof(Telefono));
            OnPropertyChanged(nameof(Direccion));
            OnPropertyChanged(nameof(Contrasena));

            MessageBox.Show("Los campos han sido limpiados", "Cancelación", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}

