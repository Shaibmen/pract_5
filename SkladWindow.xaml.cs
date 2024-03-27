using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ControlLaba
{
    /// <summary>
    /// Логика взаимодействия для SkladWindow.xaml
    /// </summary>
    public partial class SkladWindow : Window
    {
        public SkladWindow()
        {
            InitializeComponent();
            PageFrame.Content = new FramPage();
        }

        private void FarmButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new FramPage();
        }

        private void ExpensesButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ExpensesPage();
        }

        private void AnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AnimalPage();
        }

        private void WarehouseButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new WarehousePage();    
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new InventoryPage();
        }

        private void SuppliesButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new SuppliesPage();
        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new CustomerPage();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new OrdersPage();
        }
        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ProductsPage();
        }

        private void PageFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void FeedBackButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new FeedBackPage();
        }
    }
}
