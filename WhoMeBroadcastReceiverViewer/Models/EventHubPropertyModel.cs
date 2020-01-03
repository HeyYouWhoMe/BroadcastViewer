using System.Collections.Generic;

namespace WhoMeBroadcastReceiverViewer.Models
{
    public class EventHubPropertyModel
    {
        public string Guid { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string FlightNumber { get; private set; }
        public string DroneId { get; private set; }
        public string DroneIdCountryCode { get; private set; }
        public string Speed { get; private set; }
        public string Heading { get; private set; }
        public string BarometricPressure { get; private set; }
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

            infoDic.TryGetValue("1", out latitude);
            infoDic.TryGetValue("2", out longitude);
            infoDic.TryGetValue("A", out flightNumber);
            infoDic.TryGetValue("B", out id);
            infoDic.TryGetValue("C", out idCountryCode);
            infoDic.TryGetValue("E", out speed);
            infoDic.TryGetValue("F", out heading);
            infoDic.TryGetValue("G", out pressure);
            infoDic.TryGetValue("H", out timestamp);

            Guid = personaGuid;

            Latitude = latitude;
            Longitude = longitude;
            FlightNumber = flightNumber;
            DroneId = id;
            DroneIdCountryCode = idCountryCode;
            Speed = speed;
            Heading = heading;
            BarometricPressure = pressure;
            Timestamp = timestamp;
        }
    }
}
