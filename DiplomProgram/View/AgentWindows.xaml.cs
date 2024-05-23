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
    /// Логика взаимодействия для AgentWindows.xaml
    /// </summary>
    public partial class AgentWindows : Window
    {
        public AgentWindows()
        {
            InitializeComponent();
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

        private void BPolice_Click(object sender, RoutedEventArgs e)
        {
            PoliseView poliseView = new PoliseView();
            poliseView.ShowDialog();
        }

        private void BStraxovateli_Click(object sender, RoutedEventArgs e)
        {
            StraxovateliView straxovateliView = new StraxovateliView();
            straxovateliView.ShowDialog();
        }

        private void BFilials_Click(object sender, RoutedEventArgs e)
        {
            FilialsWindows filialsWindows = new FilialsWindows();
            filialsWindows.ShowDialog();
        }

        private void Voditeli_Click(object sender, RoutedEventArgs e)
        {
            VoditeliView voditeliView = new VoditeliView();
            voditeliView.ShowDialog();
        }

        private void BCar_Click(object sender, RoutedEventArgs e)
        {
            CarView carView = new CarView();
            carView.ShowDialog();
        }

        private void BSotrudniki_Click(object sender, RoutedEventArgs e)
        {
            SotrudnikiWindows sotrudnikiWindows = new SotrudnikiWindows();
            sotrudnikiWindows.ShowDialog();
        }

        private void BNedvishimost_Click(object sender, RoutedEventArgs e)
        {
            NedfijimostView nedfijimostView = new NedfijimostView();
            nedfijimostView.ShowDialog();
        }

        private void BMed_Click(object sender, RoutedEventArgs e)
        {
            MedicalView medicalView = new MedicalView();
            medicalView.ShowDialog();
        }
    }
}
