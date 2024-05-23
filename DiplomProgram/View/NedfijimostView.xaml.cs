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
    /// Логика взаимодействия для NedfijimostView.xaml
    /// </summary>
    public partial class NedfijimostView : Window
    {
        List<Realty> realtyList;
        public NedfijimostView()
        {
            InitializeComponent();
            typeCB.ItemsSource = App.DB.typerealty.ToList();
            realtyList = App.DB.Realty.ToList();
            DGNedfijimosti.ItemsSource = realtyList.ToList();

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

        private void BRedact_Click(object sender, RoutedEventArgs e)
        {
            var selectedNedvishimost = DGNedfijimosti.SelectedItem as Realty;
            if (selectedNedvishimost == null)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            else
            {
                AddNedvijimostView addNedvijimostView = new AddNedvijimostView(selectedNedvishimost);
                addNedvijimostView.ShowDialog();
            }
        }

        private void BDelet_Click(object sender, RoutedEventArgs e)
        {
            var deletedNedvijimost = DGNedfijimosti.SelectedItem as Realty;
            if (deletedNedvijimost != null)
            {
                App.DB.Realty.Remove(deletedNedvijimost);
                App.DB.SaveChanges();
                DGNedfijimosti.ItemsSource = App.DB.Realty.ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void BAddNedvijimost_Click(object sender, RoutedEventArgs e)
        {
            AddNedvijimostView addNedvijimostView = new AddNedvijimostView(new Models.Realty());
            addNedvijimostView.ShowDialog();

        }

        private void AddressTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            realtyList = realtyList.Where(a => a.Adress.Contains(AddressTB.Text)).ToList();
            DGNedfijimosti.ItemsSource = realtyList.ToList();
        }

        private void typeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = typeCB.SelectedItem as typerealty;
            realtyList = realtyList.Where(a => a.typ == selectedType.id).ToList();
            DGNedfijimosti.ItemsSource = realtyList.ToList();
        }

        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            realtyList = App.DB.Realty.ToList();
            DGNedfijimosti.ItemsSource = realtyList.ToList();
        }

        private void NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            realtyList = realtyList.Where(a => a.FIOSobstvenika.Contains(NameTB.Text)).ToList();
            DGNedfijimosti.ItemsSource = realtyList.ToList();
        }

        private void DPDateBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            realtyList = realtyList.Where(a => a.DataRegistracii == DPDateBirth.SelectedDate).ToList();
            DGNedfijimosti.ItemsSource = realtyList.ToList();
        }
    }
}
