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
using System.Windows.Input;

namespace proyecto_MarderLezcano.ViewModels.User

{
    class NuevoUsuarioVM : BaseViewModel, INotifyPropertyChanged
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

        private void CargarDatos()
        {
            using (var context = new ContextoBD())
            {
                ListaProvincias = new ObservableCollection<ProvinciaM>(context.Provincias.ToList());
                ListaPerfiles = new ObservableCollection<PerfilM>(context.Perfiles.ToList());
            }
        }
        public UsuarioM NuevoUsuario
        {
            get { return _nuevoUsuario; }
            set
            {
                _nuevoUsuario = value;
                OnPropertyChanged(nameof(NuevoUsuario));
            }
        }
        private void GuardarUsuario(object parameter)
        {
            // Lógica para guardar el usuario en la base de datos
            using (var context = new ContextoBD())
            {
                context.Usuarios.Add(NuevoUsuario);
                context.SaveChanges();
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}