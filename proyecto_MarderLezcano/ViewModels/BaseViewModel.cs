using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace proyecto_MarderLezcano.ViewModels
{
    // BaseViewModel implementa INotifyPropertyChanged para que los ViewModels puedan notificar a la vista cuando cambian las propiedades.
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Evento que se dispara cuando una propiedad cambia de valor.
        public event PropertyChangedEventHandler PropertyChanged;

        // Método protegido para notificar cambios de propiedad.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Método para establecer el valor de una propiedad y notificar a la vista del cambio.
        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
