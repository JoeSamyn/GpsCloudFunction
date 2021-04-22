using System;

namespace TestServiceBus
{
    internal class GpsEvent
    {
        public string Username { get; set; }
        public string Device { get; set; }
        public string Manufacturer { get; set; }
        public string Polyline { get; set; }
        public int Accuracy { get; set; }
        public int Speed { get; set; }
        public int Bearing { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}