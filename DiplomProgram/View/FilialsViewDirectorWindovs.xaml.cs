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
    /// Логика взаимодействия для FilialsViewDirectorWindovs.xaml
    /// </summary>
    public partial class FilialsViewDirectorWindovs : Window
    {
        List<Branches> branch;
        public FilialsViewDirectorWindovs()
        {
            InitializeComponent();
            branch = App.DB.Branches.ToList();
            DGFilialsAgent.ItemsSource = branch.ToList();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void BAddFilials_Click(object sender, RoutedEventArgs e)
        {
            AddFilialsView addFilialsView = new AddFilialsView(new Models.Branches());
            addFilialsView.ShowDialog();
        }

        private void BRedact_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilials = DGFilialsAgent.SelectedItem as Branches;
            if (selectedFilials == null)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            else
            {
                AddFilialsView addFilialsView = new AddFilialsView(selectedFilials);
                addFilialsView.ShowDialog();
            }
        }

        private void BDelet_Click(object sender, RoutedEventArgs e)
        {
            var deletedFilials = DGFilialsAgent.SelectedItem as Branches;
            if (deletedFilials != null)
            {
                App.DB.Branches.Remove(deletedFilials);
                App.DB.SaveChanges();
                DGFilialsAgent.ItemsSource = App.DB.Branches.ToList();
            }
        }

        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            branch = App.DB.Branches.ToList();
            DGFilialsAgent.ItemsSource = branch.ToList();
        }

        private void TitleTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            branch = branch.Where(a => a.Name.Contains(NameTB.Text)).ToList();
            DGFilialsAgent.ItemsSource = branch.ToList();
        }

        private void PassTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            branch = branch.Where(a => a.Adress.Contains(addresTB.Text)).ToList();
            DGFilialsAgent.ItemsSource = branch.ToList();
        }

        private void DPDateRegistred_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            branch = branch.Where(a => a.DataOtkretia == DPDateOpened.SelectedDate).ToList();
            DGFilialsAgent.ItemsSource = branch.ToList();
        }
    }
}
