using AutoTrans.WPF.Classes;
using AutoTrans.WPF.Entities;
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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            dgUsers.ItemsSource = Global.DB.Users.ToList();
        }

        private void btnGoToUser_Click(object sender, RoutedEventArgs e)
        {
            var user = (sender as Button).DataContext as User;

            if (user == null) return;
            Global.MainFrame.Navigate(new UserPage(user));
        }
    }
}
