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
        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        public DataChartWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = true;
        }


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        void timer_Tick(object sender, EventArgs e)
        {
            DataHolder.i_faultyConter++;

            dataLabelUpdate();

            alarmUpdate();
        }


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        private void alarmUpdate()
        {
            if (DataHolder.i_temperatureAlarm)
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


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        private void dataLabelUpdate()
        {
            Temp1.Content = DataHolder.i_temperature1.ToString("0.0") + " *C";
            Temp2.Content = DataHolder.i_temperature2.ToString("0.0") + " *C";
            Temp3.Content = DataHolder.i_temperature3.ToString("0.0") + " *C";

            HumAir.Content = DataHolder.i_humidityAir.ToString("0.0") + " %";
            HumEarth.Content = DataHolder.i_humidityEarth.ToString("0.0") + " %";
            HumRain.Content = DataHolder.i_humidityRain.ToString("0.0") + " %";

            Lux.Content = DataHolder.i_radianceCalculated.ToString("0.0") + " Lux";
            Height1.Content = DataHolder.i_heightCalculated.ToString("0.0") + " m";
            Pressure.Content = DataHolder.i_pressureCalculated.ToString("0.0") + " hPa";
        }
    }
}
