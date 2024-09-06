using proyecto_MarderLezcano.ViewModels;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using proyecto_MarderLezcano.ViewModels;


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
            DataContext = new PaginaInicioVM(); // Asegúrate de que el DataContext esté configurado

        }
        // Método para cambiar la vista en el Frame
        public void NavigateTo(Page page)
        {
            MainFrame.Navigate(page);
        }
    }
}