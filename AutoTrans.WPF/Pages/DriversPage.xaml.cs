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
    /// Логика взаимодействия для DriversPage.xaml
    /// </summary>
    public partial class DriversPage : Page
    {
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        public DriversPage()
        {
            InitializeComponent();

            dgDrivers.ItemsSource = Global.DB.Drivers.ToList();
        }

        /// <summary>
        /// Обработчик изменения водителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToDriver_Click(object sender, RoutedEventArgs e)
        {
            var driver = dgDrivers.SelectedItem as Driver;
            if (driver == null) return;

            Global.MainFrame.Navigate(new DriverPage(driver));

            Global.DB.ChangeTracker.Entries().ToList().ForEach(r => r.Reload());
            dgDrivers.ItemsSource = Global.DB.Drivers.ToList();
        }

        /// <summary>
        /// Обработчик добавления водителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new DriverPage());

            Global.DB.ChangeTracker.Entries().ToList().ForEach(r => r.Reload());
            dgDrivers.ItemsSource = Global.DB.Drivers.ToList();
        }

        /// <summary>
        /// Обработчик удаления водителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDriver_Click(object sender, RoutedEventArgs e)
        {
            var drivers = dgDrivers.SelectedItems.Cast<Driver>().ToList();
            if(drivers.Count == 0) return;

            MessageBoxResult res = MessageBox.Show($"Вы точно хотите удалить {drivers.Count} водителей?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (res == MessageBoxResult.No) return;

            Global.DB.Drivers.RemoveRange(drivers);
            Global.DB.SaveChanges();

            Global.DB.ChangeTracker.Entries().ToList().ForEach(r => r.Reload());
            dgDrivers.ItemsSource = Global.DB.Drivers.ToList();
        }
    }
}
