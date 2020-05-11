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

namespace test
{
    /// <summary>
    /// Логика взаимодействия для startWindow.xaml
    /// </summary>
    public partial class startWindow : Window
    {
        Authorization authorization;

        public startWindow()
        {
            InitializeComponent();
        }

        public startWindow(Authorization authorization)
        {
            this.authorization = authorization;
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

        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            helpWindow helpWindow = new helpWindow();
            helpWindow.Show();
        }

        private void buttonStartTheory_Click(object sender, RoutedEventArgs e)
        {
            startTheoryWindow startTheoryWindow = new startTheoryWindow();
            startTheoryWindow.Show();
            //this.Hide();
            this.Close();
        }

        private void buttonStartPractice_Click(object sender, RoutedEventArgs e)
        {
            startPracticeWindow startPracticeWindow = new startPracticeWindow();
            startPracticeWindow.Show();
            //this.Hide();
            this.Close();
        }

        private void buttonAuto_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }
    }
}
