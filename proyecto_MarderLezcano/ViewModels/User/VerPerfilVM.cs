using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using proyecto_MarderLezcano.Models;
using proyecto_MarderLezcano.Commands;
using System.Windows;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualBasic.ApplicationServices;
using proyecto_MarderLezcano.Views.User;
using System.Windows.Controls;

namespace proyecto_MarderLezcano.ViewModels.User
{
    public class VerPerfilVM
    {

        private Frame _frame;
        public ICommand EditarPerfilCommand { get; private set; }

        public VerPerfilVM()
        {
            EditarPerfilCommand = new RelayCommand(ExecuteEditarPerfil);
        }

        private void ExecuteEditarPerfil(object parameter)
        {

            var idUsuario = (int)parameter; 
            var editarPerfilView = new Perfil(idUsuario); 
            _frame.Navigate(editarPerfilView);  
        }
    }
}
