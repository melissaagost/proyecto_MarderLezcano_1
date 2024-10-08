using proyecto_MarderLezcano.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using proyecto_MarderLezcano.Models;
using System.Collections.ObjectModel;

namespace proyecto_MarderLezcano.ViewModels.User
{
    class NuevoPacienteVM : BaseViewModel
    {
        //PROPIEDADES
        private int _dni;
        public int dni
        {
            get { return _dni; }
            set
            {
                if (_dni != value)
                {
                    _dni = value;
                    OnPropertyChanged(nameof(dni));
                }
            }
        }

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(nombre));
                }
            }
        }

        private string _apellido;
        public string apellido
        {
            get { return _apellido; }
            set
            {
                if (_apellido != value)
                {
                    _apellido = value;
                    OnPropertyChanged(nameof(apellido));
                }
            }
        }

        private DateTime _fechaNacimiento;
        public DateTime fecha_nacimiento
        {
            get { return _fechaNacimiento; }
            set
            {
                if (_fechaNacimiento != value)
                {
                    _fechaNacimiento = value;
                    OnPropertyChanged(nameof(fecha_nacimiento));
                }
            }
        }

        private string _telefono;
        public string telefono
        {
            get { return _telefono; }
            set
            {
                if (_telefono != value)
                {
                    _telefono = value;
                    OnPropertyChanged(nameof(telefono));
                    OnTelefonoTextChanged();
                }
            }
        }

        private string _correo;
        public string correo
        {
            get { return _correo; }
            set
            {
                if (_correo != value)
                {
                    _correo = value;
                    OnPropertyChanged(nameof(correo));
                    OnTelefonoTextChanged();
                }
            }
        }

        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set
            {
                if (_direccion != value)
                {
                    _direccion = value;
                    OnPropertyChanged(nameof(direccion));
                    OnTelefonoTextChanged();
                }
            }
        }
        private int _edad;
        public int edad
        {
            get { return _edad; }
            set
            {
                if (_edad != value)
                {
                    _edad = value;
                    OnPropertyChanged(nameof(edad));
                }
            }
        }
        private int _id_obra_social;
        public int id_obra_social
        {
            get { return _id_obra_social; }
            set
            {
                _id_obra_social = value;
                OnPropertyChanged(nameof(id_obra_social));
            }
        }

        private int _id_provincia;
        public int id_provincia
        {
            get { return _id_provincia; }
            set
            {
                _id_provincia = value;
                OnPropertyChanged(nameof(id_provincia));
            }
        }

        private int _id_ciudad;
        public int id_ciudad
        {
            get { return _id_ciudad; }
            set
            {
                _id_ciudad = value;
                OnPropertyChanged(nameof(id_ciudad));
            }
        }

        public ObservableCollection<ProvinciaM> ListaProvincias { get; set; }
        public ObservableCollection<CiudadM> ListaCiudades { get; set; }
        public ObservableCollection<ObrasocialM> ListaObrasSociales { get; set; }

        // DECLARACIÓN DE COMANDOS
        public RelayCommand GoBackCommand { get; }
        public RelayCommand CloseCommand { get; }
        public RelayCommand CrearPacienteCommand { get; }
        public RelayCommand CancelarCommand { get; }
        
        
        public NuevoPacienteVM()
        {

            // Inicializar propiedades relacionadas con los datos del formulario
            dni = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            telefono = string.Empty;
            correo = string.Empty;
            direccion = string.Empty;
            edad = 0;


            // Cargar provincias u otros datos relacionados
            CargarProvincias();
            CargarCiudades();
            CargarObrasSociales();

            GoBackCommand = new RelayCommand(OnGoBack);
            CrearPacienteCommand = new RelayCommand(CrearPaciente);
            CancelarCommand = new RelayCommand(Cancelar);
        }
        //IMPLEMENTACIONES

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnTelefonoTextChanged()
        {
            Console.WriteLine($"Telefono es {telefono}");
        }

        private ProvinciaM _provinciaSeleccionada;
        public ProvinciaM ProvinciaSeleccionada
        {
            get { return _provinciaSeleccionada; }
            set
            {
                _provinciaSeleccionada = value;
                OnPropertyChanged(nameof(ProvinciaSeleccionada));
                if (_provinciaSeleccionada != null)
                {
                    CargarCiudades();
                }
                id_provincia = _provinciaSeleccionada?.id_provincia ?? 0;
            }
        }

        private void CargarProvincias()
        {
            using (var db = new ContextoBD())
            {
                var provincias = db.Provincia.ToList();
                ListaProvincias = new ObservableCollection<ProvinciaM>(provincias);
            }

            // Verificar si hay datos
            foreach (var provincia in ListaProvincias)
            {
                Console.WriteLine($"Provincia: {provincia.nombre}");
            }
        }

        private CiudadM _ciudadSeleccionada;
        public CiudadM CiudadSeleccionada
        {
            get { return _ciudadSeleccionada; }
            set
            {
                _ciudadSeleccionada = value;
                OnPropertyChanged(nameof(CiudadSeleccionada));
                id_ciudad = _ciudadSeleccionada?.id_ciudad ?? 0;
            }
        }
        private void CargarCiudades()
        {
            using (var db = new ContextoBD())
            {
                var ciudades = db.Ciudad.ToList();
                ListaCiudades = new ObservableCollection<CiudadM>(ciudades);
            }
        }

        private ObrasocialM _obraSeleccionado;
        public ObrasocialM ObraSeleccionado
        {
            get { return _obraSeleccionado; }
            set
            {
                _obraSeleccionado = value;
                OnPropertyChanged(nameof(ObraSeleccionado));
                id_obra_social = _obraSeleccionado?.id_obra_social ?? 0;
            }
        }

        private void CargarObrasSociales()
        {
            using (var db = new ContextoBD())
            {
                var obras = db.ObraSocial.ToList();
                ListaObrasSociales = new ObservableCollection<ObrasocialM>(obras);
            }
        }

        private void CrearPaciente(object parameter)
        {
            using (var db = new ContextoBD())
            {

                // Validaciones

                // Validación de DNI
                if (string.IsNullOrWhiteSpace(this.dni.ToString()) || this.dni.ToString().Length != 8 || !this.dni.ToString().All(char.IsDigit))
                {
                    MessageBox.Show("El DNI debe tener 8 caracteres numéricos y no puede estar en blanco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var dniExistente = db.Usuario.FirstOrDefault(u => u.dni == this.dni);
                if (dniExistente != null)
                {
                    MessageBox.Show($"Ya existe un paciente registrado con el DNI {this.dni}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validación de Fecha de Nacimiento
                if (this.fecha_nacimiento == DateTime.MinValue)
                {
                    MessageBox.Show("Debe seleccionar una fecha de nacimiento.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                // Validación de Nombre
                if (string.IsNullOrWhiteSpace(this.nombre) || this.nombre.Any(char.IsDigit))
                {
                    MessageBox.Show("El nombre no puede estar en blanco ni contener números.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validación de Apellido
                if (string.IsNullOrWhiteSpace(this.apellido) || this.apellido.Any(char.IsDigit))
                {
                    MessageBox.Show("El apellido no puede estar en blanco ni contener números.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validación de Dirección
                if (string.IsNullOrWhiteSpace(this.direccion))
                {
                    MessageBox.Show("La dirección no puede estar en blanco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validación de Teléfono
                if (string.IsNullOrWhiteSpace(this.telefono) || this.telefono.Length != 8 || !this.telefono.All(char.IsDigit))
                {
                    MessageBox.Show("El teléfono debe tener 8 caracteres numéricos y no puede estar en blanco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var telefonoExistente = db.Usuario.FirstOrDefault(u => u.telefono == this.telefono);
                if (telefonoExistente != null)
                {
                    MessageBox.Show($"Ya existe un usuario registrado con el telefono {this.telefono}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validación de Correo
                if (string.IsNullOrWhiteSpace(this.correo))
                {
                    MessageBox.Show("El correo no puede estar en blanco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var correoExistente = db.Usuario.FirstOrDefault(u => u.correo == this.correo);
                if (correoExistente != null)
                {
                    MessageBox.Show("Ya existe un usuario registrado con el mismo correo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Validación de edad
                if (string.IsNullOrWhiteSpace(this.edad.ToString()) || this.edad.ToString().Length != 1 || !this.edad.ToString().All(char.IsDigit))
                {
                    MessageBox.Show("El DNI debe tener 1 caracter numérico y no puede estar en blanco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                var nuevoPaciente = new PacienteM
                {
                    dni = this.dni,
                    nombre = this.nombre,
                    apellido = this.apellido,
                    fecha_nacimiento = this.fecha_nacimiento,
                    telefono = this.telefono,
                    correo = this.correo,
                    direccion = this.direccion,
                    edad = this.edad,
                    id_provincia = this.ProvinciaSeleccionada.id_provincia,
                    id_ciudad = this.CiudadSeleccionada.id_ciudad,
                    id_obra_social = this.ObraSeleccionado.id_obra_social,

                };

                db.Paciente.Add(nuevoPaciente);
                db.SaveChanges();
            }

            MessageBox.Show("Paciente registrado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancelar(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea cancelar la creación del paciente?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {

                dni = 0;
                OnPropertyChanged(nameof(dni));

                nombre = string.Empty;
                OnPropertyChanged(nameof(nombre));

                apellido = string.Empty;
                OnPropertyChanged(nameof(apellido));

                telefono = string.Empty;
                OnPropertyChanged(nameof(telefono));

                correo = string.Empty;
                OnPropertyChanged(nameof(correo));

                direccion = string.Empty;
                OnPropertyChanged(nameof(direccion));

                edad = 0;
                OnPropertyChanged(nameof(edad));

                ProvinciaSeleccionada = null;
                OnPropertyChanged(nameof(ProvinciaSeleccionada));

                CiudadSeleccionada = null;
                OnPropertyChanged(nameof(CiudadSeleccionada));

                ObraSeleccionado = null;
                OnPropertyChanged(nameof(ObraSeleccionado));

                MessageBox.Show("La operación de creación de paciente ha sido cancelada.", "Operación cancelada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void OnGoBack(object parameter)
        {
            var currentWindow = Application.Current.MainWindow as proyecto_MarderLezcano.Views.User.Menu;

            if (currentWindow != null)
            {

                var frame = currentWindow.FindName("Vistas") as Frame;

                if (frame != null && frame.NavigationService.CanGoBack)
                {
                    frame.NavigationService.GoBack();
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
