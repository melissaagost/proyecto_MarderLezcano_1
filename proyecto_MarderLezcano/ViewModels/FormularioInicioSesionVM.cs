using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using proyecto_MarderLezcano.Views;
using System.Windows.Controls;
using System.ComponentModel;
using proyecto_MarderLezcano.Commands;
using System.Windows;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;

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
            return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Contrasena);
        }
        private void OnIngresar(object parameter)
        {
            if (CanIngresar(parameter))
            {
                if (AutenticarUsuario(Usuario, Contrasena))
                {
                    // Abrir la ventana del menú si la autenticación es correcta
                    var menuWindow = new Views.User.Menu();
                    menuWindow.Show();
                    Application.Current.MainWindow.Close();
                }
               
            }
            else
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método para autenticar el usuario en la base de datos
        private bool AutenticarUsuario(string usuario, string contrasena)
        {
            bool autenticado = false;

            // Cadena de conexión a la base de datos
            string connectionString = "server=localhost;port=3307;database=medilink;uid=root;pwd=;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Primero verificamos si el usuario existe
                    string queryUsuario = "SELECT COUNT(*) FROM usuario WHERE usuario = @usuario";
                    MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, conn);
                    cmdUsuario.Parameters.AddWithValue("@usuario", usuario);

                    int userCount = Convert.ToInt32(cmdUsuario.ExecuteScalar());

                    if (userCount == 0)
                    {
                        // Si no existe el usuario
                        MessageBox.Show("Usuario incorrecto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        // Si el usuario existe, verificamos la contraseña
                        string queryContrasena = "SELECT contraseña FROM usuario WHERE usuario = @usuario";
                        MySqlCommand cmdContrasena = new MySqlCommand(queryContrasena, conn);
                        cmdContrasena.Parameters.AddWithValue("@usuario", usuario);

                        string storedPassword = cmdContrasena.ExecuteScalar()?.ToString();

                        if (contrasena == storedPassword)
                        {
                            autenticado = true;
                        }
                        else
                        {
                            // Usuario existe, pero la contraseña es incorrecta
                            MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error de conexión a la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return autenticado;
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