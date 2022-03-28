using AutoTrans.DB.Entities;
using AutoTrans.WPF.Classes;
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

namespace AutoTrans.WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoutePage.xaml
    /// </summary>
    public partial class RoutePage : Page
    {
        Route currentRoute;

        /// <summary>
        /// Инициализация создания маршрута.
        /// </summary>
        public RoutePage()
        {
            InitializeComponent();

            cbCity.ItemsSource = Global.DB.Cities.ToList();
            cbTypeRoute.ItemsSource = Global.DB.TypesRoutes.ToList();

            dpStart.DisplayDateStart = DateTime.Now;
            dpEnd.DisplayDateStart = DateTime.Now;

            currentRoute = new Route();
            DataContext = currentRoute;
        }

        /// <summary>
        /// Инициализация изменения маршрута.
        /// </summary>
        /// <param name="route"></param>
        public RoutePage(Route route)
        {
            InitializeComponent();

            cbCity.ItemsSource = Global.DB.Cities.ToList();
            cbTypeRoute.ItemsSource = Global.DB.TypesRoutes.ToList();

            dpStart.DisplayDateStart = DateTime.Now;
            dpEnd.DisplayDateStart = DateTime.Now;

            currentRoute = route;
            DataContext = currentRoute;
        }

        /// <summary>
        /// Обработчик сохранения маршрута.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (String.IsNullOrWhiteSpace(currentRoute.Number))
                errors.AppendLine("Заполните номер маршрута.");
            if(currentRoute.City == null)
                errors.AppendLine("Заполните город.");
            if (currentRoute.DateEnd.Date < currentRoute.DateStart.Date)
                errors.AppendLine("Дата завершения маршрута не может быть раньше даты начала маршрута.");
            if (currentRoute.Frequency == null || currentRoute.Frequency == 0)
                errors.AppendLine("Укажите частоту хождения транспорта.");
            if(currentRoute.TypesRoute == null)
                errors.AppendLine("Укажите тип маршрута.");

            if(errors.Length > 0)
            {
                MessageBox.Show($"Исправьте ошибки.\n{errors}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(currentRoute.ID == 0)
                Global.DB.Routes.Add(currentRoute);

            Global.DB.SaveChanges();
        }
    }
}
