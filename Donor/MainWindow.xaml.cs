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

namespace Donor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void IWTBAD_Click(object sender, RoutedEventArgs e)
        {
            IWTBAD OpenRegistration = new IWTBAD();
            OpenRegistration.Show();
        }

        private void AlreadyDonor_Click(object sender, RoutedEventArgs e)
        {
            Choose OpenWindow = new Choose();
            OpenWindow.Show();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About OpenAbout = new About();
            OpenAbout.Show();
        }
    }
}
