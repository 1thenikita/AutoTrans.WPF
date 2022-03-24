using AutoTrans.WPF.Classes;
using AutoTrans.WPF.Pages;
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

namespace AutoTrans.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Global.MainFrame = frameMain;
            Global.MainFrame.Navigate(new AuthPage());

            try
            {
                Global.DB = new Entities.DBEntities();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Критическая ошибка.\n\n" + exp.Message, "Ошибка Базы Данных.", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Обработчик изменения страницы в главной рамке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frameMain_ContentRendered(object sender, EventArgs e)
        {
            var title = (frameMain.Content as Page).Title;
            lblTitle.Content = title;

            if(title == "Аутентификация")
            {
                Global.MyUser = null;
                gridUserData.Visibility = Visibility.Hidden;
            }
            else if (title == "Главное меню")
            {
                lblUserFullName.Content = "Здравствуйте, " + Global.MyUser.LastName + " " + Global.MyUser.FirstName + " " + Global.MyUser.MiddleName;
                gridUserData.Visibility = Visibility.Visible;
            }
            else
            {
                gridUserData.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Обработчик кнопки выхода из аккаунта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (!Global.MainFrame.CanGoBack) return;

            Global.MainFrame.RemoveBackEntry();
            Global.MainFrame.Navigate(new AuthPage());
            Global.MyUser = null;
        }
    }
}
