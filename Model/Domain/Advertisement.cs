using System.Runtime.Serialization;

namespace Model.Domain
{
    [DataContract(Namespace = "")]
    public class Advertisement : IdentifiableEntity
    {
        [DataMember]
        public byte[] AdvertContent { get; set; }
    }
}