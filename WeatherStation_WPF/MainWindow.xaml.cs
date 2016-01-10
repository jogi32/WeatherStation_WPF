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
using System.IO.Ports;
using System.Windows.Threading;
using System.Windows.Controls.DataVisualization.Charting;

namespace WeatherStation_WPF
{
    public partial class MainWindow : Window
    {
        Window DataChart;
        Window DataGraph;
        SerialPortController serialController;

        public MainWindow()
        {
            InitializeComponent();

            DataChart = new DataChartWindow();
            DataGraph = new DataGraphWindow();

            //DataGraph.Show();
            //DataChart.Show();

            serialController = new SerialPortController();
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
            DataChart.Close();
            DataChart = new DataChartWindow();
            DataChart.Show();
        }

        private void AppExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}
