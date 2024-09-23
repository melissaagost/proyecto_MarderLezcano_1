using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_MarderLezcano.Commands;
using proyecto_MarderLezcano.Views;
using System.Windows.Controls;
using System.Windows;



namespace proyecto_MarderLezcano.ViewModels
{
    public class FormularioInicioSesionVM : BaseViewModel
    {
        // Aquí puedes agregar propiedades y comandos relacionados con el formulario de inicio de sesión.
        public RelayCommand IngresarCommand { get; }
        public RelayCommand EditarContrasenaCommand { get; }
        public RelayCommand MinimizeCommand { get; }
        public RelayCommand CloseCommand { get; }

        public FormularioInicioSesionVM()
        {
            // Inicializar los comandos
            IngresarCommand = new RelayCommand(OnIngresar);
            EditarContrasenaCommand = new RelayCommand(OnEditarContrasena);
            MinimizeCommand = new RelayCommand(OnMinimize);
            CloseCommand = new RelayCommand(OnClose);
        }

        private void OnIngresar(object parameter)
        {
            var menuWindow = new Views.User.Menu();
            menuWindow.Show();
            //var mainWindowVM = Application.Current.MainWindow.DataContext as PaginaPrincipalVM;
            //mainWindowVM.CloseCommand.Execute(mainWindowVM);
            Application.Current.MainWindow.Close(); //cambiar si se necesita otra funcionalidad
        }

        private void OnEditarContrasena(object parameter)
        {
            // Lógica para manejar la edición de contraseña
        }
        private void OnMinimize(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OnClose(object parameter)
        {
            Application.Current.MainWindow.Close();
        }
    }
}