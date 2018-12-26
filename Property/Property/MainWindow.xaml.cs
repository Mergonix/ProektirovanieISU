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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.IO;

namespace Property
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            PropType.Items.Add("");
            Obj.Items.Add("");
            NumbRooms.Items.Add("");
            Floor.Items.Add("");
            ObjType.Items.Add("");
            for (int i = 0; i < Service.SelectProperty_Type().Length; i++)
            {
                PropType.Items.Add(Service.SelectProperty_Type()[i].DescriptionType);
            }
            for (int i = 0; i < Service.SelectObject().Length; i++)
            {
                Obj.Items.Add(Service.SelectObject()[i].DescriptionObject);
            }
            for (int i = 1; i < 7; i++)
            {
                NumbRooms.Items.Add(i);
            }
            for (int i = 1; i < 25; i++)
            {
                Floor.Items.Add(i);
            }
            for (int i = 0; i < Service.SelectHouseType().Length; i++)
            {
                ObjType.Items.Add(Service.SelectHouseType()[i].DescriptionHouse);
            }
            DataGridTextColumn PropertyType = new DataGridTextColumn();
            PropertyType.Header = "Вид недвижимости";
            PropertyType.Binding = new Binding("PropertyType");
            Realty.Columns.Add(PropertyType);
            DataGridTextColumn ColumnObject = new DataGridTextColumn();
            ColumnObject.Header = "Тип объекта";
            ColumnObject.Binding = new Binding("Object");
            Realty.Columns.Add(ColumnObject);
            DataGridTextColumn ColumnHouseType = new DataGridTextColumn();
            ColumnHouseType.Header = "Вид объекта";
            ColumnHouseType.Binding = new Binding("HouseType");
            Realty.Columns.Add(ColumnHouseType);
            DataGridTextColumn ColumnNumberRooms = new DataGridTextColumn();
            ColumnNumberRooms.Header = "Количество комнат";
            ColumnNumberRooms.Binding = new Binding("NumberRooms");
            Realty.Columns.Add(ColumnNumberRooms);
            DataGridTextColumn ColumnTotalArea = new DataGridTextColumn();
            ColumnTotalArea.Header = "Общая площадь";
            ColumnTotalArea.Binding = new Binding("TotalArea");
            Realty.Columns.Add(ColumnTotalArea);
            DataGridTextColumn ColumnFlor = new DataGridTextColumn();
            ColumnFlor.Header = "Этаж, этажей";
            ColumnFlor.Binding = new Binding("Flor");
            Realty.Columns.Add(ColumnFlor);
            DataGridTextColumn ColumnPrice = new DataGridTextColumn();
            ColumnPrice.Header = "Цена";
            ColumnPrice.Binding = new Binding("Price");
            Realty.Columns.Add(ColumnPrice);
            DataGridTextColumn ColumnCity = new DataGridTextColumn();
            ColumnCity.Header = "Адрес";
            ColumnCity.Binding = new Binding("City");
            Realty.Columns.Add(ColumnCity);
            DataGridTextColumn ColumnDescript = new DataGridTextColumn();
            ColumnDescript.Header = "Описание";
            ColumnDescript.Binding = new Binding("Descript");
            Realty.Columns.Add(ColumnDescript);

            for (int i = 0; i < Service.SelectRealty().Length; i++)
            {

                Realty.Items.Add(new Item() { PropertyType = Service.FindByIDProperty_Type(Service.SelectRealty()[i].PropertyType_ID).DescriptionType, HouseType = Service.FindByIDHouseType(Service.SelectRealty()[i].HouseType_ID).DescriptionHouse, Object = Service.FindByIDObject(Service.SelectRealty()[i].Object_ID).DescriptionObject, NumberRooms = Service.SelectRealty()[i].NumberRooms, Status = Service.SelectRealty()[i].Status, Apartment = Service.SelectRealty()[i].Apartment, Street = Service.SelectRealty()[i].Street, City = Service.SelectRealty()[i].City + " , " + Service.SelectRealty()[i].Street + " " + Service.SelectRealty()[i].NumberHouse + " , " + Service.SelectRealty()[i].Apartment, Descript = Service.SelectRealty()[i].Descript, Price = Service.SelectRealty()[i].Price, Flors = Service.SelectRealty()[i].Flors, Flor = Service.SelectRealty()[i].Flor + " , " + Service.SelectRealty()[i].Flors, TotalArea = Service.SelectRealty()[i].TotalArea, NumberHouse = Service.SelectRealty()[i].NumberHouse, Users = Service.FindByIDUsers(Service.SelectRealty()[i].Users_ID).LastName });
               
            }
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            Authorization Window = new Authorization();
            Window.Show();
            this.Close();
        }

        private void MainWindow1_Activated(object sender, EventArgs e)
        {
            
        }
        public class Item
        {
            public decimal TotalArea { get; set; }
            public string Flor { get; set; }
            public int Flors{get;set;}
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

        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            Realty.Items.Clear();
            Realty.Columns.Clear();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            DataGridTextColumn PropertyType = new DataGridTextColumn();
            PropertyType.Header = "Вид недвижимости";
            PropertyType.Binding = new Binding("PropertyType");
            Realty.Columns.Add(PropertyType);
            DataGridTextColumn ColumnObject = new DataGridTextColumn();
            ColumnObject.Header = "Тип объекта";
            ColumnObject.Binding = new Binding("Object");
            Realty.Columns.Add(ColumnObject);
            DataGridTextColumn ColumnHouseType = new DataGridTextColumn();
            ColumnHouseType.Header = "Вид объекта";
            ColumnHouseType.Binding = new Binding("HouseType");
            Realty.Columns.Add(ColumnHouseType);
            DataGridTextColumn ColumnNumberRooms = new DataGridTextColumn();
            ColumnNumberRooms.Header = "Количество комнат";
            ColumnNumberRooms.Binding = new Binding("NumberRooms");
            Realty.Columns.Add(ColumnNumberRooms);
            DataGridTextColumn ColumnTotalArea = new DataGridTextColumn();
            ColumnTotalArea.Header = "Общая площадь";
            ColumnTotalArea.Binding = new Binding("TotalArea");
            Realty.Columns.Add(ColumnTotalArea);
            DataGridTextColumn ColumnFlor = new DataGridTextColumn();
            ColumnFlor.Header = "Этаж, этажей";
            ColumnFlor.Binding = new Binding("Flor");
            Realty.Columns.Add(ColumnFlor);
            DataGridTextColumn ColumnPrice = new DataGridTextColumn();
            ColumnPrice.Header = "Цена";
            ColumnPrice.Binding = new Binding("Price");
            Realty.Columns.Add(ColumnPrice);
            DataGridTextColumn ColumnCity = new DataGridTextColumn();
            ColumnCity.Header = "Адрес";
            ColumnCity.Binding = new Binding("City");
            Realty.Columns.Add(ColumnCity);
            DataGridTextColumn ColumnDescript = new DataGridTextColumn();
            ColumnDescript.Header = "Описание";
            ColumnDescript.Binding = new Binding("Descript");
            Realty.Columns.Add(ColumnDescript);

            for (int i = 0; i < Service.SelectRealty().Length; i++)
            {

                if ((Service.FindByIDProperty_Type(Service.SelectRealty()[i].PropertyType_ID).DescriptionType == Convert.ToString(PropType.SelectedItem) || Convert.ToString(PropType.SelectedItem)=="")
                    && (Service.FindByIDHouseType(Service.SelectRealty()[i].HouseType_ID).DescriptionHouse == Convert.ToString(ObjType.SelectedItem) || Convert.ToString(ObjType.SelectedItem)=="")
                    && (Service.FindByIDObject(Service.SelectRealty()[i].Object_ID).DescriptionObject == Convert.ToString(Obj.SelectedItem) || Convert.ToString(Obj.SelectedItem)=="")
                    && (Service.SelectRealty()[i].NumberRooms==Convert.ToInt32(NumbRooms.SelectedItem) || Convert.ToString(NumbRooms.SelectedItem)=="")
                    && (Service.SelectRealty()[i].Flor == Convert.ToInt32(Floor.SelectedItem) || Convert.ToString(Floor.SelectedItem)=="")
                    && (Service.SelectRealty()[i].Price<=Convert.ToDecimal(PriceMax.Text) || Convert.ToString(PriceMax.Text)==""))
                    Realty.Items.Add(new Item() { PropertyType = Service.FindByIDProperty_Type(Service.SelectRealty()[i].PropertyType_ID).DescriptionType, HouseType = Service.FindByIDHouseType(Service.SelectRealty()[i].HouseType_ID).DescriptionHouse, Object = Service.FindByIDObject(Service.SelectRealty()[i].Object_ID).DescriptionObject, NumberRooms = Service.SelectRealty()[i].NumberRooms, Status = Service.SelectRealty()[i].Status, Apartment = Service.SelectRealty()[i].Apartment, Street = Service.SelectRealty()[i].Street, City = Service.SelectRealty()[i].City + " , " + Service.SelectRealty()[i].Street + " " + Service.SelectRealty()[i].NumberHouse + " , " + Service.SelectRealty()[i].Apartment, Descript = Service.SelectRealty()[i].Descript, Price = Service.SelectRealty()[i].Price, Flors = Service.SelectRealty()[i].Flors, Flor = Service.SelectRealty()[i].Flor + " , " + Service.SelectRealty()[i].Flors, TotalArea = Service.SelectRealty()[i].TotalArea, NumberHouse = Service.SelectRealty()[i].NumberHouse, Users = Service.FindByIDUsers(Service.SelectRealty()[i].Users_ID).LastName });
                
            }
        }
    }
} 
