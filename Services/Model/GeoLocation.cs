using System;
using System.Runtime.Serialization;

namespace Services.Model
{
    [DataContract(Namespace = "")]
    public class GeoLocation : IdentifiableEntity
    {
        [DataMember]
        public double Accuracy { get; set; }
        [DataMember]
        public double? Altitude { get; set; }
        [DataMember]
        public double? AltitudeAccuracy { get; set; }
        [DataMember]
        public double? Heading { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longitude { get; set; }
        [DataMember]
        public double? Speed { get; set; }
        [DataMember]
        public DateTime Timestamp { get; set; }
    }
}