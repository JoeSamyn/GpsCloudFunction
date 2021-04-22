using System;
using System.Collections.Generic;
using System.Text;

namespace GpsCollectionProcess.Entities
{
    public class GpsEvent
    {
        /// <summary>
        /// Username of the user that triggered the event
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Device the event was triggered on
        /// </summary>
        public string Device { get; set; }
        /// <summary>
        /// Manufacturer of the device the event was triggered on
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Encoded polyline of the route
        /// </summary>
        public string Polyline { get; set; }
        /// <summary>
        /// Average accuracy over the course of the polyline
        /// </summary>
        public double Accuracy { get; set; }
        /// <summary>
        /// Average speed over course of polyline
        /// </summary>
        public double Speed { get; set; }
        /// <summary>
        /// Average bearing over course of the polyline
        /// </summary>
        public double Bearing { get; set; }
        /// <summary>
        /// Timestamp the event was triggered on the device
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }
    }
}
