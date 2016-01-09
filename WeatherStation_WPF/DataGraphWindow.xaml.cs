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
        public UInt32 Data { get; set; }
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Interaction logic for DataGraphWindow.xaml
    /// </summary>
    public partial class DataGraphWindow : Window
    {
        ObservableCollection<KeyValuePair<Int32, double>> Temperature = new ObservableCollection<KeyValuePair<Int32, double>>();
        DataHolder dataHolder = new DataHolder();

        public DataGraphWindow()
        {
            InitializeComponent();
            showDataChart();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);  // per 5 seconds, you could change it
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = true;
        }

        Random random = new Random(DateTime.Now.Millisecond);
        void timer_Tick(object sender, EventArgs e)
        {
            Temperature.Add(new KeyValuePair<Int32, double>(DateTime.Now.Second, DataHolder.i_temperature1));
        }

        private void showDataChart()
        {
            TemperatureChart.DataContext = Temperature;
        }
    }
}
