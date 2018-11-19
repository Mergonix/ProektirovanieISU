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

namespace Donor
{
    /// <summary>
    /// Логика взаимодействия для Choose.xaml
    /// </summary>
    public partial class Choose : Window
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PartEarlier_Click(object sender, RoutedEventArgs e)
        {
            Login OpenAuthorization = new Login();
            OpenAuthorization.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login OpenAuthorization = new Login();
            OpenAuthorization.Show();
        }

        private void NewMember_Click(object sender, RoutedEventArgs e)
        {
            IWTBAD OpenRegistration = new IWTBAD();
            OpenRegistration.Show();
        }
    }
}
