using System.Runtime.Serialization;

namespace Services
{
    [DataContract(Namespace = "")]
    public class Advertisement
    {
        [DataMember]
        int Identifier { get; set; }
        [DataMember]
        byte[] AdvertContent { get; set; }
    }
}