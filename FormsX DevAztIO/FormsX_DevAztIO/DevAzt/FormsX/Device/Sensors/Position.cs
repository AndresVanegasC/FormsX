
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevAzt.FormsX.Json;

namespace DevAzt.FormsX.Device.Sensors
{
    public class Position
    {
        public double Accuracy { get; set; }
        public DateTimeOffset? Date { get; set; }
        public bool Success { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            try
            {
                return this.SerializeObject();
            }
            catch
            {
                return $"{Latitude},{Longitude},{Accuracy}";
            }
        }
    }
}
