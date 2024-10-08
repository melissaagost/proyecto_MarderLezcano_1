﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace proyecto_MarderLezcano.Models
{
    public class MenuItemModel
    {
        public string Name { get; set; }
        public ICommand Command { get; set; }
        //public Type ViewModelType { get; set; }

        public MenuItemModel(string name, ICommand command)
        {
            Name = name;
            Command = command;
        }
    }
}
