using AutoTrans.WPF.Classes;
using AutoTrans.DB.Entities;
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
        /// <summary>
        /// Инициализация класса.
        /// </summary>
        public UsersPage()
        {
            InitializeComponent();
            dgUsers.ItemsSource = Global.DB.Users.ToList();
        }

        /// <summary>
        /// Обработчик изменения сотрудника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToUser_Click(object sender, RoutedEventArgs e)
        {
            var user = (sender as Button).DataContext as User;

            if (user == null) return;
            Global.MainFrame.Navigate(new UserPage(user));
            Global.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgUsers.ItemsSource = Global.DB.Users.ToList();

            if(user.ID == Global.MyUser.ID) Global.MyUser = user;
        }

        /// <summary>
        /// Обработчик удаления сотрудников.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedUsers = dgUsers.SelectedItems.Cast<User>().ToList();
            if (selectedUsers.Count == 0) return;

            if (selectedUsers.FirstOrDefault(_u => _u.ID == Global.MyUser.ID) != null) return;

            MessageBoxResult res = MessageBox.Show($"Удалить {selectedUsers.Count} сотрудников?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No) return;

            Global.DB.Users.RemoveRange(selectedUsers);
            Global.DB.SaveChanges();

            Global.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgUsers.ItemsSource = Global.DB.Users.ToList();
        }

        /// <summary>
        /// Обработчик добавления сотрудника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new UserPage());
            Global.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgUsers.ItemsSource = Global.DB.Users.ToList();
        }
    }
}
