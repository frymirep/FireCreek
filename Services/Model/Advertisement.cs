using System.Runtime.Serialization;

namespace Services.Model
{
    [DataContract(Namespace = "")]
    public class Advertisement : IdentifiableEntity
    {
        [DataMember]
        public byte[] AdvertContent { get; set; }
    }
}