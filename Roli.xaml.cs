using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
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
using System.Data.SqlClient;

namespace ControlLaba
{
    /// <summary>
    /// Логика взаимодействия для Roli.xaml
    /// </summary>
    public partial class Roli : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public Roli()
        {
            InitializeComponent();
            RoliGrid.ItemsSource = farmBD.Roles.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Roles roles = new Roles();
            try
            {   
                roles.RoleName = NameBox.Text;

                if (IsTextBoxEmptyOrWhitespace(NameBox))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                }

                farmBD.Roles.Add(roles);

                farmBD.SaveChanges();
                RoliGrid.ItemsSource = farmBD.Roles.ToList();

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Название роли должно быть уникальным");
                farmBD.Entry(roles).State = EntityState.Detached;
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Roles roles = new Roles();
            try
            {
                if (RoliGrid.SelectedItem != null)
            {
                var selected = RoliGrid.SelectedItem as Roles;
                selected.RoleName = NameBox.Text;

                if(IsTextBoxEmptyOrWhitespace(NameBox))
                {
                        MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                    }
                }

            farmBD.SaveChanges();
            RoliGrid.ItemsSource = farmBD.Roles.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Название роли должно быть уникальным");
                farmBD.Entry(roles).State = EntityState.Detached;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Roles roles = new Roles();
            try
            {
                if (RoliGrid.SelectedItem != null)
                {
                    farmBD.Roles.Remove(RoliGrid.SelectedItem as Roles);
                }

                farmBD.SaveChanges();
                RoliGrid.ItemsSource = farmBD.Roles.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Нельзя удалить значение связанное ключом");
                farmBD.Entry(roles).State = EntityState.Detached;
            }
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void RoliGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoliGrid.SelectedItem != null)
            {
                var selected = RoliGrid.SelectedItem as Roles;
                NameBox.Text = selected.RoleName;

            }
        }
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
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

        private void Backup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection v = new SqlConnection(farmBD.Database.Connection.ConnectionString))
                {
                    v.Open();
                    using (SqlCommand j = new SqlCommand("dbo.FarmDatabase", v))
                    {
                        j.CommandType = CommandType.StoredProcedure;
                        j.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Бэкап успешно сделан");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сделаь бэкап обратитесть к сис. админу" + ex.Message);
            }
        }
    }
}
