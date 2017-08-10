using CoreLocation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using UIKit;

namespace DevAzt.FormsX.iOS.Device.Sensors
{
    public class Geolocator
    {
        protected CLLocationManager locMgr;
        private long _timeupdates { get; set; }
        public Geolocator(long timeupdatesinmilliseconds)
        {
            _timeupdates = timeupdatesinmilliseconds;
            this.locMgr = new CLLocationManager();
            this.locMgr.PausesLocationUpdatesAutomatically = false;

            // iOS 8 has additional permissions requirements
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locMgr.RequestAlwaysAuthorization(); // works in background
                                                     //locMgr.RequestWhenInUseAuthorization (); // only in foreground
            }

            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
            {
                locMgr.AllowsBackgroundLocationUpdates = true;
            }
        }

        public CLLocationManager LocMgr
        {
            get { return this.locMgr; }
        }

        public bool IsGPSStarted { get; private set; }

        private bool _timesuccess = false;
        private Timer _timer;
        public void StartLocationUpdates()
        {
            _timer = new Timer(_timeupdates);
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
            IsGPSStarted = false;
            if (CLLocationManager.LocationServicesEnabled)
            {
                IsGPSStarted = true;
                LocMgr.DesiredAccuracy = 1;
                LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
                {
                    if (_timesuccess)
                    {
                        if (LocationUpdated != null)
                        {
                            LocationUpdated.Invoke(this, new LocationUpdatedEventArgs(e.Locations[e.Locations.Length - 1]));
                        }
                        _timesuccess = false;
                        _timer.Enabled = true;
                    }
                };
                LocMgr.StartUpdatingLocation();
            }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            if (!_timesuccess)
            {
                _timesuccess = true;
            }
        }

        public void Stop()
        {
            if (LocMgr != null)
            {
                LocMgr.StopUpdatingLocation();
            }
        }

        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated;

        public class LocationUpdatedEventArgs : EventArgs
        {
            CLLocation location;

            public LocationUpdatedEventArgs(CLLocation location)
            {
                this.location = location;
            }

            public CLLocation Location
            {
                get { return location; }
            }
        }
    }
}
