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
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : Page
    {
        Driver currentDriver;

        /// <summary>
        /// Обработчик добавления водителя.
        /// </summary>
        public DriverPage()
        {
            InitializeComponent();
            cbCity.ItemsSource = Global.DB.Cities.ToList();
            currentDriver = new Driver();
            DataContext = currentDriver;
            Title = "Добавление водителя";
        }

        /// <summary>
        /// Обработчик изменения водителя.
        /// </summary>
        /// <param name="driver"></param>
        public DriverPage(Driver driver)
        {
            InitializeComponent();
            cbCity.ItemsSource = Global.DB.Cities.ToList();
            currentDriver = driver;
            DataContext = currentDriver;
            Title = "Изменение водителя";
        }

        /// <summary>
        /// Обработчик сохранения водителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (String.IsNullOrWhiteSpace(currentDriver.LastName))
                errors.AppendLine("Заполните фамилию.");
            if (String.IsNullOrWhiteSpace(currentDriver.FirstName))
                errors.AppendLine("Заполните имя.");
            if (currentDriver.City == null)
                errors.AppendLine("Заполните город.");
            if(currentDriver.Gender.Length > 1 || String.IsNullOrWhiteSpace(currentDriver.Gender))
                errors.AppendLine("Укажите пол.");

            if(errors.Length != 0)
            {
                MessageBox.Show("Исправьте ошибки.\n" + errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentDriver.ID == 0)
                Global.DB.Drivers.Add(currentDriver);

            Global.DB.SaveChanges();
        }
    }
}
