using Microsoft.EntityFrameworkCore;
using OxyPlot;
using OxyPlot.Series;
using proyecto_MarderLezcano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace proyecto_MarderLezcano.Views.User
{
    public partial class ReporteGestor : Page
    {
        public PlotModel CitasPorMedicoPlotModel { get; private set; }
        private ContextoBD _context;

        public ReporteGestor()
        {
            InitializeComponent();
            DataContext = this; // Para que el binding funcione correctamente
            CitasPorMedicoPlotModel = new PlotModel { Title = "Citas por Médico" };
            _context = new ContextoBD();

            // Cargar datos iniciales (por defecto los últimos 30 días)
            CargarDatos(DateTime.Today.AddDays(-30), DateTime.Today);
        }

        private void CargarDatos(DateTime fechaInicio, DateTime fechaFin)
        {
            // Limpiar el gráfico anterior
            CitasPorMedicoPlotModel.Series.Clear();

            // Obtener las citas en el rango de fechas seleccionado
            var citas = _context.Cita
                .Include(c => c.id_medico) // Asegúrate de que incluyes los datos del médico
                .Where(c => ConvertToDateTime(c.fecha) >= fechaInicio && ConvertToDateTime(c.fecha) <= fechaFin)
                .ToList();

            // Agrupar las citas por médico
            var citasPorMedico = citas
                .GroupBy(c => c.id_medico) // Agrupamos por el id
                .Select(g => new { Medico = g.Key, Cantidad = g.Count() })
                .ToList();

            // Crear una nueva serie de barras para representar las citas por médico
            var barSeries = new BarSeries { Title = "Citas por Médico", StrokeColor = OxyColors.Black, StrokeThickness = 1 };

            // Agregar los médicos y sus citas a la serie
            foreach (var item in citasPorMedico)
            {
                barSeries.Items.Add(new BarItem { Value = item.Cantidad });
            }

            // Establecer las etiquetas de los médicos en el eje Y
            CitasPorMedicoPlotModel.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                ItemsSource = citasPorMedico.Select(c => c.Medico)
            });

            // Agregar la serie al gráfico
            CitasPorMedicoPlotModel.Series.Add(barSeries);

            // Actualizar el gráfico
            CitasPorMedicoPlotModel.InvalidatePlot(true);
        }

        private DateTime ConvertToDateTime(DateTime date)
        {
            return date; // Si ya tienes un DateTime, no es necesaria más conversión
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

                // Cargar los datos con el rango de fechas seleccionado
                CargarDatos(fechaInicio, fechaFin);
            }
        }
    }
}