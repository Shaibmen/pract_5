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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public OrdersPage()
        {
            InitializeComponent();
            OrdersGrid.ItemsSource = farmBD.Orders.ToList();

            FarmBox.ItemsSource = farmBD.Farm.ToList();
            FarmBox.DisplayMemberPath = "FarmName";
            FarmBox.SelectedIndex = 0;

            ProductBox.ItemsSource = farmBD.Products.ToList();
            ProductBox.DisplayMemberPath = "ProductName";
            ProductBox.SelectedIndex = 0;

            CustomerBox.ItemsSource = farmBD.Customers.ToList();
            CustomerBox.DisplayMemberPath = "LastName";
            CustomerBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();

            try
            {
                orders.Quantity = Convert.ToInt32(QuantityBox.Text);
            }
            catch
            {
                MessageBox.Show("Поле не может быть пустым");
                farmBD.Entry(orders).State = EntityState.Detached;
            }

            int selectedFarm = (FarmBox.SelectedItem as Farm).FarmID;
            int selectedProduct = (ProductBox.SelectedItem as Products).ProductID;
            int selectedCustomer = (CustomerBox.SelectedItem as Customers).CustomerID;

            orders.Farm_id = Convert.ToInt32(selectedFarm);
            orders.Product_id = Convert.ToInt32(selectedProduct);
            orders.Customer_id = Convert.ToInt32(selectedCustomer);

            if (IsTextBoxEmptyOrWhitespace(QuantityBox))
            {
                MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
            }


            farmBD.Orders.Add(orders);

            farmBD.SaveChanges();
            OrdersGrid.ItemsSource = farmBD.Orders.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem != null)
            {
                var selected = OrdersGrid.SelectedItem as Orders;
                try
                {
                    selected.Quantity = Convert.ToInt32(QuantityBox.Text);
                }
                catch
                {
                    MessageBox.Show("Поле не может быть пустым");
                    farmBD.Entry(selected).State = EntityState.Detached;
                }

                int selectedFarm = (FarmBox.SelectedItem as Farm).FarmID;
                int selectedProduct = (ProductBox.SelectedItem as Products).ProductID;
                int selectedCustomer = (CustomerBox.SelectedItem as Customers).CustomerID;

                selected.Farm_id = Convert.ToInt32(selectedFarm);
                selected.Product_id = Convert.ToInt32(selectedProduct);
                selected.Customer_id = Convert.ToInt32(selectedCustomer);

                if (IsTextBoxEmptyOrWhitespace(QuantityBox))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                }

                farmBD.SaveChanges();
                OrdersGrid.ItemsSource = farmBD.Orders.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            try
            {
                farmBD.Orders.Remove(OrdersGrid.SelectedItem as Orders);

                farmBD.SaveChanges();
                OrdersGrid.ItemsSource = farmBD.Orders.ToList();
            }
            catch
            {
                MessageBox.Show("Нельзя удалять пустое");
                farmBD.Entry(orders).State = EntityState.Detached;
            }
            
        }

        private void FarmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProductBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CustomerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OrdersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrdersGrid.SelectedItem != null)
            {
                var selected = OrdersGrid.SelectedItem as Orders;
                QuantityBox.Text = Convert.ToString(selected.Quantity);

                int selectedFarmId = selected.Farm_id;
                var selectedFarm = FarmBox.Items.OfType<Farm>().FirstOrDefault(f => f.FarmID == selectedFarmId);
                FarmBox.SelectedItem = selectedFarm;

                int selectedCustId = (int)selected.Customer_id;
                var selectedCust = CustomerBox.Items.OfType<Customers>().FirstOrDefault(r => (int)r.CustomerID == selectedCustId);
                CustomerBox.SelectedItem = selectedCust;

                int selectedProductsId = selected.Product_id;
                var selectedProduct = ProductBox.Items.OfType<Products>().FirstOrDefault(f => f.ProductID == selectedProductsId);
                ProductBox.SelectedItem = selectedProduct;


                farmBD.SaveChanges();
                OrdersGrid.ItemsSource = farmBD.Orders.ToList();
            }
        }
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }

        private void QuantityBox_TextChanged(object sender, TextChangedEventArgs e)
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
