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
    /// Логика взаимодействия для FramPage.xaml
    /// </summary>
    public partial class FramPage : Page
    {
        private FarmDatabaseEntities3 farmBD = new FarmDatabaseEntities3();
        public FramPage()
        {
            InitializeComponent();
            FarmGrid.ItemsSource = farmBD.Farm.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Farm farm = new Farm();

            try
            {
                farm.FarmName = NameFarm.Text;
                farm.Location = AddressFarm.Text;

                if (IsTextBoxEmptyOrWhitespace(NameFarm) || IsTextBoxEmptyOrWhitespace(AddressFarm))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы");
                    return; 
                }

                farmBD.Farm.Add(farm);

                farmBD.SaveChanges();
                FarmGrid.ItemsSource = farmBD.Farm.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Поля не могут быть пустыми");
                farmBD.Entry(farm).State = EntityState.Detached;
            }
           
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (FarmGrid.SelectedItems != null)
            {
                var selected = FarmGrid.SelectedItem as Farm;

                selected.FarmName = NameFarm.Text;
                selected.Location = AddressFarm.Text;

                if (IsTextBoxEmptyOrWhitespace(NameFarm) || IsTextBoxEmptyOrWhitespace(AddressFarm))
                {
                    MessageBox.Show("Поля не могут быть пустыми или содержать только пробелы");
                    return;
                }
            }
            farmBD.SaveChanges();
            FarmGrid.ItemsSource = farmBD.Farm.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Farm farm = new Farm();
            try
            {
                farmBD.Farm.Remove(FarmGrid.SelectedItem as Farm);
                farmBD.SaveChanges();
                FarmGrid.ItemsSource = farmBD.Farm.ToList();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Нельзя удалять связанные значения");
                farmBD.Entry(farm).State = EntityState.Detached;
            }
            catch
            {
                MessageBox.Show("Нельзя удалять пустоту");
                farmBD.Entry(farm).State = EntityState.Detached;
            }

        }

        private void FarmGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FarmGrid.SelectedItem != null)
            {
                var selected = (FarmGrid.SelectedItem as Farm);

                NameFarm.Text = selected.FarmName;
                AddressFarm.Text = selected.Location;
            }
        }

        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private bool IsTextBoxEmptyOrWhitespace(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }
    }
}
