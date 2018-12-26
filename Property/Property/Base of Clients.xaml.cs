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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Property
{
    /// <summary>
    /// Логика взаимодействия для Base_of_Clients.xaml
    /// </summary>
    public partial class Base_of_Clients : System.Windows.Window
    {
        public Base_of_Clients()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            DataGridTextColumn ColumnFIO = new DataGridTextColumn();
            ColumnFIO.Header = "Ф.И.О.";
            ColumnFIO.Binding = new Binding("FIO");
            Clients.Columns.Add(ColumnFIO);
            DataGridTextColumn ColumnDateBirth = new DataGridTextColumn();
            ColumnDateBirth.Header = "Дата рождения";
            ColumnDateBirth.Binding = new Binding("DateBirth");
            Clients.Columns.Add(ColumnDateBirth);
            DataGridTextColumn ColumnAdress = new DataGridTextColumn();
            ColumnAdress.Header = "Адрес";
            ColumnAdress.Binding = new Binding("Adress");
            Clients.Columns.Add(ColumnAdress);
            DataGridTextColumn ColumnTelephone = new DataGridTextColumn();
            ColumnTelephone.Header = "Телефон";
            ColumnTelephone.Binding = new Binding("Telephone");
            Clients.Columns.Add(ColumnTelephone);

            for (int i = 0; i < Service.SelectUsers().Length; i++)
            {
                if (Service.SelectUsers()[i].Role_ID==1)
                Clients.Items.Add(new Item() { FIO = Service.FindByIDUsers(Service.SelectUsers()[i].id).LastName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).FirstName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).Patronymic, DateBirth = Convert.ToString(Convert.ToDateTime(Service.SelectUsers()[i].DateBirth).Day) +"/"+ Convert.ToString(Convert.ToDateTime(Service.SelectUsers()[i].DateBirth).Month) +"/"+ Convert.ToString(Convert.ToDateTime(Service.SelectUsers()[i].DateBirth).Year), Adress = Service.SelectUsers()[i].Adress, Telephone = Service.SelectUsers()[i].Telephone });

            }
        }
        public class Item
        {

            public string FIO { get; set; }
            public string Adress { get; set; }
            public string DateBirth { get; set; }
            public string Telephone { get; set; }

        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient Window = new AddClient();
            Window.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuRealtor Window = new MenuRealtor();
            Window.Show();
            this.Close();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Clients, "Transactions");
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < Clients.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = Clients.Columns[j].Header;
            }
            for (int i = 0; i < Clients.Columns.Count; i++)
            {
                for (int j = 0; j < Clients.Items.Count; j++)
                {
                    TextBlock b = Clients.Columns[i].GetCellContent(Clients.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }

        private void Search_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            Clients.Items.Clear();
            for (int i = 0; i < Service.SelectUsers().Length; i++)
            {
                if (Service.SelectUsers()[i].Role_ID == 1)
                {
                    if ((Convert.ToString(Service.FindByIDUsers(Service.SelectUsers()[i].id).LastName).Contains(Search.Text)) || Convert.ToString(Service.FindByIDUsers(Service.SelectUsers()[i].id).FirstName).Contains(Search.Text) || Convert.ToString(Service.FindByIDUsers(Service.SelectUsers()[i].id).Patronymic).Contains(Search.Text) || Convert.ToString(Service.FindByIDUsers(Service.SelectUsers()[i].id).DateBirth).Contains(Search.Text) || (Convert.ToString(Service.FindByIDUsers(Service.SelectUsers()[i].id).Adress).Contains(Search.Text) || Convert.ToString(Service.FindByIDUsers(Service.SelectUsers()[i].id).Telephone).Contains(Search.Text)))
                        Clients.Items.Add(new Item() { FIO = Service.FindByIDUsers(Service.SelectUsers()[i].id).LastName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).FirstName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).Patronymic, DateBirth = Convert.ToString(Convert.ToDateTime(Service.SelectUsers()[i].DateBirth).Day) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectUsers()[i].DateBirth).Month) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectUsers()[i].DateBirth).Year), Adress = Service.SelectUsers()[i].Adress, Telephone = Service.SelectUsers()[i].Telephone });
                    else if (Search.Text == "")
                    {
                        Clients.Items.Add(new Item() { FIO = Service.FindByIDUsers(Service.SelectUsers()[i].id).LastName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).FirstName + " " + Service.FindByIDUsers(Service.SelectUsers()[i].id).Patronymic, DateBirth = Convert.ToString(Convert.ToDateTime(Service.SelectUsers()[i].DateBirth).Day) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectUsers()[i].DateBirth).Month) + "/" + Convert.ToString(Convert.ToDateTime(Service.SelectUsers()[i].DateBirth).Year), Adress = Service.SelectUsers()[i].Adress, Telephone = Service.SelectUsers()[i].Telephone });
                    }
                }
            }
        }
    }
}
