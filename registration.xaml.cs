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
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        Ganeral_Variable GV = new Ganeral_Variable();
        Sql_Command SC = new Sql_Command();
        public registration()
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
            string temp_name = Reg_Login.Text;
            string temp_pas = Reg_Pas.Text;
            string temp_pas2 = Reg_Pas2.Text;
            if (temp_pas == temp_pas2 &&  SC.Find_User(temp_name,temp_pas) == false && temp_name.Length<32 && temp_pas.Length<32)
            {
                SC.Add_User(temp_name, temp_pas);
                Authorization authorization = new Authorization();
                authorization.Show();
                this.Close();
            }
        
            else
            {
                if (temp_name.Length > 32)
                {
                    MessageBox.Show("Введите никнейм меньше 32 символов");
                }
                if (temp_pas.Length > 32)
                {
                    MessageBox.Show("Введите пароль меньше 32 символов");
                }
                if (temp_pas != temp_pas2)
                {
                    MessageBox.Show("Пароли не совпадают");
                }
                if (SC.Find_User(temp_name, temp_pas) == true)
                {
                    MessageBox.Show("Такой пользователь уже существует");
                }
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }
    }
}
