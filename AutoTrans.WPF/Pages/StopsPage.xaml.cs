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
    /// Логика взаимодействия для StopsPage.xaml
    /// </summary>
    public partial class StopsPage : Page
    {
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        public StopsPage()
        {
            InitializeComponent();

            dgStops.ItemsSource = Global.DB.Stops.ToList();
        }

        /// <summary>
        /// Обработчик изменения остановки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToStop_Click(object sender, RoutedEventArgs e)
        {
            var stop = (sender as Button).DataContext as Stop;

            if (stop == null) return;

            Global.MainFrame.Navigate(new StopPage(stop));
            Global.DB.ChangeTracker.Entries().ToList().ForEach(s => s.Reload());
            dgStops.ItemsSource = Global.DB.Stops.ToList();
        }
        
        /// <summary>
        /// Обработчик добавления остановки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddStop_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new StopPage());
            Global.DB.ChangeTracker.Entries().ToList().ForEach(s => s.Reload());
            dgStops.ItemsSource = Global.DB.Stops.ToList();
        }

        /// <summary>
        /// Обработчик удаления остановки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteStop_Click(object sender, RoutedEventArgs e)
        {
            var stops = dgStops.SelectedItems.Cast<Stop>().ToList();

            if(stops.Count == 0) return;

            MessageBoxResult result = MessageBox.Show($"Вы точно хотите удалить {stops.Count} остановок?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No) return;

            Global.DB.Stops.RemoveRange(stops);
            Global.DB.SaveChanges();

            Global.DB.ChangeTracker.Entries().ToList().ForEach(s => s.Reload());
            dgStops.ItemsSource = Global.DB.Stops.ToList();
        }
    }
}
