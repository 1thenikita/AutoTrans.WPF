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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        public AuthPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик начала аутентификации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbLogin.Text) || String.IsNullOrWhiteSpace(pbPassword.Password)) return;

            var login = tbLogin.Text;
            var password = pbPassword.Password;

            Global.MyUser = Global.DB.Users.FirstOrDefault(_u => _u.Login == login && _u.Password == password);

            if(Global.MyUser == null)
            {
                MessageBox.Show("Пользователь не найден.\nПроверьте ввод данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Global.MyUser.LastEnter = DateTime.Now;
            Global.DB.SaveChanges();

            Global.MainFrame.Navigate(new Pages.MenuPage());
        }

        /// <summary>
        /// Обработчик перехода от логина к паролю.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                pbPassword.Focus();
        }

        private void pbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnLogin_Click(null, null);
        }
    }
}
