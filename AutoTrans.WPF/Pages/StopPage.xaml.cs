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
    /// Логика взаимодействия для StopPage.xaml
    /// </summary>
    public partial class StopPage : Page
    {
        Stop currentStop;
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        public StopPage()
        {
            InitializeComponent();

            cbCity.ItemsSource = Global.DB.Cities.ToList(); 
            currentStop = new Stop();
            DataContext = currentStop;
        }

        /// <summary>
        /// Инициализация класса для изменения остановки.
        /// </summary>
        /// <param name="stop">Остановка</param>
        public StopPage(Stop stop)
        {
            InitializeComponent();

            cbCity.ItemsSource = Global.DB.Cities.ToList();
            currentStop = stop;
            DataContext = currentStop;
        }

        /// <summary>
        /// Обработчик сохранения остановки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (String.IsNullOrWhiteSpace(tbName.Text))
                errors.AppendLine("Заполните название.");
            if (String.IsNullOrWhiteSpace(tbDescription.Text))
                errors.AppendLine("Заполните описание.");
            if (cbCity.SelectedItem == null)
                errors.AppendLine("Укажите город.");
            if (String.IsNullOrWhiteSpace(tbGeoPosition.Text))
                errors.AppendLine("Заполните геопозицию.");

            if(errors.Length != 0)
            {
                MessageBox.Show("Исправьте ошибки.\n" + errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(currentStop.ID == 0)
                Global.DB.Stops.Add(currentStop);

            Global.DB.SaveChanges();
        }
    }
}
