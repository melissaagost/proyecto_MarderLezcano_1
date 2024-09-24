using proyecto_MarderLezcano.Database;
using System.Configuration;
using System.Data;
using System.Windows;

namespace proyecto_MarderLezcano
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string connectionString = ConfigurationManager.ConnectionStrings["medilink"].ConnectionString;
        // Puedes usar esta cadena de conexión para conectar con la base de datos


        //establecemos conexion y muestra mensaje si hay error
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
                DatabaseManager dbManager = new DatabaseManager();
                if (!dbManager.OpenConnection()) // Intenta abrir la conexión al inicio
                {
                    MessageBox.Show("No se pudo conectar a la base de datos. Por favor, verifica tu conexión o configuración.", "Error de Conexión", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Shutdown(); // Cierra la aplicación si no puede conectar
                }
            }
        

    }

}
