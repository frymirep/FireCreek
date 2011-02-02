using System.Runtime.Serialization;

namespace Services.Model
{
    [DataContract(Namespace = "")]
    public class IdentifiableEntity
    {
        // in practice I expect this field will be the ESN if data is coming from the client, and some kind of object id if coming from the server
        [DataMember]
        public int? Identifier { get; set; }
    }
}