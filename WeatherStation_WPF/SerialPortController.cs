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
        static SerialPort   i_serialPort1 = new SerialPort("COM5", 9600);
        private String      i_dataBufor = "";

        public SerialPortController() 
        {

            i_serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            i_serialPort1.ReadTimeout = 50;
            try
            {
                //i_serialPort1.Open();
            }
            catch
            {

            }
        }

        ~SerialPortController()
        {
            if (!(i_serialPort1 == null))
            {
                if (i_serialPort1.IsOpen)
                {
                    i_serialPort1.Close();
                }
            }   
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            DataHolder.i_faultyConter = 0;

            SerialPort sp = (SerialPort)sender;
            i_dataBufor = sp.ReadLine();

            try
            {
                sp.ReadTo(" ");
            }
            catch {}
            try
            {
                DataHolder.i_temperature1 = Double.Parse(sp.ReadTo(" "));
                DataHolder.i_temperatureAlarm = false;
            }
            catch { DataHolder.i_temperatureAlarm = true; }
            try
            {
                DataHolder.i_temperature2 = Double.Parse(sp.ReadTo(" ")) / 10;
                DataHolder.i_temperatureAlarm = false;
            }
            catch { DataHolder.i_temperatureAlarm = true; }
            try
            {
                DataHolder.i_humidityAir = Double.Parse(sp.ReadTo(" ")) / 10;
                DataHolder.i_humidityAlarm = false;
            }
            catch { DataHolder.i_humidityAlarm = true; }
            try
            {
                DataHolder.i_humidityEarth = (1023 - Double.Parse(sp.ReadTo(" "))) / 100;
                DataHolder.i_humidityAlarm = false;
            }
            catch { DataHolder.i_humidityAlarm = true;  }
            try
            {
                DataHolder.i_humidityRain = (1023 - Double.Parse(sp.ReadTo(" "))) / 100;
                DataHolder.i_humidityAlarm = false;
            }
            catch { DataHolder.i_humidityAlarm = true;  }
            try
            {
                DataHolder.i_radianceRaceived = UInt64.Parse(sp.ReadTo(" "));
                DataHolder.i_radianceHight = UInt32.Parse(sp.ReadTo(","));
                DataHolder.i_radianceLow = UInt32.Parse(sp.ReadTo(" "));
                DataHolder.i_radianceCalculated = Convert.ToUInt64(((DataHolder.i_radianceHight << 8) + DataHolder.i_radianceLow) / 1.2);
                DataHolder.i_otherAlarm = false;
            }
            catch { DataHolder.i_otherAlarm = true; }
            try
            {
                DataHolder.i_temperature3 = Double.Parse(sp.ReadTo(" ")) / 10;
                DataHolder.i_temperatureAlarm = false;
            }
            catch { DataHolder.i_temperatureAlarm = true; }
            try
            {
                DataHolder.i_pressureHight = UInt32.Parse(sp.ReadTo(" "));
                sp.ReadTo(" ");
                DataHolder.i_pressureLow = UInt32.Parse(sp.ReadTo(" "));
                DataHolder.i_pressureCalculated = ((DataHolder.i_pressureHight << 8) + DataHolder.i_pressureLow)/100;
                DataHolder.i_otherAlarm = false;
            }
            catch { DataHolder.i_otherAlarm = true; }
            
            sp.DiscardInBuffer();
        }
    }

   
}
