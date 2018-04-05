﻿using System;

namespace Microsoft.Caboodle
{
    public enum GeolocationAccuracy
    {
        // iOS:     ThreeKilometers         (3000m)
        // Android: ACCURACY_LOW, POWER_LOW (500m)
        // UWP:     3000                    (1000-5000m)
        Lowest,

        // iOS:     Kilometer               (1000m)
        // Android: ACCURACY_LOW, POWER_MED (500m)
        // UWP:     1000                    (300-3000m)
        Low,

        // iOS:     HundredMeters           (100m)
        // Android: ACCURACY_MED, POWER_MED (100-500m)
        // UWP:     100                     (30-500m)
        Medium,

        // iOS:     NearestTenMeters        (10m)
        // Android: ACCURACY_HI, POWER_MED  (0-100m)
        // UWP:     High                    (<=10m)
        High,

        // iOS:     Best                    (0m)
        // Android: ACCURACY_HI, POWER_HI   (0-100m)
        // UWP:     High                    (<=10m)
        Best
    }

    public class GeolocationRequest
    {
        public GeolocationRequest()
        {
            Timeout = TimeSpan.Zero;
            DesiredAccuracy = GeolocationAccuracy.Medium;
        }

        public GeolocationRequest(GeolocationAccuracy accuracy)
        {
            Timeout = TimeSpan.Zero;
            DesiredAccuracy = accuracy;
        }

        public GeolocationRequest(GeolocationAccuracy accuracy, TimeSpan timeout)
        {
            Timeout = timeout;
            DesiredAccuracy = accuracy;
        }

        public TimeSpan Timeout { get; set; }

        public GeolocationAccuracy DesiredAccuracy { get; set; }

        internal uint DesiredAccuracyInMeters
        {
            get
            {
                switch (DesiredAccuracy)
                {
                    case GeolocationAccuracy.Lowest:
                        return 3000;
                    case GeolocationAccuracy.Low:
                        return 1000;
                    case GeolocationAccuracy.Medium:
                        return 100;
                    case GeolocationAccuracy.High:
                        return 10;
                    case GeolocationAccuracy.Best:
                        return 1;
                    default:
                        return 100;
                }
            }
        }
    }
}
