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
using System.Windows.Shapes;

namespace ControlLaba
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            PageFrame.Content = new Roli();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Roli();
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new EmployeePage();
        }

        private void DataLoginButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new DataLoginPage();
        }
    }
}
