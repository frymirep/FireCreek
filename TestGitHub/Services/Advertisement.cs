using System.Runtime.Serialization;

namespace Services
{
    [DataContract(Namespace = "")]
    public class Advertisement
    {
        [DataMember]
        private int Identifier { get; set; }

        [DataMember]
        private byte[] AdvertContent { get; set; }
    }
}