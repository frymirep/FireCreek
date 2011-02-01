using System.Runtime.Serialization;

namespace Services.Advert
{
    [DataContract(Namespace = "")]
    public class Advertisement
    {
        [DataMember]
        public int Identifier { get; set; }

        [DataMember]
        public byte[] AdvertContent { get; set; }
    }
}