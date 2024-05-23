using DiplomProgram.Models;
using Microsoft.Owin.BuilderProperties;
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
    /// Логика взаимодействия для PoliseView.xaml
    /// </summary>
    public partial class PoliseView : Window
    {
        List<Policies> policiesList;
        public PoliseView()
        {
            InitializeComponent();
            policiesList = App.DB.Policies.ToList();
            DGPolicy.ItemsSource = policiesList.ToList();

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

        private void BAddPolicy_Click(object sender, RoutedEventArgs e)
        {
            var selectedPolicy = DGPolicy.SelectedItem as Policies;
            if (selectedPolicy == null)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            else
            {
                AddPolicyView addPolicyView = new AddPolicyView(selectedPolicy);
                addPolicyView.ShowDialog();
            }
        }

        private void BDelet_Click(object sender, RoutedEventArgs e)
        {
            var deletedPolicy = DGPolicy.SelectedItem as Policies;
            if (deletedPolicy != null)
            {
                App.DB.Policies.Remove(deletedPolicy);
                App.DB.SaveChanges();
                DGPolicy.ItemsSource = App.DB.Policies.ToList();
            }
        }

        private void BRedactPolice_Click(object sender, RoutedEventArgs e)
        {
            AddPolicyView addPolicyView = new AddPolicyView(new Models.Policies());
            addPolicyView.ShowDialog();
        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            policiesList = App.DB.Policies.ToList();
            DGPolicy.ItemsSource = policiesList.ToList();
        }

        private void PremTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            int premiya = 0;
            try
            {
                 premiya = Convert.ToInt32(PremTB.Text);
            }
            catch
            {
                return;
            }
            policiesList = policiesList.Where(a => a.InsurancePremium == premiya).ToList() ;
            DGPolicy.ItemsSource = policiesList.ToList();
        }

        private void TypeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            policiesList = policiesList.Where(a => a.InsuranceType.Contains(TypeTB.Text)).ToList();
            DGPolicy.ItemsSource = policiesList.ToList();
        }

        private void DPDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            policiesList = policiesList.Where(a => a.DateOfConclusion == DPDate.SelectedDate).ToList();
            DGPolicy.ItemsSource = policiesList.ToList();
        }
    }
}
