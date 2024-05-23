using DiplomProgram.Models;
using StackExchange.Profiling.Internal;
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
    /// Логика взаимодействия для VoditeliView.xaml
    /// </summary>
    public partial class VoditeliView : Window
    {
        List<Drivers> drive;
        public VoditeliView()
        {
            InitializeComponent();
            drive = App.DB.Drivers.ToList();
            DGVoditely.ItemsSource = drive.ToList();

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
            var selectedVoditely = DGVoditely.SelectedItem as Drivers;
            if (selectedVoditely == null)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            else
            {
                AddVoditelView addVoditelView = new AddVoditelView(selectedVoditely);
                addVoditelView.ShowDialog();
            }
        }

        private void BDelet_Click(object sender, RoutedEventArgs e)
        {
            var deletedVoditely = DGVoditely.SelectedItem as Drivers;
            if (deletedVoditely != null)
            {
                App.DB.Drivers.Remove(deletedVoditely);
                App.DB.SaveChanges();
                DGVoditely.ItemsSource = App.DB.Drivers.ToList();
            }
        }

        private void BAddVoditel_Click(object sender, RoutedEventArgs e)
        {
            
                AddVoditelView addVoditelView = new AddVoditelView(new Models.Drivers());
                addVoditelView.ShowDialog();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void DPDateGive_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            drive = drive.Where(a => a.DatePoluchenia == DPDateGiveUp.SelectedDate).ToList();
            DGVoditely.ItemsSource = drive.ToList();

        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            drive = App.DB.Drivers.ToList();
            DGVoditely.ItemsSource = drive.ToList();
        }


        private void NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            drive = drive.Where(a => a.Name.Contains(NameTB.Text)).ToList();
            DGVoditely.ItemsSource = drive.ToList();

        }

        private void SecNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            drive = drive.Where(a => a.Familia.Contains(SecondNameTB.Text)).ToList();
            DGVoditely.ItemsSource = drive.ToList();
        }

        private void LastNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            drive = drive.Where(a => a.Otchestvo.Contains(LastNameTB.Text)).ToList();
            DGVoditely.ItemsSource = drive.ToList();
        }
    }
}

