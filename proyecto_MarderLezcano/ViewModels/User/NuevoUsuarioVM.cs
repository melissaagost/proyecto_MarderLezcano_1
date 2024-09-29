using Microsoft.EntityFrameworkCore;
using proyecto_MarderLezcano.Commands;
using proyecto_MarderLezcano.Models;
using proyecto_MarderLezcano.Views.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;  // Asegúrate de importar esto

namespace proyecto_MarderLezcano.ViewModels.User
{
    class NuevoUsuarioVM : BaseViewModel //cambie el INotifyProperty por baseviewmodel pq baseviewmodel ya contiene el inotify y no afecta al funcionamiento
    {

        private ObservableCollection<ProvinciaM> _listaProvincias;
        private ObservableCollection<CiudadM> _listaCiudades;
        private ObservableCollection<PerfilM> _listaPerfiles;

        private UsuarioM _nuevoUsuario;
        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand GuardarUsuarioCommand { get; set; }


        public ObservableCollection<ProvinciaM> ListaProvincias
        {
            get { return _listaProvincias; }
            set { _listaProvincias = value; OnPropertyChanged(); }
        }

        public ObservableCollection<CiudadM> ListaCiudades
        {
            get { return _listaCiudades; }
            set { _listaCiudades = value; OnPropertyChanged(); }
        }

        public ObservableCollection<PerfilM> ListaPerfiles
        {
            get { return _listaPerfiles; }
            set { _listaPerfiles = value; OnPropertyChanged(); }
        }

        public NuevoUsuarioVM()
        {
            CargarDatos();
            NuevoUsuario = new UsuarioM();
            GuardarUsuarioCommand = new RelayCommand(GuardarUsuario);
        }

        // DECLARACIÓN DE COMANDOS
        public RelayCommand GoBackCommand { get; }
        public RelayCommand CloseCommand { get; }

        private ObservableCollection<ProvinciaM> _listaProvincias;
        public ObservableCollection<ProvinciaM> ListaProvincias
        private void CargarDatos()
        {
            using (var context = new ContextoBD())
            {
                ListaProvincias = new ObservableCollection<ProvinciaM>(context.Provincias.ToList());
                ListaPerfiles = new ObservableCollection<PerfilM>(context.Perfiles.ToList());
            }
        }
        public UsuarioM NuevoUsuario

        private ProvinciaM _provinciaSeleccionada;
        public ProvinciaM ProvinciaSeleccionada
        {
            get { return _nuevoUsuario; }
            set
            {
                _nuevoUsuario = value;
                OnPropertyChanged(nameof(NuevoUsuario));
            }
        }

        public NuevoUsuarioVM()
        private void GuardarUsuario(object parameter)
        {
            CargarProvincias();

            GoBackCommand = new RelayCommand(OnGoBack);
        }

        // Método para cargar las provincias desde la base de datos
        private void CargarProvincias()
        {
            using (var db = new ContextoBD())
            // Lógica para guardar el usuario en la base de datos
            using (var context = new ContextoBD())
            {
                var provincias = db.Provincia.ToList();
                ListaProvincias = new ObservableCollection<ProvinciaM>(provincias);
                context.Usuarios.Add(NuevoUsuario);
                context.SaveChanges();
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // Método para ir hacia atrás en el Frame usando NavigationService
        private void OnGoBack(object parameter)
        {
            // Obtén la ventana principal (asumiendo que es Menu.xaml)
            var currentWindow = Application.Current.MainWindow as proyecto_MarderLezcano.Views.User.Menu;

            if (currentWindow != null)
            {
                // Accede al Frame que contiene las Pages
                var frame = currentWindow.FindName("Vistas") as Frame;

                if (frame != null && frame.NavigationService.CanGoBack)
                {
                    frame.NavigationService.GoBack(); // Navega hacia la página anterior
                }
                else
                {
                    MessageBox.Show("No hay una página previa a la que volver.");
                }
            }
            else
            {
                MessageBox.Show("La ventana principal no es del tipo esperado.");
            }
        }

    }
}