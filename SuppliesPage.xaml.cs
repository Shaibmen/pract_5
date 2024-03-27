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
    /// Логика взаимодействия для SuppliesPage.xaml
    /// </summary>
    public partial class SuppliesPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public SuppliesPage()
        {
            InitializeComponent();
            SupplyGrid.ItemsSource = farmBD.Supplies.ToList();

            ProductBox.ItemsSource = farmBD.Products.ToList();
            ProductBox.DisplayMemberPath = "ProductName";
            ProductBox.SelectedIndex = 0;

            FarmBox.ItemsSource = farmBD.Farm.ToList();
            FarmBox.DisplayMemberPath = "FarmName";
            FarmBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Supplies supplies = new Supplies();

           
            try
            {
                supplies.Quantity = Convert.ToInt32(Quantity.Text);
            }
            catch
            {
                MessageBox.Show("Поле не может быть пустым");
                farmBD.Entry(supplies).State = EntityState.Detached;
            }

            int selectedFram = (FarmBox.SelectedItem as Farm).FarmID;
            supplies.Farm_id = Convert.ToInt32(selectedFram);

            int selectedProducts = (ProductBox.SelectedItem as Products).ProductID;
            supplies.Product_id = Convert.ToInt32(selectedProducts);

            farmBD.Supplies.Add(supplies);

            farmBD.SaveChanges();
            SupplyGrid.ItemsSource = farmBD.Supplies.ToList();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (SupplyGrid.SelectedItem != null)
            {
                var selected = SupplyGrid.SelectedItem as Supplies;

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
            SupplyGrid.ItemsSource = farmBD.Supplies.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Supplies supplies = new Supplies();
            try
            {
                farmBD.Supplies.Remove(SupplyGrid.SelectedItem as Supplies);
                farmBD.SaveChanges();
                SupplyGrid.ItemsSource = farmBD.Supplies.ToList();
            }
            catch
            {
                MessageBox.Show("Нельзя удалять пустое");
                farmBD.Entry(supplies).State = EntityState.Detached;
            }
            
        }

        private void SupplyGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SupplyGrid.SelectedItem != null)
            {
                var selected = SupplyGrid.SelectedItem as Supplies;

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
    }
}
