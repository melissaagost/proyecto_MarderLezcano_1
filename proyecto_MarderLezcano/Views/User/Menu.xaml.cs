using proyecto_MarderLezcano.Models;
using proyecto_MarderLezcano.ViewModels.User;
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

namespace proyecto_MarderLezcano.Views.User
{
    public partial class Menu : Window
    {
        public Menu(UsuarioM currentUser)
        {
            InitializeComponent();
            this.DataContext = new MenuVM(currentUser, Vistas);
        }


    }
}
