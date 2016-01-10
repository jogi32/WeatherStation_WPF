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
using System.Windows.Threading;

namespace WeatherStation_WPF
{
    /// <summary>
    /// Interaction logic for DataChartWindow.xaml
    /// </summary>
    public partial class DataChartWindow : Window
    {
        public DataChartWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);  // per 1 seconds,
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = true;
        }

        ~DataChartWindow()
        {
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DataHolder.i_faultyConter++;

            Temp1.Content = DataHolder.i_temperature1.ToString();
            Temp2.Content = DataHolder.i_temperature2.ToString();
            Temp3.Content = DataHolder.i_temperature3.ToString();

            HumAir.Content = DataHolder.i_humidityAir.ToString();
            HumEarth.Content = DataHolder.i_humidityEarth.ToString();
            HumRain.Content = DataHolder.i_humidityRain.ToString();

            Lux.Content = DataHolder.i_radianceCalculated.ToString();
            Height1.Content = DataHolder.i_heightCalculated.ToString();
            Pressure.Content = DataHolder.i_pressureCalculated.ToString();

            if ( DataHolder.i_temperatureAlarm)
            {
                Alarm_Temp.Fill = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Alarm_Temp.Fill = new SolidColorBrush(Colors.Green);
            }

            if (DataHolder.i_humidityAlarm)
            {
                Alarm_Hum.Fill = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Alarm_Hum.Fill = new SolidColorBrush(Colors.Green);
            }

            if (DataHolder.i_otherAlarm)
            {
                Alarm_Other.Fill = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Alarm_Other.Fill = new SolidColorBrush(Colors.Green);
            }

            if (DataHolder.i_faultyConter > 10)
            {
                Alarm_Temp.Fill = new SolidColorBrush(Colors.Red);
                Alarm_Hum.Fill = new SolidColorBrush(Colors.Red);
                Alarm_Other.Fill = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
