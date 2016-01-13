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
        public SerialPort i_serialPort1;


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        public SerialPortController() 
        {
            i_serialPort1 = new SerialPort("COM5", 9600);
            i_serialPort1.StopBits = StopBits.One;
            i_serialPort1.DataBits = 8;
            i_serialPort1.Parity = Parity.None;
            i_serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            i_serialPort1.ReadTimeout = 50;

            try
            {
                i_serialPort1.Open();
                i_serialPort1.DiscardInBuffer();
            }
            catch
            {
            }
            
        }


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        ~SerialPortController()
        {
            closeSerialPort();  
        }


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        private void closeSerialPort()
        {
            if (!(i_serialPort1 == null))
            {
                if (i_serialPort1.IsOpen)
                {
                    i_serialPort1.DiscardInBuffer();
                    i_serialPort1.Close();
                }
            }
        }


        //--------//--------//--------//--------//--------//--------//--------//--------//--------
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(200);
                return 42;
            });
            t.Wait();

            DataHolder.i_faultyConter = 0;

            SerialPort sp = (SerialPort)sender;

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

                DataHolder.i_heightCalculated = 44330 * (1 - Math.Pow((DataHolder.i_pressureCalculated / DataHolder.i_pressureInSeaArea), (1 / 5.255)));
            }
            catch { DataHolder.i_otherAlarm = true; }

            try
            {
                sp.DiscardInBuffer();
            }
            catch { }            
        }
    }

   
}
