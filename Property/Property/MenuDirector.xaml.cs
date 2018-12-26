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
    /// Логика взаимодействия для MenuDirector.xaml
    /// </summary>
    public partial class MenuDirector : Window
    {
        public MenuDirector()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Window = new MainWindow();
            Window.Show();
            this.Close();
        }

        private void RatingWorkers_Click(object sender, RoutedEventArgs e)
        {
            RatingWorkers Window = new RatingWorkers();
            Window.Show();
            this.Close();
        }

        private void AboutDeals_Click(object sender, RoutedEventArgs e)
        {
            Transactions Window = new Transactions();
            Window.Show();
            this.Close();
        }

        private void ManageWorkers_Click(object sender, RoutedEventArgs e)
        {
            Workers Window = new Workers();
            Window.Show();
            this.Close();
        }
    }
}
