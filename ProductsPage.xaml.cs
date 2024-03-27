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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public ProductsPage()
        {
            InitializeComponent();
            ProdcutsGrid.ItemsSource = farmBD.Products.ToList();

            WarehouseBox.ItemsSource = farmBD.Warehouse.ToList();
            WarehouseBox.DisplayMemberPath = "WarehouseName";
            WarehouseBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Products products = new Products();

            products.ProductName = ProductsNameBox.Text;

            try
            {
                products.CostProduct = Convert.ToDecimal(CostBox.Text);
            }
            catch
            {
                MessageBox.Show("Поле не может быть пустым");
                farmBD.Entry(products).State = EntityState.Detached;
            }
           

            int selectedWarehouse = (WarehouseBox.SelectedItem as Warehouse).WarehouseID;
            products.Warehouse_id = Convert.ToInt32(selectedWarehouse);

            if (IsTextBoxEmptyOrWhitespace(ProductsNameBox))
            {
                MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
            }

            farmBD.Products.Add(products);

            farmBD.SaveChanges();
            ProdcutsGrid.ItemsSource = farmBD.Products.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Products products = new Products();
            try
            {
                if (ProdcutsGrid.SelectedItem != null)
                {
                    var selected = ProdcutsGrid.SelectedItem as Products;

                    try
                    {
                        selected.CostProduct = Convert.ToDecimal(CostBox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Поле не может быть пустым");
                        farmBD.Entry(selected).State = EntityState.Detached;
                    }

                    int selectedWarehouse = (WarehouseBox.SelectedItem as Warehouse).WarehouseID;
                    selected.Warehouse_id = Convert.ToInt32(selectedWarehouse);

                    selected.ProductName = ProductsNameBox.Text;

                    if (IsTextBoxEmptyOrWhitespace(ProductsNameBox))
                    {
                        MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                    }

                }
                farmBD.SaveChanges();
                ProdcutsGrid.ItemsSource = farmBD.Products.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Нельзя удалять связанные значения");
                farmBD.Entry(products).State = EntityState.Detached;
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Products products = new Products();
            try
            {
                farmBD.Products.Remove(ProdcutsGrid.SelectedItem as Products);
                farmBD.SaveChanges();
                ProdcutsGrid.ItemsSource = farmBD.Products.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Нельзя удалять связанные значения");
                farmBD.Entry(products).State = EntityState.Detached;
            }
            catch
            {
                MessageBox.Show("Нельзя удалять пустоту");
                farmBD.Entry(products).State = EntityState.Detached;
            }
        }

        private void WarehouseBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProdcutsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProdcutsGrid.SelectedItem != null)
            {
                var selected = ProdcutsGrid.SelectedItem as Products;
                ProductsNameBox.Text = selected.ProductName;
                CostBox.Text = Convert.ToString(selected.CostProduct);

                int selectedWarehouseId = selected.Warehouse_id;
                var selectedWarehouse = WarehouseBox.Items.OfType<Warehouse>().FirstOrDefault(f => f.WarehouseID == selectedWarehouseId);
                WarehouseBox.SelectedItem = selectedWarehouse;

            }
        }

        private void ProductsNameBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private void CostBox_TextChanged(object sender, TextChangedEventArgs e)
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
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }
    }
}
