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
    /// Логика взаимодействия для InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public InventoryPage()
        {
            InitializeComponent();
            InventoryGrid.ItemsSource = farmBD.Inventory.ToList();

            ProductBox.ItemsSource = farmBD.Products.ToList();
            ProductBox.DisplayMemberPath = "ProductName";
            ProductBox.SelectedIndex = 0;

            FarmBox.ItemsSource = farmBD.Farm.ToList();
            FarmBox.DisplayMemberPath = "FarmName";
            FarmBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Inventory inventory = new Inventory();

            try
            {
                inventory.Quantity = Convert.ToInt32(Quantity.Text);
            }
            catch
            {
                MessageBox.Show("Поле не может быть пустым");
                farmBD.Entry(inventory).State = EntityState.Detached;
            }

            int selectedFram = (FarmBox.SelectedItem as Farm).FarmID;
            inventory.Farm_id = Convert.ToInt32(selectedFram);

            int selectedProducts = (ProductBox.SelectedItem as Products).ProductID;
            inventory.Product_id = Convert.ToInt32(selectedProducts);


            farmBD.Inventory.Add(inventory);

            farmBD.SaveChanges();
            InventoryGrid.ItemsSource = farmBD.Inventory.ToList();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryGrid.SelectedItem != null)
            {
                var selected = InventoryGrid.SelectedItem as Inventory;

                try
                {
                    selected.Quantity = Convert.ToInt32(Quantity.Text);
                }
                catch
                {
                    MessageBox.Show("Поле не может быть пустым");
                    farmBD.Entry(selected).State = EntityState.Detached;
                }

                int selectedFram = (FarmBox.SelectedItem as Farm).FarmID;
                selected.Farm_id = Convert.ToInt32(selectedFram);

                int selectedProducts = (ProductBox.SelectedItem as Products).ProductID;
                selected.Product_id = Convert.ToInt32(selectedProducts);
            }
            farmBD.SaveChanges();
            InventoryGrid.ItemsSource = farmBD.Inventory.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Inventory inventory = new Inventory();
            try
            {
                farmBD.Inventory.Remove(InventoryGrid.SelectedItem as Inventory);
                farmBD.SaveChanges();
                InventoryGrid.ItemsSource = farmBD.Inventory.ToList();
            }
            catch
            {
                MessageBox.Show("Нельзя удалять пустое");
                farmBD.Entry(inventory).State = EntityState.Detached;
            }

        }

        private void InventoryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InventoryGrid.SelectedItem != null)
            {
                var selected = InventoryGrid.SelectedItem as Inventory;

                Quantity.Text = Convert.ToString(selected.Quantity);

                int selectedFarmId = selected.Farm_id;
                var selectedFarm = FarmBox.Items.OfType<Farm>().FirstOrDefault(f => f.FarmID == selectedFarmId);
                FarmBox.SelectedItem = selectedFarm;

                int selectedProductsId = selected.Product_id;
                var selectedProduct = ProductBox.Items.OfType<Products>().FirstOrDefault(f => f.ProductID == selectedProductsId);
                ProductBox.SelectedItem = selectedProduct;
            }
        }

        private void ProductBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FarmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }

        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
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
    }
}
