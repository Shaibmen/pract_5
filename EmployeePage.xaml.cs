using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlLaba
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public List<String> Position = new List<string>();

        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public EmployeePage()
        {
            InitializeComponent();
            EmployeeGrid.ItemsSource = farmBD.Employees.ToList();

            Position.Add("Farmer");
            Position.Add("Manager");
            Position.Add("Worker");
            Position.Add("Supervisor");
            Position.Add("Assistant");
            PositionBox.ItemsSource = Position;
            PositionBox.SelectedIndex = 0;

            FarmIdBox.ItemsSource = farmBD.Farm.ToList();
            FarmIdBox.DisplayMemberPath = "FarmName";
            FarmIdBox.SelectedIndex = 0;

            RoleIdBox.ItemsSource = farmBD.Roles.ToList();
            RoleIdBox.DisplayMemberPath = "RoleName";
            RoleIdBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Employees employees = new Employees();
      
            employees.FirstName = NameBox.Text;
            employees.LastName = SecondNameBox.Text;
            employees.Position = PositionBox.Text;

            if (IsTextBoxEmptyOrWhitespace(NameBox) || IsTextBoxEmptyOrWhitespace(SecondNameBox))
            {
                MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
            }


            int selectedFarm = (FarmIdBox.SelectedItem as Farm).FarmID;
            int selectedRole = (RoleIdBox.SelectedItem as Roles).RoleID;

            employees.Farm_id = Convert.ToInt32(selectedFarm);
            employees.Role_iD = Convert.ToInt32(selectedRole);

            employees.Farm = FarmIdBox.SelectedItem as Farm;
            employees.Roles = RoleIdBox.SelectedItem as Roles;

            bool employeeExists = farmBD.Employees.Any(emp =>
            emp.FirstName == employees.FirstName &&
            emp.LastName == employees.LastName &&
            emp.Position == employees.Position &&
            emp.Role_iD == emp.Role_iD);

            if (employeeExists)
            {
                MessageBox.Show("Этот человек уже назначен на эту должность или роль.");
                return; 
            }

            farmBD.Employees.Add(employees);

            farmBD.SaveChanges();
            EmployeeGrid.ItemsSource = farmBD.Employees.ToList();
            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                var selected = EmployeeGrid.SelectedItem as Employees;
                selected.FirstName = NameBox.Text;
                selected.LastName = SecondNameBox.Text;
                selected.Position = PositionBox.Text;

                if (IsTextBoxEmptyOrWhitespace(NameBox) || IsTextBoxEmptyOrWhitespace(SecondNameBox))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                }

                int selectedFarm = (FarmIdBox.SelectedItem as Farm).FarmID;
                int selectedRole = (RoleIdBox.SelectedItem as Roles).RoleID;

                selected.Farm_id = Convert.ToInt32(selectedFarm);
                selected.Role_iD = Convert.ToInt32(selectedRole);

                selected.Farm = FarmIdBox.SelectedItem as Farm;
                selected.Roles = RoleIdBox.SelectedItem as Roles;
                bool employeeExists = farmBD.Employees.Any(emp =>
                emp.FirstName == selected.FirstName &&
                emp.LastName == selected.LastName &&
                emp.Position == selected.Position &&
                emp.Role_iD == emp.Role_iD);

                if (employeeExists)
                {
                    MessageBox.Show("Этот человек уже назначен на эту должность или роль.");
                    return;
                }
            }
            

            farmBD.SaveChanges();
            EmployeeGrid.ItemsSource = farmBD.Employees.ToList();


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Employees employees = new Employees();
            try
            {
                farmBD.Employees.Remove(EmployeeGrid.SelectedItem as Employees);

                farmBD.SaveChanges();
                EmployeeGrid.ItemsSource = farmBD.Employees.ToList();
            }
            catch
            {
                MessageBox.Show("Нельзя пустое удалять");
                farmBD.Entry(employees).State = EntityState.Detached;

            }

        }

        private void EmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (EmployeeGrid.SelectedItem != null)
            {
                var selected = EmployeeGrid.SelectedItem as Employees;
                var selectedEmployee = EmployeeGrid.SelectedItem as Employees;

                int selectedFarmId = selectedEmployee.Farm_id;
                var selectedFarm = FarmIdBox.Items.OfType<Farm>().FirstOrDefault(f => f.FarmID == selectedFarmId);
                FarmIdBox.SelectedItem = selectedFarm;

                int selectedRoleId = selectedEmployee.Role_iD;
                var selectedRole = RoleIdBox.Items.OfType<Roles>().FirstOrDefault(r => r.RoleID == selectedRoleId);
                RoleIdBox.SelectedItem = selectedRole;

                NameBox.Text = selected.FirstName;
                SecondNameBox.Text = selected.LastName;
                PositionBox.Text = selected.Position;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void PositionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FarmIdBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoleIdBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private void SecondNameBox_TextChanged(object sender, TextChangedEventArgs e)
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
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }

    }
}
