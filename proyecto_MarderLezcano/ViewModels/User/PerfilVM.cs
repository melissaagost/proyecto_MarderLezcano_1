using proyecto_MarderLezcano.Commands;
using proyecto_MarderLezcano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using static Mysqlx.Crud.Order.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace proyecto_MarderLezcano.ViewModels.User
{
    public class PerfilVM : BaseViewModel
    {

        private int idUsuario;
        public int IdUsuario
        {
            get { return idUsuario; }
            set
            {
                idUsuario = value;
                OnPropertyChanged(nameof(IdUsuario));
            }
        }


        private string nombreUsuario;
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set
            {
                nombreUsuario = value;
                OnPropertyChanged(nameof(NombreUsuario));
            }
        }

     

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set
            {
                telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                OnPropertyChanged(nameof(Direccion));
            }
        }

        private string contraseña;
        public string Contraseña
        {
            get { return contraseña; }
            set
            {
                contraseña = value;
                OnPropertyChanged(nameof(Contraseña));
            }
        }
        public ICommand GuardarCommand { get; set; }

        public PerfilVM()
        {
            GuardarCommand = new RelayCommand(Guardar, CanGuardar);
        }


        private void Guardar(object parameter)
        {
            try
            {
                using (var context = new ContextoBD())
                {
                    var usuario = context.Usuario.FirstOrDefault(u => u.id_usuario == IdUsuario);

                    if (usuario != null)
                    {
                        context.Attach(usuario);
                        usuario.usuario = NombreUsuario;
                        usuario.correo = Email;
                        usuario.telefono = Telefono;
                        usuario.direccion = Direccion;
                        usuario.contraseña = Contraseña;

                        context.SaveChanges();
                    }
                    else
                    {
                        if (usuario == null)
                        {
                            MessageBox.Show("Usuario no encontrado");
                            return;
                        }

                    }
                }
                MessageBox.Show("Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message);
            }
        }

        private bool CanGuardar(object parameter)
        {
            // Lógica de validación para determinar si se puede guardar
            return !string.IsNullOrEmpty(NombreUsuario) && !string.IsNullOrEmpty(Email);
        }


    }
}

