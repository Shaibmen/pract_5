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
    /// Логика взаимодействия для ExpensesPage.xaml
    /// </summary>
    public partial class ExpensesPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public ExpensesPage()
        {
            InitializeComponent();
            ExpensesGrid.ItemsSource = farmBD.Expenses.ToList();
            FarmBox.ItemsSource = farmBD.Farm.ToList();
            FarmBox.DisplayMemberPath = "FarmName";
            FarmBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Expenses expenses = new Expenses();
            int selectedFram = (FarmBox.SelectedItem as Farm).FarmID;

            expenses.ExpenseType = ExpnesesBox.Text;
            try
            {
                expenses.Amount = Convert.ToDecimal(AmountBox.Text);
            }
            catch
            {
                MessageBox.Show("Поле не может быть пустым");
                farmBD.Entry(expenses).State = EntityState.Detached;
            }
           
            expenses.Farm_id = Convert.ToInt32(selectedFram);

            farmBD.Expenses.Add(expenses);

            farmBD.SaveChanges();
            ExpensesGrid.ItemsSource = farmBD.Expenses.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Expenses expenses = new Expenses();

            if (ExpensesGrid.SelectedItem != null)
            {

                var selected = ExpensesGrid.SelectedItem as Expenses;
                selected.ExpenseType = ExpnesesBox.Text;
                try
                {
                    expenses.Amount = Convert.ToDecimal(AmountBox.Text);
                }
                catch
                {
                    MessageBox.Show("Поле не может быть пустым");
                    farmBD.Entry(expenses).State = EntityState.Detached;
                }

                int selectedFram = (FarmBox.SelectedItem as Farm).FarmID;

                selected.ExpenseType = ExpnesesBox.Text;
                selected.Amount = Convert.ToDecimal(AmountBox.Text);
                selected.Farm_id = Convert.ToInt32(selectedFram);

                if (IsTextBoxEmptyOrWhitespace(ExpnesesBox))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
                }
            }

            farmBD.SaveChanges();
            ExpensesGrid.ItemsSource = farmBD.Expenses.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Expenses expenses = new Expenses();
            try
            {
                farmBD.Expenses.Remove(ExpensesGrid.SelectedItem as Expenses);
                farmBD.SaveChanges();
                ExpensesGrid.ItemsSource = farmBD.Expenses.ToList();
            }
            catch
            {
                MessageBox.Show("Нельзя удалять пустое");
                farmBD.Entry(expenses).State = EntityState.Detached;

            }

        }
        private void Expenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExpensesGrid.SelectedItem != null)
            {
                var selected = ExpensesGrid.SelectedItem as Expenses;

                ExpnesesBox.Text = selected.ExpenseType;
                AmountBox.Text = selected.Amount.ToString();

                int selectedFarmId = selected.Farm_id;
                var selectedFarm = FarmBox.Items.OfType<Farm>().FirstOrDefault(f => f.FarmID == selectedFarmId);
                FarmBox.SelectedItem = selectedFarm;
            }
        }

        private void PositionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ExpnesesBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private void AmountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text;

            foreach (char c in text)
            {
                if (!char.IsDigit(c) && c != ',')
                {
                    textBox.Text = text.Remove(text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length;
                    return;
                }
            }
        }
        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }

    }
}
