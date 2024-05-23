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
    /// Логика взаимодействия для MedicalView.xaml
    /// </summary>
    public partial class MedicalView : Window
    {
        List<MedicalInsurance> insurances;
        public MedicalView()
        {
            InitializeComponent();
            insurances = App.DB.MedicalInsurance.ToList();
            DGMedical.ItemsSource = insurances.ToList();
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
            var selectedMedical = DGMedical.SelectedItem as MedicalInsurance;
            if (selectedMedical == null)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            else
            {
                AddMedicalView addMedicalView = new AddMedicalView(selectedMedical);
                addMedicalView.ShowDialog();
            }
        }

        private void BDelet_Click(object sender, RoutedEventArgs e)
        {
            var deletedMedical = DGMedical.SelectedItem as MedicalInsurance;
            if (deletedMedical != null)
            {
                App.DB.MedicalInsurance.Remove(deletedMedical);
                App.DB.SaveChanges();
                DGMedical.ItemsSource = App.DB.MedicalInsurance.ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void BAddNedvijimost_Click(object sender, RoutedEventArgs e)
        {
            AddMedicalView addMedicalView = new AddMedicalView(new Models.MedicalInsurance());
            addMedicalView.ShowDialog();
        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            insurances = App.DB.MedicalInsurance.ToList();
            DGMedical.ItemsSource = insurances.ToList();
        }


        private void NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            insurances = insurances.Where(a => a.Name.Contains(NameTB.Text)).ToList();
            DGMedical.ItemsSource = insurances.ToList();
        }

        private void SecNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            insurances = insurances.Where(a => a.Familia.Contains(SecondNameTB.Text)).ToList();
            DGMedical.ItemsSource = insurances.ToList();
        }

        private void LastNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            insurances = insurances.Where(a => a.Otchestvo.Contains(LastNameTB.Text)).ToList();
            DGMedical.ItemsSource = insurances.ToList();
        }

        private void DPDateBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            insurances = insurances.Where(a => a.DateBirthday == DPDateBirth.SelectedDate).ToList();
            DGMedical.ItemsSource = insurances.ToList();
        }
    }
}
