using Microsoft.EntityFrameworkCore;
using proyecto_MarderLezcano.Commands;
using proyecto_MarderLezcano.Models;
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
        private string _telefonoText;
        public string TelefonoText
        {
            get { return _telefonoText; }
            set
            {
                if (_telefonoText != value)
                {
                    _telefonoText = value;
                    OnPropertyChanged(nameof(TelefonoText));
                    OnTelefonoTextChanged();
                }
            }
        }

        // DECLARACIÓN DE COMANDOS
        public RelayCommand GoBackCommand { get; }
        public RelayCommand CloseCommand { get; }

        private ObservableCollection<ProvinciaM> _listaProvincias;
        public ObservableCollection<ProvinciaM> ListaProvincias
        {
            get { return _listaProvincias; }
            set
            {
                _listaProvincias = value;
                OnPropertyChanged(nameof(ListaProvincias));
            }
        }

        private ProvinciaM _provinciaSeleccionada;
        public ProvinciaM ProvinciaSeleccionada
        {
            get { return _provinciaSeleccionada; }
            set
            {
                _provinciaSeleccionada = value;
                OnPropertyChanged(nameof(ProvinciaSeleccionada));
            }
        }

        public NuevoUsuarioVM()
        {
            CargarProvincias();
            // Inicializa los comandos de navegación
            GoBackCommand = new RelayCommand(OnGoBack);
            CloseCommand = new RelayCommand(OnClose);
        }

        // Método para cargar las provincias desde la base de datos
        private void CargarProvincias()
        {
            using (var db = new ContextoBD())
            {
                var provincias = db.Provincia.ToList();
                ListaProvincias = new ObservableCollection<ProvinciaM>(provincias);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnTelefonoTextChanged()
        {
            Console.WriteLine($"Telefono es {TelefonoText}");
        }

        // Método para ir hacia atrás en el Frame usando NavigationService
        private void OnGoBack(object parameter)
        {
            // Obtén la ventana actual (puede ser Menu.xaml que contiene el Frame)
            var currentWindow = Application.Current.MainWindow as proyecto_MarderLezcano.Views.User.Menu;
            if (currentWindow != null)
            {
                // Obtén el Frame llamado "Vistas"
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
        }
        private void OnClose(object parameter)
        {
            
            var currentPage = Application.Current.MainWindow.Content as Page;

            if (currentPage != null)
            {
                Window mainWindow = Window.GetWindow(currentPage);

                if (mainWindow != null)
                {
                    mainWindow.Close(); // Cierra la ventana actual
                }
            }
        }
    }
}
