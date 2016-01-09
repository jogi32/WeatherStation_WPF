using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation_WPF
{
    class DataHolder
    {
        public static double i_temperature1 { get; set; }
        public static double i_temperature2 { get; set; }
        public static double i_temperature3 { get; set; }
        public static double i_humidityAir { get; set; }
        public static double i_humidityEarth { get; set; }
        public static double i_humidityRain { get; set; }
        public static UInt64 i_radianceRaceived { get; set; }
        public static UInt32 i_radianceHight { get; set; }
        public static UInt32 i_radianceLow { get; set; }
        public static UInt64 i_radianceCalculated { get; set; }
        public static UInt32 i_pressureHight { get; set; }
        public static UInt32 i_pressureLow { get; set; }
        public static UInt64 i_pressureCalculated { get; set; }
        public static UInt64 i_heightCalculated { get; set; }


        public DataHolder() 
        {
        }

        ~DataHolder()
        {
        }
    }
}
