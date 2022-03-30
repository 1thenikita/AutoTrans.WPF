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
    /// Логика взаимодействия для TransportsPage.xaml
    /// </summary>
    public partial class TransportsPage : Page
    {
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        public TransportsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик изменения транспорта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToTransport_Click(object sender, RoutedEventArgs e)
        {
            var transport = (sender as Button).DataContext as Transport;

            if (transport == null) return;

            Global.MainFrame.Navigate(new TransportPage(transport));
        }

        /// <summary>
        /// Обработчик добавления транспорта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTransport_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new TransportPage());
        }

        /// <summary>
        /// Обработчик обновления данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Global.DB.ChangeTracker.Entries().ToList().ForEach(r => r.Reload());
            dgTransports.ItemsSource = Global.DB.Transports.ToList();
        }

        /// <summary>
        /// Обработчик удаления данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveTransport_Click(object sender, RoutedEventArgs e)
        {
            var transports = dgTransports.SelectedItems as List<Transport>;
            if (transports == null) return;

            MessageBoxResult result = MessageBox.Show($"Вы действительно хотите удалить {transports.Count} предметов?", "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No) return;

            Global.DB.Transports.RemoveRange(transports);
            Global.DB.SaveChanges();

            Global.DB.ChangeTracker.Entries().ToList().ForEach(r => r.Reload());
            dgTransports.ItemsSource = Global.DB.Transports.ToList();
        }
    }
}
