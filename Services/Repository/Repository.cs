using Services.Model;
using EntityToEntityFuncMap = System.Collections.Generic.Dictionary<System.Type, System.Func<Services.Model.IdentifiableEntity, Services.Model.IdentifiableEntity>>;
using StringToEntityFuncMap = System.Collections.Generic.Dictionary<System.Type, System.Func<System.String, Services.Model.IdentifiableEntity>>;
namespace Services.Repository
{
    public class Repository<T> where T : IdentifiableEntity
    {
        // refactor to seperate FuncMaps class?
        private static readonly EntityToEntityFuncMap CreateTypeMap = new EntityToEntityFuncMap
                              {
                                  {
                                      typeof(Advertisement), p => { return AdvertisementRepository.Create(p as Advertisement); }
                                  },
                              };

        private static readonly StringToEntityFuncMap RetrieveTypeMap = new StringToEntityFuncMap
                              {
                                  {
                                      typeof(Advertisement), id =>
                                                                 {
                                                                     int identifier;
                                                                     return !int.TryParse(id, out identifier) 
                                                                         ? null : AdvertisementRepository.GetAdvertById(identifier);
                                                                 }
                                  }
                              };

        private static readonly EntityToEntityFuncMap UpdateTypeMap = new EntityToEntityFuncMap
                              {
                                  {
                                      typeof(Advertisement), p => { return AdvertisementRepository.Update(p as Advertisement); }
                                  }
                              };
        private static readonly StringToEntityFuncMap DeleteTypeMap = new StringToEntityFuncMap
                              {
                                  {
                                      typeof(Advertisement), id =>
                                                                 {
                                                                     int identifier;
                                                                     if (!int.TryParse(id, out identifier)) return null; 
                                                                     AdvertisementRepository.RemoveById(identifier);
                                                                     return null;
                                                                 }
                                  }
                              };

        // TODO:  These static methods are so similar... some way to refactor to common code even though type maps are different types?
        public static T Create(T payload) 
        {
            var typeMap = CreateTypeMap;
            var type =  typeof(T);
            if (!typeMap.ContainsKey(type)) return null;
            var result = typeMap[type](payload);
            return result as T;
        }

        public static T GetById(string id)
        {
            var typeMap = RetrieveTypeMap;
            var type = typeof(T);
            if (!typeMap.ContainsKey(type)) return null;
            var result = typeMap[type](id);
            return result as T;
        }

        public static T Update(T payload)
        {
            var typeMap = UpdateTypeMap;
            var type = typeof(T);
            if (!typeMap.ContainsKey(type)) return null;
            var result = typeMap[type](payload);
            return result as T;
        }

        public static void RemoveById(string id)
        {
            var typeMap = DeleteTypeMap;
            var type = typeof(T);
            if (!typeMap.ContainsKey(type)) return;
            typeMap[type](id);
        }
    }
}