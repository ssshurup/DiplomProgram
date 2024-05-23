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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace DiplomProgram.View
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
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

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = TBLogin.Text;
            string password = TBPзssword.Password;

            var LoggedUser = App.DB.Staff.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (LoggedUser == null)
            {
                MessageBox.Show("Указанный логин и/или пароль неверен");
                return;
            }
            App.LoggedUser = LoggedUser;
            if (LoggedUser.Rolid == 1)
            {
                AdministrationWindows administrationWindows = new AdministrationWindows();
                administrationWindows.ShowDialog();
            }
            if (LoggedUser.Rolid == 2)
            {
                DirectorWindows directorWindows = new DirectorWindows();
                directorWindows.ShowDialog();
            }
            if(LoggedUser.Rolid == 3)
            {
                AgentWindows agentWindows = new AgentWindows();
                agentWindows.ShowDialog();
            }        
        }
    }
}
