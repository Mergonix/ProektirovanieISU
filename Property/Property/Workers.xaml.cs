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
    /// Логика взаимодействия для Workers.xaml
    /// </summary>
    public partial class Workers : Window
    {
        public Workers()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            DataGridTextColumn ColumnFIO = new DataGridTextColumn();
            ColumnFIO.Header = "Ф.И.О.";
            ColumnFIO.Binding = new Binding("FIO");
            Workers1.Columns.Add(ColumnFIO);
            DataGridTextColumn ColumnDateBirth = new DataGridTextColumn();
            ColumnDateBirth.Header = "Email";
            ColumnDateBirth.Binding = new Binding("Email");
            Workers1.Columns.Add(ColumnDateBirth);
            DataGridTextColumn ColumnTelephone = new DataGridTextColumn();
            ColumnTelephone.Header = "Телефон";
            ColumnTelephone.Binding = new Binding("Telephone");
            Workers1.Columns.Add(ColumnTelephone);

            for (int i = 0; i < Service.SelectUsers().Length; i++)
            {
                if (Convert.ToInt32(Service.SelectUsers()[i].Role_ID)==2)
                Workers1.Items.Add(new Item() {  Email = Service.SelectUsers()[i].Email,FIO = Service.FindByIDUsers(Service.SelectUsers()[i].id).LastName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).FirstName+" " + Service.FindByIDUsers(Service.SelectUsers()[i].id).Patronymic, Telephone = Service.SelectUsers()[i].Telephone });

            }
        }
        public class Item
        {

            public string FIO { get; set; }
            public string Email { get; set; }
            public string Telephone { get; set; }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuDirector Window = new MenuDirector();
            Window.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWorker Window = new AddWorker();
            Window.Show();
            this.Close();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Workers1, "Transactions");
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            Workers1.Items.Clear();
            for (int i = 0; i < Service.SelectUsers().Length; i++)
            {
                if (Service.SelectUsers()[i].Role_ID == 2)
                {
                    if (Convert.ToString(Service.SelectUsers()[i].Email).Contains(Search.Text) || Convert.ToString(Service.SelectUsers()[i].LastName).Contains(Search.Text) || Convert.ToString(Service.SelectUsers()[i].FirstName).Contains(Search.Text) || Convert.ToString(Service.SelectUsers()[i].Patronymic).Contains(Search.Text) || Convert.ToString(Service.SelectUsers()[i].Telephone).Contains(Search.Text))
                    {
                        Workers1.Items.Add(new Item() { Email = Service.SelectUsers()[i].Email, FIO = Service.FindByIDUsers(Service.SelectUsers()[i].id).LastName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).FirstName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).Patronymic, Telephone = Service.SelectUsers()[i].Telephone });
                    }
                    else if (Search.Text == "")
                    {
                        Workers1.Items.Add(new Item() { Email = Service.SelectUsers()[i].Email, FIO = Service.FindByIDUsers(Service.SelectUsers()[i].id).LastName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).FirstName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).Patronymic, Telephone = Service.SelectUsers()[i].Telephone });

                    }
                }
                
            }
        }
        
    }
}
