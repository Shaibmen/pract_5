using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для DataLoginPage.xaml
    /// </summary>
    public partial class DataLoginPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public DataLoginPage()
        {
            InitializeComponent();
            DataLoginGrid.ItemsSource = farmBD.LoginData.ToList();

            RoleIDBox.ItemsSource = farmBD.Roles.ToList();
            RoleIDBox.DisplayMemberPath = "RoleName";
            RoleIDBox.SelectedIndex = 0;

            EmployeeBox.ItemsSource = farmBD.Employees.ToList();
            EmployeeBox.DisplayMemberPath = "LastName";

            CustomerBox.ItemsSource = farmBD.Customers.ToList();
            CustomerBox.DisplayMemberPath = "LastName";

        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            LoginData logindata = new LoginData();
            try
            {
                logindata.Login = NameRole.Text;
                logindata.Password = PasswordRole.Text;

                int selectedRole = (RoleIDBox.SelectedItem as Roles).RoleID;
                logindata.Role_id = Convert.ToInt32(selectedRole);
                logindata.Roles = DataLoginGrid.SelectedItem as Roles;
                if (IsTextBoxEmptyOrWhitespace(NameRole) || IsTextBoxEmptyOrWhitespace(PasswordRole))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                }


                if (EmployeeBox.SelectedItem != null && CustomerBox.SelectedItem != null)
                {

                    MessageBox.Show("Нельзя сделать данные для входа для нескoльких людей");
                    return;
                }
                else if (EmployeeBox.SelectedItem != null)
                {
                    int selectedEmp = (EmployeeBox.SelectedItem as Employees).EmployeeID;
                    logindata.EmployeeID = Convert.ToInt32(selectedEmp);
                    logindata.Employees = DataLoginGrid.SelectedItem as Employees;
                    farmBD.LoginData.Add(logindata);
                }
                else if (CustomerBox.SelectedItem != null)
                {
                    int selectedCust = (CustomerBox.SelectedItem as Customers).CustomerID;
                    logindata.CustomerID = Convert.ToInt32(selectedCust);
                    logindata.Customers = DataLoginGrid.SelectedItem as Customers;
                    farmBD.LoginData.Add(logindata);
                }
                
                else
                {

                    MessageBox.Show("Необходимо выбрать работника или посетителя.");
                    return;
                }


                

                farmBD.SaveChanges();
                DataLoginGrid.ItemsSource = farmBD.LoginData.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Значения должны быть уникальными");
                farmBD.Entry(logindata).State = EntityState.Detached;
            }

            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            LoginData logindata = new LoginData();
            try
            {
                if (DataLoginGrid.SelectedItem != null)
                {

                    var selected = DataLoginGrid.SelectedItem as LoginData;

                    selected.Login = NameRole.Text;
                    selected.Password = PasswordRole.Text;

                    if (IsTextBoxEmptyOrWhitespace(NameRole) || IsTextBoxEmptyOrWhitespace(PasswordRole))
                    {
                        MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                    }

                    int selectedRole = (RoleIDBox.SelectedItem as Roles).RoleID;
                    selected.Role_id = Convert.ToInt32(selectedRole);
                    selected.Roles = DataLoginGrid.SelectedItem as Roles;
                }
                farmBD.SaveChanges();
                DataLoginGrid.ItemsSource = farmBD.LoginData.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Значения должны быть уникальными");
                farmBD.Entry(logindata).State = EntityState.Detached;
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("При изменении данных нужно менять и роль");
                farmBD.Entry(logindata).State = EntityState.Detached;
            }
}

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            LoginData loginData = new LoginData();
            try
            {
                farmBD.LoginData.Remove(DataLoginGrid.SelectedItem as LoginData);

                farmBD.SaveChanges();
                DataLoginGrid.ItemsSource = farmBD.LoginData.ToList();
            }
            catch
            {
                MessageBox.Show("нельзя удалить пустое");
                farmBD.Entry(loginData).State = EntityState.Detached;

            }

        }

        private void DataLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataLoginGrid.SelectedItem != null)
            {
                var selected = DataLoginGrid.SelectedItem as LoginData;

                int selectedRoleId = selected.Role_id;
                var selectedRole = RoleIDBox.Items.OfType<Roles>().FirstOrDefault(r => r.RoleID == selectedRoleId);
                RoleIDBox.SelectedItem = selectedRole;

                /*int selectedEmpId = (int)selected.EmployeeID;
                var selectedEpm = EmployeeBox.Items.OfType<Employees>().FirstOrDefault(r => (int)r.EmployeeID == selectedEmpId);
                EmployeeBox.SelectedItem = selectedEpm;

                int selectedCustId = (int)selected.Customer_id;
                var selectedCust = CustomerBox.Items.OfType<Customers>().FirstOrDefault(r => (int)r.CustomerID == selectedCustId);
                CustomerBox.SelectedItem = selectedCust;*/


                NameRole.Text = selected.Login;
                PasswordRole.Text = selected.Password;
            }
        }

        private void RoleIdBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EmployeeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CustomerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClearEmp_Click(object sender, RoutedEventArgs e)
        {
            EmployeeBox.ItemsSource = null;

            EmployeeBox.ItemsSource = farmBD.Employees.ToList();
            EmployeeBox.DisplayMemberPath = "LastName";

        }

        private void ClearCust_Click(object sender, RoutedEventArgs e)
        {
            CustomerBox.ItemsSource = null;

            CustomerBox.ItemsSource = farmBD.Customers.ToList();
            CustomerBox.DisplayMemberPath = "LastName";
        }

        private void NameRole_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }

        private void PasswordRole_TextChanged(object sender, TextChangedEventArgs e)
        {
 
        }
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }

    }
}
