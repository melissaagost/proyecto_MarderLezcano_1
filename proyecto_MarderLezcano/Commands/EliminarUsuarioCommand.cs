using proyecto_MarderLezcano.Models;
using proyecto_MarderLezcano.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace proyecto_MarderLezcano.Commands
{
    public class EliminarUsuarioCommand : ICommand
    {
        private readonly ListadoUsuariosVM _viewModel;

        public EliminarUsuarioCommand(ListadoUsuariosVM viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return parameter is UsuarioM; // El comando puede ejecutarse si el parámetro es de tipo UsuarioM
        }

        public void Execute(object parameter)
        {
            if (parameter is UsuarioM usuario)
            {
                _viewModel.CambiarStatusUsuario(usuario); // Llama al método para cambiar el estado del usuario
            }
        }
    }

}