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
using System.Windows.Controls.DataVisualization.Charting;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace WeatherStation_WPF
{
    public partial class DataGraphWindow : Window
    {
        ObservableCollection<KeyValuePair<Int32, double>> Temperature   = new ObservableCollection<KeyValuePair<Int32, double>>();
        ObservableCollection<KeyValuePair<Int32, double>> Pressure      = new ObservableCollection<KeyValuePair<Int32, double>>();
        ObservableCollection<KeyValuePair<Int32, double>> Humidity      = new ObservableCollection<KeyValuePair<Int32, double>>();
        ObservableCollection<KeyValuePair<Int32, UInt64>> Radiance      = new ObservableCollection<KeyValuePair<Int32, UInt64>>();


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        public DataGraphWindow()
        {
            InitializeComponent();
            showDataChart();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = true;
        }


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        void timer_Tick(object sender, EventArgs e)
        {
            Int32 seconds = DateTime.Now.Second;
            if (seconds == 0)
            {
                chartValueClear();
            }

            chartValueUpdate(seconds);
        }


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        private void chartValueClear()
        {
            Temperature.Clear();
            Pressure.Clear();
            Humidity.Clear();
            Radiance.Clear();
        }


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        private void chartValueUpdate(Int32 seconds)
        {
            Temperature.Add(new KeyValuePair<Int32, double>(seconds, DataHolder.i_temperature1));
            Pressure.Add(new KeyValuePair<Int32, double>(seconds, DataHolder.i_pressureCalculated));
            Humidity.Add(new KeyValuePair<Int32, double>(seconds, DataHolder.i_humidityAir));
            Radiance.Add(new KeyValuePair<Int32, UInt64>(seconds, DataHolder.i_radianceCalculated));
        }


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        private void showDataChart()
        {
            TemperatureChart.DataContext = Temperature;
            PressureChart.DataContext    = Pressure;
            HumidityChart.DataContext    = Humidity;
            RadianceChart.DataContext    = Radiance;
        }
    }
}
