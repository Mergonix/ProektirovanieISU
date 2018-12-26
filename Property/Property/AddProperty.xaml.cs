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
    /// Логика взаимодействия для AddProperty.xaml
    /// </summary>
    public partial class AddProperty : Window
    {
        static ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
        int[] Help1 = new int[Service.SelectRealty().Length];
        int[] Help2 = new int[Service.SelectRealty().Length];
        int[] Help3 = new int[Service.SelectRealty().Length];
        public AddProperty()
        {
            InitializeComponent();
            for (int i = 0; i < Service.SelectProperty_Type().Length; i++)
            {
                PropType.Items.Add(Service.SelectProperty_Type()[i].DescriptionType);
                Help1[i] = Service.SelectProperty_Type()[i].id;
            }
            for (int i = 0; i < Service.SelectObject().Length; i++)
            {
                Obj.Items.Add(Service.SelectObject()[i].DescriptionObject);
                Help2[i] = Service.SelectObject()[i].id;
            }
            for (int i = 0; i < Service.SelectHouseType().Length; i++)
            {
                ObjType.Items.Add(Service.SelectHouseType()[i].DescriptionHouse);
                Help3[i] = Service.SelectHouseType()[i].id;
            }
            for (int i = 1; i < 7; i++)
            {
                NumbRooms.Items.Add(i);
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MyProperty Window = new MyProperty();
            Window.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(PropType.SelectedItem)=="" || Convert.ToString(Obj.SelectedItem)=="" || Convert.ToString(ObjType.SelectedItem)=="" || Convert.ToString(NumbRooms.SelectedItem)==""
                || TotalArea.Text=="" || Floor.Text=="" || Floors.Text=="" || Price.Text=="" || Adress.Text=="" || Description.Text=="")
            {
                
            }
            else
            {
                ServiceReference1.Realty Real = new ServiceReference1.Realty();
                Real.PropertyType_ID = Help1[PropType.SelectedIndex];
                Real.Object_ID = Help2[Obj.SelectedIndex];
                Real.HouseType_ID = Help3[ObjType.SelectedIndex];
                Real.NumberRooms = Convert.ToInt32(NumbRooms.SelectedItem);
                Real.TotalArea = Convert.ToDecimal(TotalArea.Text);
                Real.Flor = Convert.ToInt32(Floor.Text);
                Real.Flors = Convert.ToInt32(Floors.Text);
                Real.Price = Convert.ToDecimal(Price.Text);
                Real.City = Convert.ToString(Adress.Text);
                Real.Street = Convert.ToString(Street.Text);
                Real.NumberHouse = Convert.ToString(NumberHouse.Text);
                Real.Apartment = Convert.ToString(NumberRoom.Text);
                Real.Descript = Convert.ToString(Description.Text);
                Real.Users_ID = Authorization.IDUser;
                Real.Status = "Не сдано";
                Service.AddRealty(Real);
                MyProperty Window = new MyProperty();
                Window.Show();
                this.Close();
               // Real.PropertyType_ID = Convert.ToString(PropType.SelectedItem);
                //Service.AddRealty();
            }
        }
    }
}
