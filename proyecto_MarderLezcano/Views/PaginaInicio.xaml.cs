﻿using System;
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
            
        }
        // Método para cambiar la vista en el Frame
        public void NavigateTo(object page)
        {
            MainFrame.Navigate(page);
        }
    }
}
