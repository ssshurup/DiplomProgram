using DiplomProgram.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для CarView.xaml
    /// </summary>
    public partial class CarView : Window
    {
        List<Car> cars;
        public CarView()
        {
            InitializeComponent();
            cars = App.DB.Car.ToList();
            DGCar.ItemsSource = cars.ToList();
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
            var selectedCar = DGCar.SelectedItem as Car;
            if (selectedCar == null)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            else
            {
                AddCarView addCarView = new AddCarView(selectedCar);
                addCarView.ShowDialog();
            }
        }

        private void BDelet_Click(object sender, RoutedEventArgs e)
        {
            var deletedCar = DGCar.SelectedItem as Car;
            if (deletedCar != null)
            {
                App.DB.Car.Remove(deletedCar);
                App.DB.SaveChanges();
                DGCar.ItemsSource = App.DB.Car.ToList();
            }
        }       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DGCar.ItemsSource = App.DB.Car.ToList();
        }
        private void BAddCar_Click(object sender, RoutedEventArgs e)
        {
            AddCarView addCarView = new AddCarView(new Models.Car());
            addCarView.ShowDialog();
        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
           cars = App.DB.Car.ToList();
            DGCar.ItemsSource = cars.ToList();
        }

        private void TitleTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            cars = cars.Where(a => a.Model.Contains(NameTB.Text)).ToList();
            DGCar.ItemsSource = cars.ToList();
        }

        private void PassTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            cars = cars.Where(a => a.VehiclePassport.Contains(PassTB.Text)).ToList();
            DGCar.ItemsSource = cars.ToList();
        }

        private void DPDateRegistred_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            cars = cars.Where(a => a.DateRegistration == DPDateRegistred.SelectedDate).ToList();
            DGCar.ItemsSource = cars.ToList();
        }
    }
}
