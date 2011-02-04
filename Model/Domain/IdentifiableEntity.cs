using System.Runtime.Serialization;

namespace Model.Domain
{
    [DataContract(Namespace = "")]
    public class IdentifiableEntity
    {
        // in practice I expect this field will be the ESN if data is coming from the client, and some kind of object id if coming from the server
        [DataMember]
        public long? Identifier { get; set; }
    }
}