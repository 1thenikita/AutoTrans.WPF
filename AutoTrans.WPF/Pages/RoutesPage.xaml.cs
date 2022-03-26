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

        }
    }
}
