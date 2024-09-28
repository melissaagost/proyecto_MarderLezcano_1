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



namespace proyecto_MarderLezcano.ViewModels.User
{
    public class MenuVM : BaseViewModel
    {
        //MANEJO DE ROLES
        private UsuarioM _currentUser;

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



        //DECLARACION DE COMANDOS
        public RelayCommand MinimizeCommand { get; }
        public RelayCommand CloseCommand { get; }


        //vistas
        public RelayCommand ShowDashboardCommand { get; }



        //LLAMADAS A COMANDOS
        public MenuVM(UsuarioM user)
        {
            CurrentUser = user;
            MinimizeCommand = new RelayCommand(OnMinimize);
            CloseCommand = new RelayCommand(OnClose);
            //vistas
            ShowDashboardCommand = new RelayCommand(ShowDashboard);

        }

        //FUNCIONAMIENTO DE COMANDOS
        private void ShowDashboard(object obj) => MessageBox.Show("New Command Executed!"); //hacer que muestre la vista con navigate to
        //private void ShowCrearNuevoUsuario(object obj) => NavigateTo(new NuevoUsuario());





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
