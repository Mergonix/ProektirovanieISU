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
    /// Логика взаимодействия для Base_of_transactions.xaml
    /// </summary>
    public partial class Base_of_transactions : Window
    {
        public Base_of_transactions()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            DataGridTextColumn PropertyType = new DataGridTextColumn();
            PropertyType.Header = "Вид недвижимости";
            PropertyType.Binding = new Binding("PropertyType");
            Transactions.Columns.Add(PropertyType);
            DataGridTextColumn TypeOfDeal = new DataGridTextColumn();
            TypeOfDeal.Header = "Тип сделки";
            TypeOfDeal.Binding = new Binding("TypeOfDeal");
            Transactions.Columns.Add(TypeOfDeal);
            DataGridTextColumn ColumnPrice = new DataGridTextColumn();
            ColumnPrice.Header = "Стоимость";
            ColumnPrice.Binding = new Binding("Price");
            Transactions.Columns.Add(ColumnPrice);
            DataGridTextColumn ColumnDate = new DataGridTextColumn();
            ColumnDate.Header = "Дата";
            ColumnDate.Binding = new Binding("Date");
            Transactions.Columns.Add(ColumnDate);
            DataGridTextColumn Users = new DataGridTextColumn();
            Users.Header = "Клиент";
            Users.Binding = new Binding("Users");
            Transactions.Columns.Add(Users);

            for (int i = 0; i < Service.SelectDeal().Length; i++)
            {
                Transactions.Items.Add(new Item() { PropertyType = Service.FindByIDProperty_Type(Service.FindByIdRealty(Service.SelectDeal()[i].Realty_ID).PropertyType_ID).DescriptionType, Users = Service.FindByIDUsers(Service.SelectDeal()[i].Users_ID).LastName + " " + Service.FindByIDUsers(Service.SelectDeal()[i].Users_ID).FirstName, Date = Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Day)+"/"+Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Month)+"/"+Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Year), TypeOfDeal = Service.FindByIDServices(Service.SelectDeal()[i].Services_ID).Description, Price = Service.FindByIdRealty(Service.SelectDeal()[i].Realty_ID).Price });//,Users = Service.FindByIDUsers(Service.SelectDeal()[i].id).LastName

            }
        }
        public class Item
        {
           
            public string Users { get; set; }
            public string PropertyType { get; set; }
            public string Date { get; set; }
            public string TypeOfDeal { get; set; }
            public decimal Price { get; set; }

        }

        private void Deal_Click(object sender, RoutedEventArgs e)
        {
            Make_a_deal Window = new Make_a_deal();
            Window.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuRealtor Window = new MenuRealtor();
            Window.Show();
            this.Close();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            Transactions.Items.Clear();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            for (int i = 0; i < Service.SelectDeal().Length; i++)
            {
                if (Service.SelectDeal()[i].DateDeal > DataOt.SelectedDate && Service.SelectDeal()[i].DateDeal < DataDo.SelectedDate)
                {
                    Transactions.Items.Add(new Item() { PropertyType = Service.FindByIDProperty_Type(Service.FindByIdRealty(Service.SelectDeal()[i].Realty_ID).PropertyType_ID).DescriptionType, Users = Service.FindByIDUsers(Service.SelectDeal()[i].Users_ID).LastName + " " + Service.FindByIDUsers(Service.SelectDeal()[i].Users_ID).FirstName, Date = Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Day) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Month) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Year), TypeOfDeal = Service.FindByIDServices(Service.SelectDeal()[i].Services_ID).Description, Price = Service.FindByIdRealty(Service.SelectDeal()[i].Realty_ID).Price });
                }//,Users = Service.FindByIDUsers(Service.SelectDeal()[i].id).LastName

            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Transactions, "Transactions");
            }
        }
    }
}
