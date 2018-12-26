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
    /// Логика взаимодействия для Transactions.xaml
    /// </summary>
    public partial class Transactions : Window
    {
        public Transactions()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            DataGridTextColumn PropertyType = new DataGridTextColumn();
            PropertyType.Header = "Вид недвижимости";
            PropertyType.Binding = new Binding("PropertyType");
            Trans.Columns.Add(PropertyType);
            DataGridTextColumn TypeOfDeal = new DataGridTextColumn();
            TypeOfDeal.Header = "Вид сделки";
            TypeOfDeal.Binding = new Binding("TypeOfDeal");
            Trans.Columns.Add(TypeOfDeal);
            DataGridTextColumn ColumnPrice = new DataGridTextColumn();
            ColumnPrice.Header = "Стоимость";
            ColumnPrice.Binding = new Binding("Price");
            Trans.Columns.Add(ColumnPrice);
            DataGridTextColumn ColumnDate = new DataGridTextColumn();
            ColumnDate.Header = "Дата";
            ColumnDate.Binding = new Binding("Date");
            Trans.Columns.Add(ColumnDate);
            DataGridTextColumn Rieltor = new DataGridTextColumn();
            Rieltor.Header = "Риелтор";
            Rieltor.Binding = new Binding("Rieltor");
            Trans.Columns.Add(Rieltor);
            DataGridTextColumn Users = new DataGridTextColumn();
            Users.Header = "Клиент";
            Users.Binding = new Binding("Users");
            Trans.Columns.Add(Users);

            for (int i = 0; i < Service.SelectDeal().Length; i++)
            {

                Trans.Items.Add(new Item() { PropertyType = Service.FindByIDProperty_Type(Service.FindByIdRealty(Service.SelectDeal()[i].Realty_ID).PropertyType_ID).DescriptionType, Users = Service.FindByIDUsers(Service.SelectRealty()[i].Users_ID).LastName + " " + Service.FindByIDUsers(Service.SelectRealty()[i].Users_ID).FirstName, Date = Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Day) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Month) +"/"+ Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Year), TypeOfDeal = Service.FindByIDServices(Service.SelectDeal()[i].Services_ID).Description, Price = Service.FindByIdRealty(Service.SelectDeal()[i].Realty_ID).Price, Rieltor = Service.FindByIDUsers(Service.SelectDeal()[i].Users_ID).LastName + " " + Service.FindByIDUsers(Service.SelectDeal()[i].Users_ID).FirstName });//,Users = Service.FindByIDUsers(Service.SelectDeal()[i].id).LastName

            }
        }
        public class Item
        {

            public string Users { get; set; }
            public string PropertyType { get; set; }
            public string Date { get; set; }
            public string TypeOfDeal { get; set; }
            public decimal Price { get; set; }
            public string Rieltor { get; set; }

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuDirector Window = new MenuDirector();
            Window.Show();
            this.Close();
        }
        
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            Trans.Items.Clear();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
  
            for (int i = 0; i < Service.SelectDeal().Length; i++)
            {
                if (Service.SelectDeal()[i].DateDeal > DataOt.SelectedDate && Service.SelectDeal()[i].DateDeal < DataDo.SelectedDate)
                {
                    Trans.Items.Add(new Item() { PropertyType = Service.FindByIDProperty_Type(Service.FindByIdRealty(Service.SelectDeal()[i].Realty_ID).PropertyType_ID).DescriptionType, Users = Service.FindByIDUsers(Service.SelectRealty()[i].Users_ID).LastName + " " + Service.FindByIDUsers(Service.SelectRealty()[i].Users_ID).FirstName, Date = Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Day) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Month) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectDeal()[i].DateDeal).Year), TypeOfDeal = Service.FindByIDServices(Service.SelectDeal()[i].Services_ID).Description, Price = Service.FindByIdRealty(Service.SelectDeal()[i].Realty_ID).Price, Rieltor = Service.FindByIDUsers(Service.SelectDeal()[i].Users_ID).LastName + " " + Service.FindByIDUsers(Service.SelectDeal()[i].Users_ID).FirstName });//,Users = Service.FindByIDUsers(Service.SelectDeal()[i].id).LastName
                }
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Trans, "Transactions");
            }
        }
    }
}
