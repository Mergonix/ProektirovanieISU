﻿using System;
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

namespace Donor
{
    /// <summary>
    /// Логика взаимодействия для About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Requirements_Click(object sender, RoutedEventArgs e)
        {
            Requirements OpenRequirements = new Requirements();
            OpenRequirements.Show();
        }

        private void Centers_Click(object sender, RoutedEventArgs e)
        {
            Centers OpenCenters = new Centers();
            OpenCenters.Show();
        }
    }
}
