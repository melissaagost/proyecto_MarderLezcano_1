using Microsoft.EntityFrameworkCore;
using OxyPlot;
using OxyPlot.Series;
using proyecto_MarderLezcano.Models;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace proyecto_MarderLezcano.Views.User
{
    /// <summary>
    /// Lógica de interacción para ReporteRecepcionista.xaml
    /// </summary>
    public partial class ReporteRecepcionista : Page
    {
        public PlotModel CitasPlotModel { get; private set; }
        private ContextoBD _context;
        public ReporteRecepcionista()
        {
            InitializeComponent();
            DataContext = this; // Esto es necesario para el binding
            CitasPlotModel = new PlotModel { Title = "Cantidad de Citas" };
            _context = new ContextoBD();

            // Cargar datos iniciales (puedes mostrar un periodo por defecto)
            CargarDatos(DateTime.Today.AddDays(-30), DateTime.Today);
        }
        private void CargarDatos(DateTime fechaInicio, DateTime fechaFin)
        {
            // Limpia el modelo anterior
            CitasPlotModel.Series.Clear();

            // Obtiene las citas del contexto
            var citas = _context.Citas
                .ToList()
                .Where(c => ConvertToDateTime(c.fecha) >= fechaInicio && ConvertToDateTime(c.fecha) <= fechaFin)
                .ToList();

            // Agrupar por fecha y contar citas
            var citasPorFecha = citas
                .GroupBy(c => ConvertToDateTime(c.fecha)) // Agrupamos también aquí
                .Select(g => new { Fecha = g.Key, Cantidad = g.Count() })
                .ToList();

            // Agregar series al gráfico
            var series = new ColumnSeries { Title = "Citas" };
            foreach (var item in citasPorFecha)
            {
                series.Items.Add(new ColumnItem(item.Cantidad));
            }

            CitasPlotModel.Series.Add(series);
        }

        // Ejemplo de método de conversión
        private DateTime ConvertToDateTime(DateTime date)
        {
            // Si ya estás usando un DateTime, no necesitas conversión adicional
            return date;
        }

        private void FiltroPeriodo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FiltroPeriodo.SelectedItem is ComboBoxItem selectedItem)
            {
                DateTime fechaInicio = DateTime.Today;
                DateTime fechaFin = DateTime.Today;

                switch (selectedItem.Content.ToString())
                {
                    case "Día":
                        fechaInicio = DateTime.Today;
                        fechaFin = DateTime.Today;
                        break;
                    case "Semana":
                        fechaInicio = DateTime.Today.AddDays(-7);
                        fechaFin = DateTime.Today;
                        break;
                    case "Mes":
                        fechaInicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        fechaFin = DateTime.Today;
                        break;
                    case "Año":
                        fechaInicio = new DateTime(DateTime.Today.Year, 1, 1);
                        fechaFin = DateTime.Today;
                        break;
                }

                // Cargar datos según el rango de fechas
                CargarDatos(fechaInicio, fechaFin);
            }
        }
    }
}
