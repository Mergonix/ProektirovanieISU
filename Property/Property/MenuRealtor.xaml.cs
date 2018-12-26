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
    /// Логика взаимодействия для MenuRealtor.xaml
    /// </summary>
    public partial class MenuRealtor : Window
    {
        public MenuRealtor()
        {
            InitializeComponent();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            Base_of_Clients Window = new Base_of_Clients();
            Window.Show();
            this.Close();
        }

        private void Property_Click(object sender, RoutedEventArgs e)
        {
            Base_of_Property Window = new Base_of_Property();
            Window.Show();
            this.Close();
        }

        private void Transactions_Click(object sender, RoutedEventArgs e)
        {
            Base_of_transactions Window = new Base_of_transactions();
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
