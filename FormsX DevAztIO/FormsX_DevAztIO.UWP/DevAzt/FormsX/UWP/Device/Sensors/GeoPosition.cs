
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using DevAzt.FormsX.Device.Sensors;

[assembly: Dependency(typeof(DevAzt.FormsX.UWP.Device.Sensors.GeoPosition))]
namespace DevAzt.FormsX.UWP.Device.Sensors
{
    public class GeoPosition : IGeoPosition
    {
        public event EventHandler<Position> Position;
        public bool IsGPSStarted { get; set; }
        private Geolocator _geolocator { get; set; }

        public Position LastPosition
        {
            get; set;
        }

        public long TimeUpdates { get; set; }

        public async Task<bool> PermitsGranted()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnPositionChange(Position currentposition)
        {
            if (Position != null)
            {
                Position.Invoke(this, currentposition);
            }
        }

        private DispatcherTimer _timer;
        public void Init()
        {
            IsGPSStarted = false;
            try
            {
                _geolocator = new Geolocator();
                _geolocator.ReportInterval = (uint) TimeUpdates;
                _geolocator.PositionChanged += Geolocator_PositionChanged;
                IsGPSStarted = true;
            }
            catch
            {
                if (Geolocator.DefaultGeoposition.HasValue)
                {
                    _timer = new DispatcherTimer();
                    _timer.Interval = TimeSpan.FromSeconds(5);
                    _timer.Tick += Timer_Tick;
                    _timer.Start();
                    IsGPSStarted = true;
                }
            }
        }

        private void Timer_Tick(object sender, object e)
        {
            LastPosition = new DevAzt.FormsX.Device.Sensors.Position
            {
                Accuracy = 0,
                Date = DateTime.Now,
                Latitude = Geolocator.DefaultGeoposition.Value.Latitude,
                Longitude = Geolocator.DefaultGeoposition.Value.Longitude,
                Success = true
            };
            OnPositionChange(LastPosition);
        }

        private void Geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            try
            {
                var latitude = args.Position.Coordinate.Point.Position.Latitude;
                var longitude = args.Position.Coordinate.Point.Position.Longitude;
                var accuaracy = args.Position.Coordinate.Accuracy;
                var date = args.Position.Coordinate.PositionSourceTimestamp;
                LastPosition = new Position()
                {
                    Success = true,
                    Date = date,
                    Accuracy = accuaracy,
                    Latitude = latitude,
                    Longitude = longitude
                };
                OnPositionChange(LastPosition);
            }
            catch
            {
                OnPositionChange(new Position { Success = false });
            }
        }

        public void Stop()
        {
            if (_geolocator != null)
            {
                _geolocator.PositionChanged -= Geolocator_PositionChanged;
                IsGPSStarted = false;
            }
            
            if (_timer != null)
            {
                _timer.Stop();
                IsGPSStarted = false;
            }
        }
    }
}
