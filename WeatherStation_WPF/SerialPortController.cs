﻿using System;
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
                DataHolder.i_radianceRaceived = UInt64.Parse(sp.ReadTo(" "));
                DataHolder.i_radianceHight = UInt32.Parse(sp.ReadTo(","));
                DataHolder.i_radianceLow = UInt32.Parse(sp.ReadTo(" "));
                DataHolder.i_radianceCalculated = Convert.ToUInt64(((DataHolder.i_radianceHight << 8) + DataHolder.i_radianceLow) / 1.2);
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
                sp.ReadTo(" ");
                DataHolder.i_pressureLow = UInt32.Parse(sp.ReadTo(" "));
                DataHolder.i_pressureCalculated = ((DataHolder.i_pressureHight << 8) + DataHolder.i_pressureLow)/100;
            }
            catch { }
            
            sp.DiscardInBuffer();
        }
    }

   
}
