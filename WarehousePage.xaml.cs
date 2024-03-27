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
    /// Логика взаимодействия для WarehousePage.xaml
    /// </summary>
    public partial class WarehousePage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public WarehousePage()
        {
            InitializeComponent();
            WarehouseGrid.ItemsSource = farmBD.Warehouse.ToList();
            FarmBox.ItemsSource = farmBD.Farm.ToList();
            FarmBox.DisplayMemberPath = "FarmName";
            FarmBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.WarehouseName = WarenameBox.Text;
            warehouse.Location = AddressBox.Text;

            int selectedFram = (FarmBox.SelectedItem as Farm).FarmID;
            warehouse.Farm_id = Convert.ToInt32(selectedFram);

            if (IsTextBoxEmptyOrWhitespace(WarenameBox) || IsTextBoxEmptyOrWhitespace(AddressBox))
            {
                MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
            }


            farmBD.Warehouse.Add(warehouse);

            farmBD.SaveChanges();
            WarehouseGrid.ItemsSource = farmBD.Warehouse.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (WarehouseGrid.SelectedItem != null)
            {
                var selected = WarehouseGrid.SelectedItem as Warehouse;
                selected.WarehouseName = WarenameBox.Text;
                selected.Location = AddressBox.Text;

                int selectedFram = (FarmBox.SelectedItem as Farm).FarmID;
                selected.Farm_id = Convert.ToInt32(selectedFram);

                if (IsTextBoxEmptyOrWhitespace(WarenameBox) || IsTextBoxEmptyOrWhitespace(AddressBox))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                }

            }
            farmBD.SaveChanges();
            WarehouseGrid.ItemsSource = farmBD.Warehouse.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse = new Warehouse();
            try
            {
                farmBD.Warehouse.Remove(WarehouseGrid.SelectedItem as Warehouse);
                farmBD.SaveChanges();
                WarehouseGrid.ItemsSource = farmBD.Warehouse.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Нельзя удалять связанные значения");
                farmBD.Entry(warehouse).State = EntityState.Detached;
            }
            catch 
            {
                MessageBox.Show("Нельзя удалять пустоту");
                farmBD.Entry(warehouse).State = EntityState.Detached;
            }

        }


        private void FarmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Warehouse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WarehouseGrid.SelectedItem != null)
            {
                var selected = WarehouseGrid.SelectedItem as Warehouse;
                WarenameBox.Text = selected.WarehouseName;
                AddressBox.Text = selected.Location;

                int selectedFarmId = selected.Farm_id;
                var selectedFarm = FarmBox.Items.OfType<Farm>().FirstOrDefault(f => f.FarmID == selectedFarmId);
                FarmBox.SelectedItem = selectedFarm;

            }
        }
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }

        private void WarenameBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private void AddressBox_TextChanged(object sender, TextChangedEventArgs e)
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
    }
}
