using Microsoft.EntityFrameworkCore;
using proyecto_MarderLezcano.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_MarderLezcano.ViewModels.User

{
    class NuevoUsuarioVM : INotifyPropertyChanged
    {
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
        }
        // Método para cargar las provincias desde la base de datos
        private void CargarProvincias()
        {
            using (var db = new ContextoBD())
            {
                var provincias = db.Provincias.ToList();
                ListaProvincias = new ObservableCollection<ProvinciaM>(provincias);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
