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
    /// Логика взаимодействия для FeedBackPage.xaml
    /// </summary>
    public partial class FeedBackPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public FeedBackPage()
        {
            InitializeComponent();
            FeedBackGrid.ItemsSource = farmBD.Feedback.ToList();

            LastNameBox.ItemsSource = farmBD.Customers.ToList();
            LastNameBox.DisplayMemberPath = "LastName";
            LastNameBox.SelectedIndex = 0;

            ProductBox.ItemsSource = farmBD.Products.ToList();
            ProductBox.DisplayMemberPath = "ProductName";
            ProductBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Feedback feedback = new Feedback();

            try
            {
                feedback.Rating = Convert.ToInt32(RatingBox.Text);
            }
            catch
            {
                MessageBox.Show("Поле не может быть пустым");
                farmBD.Entry(feedback).State = EntityState.Detached;
            }

            int selectedCustomer = (LastNameBox.SelectedItem as Customers).CustomerID;
            int selectedProduct = (ProductBox.SelectedItem as Products).ProductID;

            feedback.Product_id = Convert.ToInt32(selectedProduct);
            feedback.Customer_id = Convert.ToInt32(selectedCustomer);

            feedback.Comment = CommentBox.Text;

            if (IsTextBoxEmptyOrWhitespace(CommentBox))
            {
                MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
            }


            farmBD.Feedback.Add(feedback);

            farmBD.SaveChanges();
            FeedBackGrid.ItemsSource = farmBD.Feedback.ToList();
        }
    

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (FeedBackGrid.SelectedItem != null)
            {
                var selected = FeedBackGrid.SelectedItem as Feedback;
                try
                {
                    selected.Rating = Convert.ToInt32(RatingBox.Text);
                }
                catch
                {
                    MessageBox.Show("Поле не может быть пустым");
                    farmBD.Entry(selected).State = EntityState.Detached;
                }

                int selectedProduct = (ProductBox.SelectedItem as Products).ProductID;
                int selectedCustomer = (LastNameBox.SelectedItem as Customers).CustomerID;

                selected.Product_id = Convert.ToInt32(selectedProduct);
                selected.Customer_id = Convert.ToInt32(selectedCustomer);

                selected.Comment = CommentBox.Text;


                if (IsTextBoxEmptyOrWhitespace(CommentBox))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                }

                farmBD.SaveChanges();
                FeedBackGrid.ItemsSource = farmBD.Feedback.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Feedback feedback = new Feedback();
            try
            {
                farmBD.Feedback.Remove(FeedBackGrid.SelectedItem as Feedback);

                farmBD.SaveChanges();
                FeedBackGrid.ItemsSource = farmBD.Feedback.ToList();
            }
            catch
            {
                MessageBox.Show("Нельзя удалять пустое");
                farmBD.Entry(feedback).State = EntityState.Detached;
            }
        }

        private void RatingBox_SelectionChanged(object sender, TextChangedEventArgs e)
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

        private void CommentBox_SelectionChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastNameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProductBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FeedBackGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FeedBackGrid.SelectedItem != null)
            {
                var selected = FeedBackGrid.SelectedItem as Feedback;
                RatingBox.Text = Convert.ToString(selected.Rating);

                int selectedCustId = (int)selected.Customer_id;
                var selectedCust = LastNameBox.Items.OfType<Customers>().FirstOrDefault(r => (int)r.CustomerID == selectedCustId);
                LastNameBox.SelectedItem = selectedCust;

                int selectedProductsId = selected.Product_id;
                var selectedProduct = ProductBox.Items.OfType<Products>().FirstOrDefault(f => f.ProductID == selectedProductsId);
                ProductBox.SelectedItem = selectedProduct;

                farmBD.SaveChanges();
                FeedBackGrid.ItemsSource = farmBD.Feedback.ToList();
            }
        }
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }


    }
}
