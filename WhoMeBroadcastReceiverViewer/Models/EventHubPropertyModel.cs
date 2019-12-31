using System.Collections.Generic;

namespace WhoMeBroadcastReceiverViewer.Models
{
    public class EventHubPropertyModel
    {
        public string Guid { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string DroneName { get; private set; }
        public string FlightNumber { get; private set; }
        public string DroneId { get; private set; }
        public string DroneIdCountryCode { get; private set; }
        public string DroneSpeed { get; private set; }
        public string DroneHeading { get; private set; }
        public string DroneBarometricPressure { get; private set; }
        public string Timestamp { get; private set; }

        public EventHubPropertyModel(string personaGuid, Dictionary<string, string> infoDic)
        {
            var guid = string.Empty;
            var latitude = string.Empty;
            var longitude = string.Empty;
            var name = string.Empty;
            var flightNumber = string.Empty;
            var id = string.Empty;
            var idCountryCode = string.Empty;
            var speed = string.Empty;
            var heading = string.Empty;
            var pressure = string.Empty;
            var timestamp = string.Empty;

            infoDic.TryGetValue("", out guid);
            infoDic.TryGetValue("", out latitude);
            infoDic.TryGetValue("", out longitude);
            infoDic.TryGetValue("", out name);
            infoDic.TryGetValue("", out flightNumber);
            infoDic.TryGetValue("", out id);
            infoDic.TryGetValue("", out idCountryCode);
            infoDic.TryGetValue("", out speed);
            infoDic.TryGetValue("", out heading);
            infoDic.TryGetValue("", out pressure);
            infoDic.TryGetValue("", out timestamp);

            Guid = guid;
            Latitude = latitude;
            Longitude = longitude;
            DroneName = name;
            FlightNumber = flightNumber;
            DroneId = id;
            DroneIdCountryCode = idCountryCode;
            DroneSpeed = speed;
            DroneHeading = heading;
            DroneBarometricPressure = pressure;
            Timestamp = timestamp;
        }
    }
}
