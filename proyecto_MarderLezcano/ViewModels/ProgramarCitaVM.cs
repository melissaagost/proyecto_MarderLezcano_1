using proyecto_MarderLezcano.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace proyecto_MarderLezcano.ViewModels
{
    public class ProgramarCitaVM
    {
        public ICommand AgendarCommand { get; private set; }

        public ProgramarCitaVM()
        {
            AgendarCommand = new RelayCommand(AgendarExecute, PuedeAgendarExecute);
        }

        private bool PuedeAgendarExecute(object parameter)
        {
            // Aquí puedes poner lógica para habilitar el botón, por ejemplo, verificar que todos los campos estén completos
            return true;
        }

        private void AgendarExecute(object parameter)
        {
            // Aquí va la lógica que se ejecutará cuando se presione el botón Agendar
            MessageBox.Show("Cita agendada con éxito!");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
