using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using proyecto_MarderLezcano.Models;



namespace proyecto_MarderLezcano.ViewModels
{
    public class MenuVM : BaseViewModel
    {
        //public ObservableCollection<MenuItemModel> MenuItems { get; set; }
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public ICommand ChangeViewCommand { get; }

        //public MenuVM()
        //{
        // Inicializa los ítems del menú
        //MenuItems = new ObservableCollection<MenuItemModel>
        //{
        //new MenuItemModel { Name = "Dashboard", ViewModelType = typeof(DashboardViewModel) },
        //new MenuItemModel { Name = "Citas Médicas", ViewModelType = typeof(AppointmentsViewModel) },
        //new MenuItemModel { Name = "Pacientes", ViewModelType = typeof(PatientsViewModel) },
        //new MenuItemModel { Name = "Médicos", ViewModelType = typeof(DoctorsViewModel) },
        //new MenuItemModel { Name = "Facturación", ViewModelType = typeof(BillingViewModel) },
        //new MenuItemModel { Name = "Reportes", ViewModelType = typeof(ReportsViewModel) },
        //new MenuItemModel { Name = "Configuración", ViewModelType = typeof(SettingsViewModel) }
        //};

        // Inicializa el comando para cambiar la vista
        //ChangeViewCommand = new RelayCommand(ChangeView);

        // Establece la vista inicial
        //CurrentViewModel = new DashboardViewModel();
        // }

        private void ChangeView(object viewModelType)
        {
            var viewModel = Activator.CreateInstance((Type)viewModelType) as BaseViewModel;
            CurrentViewModel = viewModel;
        }
    }
}
