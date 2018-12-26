using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Логика взаимодействия для RatingWorkers.xaml
    /// </summary>
    public partial class RatingWorkers : Window
    {
        public RatingWorkers()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            DataGridTextColumn Rang = new DataGridTextColumn();
            Rang.Header = "Ранг";
            Rang.Binding = new Binding("Rang");
            Rating.Columns.Add(Rang);
            DataGridTextColumn ColumnFIO = new DataGridTextColumn();
            ColumnFIO.Header = "Ф.И.О.";
            ColumnFIO.Binding = new Binding("FIO");
            Rating.Columns.Add(ColumnFIO);
            DataGridTextColumn ColumnDateBirth = new DataGridTextColumn();
            ColumnDateBirth.Header = "Количество сделок";
            ColumnDateBirth.Binding = new Binding("CountDeals");
            Rating.Columns.Add(ColumnDateBirth);
            DataGridTextColumn ColumnTelephone = new DataGridTextColumn();
            ColumnTelephone.Header = "Сумма сделок";
            ColumnTelephone.Binding = new Binding("SumDeals");
            Rating.Columns.Add(ColumnTelephone);

            for (int i = 0; i < Service.ReportCount().Length; i++)
            {
                Rating.Items.Add(new Item() {Rang = i+1, FIO = Service.ReportCount()[i].LastName + " " + Service.ReportCount()[i].FirstName + " " + Service.ReportCount()[i].Patronymic,CountDeals=Service.ReportCount()[i].Count,SumDeals=Service.ReportCount()[i].Sum });
            }
           
           // (Rating.ItemsSource as DataView).Sort = "SumDeals";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuDirector Window = new MenuDirector();
            Window.Show();
            this.Close();
        }


        private void RangCountDeal_Click(object sender, RoutedEventArgs e)
        {
            Rating.Items.Clear();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            //Rating.Items.SortDescriptions.Clear();
            //var column = Rating.Columns[2];
            //Rating.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, ListSortDirection.Descending));
            //for (int i = 0; i < Rating.Items.Count; i++)
            //{
            //   // Rating.Columns[0].
            //}
            for (int i = 0; i < Service.ReportCount().Length; i++)
            {
                Rating.Items.Add(new Item() { Rang = i+1, FIO = Service.ReportCount()[i].LastName + " " + Service.ReportCount()[i].FirstName + " " + Service.ReportCount()[i].Patronymic, CountDeals = Service.ReportCount()[i].Count, SumDeals = Service.ReportCount()[i].Sum });
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Rating, "Transactions");
            }
        }
        public class Item
        {
            public int Rang { get; set; }
            public string FIO { get; set; }
            public int CountDeals { get; set; }
            public decimal SumDeals { get; set; }
        }

        private void RangSumDeal_Click(object sender, RoutedEventArgs e)
        {
            Rating.Items.Clear();
            //Rating.Items.SortDescriptions.Clear();
            //var column = Rating.Columns[3];
            //Rating.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, ListSortDirection.Descending));
            //for (int i = 0; i < Rating.Items.Count; i++)
            //{
            //    //Rating.Items[i]= i;
            //}
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            for (int i = 0; i < Service.ReportPrice().Length; i++)
            {
                Rating.Items.Add(new Item() { Rang = i+1, FIO = Service.ReportPrice()[i].LastName + " " + Service.ReportPrice()[i].FirstName + " " + Service.ReportPrice()[i].Patronymic, CountDeals = Service.ReportPrice()[i].Count, SumDeals = Service.ReportPrice()[i].Sum });
            }
        }
    }
}
