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
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections;



namespace proyecto_MarderLezcano.ViewModels
{
    public class FormularioInicioSesionVM : BaseViewModel, IDataErrorInfo
    {

        private string _usuario;
        private string _contrasena;

        public string Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }

        public string Contrasena
        {
            get => _contrasena;
            set
            {
                _contrasena = value;
                OnPropertyChanged(nameof(Contrasena));

            }
        }
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
        private bool CanIngresar(object parameter)
        {
            // Permitir el ingreso solo si los campos no están vacíos
            return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Contrasena);
        }
        private void OnIngresar(object parameter)
        {
            if (CanIngresar(parameter))
            {
                // Lógica de autenticación
                var menuWindow = new Views.User.Menu();
                menuWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        // Implementación de IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == nameof(Usuario))
                {
                    if (string.IsNullOrEmpty(Usuario))
                        result = "El campo usuario no puede estar vacío.";
                }
                else if (columnName == nameof(Contrasena))
                {
                    if (string.IsNullOrEmpty(Contrasena))
                        result = "El campo contraseña no puede estar vacío.";
                }
                return result;
            }
        }

        public string Error => null;
    }
}