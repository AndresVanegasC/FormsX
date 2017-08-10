

using DevAzt.FormsX.Device.Sensors;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(DevAzt.FormsX.iOS.Device.Sensors.GeoPosition))]
namespace DevAzt.FormsX.iOS.Device.Sensors
{
    public class GeoPosition : IGeoPosition
    {
        public bool IsGPSStarted { get; set; }

        public Position LastPosition
        {
            get; set;
        }
        public long TimeUpdates { get; set; }

        public event EventHandler<Position> Position;

        private void OnPositionChange(Position position)
        {
            if (Position != null)
            {
                Position.Invoke(this, position);
            }
        }

        Geolocator _geolocator;
        public void Init()
        {
            _geolocator = new Geolocator(TimeUpdates);
            _geolocator.StartLocationUpdates();
            IsGPSStarted = _geolocator.IsGPSStarted;
            _geolocator.LocationUpdated += Geolocator_LocationUpdated;
        }

        private void Geolocator_LocationUpdated(object sender, Geolocator.LocationUpdatedEventArgs e)
        {
            try
            {
                var latitude = e.Location.Coordinate.Latitude;
                var longitude = e.Location.Coordinate.Longitude;
                var accuaracy = 1;
                Position position = new Position()
                {
                    Success = true,
                    Date = DateTime.Now,
                    Accuracy = accuaracy,
                    Latitude = latitude,
                    Longitude = longitude
                };
                LastPosition = position;
                OnPositionChange(position);
            }
            catch
            {
                OnPositionChange(new Position { Success = false });
            }
        }

        public void Stop()
        {
            _geolocator.LocationUpdated -= Geolocator_LocationUpdated;
            _geolocator.Stop();
            IsGPSStarted = false;
        }

        public Task<bool> PermitsGranted()
        {
            // pedimos los permisos para usar el gps
            // por el momento no es necesario pedir los permisos para el archivo, a menos que sea un android 6.0
            Task<bool> mytask = new Task<bool>(() => true);
            mytask.Start();
            return mytask;
        }
    }
}
