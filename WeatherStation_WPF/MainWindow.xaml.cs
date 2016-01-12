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

            DataGraph.Show();
            DataChart.Show();

            serialController = new SerialPortController();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            ProgBarT1.Value         = DataHolder.i_temperature1;
            T1Value.Content         = DataHolder.i_temperature1.ToString();
            ProgBarT2.Value         = DataHolder.i_temperature2;
            T2Value.Content         = DataHolder.i_temperature2.ToString();
            ProgBarT3.Value         = DataHolder.i_temperature3;
            T3Value.Content         = DataHolder.i_temperature3.ToString();
            ProgBarPressure.Value   = DataHolder.i_pressureCalculated;
            PressureValue.Content   = DataHolder.i_pressureCalculated.ToString();
            ProgBarHeight.Value     = DataHolder.i_heightCalculated;
            HeightValue.Content     = DataHolder.i_heightCalculated.ToString("0.0");
            pbStatus.Value          = DataHolder.i_radianceCalculated / 10;
            RadianceValue.Content   = DataHolder.i_radianceCalculated.ToString();

            // Set Fill property of rectangle
            HumAirElipse.Fill = ElepseFillBrush(DataHolder.i_humidityAir / 100.0);
            HumEarthElipse.Fill = ElepseFillBrush(DataHolder.i_humidityEarth / 100.0);
            HumRainElipse.Fill = ElepseFillBrush(DataHolder.i_humidityRain / 100.0);
        }

        private LinearGradientBrush ElepseFillBrush(double humidity_)
        {
            // Create a linear gradient brush with two stops 
            LinearGradientBrush BrushColor = new LinearGradientBrush();
            BrushColor.StartPoint = new Point(0, 0);
            BrushColor.EndPoint = new Point(1, 1);

            // Create and add Gradient stops
            GradientStop whiteGS = new GradientStop();
            whiteGS.Color = Colors.White;
            whiteGS.Offset = 0.0;
            BrushColor.GradientStops.Add(whiteGS);

            GradientStop blueGS = new GradientStop();
            blueGS.Color = Colors.Blue;
            blueGS.Offset = 1.0 - humidity_;
            BrushColor.GradientStops.Add(blueGS);

            return BrushColor;
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
            DataChart.Close();
            DataGraph.Close();
        }
    }

    
}
