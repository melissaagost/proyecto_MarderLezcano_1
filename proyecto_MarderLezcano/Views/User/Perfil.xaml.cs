using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using proyecto_MarderLezcano.Commands;
using proyecto_MarderLezcano.Models;

namespace proyecto_MarderLezcano.Views.User
{
    /// <summary>
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : Page
    {
        private int _idUsuario;

        public Perfil(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            CargarDatosUsuario(); // Cargar los datos del usuario al inicializar la página
        }

        private void CargarDatosUsuario()
        {
            using (var context = new ContextoBD())
            {
                var usuario = context.Usuario.FirstOrDefault(u => u.id_usuario == _idUsuario);

                if (usuario != null)
                {
                    NombreUsuarioTextBox.Text = usuario.usuario;
                    EmailTextBox.Text = usuario.correo;
                    TelefonoTextBox.Text = usuario.telefono;
                    DireccionTextBox.Text = usuario.direccion;
                    ContraseñaTextBox.Text = usuario.contraseña;
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }
            }
        }
    }
}
