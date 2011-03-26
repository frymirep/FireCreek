using System.Runtime.Serialization;

namespace Model.Domain
{
    [DataContract(Namespace = "")]
    [RouteName(Name = "Advert")]
    public class Advertisement : IdentifiableEntity
    {
        [DataMember]
        public byte[] AdvertContent { get; set; }
    }
}