using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace proyecto_MarderLezcano.Database
{
    internal class DatabaseManager
    {
        private MySqlConnection connection;

        public DatabaseManager()
        {
            // Asegúrate de que el nombre de la conexión coincida con el nombre en App.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["medilink"].ConnectionString;
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                    MessageBox.Show("Conexión a la base de datos establecida con éxito.", "Conexión Exitosa", MessageBoxButton.OK, MessageBoxImage.Information);  // Mensaje de éxito
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }



        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar la conexión: {ex.Message}", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
