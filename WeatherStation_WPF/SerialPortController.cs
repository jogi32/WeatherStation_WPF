using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Threading;
using System.Windows;

namespace WeatherStation_WPF
{
    class SerialPortController
    {
        private static SerialPortController instance;
        static SerialPort serialPort1 = new SerialPort("COM5", 9600);

        public SerialPortController() 
        {
            
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort1.ReadTimeout = 50;
            try
            {
                serialPort1.Open();
            }
            catch
            {

            }
            
            /*
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += timer_Tick;
            timer.Start();
             * */
        }

        ~SerialPortController()
        {
            if (!(serialPort1 == null))
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }   
        }

        public static SerialPortController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SerialPortController();
                }
                return instance;
            }
        }
        /*
        void timer_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.DiscardInBuffer();
        }
        */

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            try
            {
                sp.ReadTo(" ");
            }
            catch {}
            try
            {
                DataHolder.i_temperature1 = Double.Parse(sp.ReadTo(" "));
            }
            catch { }
            try
            {
                DataHolder.i_temperature2 = Double.Parse(sp.ReadTo(" ")) / 10;
            }
            catch { }
            try
            {
                DataHolder.i_humidityAir = Double.Parse(sp.ReadTo(" ")) / 10;
            }
            catch { }
            try
            {
                DataHolder.i_humidityEarth = (1023 - Double.Parse(sp.ReadTo(" "))) / 100;
            }
            catch { }
            try
            {
                DataHolder.i_humidityRain = (1023 - Double.Parse(sp.ReadTo(" "))) / 100;
            }
            catch { }
            try
            {
                DataHolder.i_radianceRaceived = Double.Parse(sp.ReadTo(" "));
                DataHolder.i_radianceHight = UInt32.Parse(sp.ReadTo(","));
                DataHolder.i_radianceLow = UInt32.Parse(sp.ReadTo(" "));
                DataHolder.i_radianceCalculated = (DataHolder.i_radianceHight << 8) + DataHolder.i_radianceLow;
            }
            catch { }
            try
            {
                DataHolder.i_temperature3 = Double.Parse(sp.ReadTo(" ")) / 10;
            }
            catch { }
            try
            {
                DataHolder.i_pressureHight = UInt32.Parse(sp.ReadTo(" "));
                DataHolder.i_pressureLow = UInt32.Parse(sp.ReadTo(" "));
                DataHolder.i_pressureCalculated = (DataHolder.i_pressureHight << 8) + DataHolder.i_pressureLow;
            }
            catch { }
            

            sp.DiscardInBuffer();
        }
    }

   
}
