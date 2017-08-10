using DevAzt.FormsX.Device.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAzt.FormsX.Device.Geolocation;

namespace DevAzt.FormsX.Device.Geolocation
{
    public static class PositionHelper
    {

        public const double EarthRadius = 6371;
        public static double Distance(this Position point1, Position point2, Distance tipemetric)
        {
            double distance = 0;
            double Lat = (point2.Latitude - point1.Latitude) * (Math.PI / 180);
            double Lon = (point2.Longitude - point1.Longitude) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(point1.Latitude * (Math.PI / 180)) * Math.Cos(point2.Latitude * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;
            switch (tipemetric)
            {
                case Geolocation.Distance.Centimentros:
                    return distance * 100000;
                    break;

                case Geolocation.Distance.Metros:
                    return distance * 1000;

                case Geolocation.Distance.Kilometros:
                    return distance;
            }
            return distance;
        }

    }
}
