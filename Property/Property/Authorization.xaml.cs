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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }
        public static int IDUser;
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Window = new MainWindow();
            Window.Show();
            this.Close();
        }

        private void Authorization1_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            if (Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).role_id == 1 && Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).error==false)
            {
                IDUser=Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).id_user;
                MenuClient Window = new MenuClient();
                Window.Show();
                this.Close();
            }
            else if (Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).role_id == 2 && Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).error == false)
            {
                IDUser = Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).id_user;
                MenuRealtor Window = new MenuRealtor();
                Window.Show();
                this.Close();
            }
            else if (Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).role_id == 3 && Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).error == false)
            {
                IDUser = Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).id_user;
                MenuDirector Window = new MenuDirector();
                Window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(Service.Authentication(Convert.ToString(Email.Text), Convert.ToString(Password.Password)).error_message, "Внимание");
            }

        }
    }
}
