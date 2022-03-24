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
        }

        /// <summary>
        /// Обработчик изменения страницы в главной рамке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frameMain_ContentRendered(object sender, EventArgs e)
        {
            lblTitle.Content = (frameMain.Content as Page).Title;
        }
    }
}
