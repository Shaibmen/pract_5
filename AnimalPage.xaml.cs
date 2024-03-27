using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для AnimalPage.xaml
    /// </summary>
    public partial class AnimalPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public AnimalPage()
        {
            InitializeComponent();
            AnimalGrid.ItemsSource = farmBD.Animals.ToList();
            FarmBox.ItemsSource = farmBD.Farm.ToList();
            FarmBox.DisplayMemberPath = "FarmName";
            FarmBox.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Animals animals = new Animals();

            animals.Species = TypeAnimal.Text;
           
            try
            {
                animals.Age = Convert.ToInt32(AgeBox.Text);
            }
            catch
            {
                MessageBox.Show("Поле не может быть пустым");
                farmBD.Entry(animals).State = EntityState.Detached;
            }
            int selectedFram = (FarmBox.SelectedItem as Farm).FarmID;
            animals.Farm_id = Convert.ToInt32(selectedFram);

            if (IsTextBoxEmptyOrWhitespace(TypeAnimal))
            {
                MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
            }

            farmBD.Animals.Add(animals);

            farmBD.SaveChanges();
            AnimalGrid.ItemsSource = farmBD.Animals.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalGrid.SelectedItem != null)
            {
                var selected = AnimalGrid.SelectedItem as Animals;

                selected.Species = TypeAnimal.Text;
                try
                {
                    selected.Age = Convert.ToInt32(AgeBox.Text);
                }
                catch
                {
                    MessageBox.Show("Поле не может быть пустым");
                    farmBD.Entry(selected).State = EntityState.Detached;
                }
                int selectedFram = (FarmBox.SelectedItem as Farm).FarmID;
                selected.Farm_id = Convert.ToInt32(selectedFram);
            }

            if (IsTextBoxEmptyOrWhitespace(TypeAnimal))
            {
                MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы"); return;
            }

            farmBD.SaveChanges();
            AnimalGrid.ItemsSource = farmBD.Animals.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Animals animals = new Animals();
            try
            {
                farmBD.Animals.Remove(AnimalGrid.SelectedItem as Animals);
                farmBD.SaveChanges();
                AnimalGrid.ItemsSource = farmBD.Animals.ToList();
            }
            catch (System.ArgumentNullException ex)
            {
                MessageBox.Show("Нельзя удалить пустое место");
                farmBD.Entry(animals).State = EntityState.Detached;
            }
            
        }

        private void AnimalGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimalGrid.SelectedItem != null)
            {
                var selected = AnimalGrid.SelectedItem as Animals;

                TypeAnimal.Text = selected.Species;
                AgeBox.Text = Convert.ToString(selected.Age);
                int selectedFarmId = selected.Farm_id;
                var selectedFarm = FarmBox.Items.OfType<Farm>().FirstOrDefault(f => f.FarmID == selectedFarmId);
                FarmBox.SelectedItem = selectedFarm;
            }
        }

        private void TypeAnimal_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text;

            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    textBox.Text = text.Remove(text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length;
                    return;
                }
            }
        }

        private void AgeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text;

            foreach (char c in text)
            {
                if (!char.IsDigit(c))
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
