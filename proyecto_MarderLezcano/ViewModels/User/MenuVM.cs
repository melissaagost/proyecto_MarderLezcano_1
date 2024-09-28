using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using proyecto_MarderLezcano.Models;
using proyecto_MarderLezcano.Commands;
using System.Windows;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualBasic.ApplicationServices;
using proyecto_MarderLezcano.Views.User;
using System.Windows.Controls;




namespace proyecto_MarderLezcano.ViewModels.User
{
    public class MenuVM : BaseViewModel
    {
        // MANEJO DE ROLES Y VISTAS
        private UsuarioM _currentUser;
        private Frame _frame;

        public UsuarioM CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public string UserRole
        {
            get
            {
                return CurrentUser.id_perfil switch
                {
                    1 => "Sistemas",
                    2 => "Gestor",
                    3 => "Medico",
                    4 => "Recepcionista",
                    _ => "Unknown"
                };
            }
        }

        // PROPIEDAD PARA EL ContentControl
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        // DECLARACIÓN DE COMANDOS
        public RelayCommand MinimizeCommand { get; }
        public RelayCommand CloseCommand { get; }

        // Vistas
        public RelayCommand ShowNuevoUsuarioCommand { get; }

        // LLAMADAS A COMANDOS
        public MenuVM(UsuarioM user, Frame frame)
        {
                _frame = frame;
                CurrentUser = user;
                MinimizeCommand = new RelayCommand(OnMinimize);
                CloseCommand = new RelayCommand(OnClose);

                // Inicializamos las vistas en comandos
                ShowNuevoUsuarioCommand = new RelayCommand(ShowNuevoUsuario);
            

        }

        // FUNCIONAMIENTO DE COMANDOS
        private void ShowNuevoUsuario(object obj)
        {
            var nuevoUsuarioPage = new NuevoUsuario();
            _frame.Navigate(nuevoUsuarioPage); 
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
