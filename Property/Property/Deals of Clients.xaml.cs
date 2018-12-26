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
    /// Логика взаимодействия для Deals_of_Clients.xaml
    /// </summary>
    public partial class Deals_of_Clients : Window
    {
        public Deals_of_Clients()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
           
            DataGridTextColumn PropertyType = new DataGridTextColumn();
            PropertyType.Header = "Вид недвижимости";
            PropertyType.Binding = new Binding("PropertyType");
            MyDeals.Columns.Add(PropertyType);
            DataGridTextColumn ColumnTypeOfDeal = new DataGridTextColumn();
            ColumnTypeOfDeal.Header = "Вид сделки";
            ColumnTypeOfDeal.Binding = new Binding("Services");
            MyDeals.Columns.Add(ColumnTypeOfDeal);
            DataGridTextColumn ColumnPrice = new DataGridTextColumn();
            ColumnPrice.Header = "Стоимость";
            ColumnPrice.Binding = new Binding("Price");
            MyDeals.Columns.Add(ColumnPrice);
            DataGridTextColumn ColumnDate = new DataGridTextColumn();
            ColumnDate.Header = "Дата";
            ColumnDate.Binding = new Binding("Date");
            MyDeals.Columns.Add(ColumnDate);
            DataGridTextColumn ColumnRieltor = new DataGridTextColumn();
            ColumnRieltor.Header = "Риелтор";
            ColumnRieltor.Binding = new Binding("Users");
            MyDeals.Columns.Add(ColumnRieltor);

            for (int i = 0; i < Service.SelectRealtorDeal(Authorization.IDUser).Length; i++)// i < Service.SelectRealtorDeal(Authorization.IDUser)
            {
                //if (Service.SelectDeal()[i]. ==(Authorization.IDUser))
                MyDeals.Items.Add(new Item() { PropertyType = Service.SelectRealtorDeal(Authorization.IDUser)[i].Property_Type, Services = Service.SelectRealtorDeal(Authorization.IDUser)[i].Services, Price = Service.SelectRealtorDeal(Authorization.IDUser)[i].Price, Users = Service.FindByIDUsers(Service.SelectRealtorDeal(Authorization.IDUser)[i].Users_ID).LastName +" " + Service.FindByIDUsers(Service.SelectRealtorDeal(Authorization.IDUser)[i].Users_ID).FirstName, Date = Convert.ToString(Convert.ToDateTime(Service.SelectRealtorDeal(Authorization.IDUser)[i].DateDeal).Day) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectRealtorDeal(Authorization.IDUser)[i].DateDeal).Month) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectRealtorDeal(Authorization.IDUser)[i].DateDeal).Year) });

            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuClient Window = new MenuClient();
            Window.Show();
            this.Close();
        }
        public class Item
        {
            public string Date { get; set; }
            public decimal TotalArea { get; set; }
            public string Flor { get; set; }
            public int Flors { get; set; }
            public decimal Price { get; set; }
            public string Descript { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string Apartment { get; set; }
            public string Status { get; set; }
            public string NumberHouse { get; set; }
            public int NumberRooms { get; set; }
            public string Users { get; set; }
            public string PropertyType { get; set; }
            public string Object { get; set; }
            public string HouseType { get; set; }
            public string Services { get; set; }

        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            MyDeals.Items.Clear();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            for (int i = 0; i < Service.SelectRealtorDeal(Authorization.IDUser).Length; i++)
            {
                if (Service.SelectRealtorDeal(Authorization.IDUser)[i].DateDeal > DataOt.SelectedDate && Service.SelectRealtorDeal(Authorization.IDUser)[i].DateDeal < DataDo.SelectedDate)
                {
                    MyDeals.Items.Add(new Item() { PropertyType = Service.SelectRealtorDeal(Authorization.IDUser)[i].Property_Type, Services = Service.SelectRealtorDeal(Authorization.IDUser)[i].Services, Price = Service.SelectRealtorDeal(Authorization.IDUser)[i].Price, Users = Service.FindByIDUsers(Service.SelectRealtorDeal(Authorization.IDUser)[i].Users_ID).LastName + " "+ Service.FindByIDUsers(Service.SelectRealtorDeal(Authorization.IDUser)[i].Users_ID).FirstName, Date = Convert.ToString(Convert.ToDateTime(Service.SelectRealtorDeal(Authorization.IDUser)[i].DateDeal).Day) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectRealtorDeal(Authorization.IDUser)[i].DateDeal).Month) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectRealtorDeal(Authorization.IDUser)[i].DateDeal).Year) });

                }//,Users = Service.FindByIDUsers(Service.SelectDeal()[i].id).LastName

            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(MyDeals, "Transactions");
            }
        }
    }
}
