using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using proyecto_MarderLezcano.Views;
using System.Windows; 
using proyecto_MarderLezcano.ViewModels;
using proyecto_MarderLezcano.Commands;

namespace proyecto_MarderLezcano.ViewModels
{
    public class PaginaPrincipalVM : BaseViewModel
    {
        // Este comando se activará cuando el usuario haga clic en "Iniciar Sesión".
        public ICommand IniciarSesionCommand { get; }
        public RelayCommand MinimizeCommand { get; private set; }
        public RelayCommand CloseCommand { get; private set; }

        public PaginaPrincipalVM()
        {
            // Inicializa el comando con la acción a realizar cuando se ejecuta.
            IniciarSesionCommand = new RelayCommand(OnIniciarSesion);
            MinimizeCommand = new RelayCommand(OnMinimize);
            CloseCommand = new RelayCommand(OnClose);
        }

        private void NavegarAFormularioInicioSesion(object parameter)
        {
            FormularioInicioSesion formularioInicioSesion = new FormularioInicioSesion();
            //formularioInicioSesion.Show(); // Mostrar la segunda vista
            // Aquí podrías cerrar la primera ventana si es necesario
        }

        private void OnIniciarSesion(object parameter)
        {
            MessageBox.Show("Comando de iniciar sesión ejecutado."); 

            // Obtener la ventana principal
            var ventanaPrincipal = Application.Current.MainWindow as PaginaInicio;

            if (ventanaPrincipal != null)
            {
                MessageBox.Show("Ventana principal encontrada."); // Para verificar que encontró la ventana

                // Asumiendo que hay un Frame llamado 'MainFrame' en tu ventana principal
                ventanaPrincipal.NavigateTo(new FormularioInicioSesion()); 
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la ventana principal.");
            }
        }


        // Estos métodos no tendrán lógica en el ViewModel porque la acción se maneja en la vista (code-behind)
        private void OnMinimize(object parameter)
        {
            // La lógica de minimizar se manejará en la vista (Window.xaml.cs)

            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OnClose(object parameter)
        {
            // La lógica de cerrar se manejará en la vista (Window.xaml.cs)

            Application.Current.MainWindow.Close();
        }

    }
}