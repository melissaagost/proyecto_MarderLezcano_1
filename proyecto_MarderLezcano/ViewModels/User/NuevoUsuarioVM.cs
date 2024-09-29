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
using System.Windows.Navigation;  

namespace proyecto_MarderLezcano.ViewModels.User
{
    class NuevoUsuarioVM : BaseViewModel 

        //PROPIEDADES

    {
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

        private string _usuario;
        public string usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    OnPropertyChanged(nameof(usuario));
                }
            }
        }

        private string _contraseña;
        public string contraseña
        {
            get { return _contraseña; }
            set
            {
                if (_contraseña != value)
                {
                    _contraseña = value;
                    OnPropertyChanged(nameof(contraseña));
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
                if (_correo!= value)
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

        private int _id_perfil;
        public int id_perfil
        {
            get { return _id_perfil; }
            set
            {
                _id_perfil = value;
                OnPropertyChanged(nameof(id_perfil));
            }
        }

        public ObservableCollection<ProvinciaM> ListaProvincias { get; set; }
        public ObservableCollection<CiudadM> ListaCiudades { get; set; }
        public ObservableCollection<PerfilM> ListaPerfiles { get; set; }





        // DECLARACIÓN DE COMANDOS
        public RelayCommand GoBackCommand { get; }
        public RelayCommand CloseCommand { get; }
        public RelayCommand CrearUsuarioCommand { get; }

        public RelayCommand CancelarCommand { get; }









       
        //METODO CONSTRUCTOR
        public NuevoUsuarioVM()
        {
            // Inicializar propiedades relacionadas con los datos del formulario
            dni = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            usuario = string.Empty;
            contraseña = string.Empty;
            telefono = string.Empty; 
            correo = string.Empty;
            direccion = string.Empty;


            // Cargar provincias u otros datos relacionados
            CargarProvincias();
            CargarCiudades();
            CargarPerfiles();

            GoBackCommand = new RelayCommand(OnGoBack);
            CrearUsuarioCommand = new RelayCommand(CrearUsuario);
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



        private PerfilM _perfilSeleccionado;
        public PerfilM PerfilSeleccionado
        {
            get { return _perfilSeleccionado; }
            set
            {
                _perfilSeleccionado = value;
                OnPropertyChanged(nameof(PerfilSeleccionado));
                id_perfil = _perfilSeleccionado?.id_perfil ?? 0;
            }
        }

        private void CargarPerfiles()
        {
            using (var db = new ContextoBD())
            {
                var perfiles = db.Perfil.ToList();
                ListaPerfiles = new ObservableCollection<PerfilM>(perfiles);
            }
        }

        private void CrearUsuario(object parameter)
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
                        MessageBox.Show($"Ya existe un usuario registrado con el DNI {this.dni}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Validación de Fecha de Nacimiento
                    if (this.fecha_nacimiento == DateTime.MinValue)
                    {
                        MessageBox.Show("Debe seleccionar una fecha de nacimiento.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Validación de Usuario
                    if (string.IsNullOrWhiteSpace(this.usuario))
                    {
                        MessageBox.Show("El nombre de usuario no puede estar en blanco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var usuarioExistente = db.Usuario.FirstOrDefault(u => u.usuario == this.usuario);
                    if (usuarioExistente != null)
                    {
                        MessageBox.Show("El nombre de usuario ya está en uso.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

                    // Validación de Contraseña
                    if (string.IsNullOrWhiteSpace(this.contraseña))
                    {
                        MessageBox.Show("La contraseña no puede estar en blanco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }


                var nuevoUsuario = new UsuarioM
                {
                    dni = this.dni,
                    nombre = this.nombre,
                    apellido = this.apellido,
                    usuario = this.usuario,
                    contraseña = this.contraseña,
                    fecha_nacimiento = this.fecha_nacimiento,
                    telefono = this.telefono,
                    correo = this.correo,
                    direccion = this.direccion,
                    status = "si",
                    id_provincia = this.ProvinciaSeleccionada.id_provincia,
                    id_ciudad = this.CiudadSeleccionada.id_ciudad,
                    id_perfil = this.PerfilSeleccionado.id_perfil,

                };

                db.Usuario.Add(nuevoUsuario);
                db.SaveChanges(); 
            }

            MessageBox.Show("Usuario creado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancelar(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea cancelar la creación del usuario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                
                dni = 0;
                OnPropertyChanged(nameof(dni));

                nombre = string.Empty;
                OnPropertyChanged(nameof(nombre));

                apellido = string.Empty;
                OnPropertyChanged(nameof(apellido));

                usuario = string.Empty;
                OnPropertyChanged(nameof(usuario));

                contraseña = string.Empty;
                OnPropertyChanged(nameof(contraseña));

                telefono = string.Empty;
                OnPropertyChanged(nameof(telefono));

                correo = string.Empty;
                OnPropertyChanged(nameof(correo));

                direccion = string.Empty;
                OnPropertyChanged(nameof(direccion));


                ProvinciaSeleccionada = null; 
                OnPropertyChanged(nameof(ProvinciaSeleccionada));

                CiudadSeleccionada = null;    
                OnPropertyChanged(nameof(CiudadSeleccionada));

                PerfilSeleccionado = null;    
                OnPropertyChanged(nameof(PerfilSeleccionado));

                MessageBox.Show("La operación de creación de usuario ha sido cancelada.", "Operación cancelada", MessageBoxButton.OK, MessageBoxImage.Information);
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
