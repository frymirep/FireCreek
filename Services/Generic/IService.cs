// inspiration: http://geekswithblogs.net/michelotti/archive/2010/08/21/restful-wcf-services-with-no-svc-file-and-no-config.aspx

using System.ServiceModel;
using Services.Model;

namespace Services.Generic
{
    [ServiceContract]
    public interface IService<T> where T : IdentifiableEntity
    {
        [OperationContract]
        T Create(string id, T payload);

        [OperationContract]
        T Read(string id);

        [OperationContract]
        T Update(string id, T payload);

        [OperationContract]
        void Delete(string id);
    }
}