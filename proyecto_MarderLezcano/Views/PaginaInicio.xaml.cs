using proyecto_MarderLezcano.ViewModels;
using System.Windows.Controls;
using System.Windows;
using proyecto_MarderLezcano.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace proyecto_MarderLezcano.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PaginaInicio : Window
    {
        public PaginaInicio()
        {
            InitializeComponent();
            this.DataContext = new PaginaInicioVM(); // Asigna el ViewModel
        }

        // Método para cambiar la vista en el Frame
        public void NavigateTo(Page page)
        {
            //MainFrame.Navigate(page);
            MainFrame.NavigationService.Navigate(page);

        }
        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}