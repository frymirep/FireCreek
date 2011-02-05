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

        [WebInvoke(UriTemplate = "{id}", Method = "POST")]
        public T Create(string id, T payload)
        {
            Func<T> action = () => Repository<T>.Create(payload);
            var result = PerformAction(action);
            return result;
        }

        [WebGet(UriTemplate = "{id}")]
        public T Read(string id)
        {
            Func<T> action = () => Repository<T>.GetById(id);
            var result = PerformAction(action);
            return result;
        }

        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        public T Update(string id, T payload)
        {
            Func<T> action = () => Repository<T>.Update(payload);
            var result = PerformAction(action);
            return result;
        }

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        public void Delete(string id)
        {
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