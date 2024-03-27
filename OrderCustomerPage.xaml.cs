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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlLaba
{
    /// <summary>
    /// Логика взаимодействия для OrderCustomerPage.xaml
    /// </summary>
    public partial class OrderCustomerPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public List<Orders> CheckProducts = new List<Orders>();
        public OrderCustomerPage()
        {
            InitializeComponent();
            StoreGrid.ItemsSource = farmBD.Orders.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (StoreGrid.SelectedItems != null)
            {
                foreach (Orders item in StoreGrid.SelectedItems)
                {
                    CheckProducts.Add(item);
                }

                CheckGrid.ItemsSource = CheckProducts.ToList();

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StoreGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Oplata_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
