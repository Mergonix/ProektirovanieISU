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

namespace Property
{
    /// <summary>
    /// Логика взаимодействия для MenuClient.xaml
    /// </summary>
    public partial class MenuClient : Window
    {
        public MenuClient()
        {
            InitializeComponent();
        }

        private void MyProperty_Click(object sender, RoutedEventArgs e)
        {
            MyProperty Window = new MyProperty();
            Window.Show();
            this.Close();
        }

        private void MyDeals_Click(object sender, RoutedEventArgs e)
        {
            Deals_of_Clients Window = new Deals_of_Clients();
            Window.Show();
            this.Close();
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            MyProfileClient Window = new MyProfileClient();
            Window.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Window = new MainWindow();
            Window.Show();
            this.Close();
        }
    }
}
