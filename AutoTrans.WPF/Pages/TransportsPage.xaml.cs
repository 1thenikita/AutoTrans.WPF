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

            dgTransports.ItemsSource = Global.DB.Transports.ToList();
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
    }
}
