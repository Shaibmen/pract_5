using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ControlLaba
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password =PasswordBox.Password;

            var user = farmBD.LoginData.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
/*                MessageBox.Show("Авторизация прошла успешно!");*/
                if (user.Role_id.Equals(1))
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close(); 
                }
                else if (user.Role_id.Equals(2))
                {
                    SkladWindow skladWindow = new SkladWindow();
                    skladWindow.Show();
                    this.Close();
                }
                else if (user.Role_id != 1 && user.Role_id != 2)
                {
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    this.Close();
                }
/*                MessageBox.Show($"Login: {login}, Password: {password}, Role: {user.Role_id}");*/
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void TextBox_Login(object sender, TextChangedEventArgs e)
        {

        }

    }
}
