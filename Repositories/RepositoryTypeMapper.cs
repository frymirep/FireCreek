using Model.Domain;

namespace Repositories
{
    public class RepositoryTypeMapper : IRepositoryTypeMap
    {
        #region Implementation of IRepositoryTypeMap

        public EntityToEntityFuncMap CreateEntityMap
        {
            get { return _createEntityMap; }
        }

        public EntityToEntityFuncMap UpdateEntityMap
        {
            get { return _updateEntityMap; }
        }

        public StringToEntityFuncMap RetrieveEntityMap
        {
            get { return _retrieveEntityMap; }
        }

        public StringToEntityFuncMap DeleteEntityMap
        {
            get { return _deleteEntityMap; }
        }

        #endregion

        private static readonly EntityToEntityFuncMap _createEntityMap =  new EntityToEntityFuncMap
        {
            { typeof(Advertisement), p => { return AdvertisementRepository.Create(p as Advertisement); }},
            { typeof(GeoLocation),   p => { return GeolocationRepository.Create(p as GeoLocation);     }},
        };

        private static readonly EntityToEntityFuncMap _updateEntityMap = new EntityToEntityFuncMap
        {
            { typeof(Advertisement), p => { return AdvertisementRepository.Update(p as Advertisement); }}
        };


        private static readonly StringToEntityFuncMap _retrieveEntityMap = new StringToEntityFuncMap
        {
            { typeof(Advertisement), id => { return AdvertisementRepository.GetAdvertById(BoxIdAsInt(id));     }},
            { typeof(GeoLocation),   id => { return GeolocationRepository.GetGeoLocationById(BoxIdAsLong(id)); }}
        };

        private static readonly StringToEntityFuncMap _deleteEntityMap = new StringToEntityFuncMap
        {
            {
                typeof(Advertisement), id =>{
                                                int identifier;
                                                if (!int.TryParse(id, out identifier)) return null; 
                                                AdvertisementRepository.RemoveById(identifier);
                                                return null;
                                            }
            }
        };

        // this needs a better name very badly
        protected static int BoxIdAsInt(string id)
        {
            int identifier;
            return !int.TryParse(id, out identifier) ? int.MinValue : identifier;
        }
        // this needs a better name very badly
        protected static long BoxIdAsLong(string id)
        {
            long identifier;
            return !long.TryParse(id, out identifier) ? long.MinValue : identifier;
        }
    }
}
