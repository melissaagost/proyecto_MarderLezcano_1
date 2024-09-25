using proyecto_MarderLezcano.Models;
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
using proyecto_MarderLezcano.Models;

namespace proyecto_MarderLezcano.Views.User
{
    /// <summary>
    /// Interaction logic for NuevoUsuario.xaml
    /// </summary>
    public partial class NuevoUsuario : Page
    {
        public NuevoUsuario()
        {
            InitializeComponent();
            CargarPerfiles();

        }
        private void CargarPerfiles()
        {
            List<PerfilM> perfiles = PerfilM.ObtenerPerfiles();

            // Verificar que hay datos
            if (perfiles.Count > 0)
            {
                MessageBox.Show($"Perfiles cargados: {perfiles.Count}");
            }
            else
            {
                MessageBox.Show("No se cargaron perfiles");
            }

            // Asignar la lista de perfiles al ListBox
            PerfilesListBox.ItemsSource = perfiles;
        }
    }
}
