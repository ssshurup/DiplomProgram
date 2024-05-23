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
    /// Логика взаимодействия для FilialsWindows.xaml
    /// </summary>
    public partial class FilialsWindows : Window
    {
        List<Branches> branch;
        public FilialsWindows()
        {
            InitializeComponent();
            DGFilialsAgent.ItemsSource = App.DB.Branches.ToList();
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
