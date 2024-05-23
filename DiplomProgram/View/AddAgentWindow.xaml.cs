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

namespace DiplomProgram.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAgentWindow.xaml
    /// </summary>
    public partial class AddAgentWindow : Window
    {
        Staff contextSotrudniki;
        public AddAgentWindow(Staff sotrudniki)
        {
            InitializeComponent();
            PostCB.ItemsSource = App.DB.rol.ToList();
            contextSotrudniki = sotrudniki;
            DataContext = contextSotrudniki;
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
                if (contextSotrudniki.id == 0)
                    App.DB.Staff.Add(contextSotrudniki);
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
