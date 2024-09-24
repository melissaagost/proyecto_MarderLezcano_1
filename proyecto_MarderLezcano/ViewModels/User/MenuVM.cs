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



namespace proyecto_MarderLezcano.ViewModels.User
{
    public class MenuVM : BaseViewModel
    {
        public RelayCommand MinimizeCommand { get; }

        //por cada vista
        public RelayCommand ShowDashboardCommand { get; }
        public RelayCommand CloseCommand { get; }


        //public ObservableCollection<MenuItemModel> MenuItems { get; set; }
        //private BaseViewModel _currentViewModel;
        //public BaseViewModel CurrentViewModel
        //{
        //    get { return _currentViewModel; }
        //    set { SetProperty(ref _currentViewModel, value); }
        //}

        //public ICommand ChangeViewCommand { get; }

        // Collection of dynamic items
        //private ObservableCollection<MenuItemModel> _menuItems;
        //public ObservableCollection<MenuItemModel> MenuItems
        //{
        //    get => _menuItems;
        //    set
        //    {
        //        _menuItems = value;
        //        OnPropertyChanged(nameof(MenuItems));
        //    }
        //}

        public MenuVM()
        {
            MinimizeCommand = new RelayCommand(OnMinimize);
            CloseCommand = new RelayCommand(OnClose);
            //por cada vista
            ShowDashboardCommand = new RelayCommand(ShowDashboard);

            // Inicializa los ítems del menú
            //var MenuItems = new ObservableCollection<MenuItemModel>

            //{
            //    new MenuItemModel("Dashboard", new RelayCommand(ShowDashboard)),
            //    //new MenuItemModel { Name = "Citas Médicas", ViewModelType = typeof(User.AppointmentsViewModel) },

            //};

            // Inicializa el comando para cambiar la vista
            //ChangeViewCommand = new RelayCommand(ChangeView);

            // Establece la vista inicial
            //CurrentViewModel = new DashboardVM();
        }

        // Command implementations
        private void ShowDashboard(object obj) => MessageBox.Show("New Command Executed!"); //hacer que muestre la vista con navigate to
       


        private void OnMinimize(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OnClose(object parameter)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
