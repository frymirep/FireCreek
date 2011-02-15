using System;
using System.Runtime.Serialization;

namespace Model.Domain
{
    [DataContract(Namespace = "")]
    public class GeoLocation : IdentifiableEntity
    {
        [DataMember(IsRequired=false)]
        public double Accuracy { get; set; }
        [DataMember(IsRequired = false)]
        public double? Altitude { get; set; }
        [DataMember(IsRequired = false)]
        public double? AltitudeAccuracy { get; set; }
        [DataMember(IsRequired = false)]
        public double? Heading { get; set; }
        [DataMember(IsRequired = true)]
        public double Latitude { get; set; }
        [DataMember(IsRequired = true)]
        public double Longitude { get; set; }
        [DataMember(IsRequired = false)]
        public double? Speed { get; set; }
        [DataMember(IsRequired = true)]
        public DateTime Timestamp { get; set; }
        [DataMember(IsRequired = true)]
        public string PhoneId { get; set; }

        public static new GeoLocation Null
        {
            get { return IdentifiableEntity.Null as GeoLocation; }
        }
    }
}