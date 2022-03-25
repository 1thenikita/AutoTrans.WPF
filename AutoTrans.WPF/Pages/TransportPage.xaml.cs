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
    /// Логика взаимодействия для TransportPage.xaml
    /// </summary>
    public partial class TransportPage : Page
    {
        Transport currentTransport;

        /// <summary>
        /// Обработчик добавления транспорта.
        /// </summary>
        public TransportPage()
        {
            InitializeComponent();

            cbManufacturer.ItemsSource = Global.DB.Manufacrurers.ToList();
            cbTypeTransport.ItemsSource = Global.DB.TypesTransports.ToList();
            cbDriver.ItemsSource = Global.DB.Drivers.ToList();
            cbCity.ItemsSource = Global.DB.Cities.ToList();
            cbRoute.ItemsSource = Global.DB.Routes.ToList();

            currentTransport = new Transport();
            DataContext = currentTransport;
        }

        /// <summary>
        /// Обработчик изменения транспорта.
        /// </summary>
        /// <param name="transport"></param>
        public TransportPage(Transport transport)
        {
            InitializeComponent();

            cbManufacturer.ItemsSource = Global.DB.Manufacrurers.ToList();
            cbTypeTransport.ItemsSource = Global.DB.TypesTransports.ToList();
            cbDriver.ItemsSource = Global.DB.Drivers.ToList();
            cbCity.ItemsSource = Global.DB.Cities.ToList();
            cbRoute.ItemsSource = Global.DB.Routes.ToList();

            currentTransport = transport;
            DataContext = currentTransport;
        }
        /// <summary>
        /// Обработчик изменения производителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var manufactuter = cbManufacturer.SelectedItem as Manufacrurer;
            if (manufactuter == null)
            {
                cbModel.ItemsSource = null;
                return;
            }
            cbModel.ItemsSource = Global.DB.Models.Where(m => m.Manufacrurer.ID == manufactuter.ID).ToList();
            cbTypeTransport.SelectedItem = null;
        }

        /// <summary>
        /// Обработчик изменения типа транспорта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTypeTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTypeTransport.SelectedItem == null) return;

            var manufactuter = cbManufacturer.SelectedItem as Manufacrurer;
            var model = cbModel.SelectedItem as Model;
            var typeTransport = cbTypeTransport.SelectedItem as TypesTransport;

            if (manufactuter == null)
            {
                cbModel.ItemsSource = null;
                return;
            }

            cbModel.ItemsSource = Global.DB.Models.Where(m => m.TypesTransport.ID == typeTransport.ID && m.Manufacrurer.ID == manufactuter.ID).ToList();
        }

        /// <summary>
        /// Обработчик изменения модели транспорта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var model = cbModel.SelectedItem as Model;

            if (model == null) return;

            cbTypeTransport.SelectedItem = model.TypesTransport;
        }

        /// <summary>
        /// Обработчик изменения города
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var city = cbCity.SelectedItem as City;
            if(city == null) return;
            cbDriver.ItemsSource = Global.DB.Drivers.Where(d => d.City.ID == city.ID).ToList();
            cbRoute.ItemsSource = Global.DB.Routes.Where(r => r.City.ID == city.ID).ToList();
        }

        /// <summary>
        /// Обработчик изменения водителя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDriver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var driver = cbDriver.SelectedItem as Driver;
            if(driver == null) return;
            lblDriverFullName.Content = driver.LastName + " " + driver.FirstName + " " + driver.MiddleName;
            cbCity.SelectedItem = driver.City;
        }

        /// <summary>
        /// Обработчик просмотра информации о маршруте.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var route = cbRoute.SelectedItem as Route;
            if(route == null) return;
            lblRouteName.Content = route.StopsInRoutes.FirstOrDefault(st => st.Position == 0).Stop.Name + " - " + route.StopsInRoutes.FirstOrDefault(st => st.Position == -1).Stop.Name;
        }

        /// <summary>
        /// Обработчик сохранения транспорта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
