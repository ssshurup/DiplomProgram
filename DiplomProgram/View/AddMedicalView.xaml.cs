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
    /// Логика взаимодействия для AddMedicalView.xaml
    /// </summary>
    public partial class AddMedicalView : Window
    {
        MedicalInsurance contextMedical; 
        public AddMedicalView(MedicalInsurance medical)
        {
            InitializeComponent();
            contextMedical = medical;
            DataContext = contextMedical;
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

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (contextMedical.id == 0)
                    App.DB.MedicalInsurance.Add(contextMedical);
                App.DB.SaveChanges();
                MessageBox.Show("Успешно");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
           
        }
    }
}
