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
        // DECLARACIÓN DE COMANDOS REPORTES
        public RelayCommand ShowReporteGestorCommand { get; }
        public RelayCommand ShowReporteMedicoCommand { get; }
        public RelayCommand ShowReporteRecepcionistaCommand { get; }

        // DECLARACIÓN DE COMANDOS CERRAR/MIN
        public RelayCommand MinimizeCommand { get; }
        public RelayCommand CloseCommand { get; }

        // DECLARACION DE VISTAS
        //GENERALES (PARA TODOS LOS USERS)
        public RelayCommand ShowEditarPerfilCommand { get; }
        //USUARIO
        public RelayCommand ShowNuevoUsuarioCommand { get; }
        public RelayCommand ShowListadoUsuariosCommand { get; }

        //MEDICO
        //RECEPCIONISTA
        public RelayCommand ShowListadoCitasCommand { get; }
        public RelayCommand ShowNuevoPacienteCommand { get; }
        public RelayCommand ShowNuevaCitaCommand { get; }

        //GESTOR

        // LLAMADAS A COMANDOS
        public MenuVM(UsuarioM user, Frame frame)
        {
                _frame = frame;
                CurrentUser = user;
                MinimizeCommand = new RelayCommand(OnMinimize);
                CloseCommand = new RelayCommand(OnClose);

            // Inicializamos las vistas en comandos
            ShowEditarPerfilCommand = new RelayCommand(ShowEditarPerfil);
            //usuarios
            ShowNuevoUsuarioCommand = new RelayCommand(ShowNuevoUsuario);
            ShowListadoUsuariosCommand = new RelayCommand(ShowListadoUsuarios);
            //medico

            //recepcionista
            ShowListadoCitasCommand = new RelayCommand(ShowListadoCitas);
            ShowNuevaCitaCommand = new RelayCommand(ShowNuevaCita);
            ShowNuevoPacienteCommand = new RelayCommand(ShowNuevoPaciente);

            //gestor

            // reportes
            ShowReporteGestorCommand = new RelayCommand(ShowReporteGestor);
            ShowReporteMedicoCommand = new RelayCommand(ShowReporteMedico);
            ShowReporteRecepcionistaCommand = new RelayCommand(ShowReporteRecepcionista);


        }

        //METODOS VISTAS GENERALES
        private void ShowEditarPerfil(object obj)
        {
            var nuevoUsuarioPage = new EditarPerfil();
            _frame.Navigate(nuevoUsuarioPage);
        }
        // METODOS PARA MOSTRAR VISTAS USUARIO
        private void ShowNuevoUsuario(object obj)
        {
            var nuevoUsuarioPage = new NuevoUsuario();
            _frame.Navigate(nuevoUsuarioPage); 
        }

        private void ShowListadoUsuarios(object obj)
        {
            var nuevoUsuarioPage = new ListadoUsuarios();
            _frame.Navigate(nuevoUsuarioPage);
        }
        // METODOS PARA MOSTRAR VISTAS MEDICO
        // METODOS PARA MOSTRAR VISTAS RECPCIONISTA
        private void ShowNuevoPaciente(object obj)
        {
            var nuevoUsuarioPage = new NuevoPaciente();
            _frame.Navigate(nuevoUsuarioPage);
        }
        private void ShowNuevaCita(object obj)
        {
            var nuevoUsuarioPage = new ProgramarCita();
            _frame.Navigate(nuevoUsuarioPage);
        }
        private void ShowListadoCitas(object obj)
        {
            var nuevoUsuarioPage = new ListadoCitas();
            _frame.Navigate(nuevoUsuarioPage);
        }
        // METODOS PARA MOSTRAR VISTAS GESTOR
        private void OnMinimize(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OnClose(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        // Métodos para mostrar reportes
        
        private void ShowReporteGestor(object obj)
        {
            var reporteGestorPage = new ReporteGestor(); // Vista para reportes de gestor
            _frame.Navigate(reporteGestorPage);
        }

        private void ShowReporteMedico(object obj)
        {
            var reporteMedicoPage = new ReporteMedico(); // Vista para reportes de médico
            _frame.Navigate(reporteMedicoPage);
        }

        private void ShowReporteRecepcionista(object obj)
        {
            var reporteRecepcionistaPage = new ReporteRecepcionista(); // Vista para reportes de recepcionista
            _frame.Navigate(reporteRecepcionistaPage);
        }

        
    }
}
