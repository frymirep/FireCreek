using System;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Model.Domain;
using Repositories;

namespace Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service<T> : IService<T> where T : IdentifiableEntity
    {
        #region IAdvertisementService Members

        [WebInvoke(Method = "POST")]
        public T Create(T payload)
        {
            var id = "test string"; // cant seem to get two parameter post working eventhough message body style is wrapped
            if (payload == null) return null;
            Func<T> action = () => Repository<T>.Create(id, payload);
            var result = PerformAction(action);
            return result;
        }

        [WebGet(UriTemplate = "{id}")]
        public T Read(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            Func<T> action = () => Repository<T>.GetById(id);
            var result = PerformAction(action);
            return result;
        }

        [WebInvoke(Method = "PUT")]
        public T Update(T payload)
        {
            if (payload == null) return null;
            Func<T> action = () => Repository<T>.Update(payload);
            var result = PerformAction(action);
            return result;
        }

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        public void Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return;
            Func<T> action = () =>
            {
                Repository<T>.RemoveById(id);
                return null;
            };

            PerformAction(action);
        }
        #endregion

        private static T PerformAction(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception)
            {
                // Add Logging, Error handling etc here
                throw;
            }
        }
    }


}