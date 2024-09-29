using proyecto_MarderLezcano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_MarderLezcano.ViewModels.User
{
    class PerfilVM : INotifyPropertyChanged
    {
        private UsuarioM _usuario;

        public UsuarioM Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                OnPropertyChanged();
            }
        }

        public PerfilVM()
        {
            CargarDatosUsuario();
        }

        // Método para cargar los datos del usuario desde la base de datos
        private void CargarDatosUsuario()
        {
            using (var db = new ContextoBD())
            {
                // Supongamos que tienes un método para obtener el usuario logueado
                Usuario = db.Usuario.FirstOrDefault(u => u.id_usuario == ObtenerUsuarioLogueadoId());
            }
        }

        private int ObtenerUsuarioLogueadoId()
        {
            // Implementar la lógica para obtener el ID del usuario logueado, posiblemente desde el sistema de autenticación.
            return 1; // Ejemplo: Retornar el ID del usuario logueado.
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

