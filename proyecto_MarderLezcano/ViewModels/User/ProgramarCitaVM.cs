using proyecto_MarderLezcano.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Collections.ObjectModel;
using proyecto_MarderLezcano.Models;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Navigation;
using Microsoft.EntityFrameworkCore;
using static Mysqlx.Crud.Order.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_MarderLezcano.ViewModels.User
{
    public class ProgramarCitaVM : BaseViewModel
    {
        //PROPIEDADES

        private int _dni;
        private string _motivo;
        private DateTime _fecha_seleccionada;
        private string _status; // Nueva propiedad para el estado de la cita (activa o cancelada)
        private MedicoM _medico_seleccionado;
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

        public string motivo
        {
            get { return _motivo; }
            set
            {
                if (_motivo != value)
                {
                    _motivo = value;
                    OnPropertyChanged(nameof(motivo));
                }
            }
        }

        public DateTime fecha_seleccionada
        {
            get { return _fecha_seleccionada; }
            set
            {
                if (_fecha_seleccionada != value)
                {
                    _fecha_seleccionada = value;
                    OnPropertyChanged(nameof(fecha_seleccionada));
                }
            }
        }

        //public ObservableCollection<MedicoM> lista_medicos
        //{
          //  get { return _lista_medicos; }
            //set
            //{
              //  if (_lista_medicos != value)
               // {
                 //   _lista_medicos = value;
                 //   OnPropertyChanged(nameof(lista_medicos));
                //}
            //}
        //}

        public MedicoM medico_seleccionado
        {
            get { return _medico_seleccionado; }
            set
            {
                if (_medico_seleccionado != value)
                {
                    _medico_seleccionado = value;
                    OnPropertyChanged(nameof(medico_seleccionado));
                }
            }
        }

        public string status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(status));
                }
            }
        }

        public ObservableCollection<MedicoM> lista_medicos { get; set; }
        public ObservableCollection<PacienteM> ListaPacientes { get; set; }



        // DECLARACIÓN DE COMANDOS
        public RelayCommand GoBackCommand { get; }
        public RelayCommand CloseCommand { get; }
        public RelayCommand AgendarCitaCommand { get; }
        public RelayCommand CancelarCommand { get; }
        public RelayCommand BuscarPacientePorDniCommand { get; }

        //METODO CONSTRUCTOR

        public ProgramarCitaVM()
        {
            // Inicializar propiedades relacionadas con los datos del formulario
            dni = 0;
            motivo = string.Empty;
            fecha_seleccionada = DateTime.MinValue;
            status = "activa"; // Estatus por defecto
            medico_seleccionado = null;
            
            CargarMedicos(); // Llama a este método para cargar los médicos al iniciar
            GoBackCommand = new RelayCommand(OnGoBack);
            AgendarCitaCommand = new RelayCommand(AgendarCita);
            CancelarCommand = new RelayCommand(Cancelar);
            BuscarPacientePorDniCommand = new RelayCommand(BuscarPacientePorDniExecute);
        }


        private PacienteM _paciente;
        public PacienteM Paciente

        {
            get { return _paciente; }
            set
            {
                _paciente = value;
                OnPropertyChanged(nameof(Paciente));
                dni = _paciente?.dni ?? 0;
            }
        }

        private void CargarPaciente()
        {
            using (var db = new ContextoBD())
            {
                var pacientes = db.Paciente.ToList();
                ListaPacientes = new ObservableCollection<PacienteM>(pacientes);
            }

        }
        private bool PuedeBuscarPacienteExecute(object parameter)
        {
            string dniString = dni.ToString();

            return !string.IsNullOrEmpty(dniString) && dniString.Length == 8;
        }

        private void BuscarPacientePorDniExecute(object parameter)
        {
            try
            {
                using (var db = new ContextoBD())
                {
                    // Consulta para buscar el paciente por DNI
                    string query = "SELECT COUNT(*) FROM paciente WHERE DNI = @dni";
                    MySqlCommand cmd = new MySqlCommand(query, db.Database.GetDbConnection() as MySqlConnection);
                    cmd.Parameters.AddWithValue("@dni", dni);

                    // Verificar si el paciente existe
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // Si existe, obtener los datos del paciente
                        query = "SELECT * FROM paciente WHERE DNI = @dni";
                        cmd = new MySqlCommand(query, db.Database.GetDbConnection() as MySqlConnection);
                        cmd.Parameters.AddWithValue("@dni", dni);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Suponiendo que tienes una clase Paciente con propiedades como Nombre, etc.
                                var paciente = new PacienteM
                                {
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),

                                    // Agregar aquí otras propiedades según tu modelo de datos
                                };

                                // Manejar el paciente encontrado
                                MessageBox.Show($"Paciente encontrado: {paciente.nombre  }");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("DNI no registrado en el sistema.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error de conexión a la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
       

        private void CargarMedicos()
        {
            using (var db = new ContextoBD())
            {
                // Asegúrate de que esto coincida con la definición en tu contexto
                var medicos = db.Medico.ToList(); // Cambié Medico a Medicos
                lista_medicos = new ObservableCollection<MedicoM>(medicos);
            }

            // Verificar si hay datos
            foreach (var medico in lista_medicos)
            {
                Console.WriteLine($"Médico: {medico.id_medico}");
            }
        }

        private bool PuedeAgendarExecute(object parameter)
        {
            // Verificar que todos los campos estén completos para habilitar el botón Agendar
            return !string.IsNullOrWhiteSpace(dni) && medico_seleccionado != null
                   && !string.IsNullOrWhiteSpace(motivo);
        }

        private void AgendarCita(object parameter)
        {
            try
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
                    // Validación de Fecha 
                    if (this.fecha_seleccionada == DateTime.MinValue)
                    {
                        MessageBox.Show("Debe seleccionar una fecha para la cita.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    // Validación de Motivo
                    if (string.IsNullOrWhiteSpace(this.motivo))
                    {
                        MessageBox.Show("El motivo no puede estar en blanco.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    // Validación de Medico
                    if (string.IsNullOrWhiteSpace(this.medico_seleccionado))
                    {
                        MessageBox.Show("Debe elegir un medico para la cita.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var nuevaCita = new CitaM
                    {
                        dni = this.dni,
                        motivo = this.motivo,
                        fecha_seleccionada = this.fecha_seleccionada,
                        status = "activa", // Estatus por defecto
                        medico_seleccionado = this.medico_seleccionado,
                    };

                    // Guardar la cita en la base de datos
                    db.Cita.Add(nuevaCita);
                    db.SaveChanges();
                }
            MessageBox.Show("Cita agendada con éxito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agendar la cita: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Cancelar(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea cancelar la creación del usuario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {

                dni = 0;
                OnPropertyChanged(nameof(dni));

                motivo = string.Empty;
                OnPropertyChanged(nameof(motivo));

                fecha_seleccionada = DateTime.MinValue;
                OnPropertyChanged(nameof(fecha_seleccionada));

                medico_seleccionado = null;
                OnPropertyChanged(nameof(medico_seleccionado));

                MessageBox.Show("La operación de creación de cita ha sido cancelada.", "Operación cancelada", MessageBoxButton.OK, MessageBoxImage.Information);
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