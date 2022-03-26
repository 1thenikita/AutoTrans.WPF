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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        public MenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик просмотра сотрудников.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new Pages.UsersPage());
        }

        /// <summary>
        /// Обработчик просмотра водителей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrivers_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new Pages.DriversPage());
        }

        /// <summary>
        /// Обработчик просмотра транспорта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransports_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new Pages.TransportsPage());
        }

        /// <summary>
        /// Обработчик просмотра маршрутов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoutes_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new Pages.RoutesPage());
        }

        /// <summary>
        /// Обработчик просмотра остановок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStops_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new Pages.StopsPage());
        }
    }
}
