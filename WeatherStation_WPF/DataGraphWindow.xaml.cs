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
using System.Windows.Controls.DataVisualization.Charting;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace WeatherStation_WPF
{
    public class MemorySample
    {
        public long ByteCount { get; set; }
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Interaction logic for DataGraphWindow.xaml
    /// </summary>
    public partial class DataGraphWindow : Window
    {
        ObservableCollection<KeyValuePair<double, double>> Power = new ObservableCollection<KeyValuePair<double, double>>();

        public DataGraphWindow()
        {
            InitializeComponent();
            showColumnChart();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);  // per 5 seconds, you could change it
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = true;
        }

        double i = 5;
        Random random = new Random(DateTime.Now.Millisecond);
        void timer_Tick(object sender, EventArgs e)
        {
            Power.Add(new KeyValuePair<double, double>(i, random.NextDouble()));
            i += 1;
        }

        private void showColumnChart()
        {
            TemperatureChart.DataContext = Power;
        }
    }
}
