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

using ClassLibrary1.Collections.Generic;
using System.ComponentModel;

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
    public partial class DataGraphWindow : Window, INotifyPropertyChanged
    {
        Random rnd = new Random();
       
        public DataGraphWindow()
        {
            InitializeComponent();
        }

        private void mcChart_Loaded(object sender, RoutedEventArgs e)
        {
            ZaladujDane();
        }

        //Dane String i Int (Odpowiadajace wartościom CHART w XAML
        //     IndependentValueBinding="{Binding Path=Key}"
        //     DependentValueBinding="{Binding Path=Value}">
        private void ZaladujDane()
        {
            ((LineSeries)mcChart.Series[0]).ItemsSource =
            new KeyValuePair<string, int>[]{
            new KeyValuePair<string,int>("Google", 90),
            new KeyValuePair<string,int>("WP", 3),
            new KeyValuePair<string,int>("Netsprint", 2),
            new KeyValuePair<string,int>("Onet", 2),
            new KeyValuePair<string,int>("Interia", 1),
            new KeyValuePair<string,int>("MSN", 2) };
        }

        public void InitMemoryWatch()
        {
            // keep 60 seconds worth of memory by default
            const int memorySamples = 60;
            MemoryStats = new RingBuffer<MemorySample>(memorySamples);

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimerTick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimerTick(object sender, EventArgs e)
        {
            LatestMemorySample = new MemorySample
            {
                ByteCount = rnd.Next(1, 13), // creates a number between 1 and 12//GC.GetTotalMemory(false),
                Timestamp = DateTime.Now
            };
            _memoryStats.Add(LatestMemorySample);
        }

        private RingBuffer<MemorySample> _memoryStats;
        public RingBuffer<MemorySample> MemoryStats
        {
            get { return _memoryStats; }
            set
            {
                _memoryStats = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MemoryStats"));
                }
            }
        }
        private MemorySample _latestMemorySample;
        public MemorySample LatestMemorySample
        {
            get { return _latestMemorySample; }
            set
            {
                _latestMemorySample = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LatestMemorySample"));
                }
            }
        }

        #region INotifyPropertyChanged Interface

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
