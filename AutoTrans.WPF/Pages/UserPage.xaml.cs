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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        User currentUser;

        /// <summary>
        /// Обработчик добавления сотрудника.
        /// </summary>
        public UserPage()
        {
            InitializeComponent();
            Title = "Добавление сотрудника";
            currentUser = new User();

            cbRole.ItemsSource = Global.DB.Roles.ToList();
            cbCity.ItemsSource = Global.DB.Cities.ToList();
            DataContext = currentUser;
        }

        /// <summary>
        /// Обработчик изменения сотрудника.
        /// </summary>
        /// <param name="user"></param>
        public UserPage(User user)
        {
            InitializeComponent();
            Title = "Изменение сотрудника";
            cbRole.ItemsSource = Global.DB.Roles.ToList();
            cbCity.ItemsSource = Global.DB.Cities.ToList();
            currentUser = user;
            DataContext = currentUser;

            pbPassword.Password = currentUser.Password;
        }

        /// <summary>
        /// Обработчик сохранения изменений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (String.IsNullOrWhiteSpace(tbFirstName.Text))
                errors.AppendLine("Заполните имя.");
            if (String.IsNullOrWhiteSpace(tbLastName.Text))
                errors.AppendLine("Заполните фамилию.");
            if (String.IsNullOrWhiteSpace(tbLogin.Text))
                errors.AppendLine("Заполните логин.");
            if (String.IsNullOrWhiteSpace(tbGender.Text) || tbGender.Text.Length > 1)
                errors.AppendLine("Заполните пол (1 символ).");
            if (String.IsNullOrWhiteSpace(pbPassword.Password))
                errors.AppendLine("Заполните пароль.");

            currentUser.Password = pbPassword.Password;

            if(currentUser.ID == 0)
                Global.DB.Users.Add(currentUser);

            if(errors.Length != 0)
            {
                MessageBox.Show("Проверьте поля.\n" + errors, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Global.DB.SaveChanges();
        }
    }
}
