using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_MarderLezcano.Commands;
using proyecto_MarderLezcano.Views;



namespace proyecto_MarderLezcano.ViewModels
{
    public class FormularioInicioSesionVM : BaseViewModel
    {
        // Aquí puedes agregar propiedades y comandos relacionados con el formulario de inicio de sesión.
        public RelayCommand IngresarCommand { get; }
        public RelayCommand EditarContrasenaCommand { get; }

        public FormularioInicioSesionVM()
        {
            // Inicializar los comandos
            IngresarCommand = new RelayCommand(OnIngresar);
            EditarContrasenaCommand = new RelayCommand(OnEditarContrasena);
        }

        private void OnIngresar(object parameter)
        {
            // Lógica para manejar el inicio de sesión
        }

        private void OnEditarContrasena(object parameter)
        {
            // Lógica para manejar la edición de contraseña
        }
    }
}