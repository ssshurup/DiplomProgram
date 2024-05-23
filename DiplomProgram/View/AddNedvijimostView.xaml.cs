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
    /// Логика взаимодействия для AddNedvijimostView.xaml
    /// </summary>
    public partial class AddNedvijimostView : Window
    {
        Realty contextNedvijimost;
        public AddNedvijimostView(Realty nedvijimost)
           
        {
            InitializeComponent();
            TypeCB.ItemsSource = App.DB.typerealty.ToList();
            contextNedvijimost = nedvijimost;
            DataContext = contextNedvijimost;
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
                if (contextNedvijimost.id == 0)
                    App.DB.Realty.Add(contextNedvijimost);
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

