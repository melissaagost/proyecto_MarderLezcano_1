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



namespace proyecto_MarderLezcano.ViewModels.User
{
    public class MenuVM : BaseViewModel
    {
        public RelayCommand MinimizeCommand { get; }
        public RelayCommand CloseCommand { get; }
        //public ObservableCollection<MenuItemModel> MenuItems { get; set; }
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public ICommand ChangeViewCommand { get; }

        public MenuVM()
        {
            MinimizeCommand = new RelayCommand(OnMinimize);
            CloseCommand = new RelayCommand(OnClose);
            // Inicializa los ítems del menú
            var MenuItems = new ObservableCollection<MenuItemModel>

            {
                new MenuItemModel { Name = "Dashboard", ViewModelType = typeof(DashboardVM) },
                //new MenuItemModel { Name = "Citas Médicas", ViewModelType = typeof(User.AppointmentsViewModel) },
               
            };

           // Inicializa el comando para cambiar la vista
           ChangeViewCommand = new RelayCommand(ChangeView);

           // Establece la vista inicial
            CurrentViewModel = new DashboardVM();
        }

        private void ChangeView(object viewModelType)
        {
            var viewModel = Activator.CreateInstance((Type)viewModelType) as BaseViewModel;
            CurrentViewModel = viewModel;
        }
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
