using proyecto_MarderLezcano.ViewModels;
using System.Windows.Controls;
using proyecto_MarderLezcano.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace proyecto_MarderLezcano.Views
{
    /// <summary>
    /// Lógica de interacción para FormularioInicioSesion.xaml
    /// </summary>
    public partial class FormularioInicioSesion : Page
    {
        public FormularioInicioSesion()
        {
            InitializeComponent();
            DataContext = new FormularioInicioSesionVM();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var viewModel = this.DataContext as FormularioInicioSesionVM;
            if (viewModel != null)
            {
                viewModel.Contrasena = passwordBox.Password;
            }
        }
    }
}

