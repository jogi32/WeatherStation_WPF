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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Windows.Threading;
using System.Windows.Controls.DataVisualization.Charting;

namespace WeatherStation_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void But_Bt_Stop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void But_Bt_Start_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProgBar1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Author\n Tomasz Szafrański");
        }

        private void DataGraphWindow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProgresBarWIndow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataChartWindow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}