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
    /// Логика взаимодействия для Make_a_deal.xaml
    /// </summary>
    public partial class Make_a_deal : Window
    {
        static ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
        int[] Help1 = new int[Service.SelectRealty().Length];
        int[] Help2 = new int[Service.SelectRealty().Length];
        public Make_a_deal()
        {
            InitializeComponent();
            
            for (int i = 0; i < Service.SelectRealty().Length; i++)
            {
                Property.Items.Add(Convert.ToString(Service.SelectRealty()[i].City)+Convert.ToString(Service.SelectRealty()[i].Street)+Convert.ToString(Service.SelectRealty()[i].NumberHouse)+Convert.ToString(Service.SelectRealty()[i].Apartment));
                Help1[i] = Service.SelectRealty()[i].id;//Property.DisplayMemberPath=Convert.ToString(Service.SelectRealty()[i].City)+Convert.ToString(Service.SelectRealty()[i].Street)+Convert.ToString(Service.SelectRealty()[i].NumberHouse)+Convert.ToString(Service.SelectRealty()[i].Apartment);
                //Property.SelectedValuePath = Convert.ToString(Service.SelectRealty()[i].id);
            }
            for (int i = 0; i < Service.SelectServices().Length; i++)
            {
                TypeOfDeal.Items.Add(Service.SelectServices()[i].Description);
                Help2[i] = Service.SelectServices()[i].id;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Base_of_transactions Window = new Base_of_transactions();
            Window.Show();
            this.Close();
        }

        private void MakeADeal_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            if (Convert.ToString(Property.SelectedItem)=="" || Convert.ToString(TypeOfDeal.SelectedItem)=="" || Convert.ToDouble(Cost.Text)<=0 || Cost.Text=="" )
            {
                MessageBox.Show("Заполните поля корректно", "Внимание");
            }
            else
            {
                
                ServiceReference1.Deal SaveDeal = new ServiceReference1.Deal();
                SaveDeal.Realty_ID = Help1[Convert.ToInt32(Property.SelectedIndex)];
                SaveDeal.DateDeal = Convert.ToDateTime(Date.SelectedDate);
                SaveDeal.Services_ID = Help2[Convert.ToInt32(TypeOfDeal.SelectedIndex)];
                SaveDeal.Users_ID = Authorization.IDUser;
                Service.AddDeal(SaveDeal);
                Base_of_transactions Window = new Base_of_transactions();
                Window.Show();
                this.Close();
            }
        }
    }
}
