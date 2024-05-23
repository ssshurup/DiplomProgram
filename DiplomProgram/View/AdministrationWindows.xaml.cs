using DiplomProgram.Models;
using DiplomProgram.Pages;
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
    /// Логика взаимодействия для AdministrationWindows.xaml
    /// </summary>
    public partial class AdministrationWindows : Window
    {
        public AdministrationWindows()
        {
            InitializeComponent();
            PostCB.ItemsSource = App.DB.rol.ToList();
            DGAddAdmin.ItemsSource = App.DB.Staff.ToList();
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
            App.Current.Shutdown();
        }

        private void BRedact_Click(object sender, RoutedEventArgs e)
        {
            var selectedStaff = DGAddAdmin.SelectedItem as Staff;
            if (selectedStaff == null)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            else
            {
                AddAgentWindow addAgentWindow = new AddAgentWindow(selectedStaff);
                addAgentWindow.ShowDialog();
            }
        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            var deletedStaff = DGAddAdmin.SelectedItem as Staff;
            if (deletedStaff != null)
            {
                App.DB.Staff.Remove(deletedStaff);
                App.DB.SaveChanges();
                DGAddAdmin.ItemsSource = App.DB.Staff.ToList();
            }
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            AddAgentWindow addAgentWindow = new AddAgentWindow(new Models.Staff());
            addAgentWindow.ShowDialog();
        }


        private void TBSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBSearch.Text == "Введите vin номер")
            {
                TBSearch.Text = "";
            }
        }

        private void TBSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBSearch.Text))
                TBSearch.Text = "Введите vin номер";
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            var filtred = App.DB.Staff.ToList();

            if (!string.IsNullOrEmpty(TBSearch.Text))
                filtred = filtred.Where(x => x.FIO.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            DGAddAdmin.ItemsSource = filtred;
        }

        private void BSbros_Click(object sender, RoutedEventArgs e)
        {
            TBSearch.Text = "";
            Refresh();
        }

        private void PostCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRole = PostCB.SelectedItem as rol;

            DGAddAdmin.ItemsSource = App.DB.Staff.Where(a => a.Rolid == selectedRole.id).ToList();
        }

        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            this.Refresh();
        }

        private void TitleTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGAddAdmin.ItemsSource = App.DB.Staff.Where(a => a.FIO.Contains(NameTB.Text)).ToList();
        }
    }
}

