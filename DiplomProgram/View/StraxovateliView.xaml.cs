using DiplomProgram.Models;
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

namespace DiplomProgram.View
{
    /// <summary>
    /// Логика взаимодействия для StraxovateliView.xaml
    /// </summary>
    public partial class StraxovateliView : Window
    {
        List<PolicyHolder> holders;
        public StraxovateliView()
        {
            InitializeComponent();
            holders = App.DB.PolicyHolder.ToList();
            DGStraxovateli.ItemsSource = holders.ToList();

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BMinimaze_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BAddStrsxovatel_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindovs addClientWindovs = new AddClientWindovs(new Models.PolicyHolder());
            addClientWindovs.ShowDialog();
        }

        private void BRedactStraxovateal_Click(object sender, RoutedEventArgs e)
        {
            var selectedPolicy = DGStraxovateli.SelectedItem as PolicyHolder;
            if (selectedPolicy == null)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            else
            {
                AddClientWindovs addClientWindovs = new AddClientWindovs(selectedPolicy);
                addClientWindovs.ShowDialog();
            }
        }

        private void BDelet_Click(object sender, RoutedEventArgs e)
        {
            var deletedStraxovateli = DGStraxovateli.SelectedItem as PolicyHolder;
            if (deletedStraxovateli != null)
            {
                App.DB.PolicyHolder.Remove(deletedStraxovateli);
                App.DB.SaveChanges();
                DGStraxovateli.ItemsSource = App.DB.PolicyHolder.ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            holders = App.DB.PolicyHolder.ToList();
            DGStraxovateli.ItemsSource = holders.ToList();
        }


        private void NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            holders = holders.Where(a => a.Name.Contains(NameTB.Text)).ToList();
            DGStraxovateli.ItemsSource = holders.ToList();

        }

        private void SecNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            holders = holders.Where(a => a.Familia.Contains(SecondNameTB.Text)).ToList();
            DGStraxovateli.ItemsSource = holders.ToList();
        }

        private void LastNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            holders = holders.Where(a => a.Otchestvo.Contains(LastNameTB.Text)).ToList();
            DGStraxovateli.ItemsSource = holders.ToList();
        }

        private void DPDateBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            holders = holders.Where(a => a.Birthday == DPDateBirth.SelectedDate).ToList();
            DGStraxovateli.ItemsSource = holders.ToList();
        }
    }
}
