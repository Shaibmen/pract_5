using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public CustomerPage()
        {
            InitializeComponent();
            CustomerGrid.ItemsSource = farmBD.Customers.ToList();

            RoleBox.ItemsSource = farmBD.Roles.ToList();
            RoleBox.DisplayMemberPath = "RoleName";
            RoleBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            try
            {
                

                customers.FirstName = Name.Text;
                customers.LastName = SecondName.Text;
                customers.Email = EmailBox.Text;
                customers.Phone = NumberBox.Text;
                int selectedRole = (RoleBox.SelectedItem as Roles).RoleID;
                customers.Role_iD = Convert.ToInt32(selectedRole);

                string email = EmailBox.Text;
                bool isValid = IsValidEmail(email);
                if (IsTextBoxEmptyOrWhitespace(Name) || IsTextBoxEmptyOrWhitespace(SecondName) || IsTextBoxEmptyOrWhitespace(EmailBox) || IsTextBoxEmptyOrWhitespace(NumberBox))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                }

                if (isValid)
                {
                    farmBD.Customers.Add(customers);

                    farmBD.SaveChanges();
                    CustomerGrid.ItemsSource = farmBD.Customers.ToList();
                }
                else
                {
                    MessageBox.Show("Не верный формат почты");
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Значение полей почты и телефона должны быть уникальными");
                farmBD.Entry(customers).State = EntityState.Detached;
            }
            

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            try
            {
                if (CustomerGrid.SelectedItem != null)
                {
                    var selected = CustomerGrid.SelectedItem as Customers;

                    selected.FirstName = Name.Text;
                    selected.LastName = SecondName.Text;

                    selected.Email = EmailBox.Text;
                    string email = EmailBox.Text;
                    bool isValid = IsValidEmail(email);
                    if (isValid)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Не верный формат почты");
                    }

                    selected.Phone = NumberBox.Text;

                    int selectedRole = (RoleBox.SelectedItem as Roles).RoleID;
                    selected.Role_iD = Convert.ToInt32(selectedRole);
                    if (IsTextBoxEmptyOrWhitespace(Name) || IsTextBoxEmptyOrWhitespace(SecondName) || IsTextBoxEmptyOrWhitespace(EmailBox) || IsTextBoxEmptyOrWhitespace(NumberBox))
                    {
                        MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                    }
                }
                farmBD.SaveChanges();
                CustomerGrid.ItemsSource = farmBD.Customers.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Значение полей почты и телефона должны быть уникальными");
                farmBD.Entry(customers).State = EntityState.Detached;
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            try
            {
                farmBD.Customers.Remove(CustomerGrid.SelectedItem as Customers);
                farmBD.SaveChanges();
                CustomerGrid.ItemsSource = farmBD.Customers.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Нельзя удалять связанные значения");
                farmBD.Entry(customers).State = EntityState.Detached;
            }
            catch
            {
                MessageBox.Show("Нельзя удалять пустоту");
                farmBD.Entry(customers).State = EntityState.Detached;
            }

        }

        private void CustomerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerGrid.SelectedItem != null)
            {
                var selected = CustomerGrid.SelectedItem as Customers;

                Name.Text = selected.FirstName;
                SecondName.Text = selected.LastName;
                EmailBox.Text = selected.Email;
                NumberBox.Text = selected.Phone;


                int selectedRoleId = selected.Role_iD;
                var selectedRole = RoleBox.Items.OfType<Roles>().FirstOrDefault(r => r.RoleID == selectedRoleId);
                RoleBox.SelectedItem = selectedRole;
            }
        }

        private void RoleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; string text = textBox.Text;
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    textBox.Text = text.Remove(text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length; return;
                }
            }
        }

        private void SecondName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; string text = textBox.Text;
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    textBox.Text = text.Remove(text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length; return;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; string text = textBox.Text;
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    textBox.Text = text.Remove(text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length; return;
                }
            }
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }

    }
}
