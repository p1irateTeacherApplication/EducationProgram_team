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

namespace test
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        Ganeral_Variable GV = new Ganeral_Variable();
        Sql_Command SC = new Sql_Command();

        public Authorization()
        {            
            InitializeComponent();
        }

        private void buttonHide_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonRegin_Click(object sender, RoutedEventArgs e)
        {
            registration registration = new registration();
            registration.Show();
            this.Close();
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
            
            startWindow startWindow = new startWindow();
            GV.UserName = login.Text;
            GV.UserPas = password.Text;

            GV.Login_Permission = SC.Find_User(GV.UserName, GV.UserPas);
            if (GV.Login_Permission == true)
            {
                startWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Логин или пароль неверен");
            }  
        }
    }
}
