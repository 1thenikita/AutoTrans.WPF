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
    /// Логика взаимодействия для RoutesPage.xaml
    /// </summary>
    public partial class RoutesPage : Page
    {
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        public RoutesPage()
        {
            InitializeComponent();

            dgRoutes.ItemsSource = Global.DB.Routes.ToList();
        }

        /// <summary>
        /// Обработчик изменения маршрута.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToRoute_Click(object sender, RoutedEventArgs e)
        {
            var route = (sender as Button).DataContext as Route;
            if (route == null)
                return;

            Global.MainFrame.Navigate(new RoutePage(route));
        }

        /// <summary>
        /// Обработчик обновления данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Global.DB.ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
            dgRoutes.ItemsSource = Global.DB.Routes.ToList();
        }

        /// <summary>
        /// Обработчик добавления маршрута.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new RoutePage());
        }
    }
}
