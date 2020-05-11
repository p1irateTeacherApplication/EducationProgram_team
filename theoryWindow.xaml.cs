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
    /// Логика взаимодействия для theoryWindow.xaml
    /// </summary>
    public partial class theoryWindow : Window
    {
        public theoryWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            startPracticeWindow startPracticeWindow = new startPracticeWindow();
            startPracticeWindow.Show();
            this.Close();
            // this.Hide();
        }
    }
}
