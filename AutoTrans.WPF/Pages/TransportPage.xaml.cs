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
    }
}
