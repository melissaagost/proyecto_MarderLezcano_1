using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using proyecto_MarderLezcano.Helpers; // Agrega esta línea
using proyecto_MarderLezcano.Views;
using System.Windows; // Asegúrate de tener esta línea



namespace proyecto_MarderLezcano.ViewModels
{
   
    public class PaginaInicioVM : BaseViewModel
    {
        // Este comando se activará cuando el usuario haga clic en "Iniciar Sesión".
        public ICommand IniciarSesionCommand { get; }

        public PaginaInicioVM()
        {
            // Inicializa el comando con la acción a realizar cuando se ejecuta.
            IniciarSesionCommand = new RelayCommand(OnIniciarSesion);
        }

        private void OnIniciarSesion(object parameter)
        {
            // Obtener la ventana principal
            var ventanaPrincipal = Application.Current.MainWindow as PaginaInicio;

            if (ventanaPrincipal != null)
            {
                
                // Navegar a la vista de formulario de inicio de sesión
                ventanaPrincipal.NavigateTo(new FormularioInicioSesion());
            }
        }
    }
}
