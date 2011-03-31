﻿using Model.Domain;

namespace Repositories
{
    public class Repository<T> where T : IdentifiableEntity
    {
        private readonly IRepositoryTypeMap _typeMap;
        public Repository(IRepositoryTypeMap typeMap)
        {
            _typeMap = typeMap;
        }

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

        // TODO:  These static methods are so similar... some way to refactor to common code even though type maps are different types?
        public T Create(T payload)
        {
            var typeMap = _typeMap.CreateEntityMap;
            var type = typeof(T);
            if (!typeMap.ContainsKey(type)) return null;
            var result = typeMap[type](payload);
            return result as T;
        }

        public T GetById(string id)
        {

            var typeMap = _typeMap.RetrieveEntityMap;
            var type = typeof(T);
            if (!typeMap.ContainsKey(type)) return null;
            var result = typeMap[type](id);
            return result as T;
        }

        public T Update(T payload)
        {
            var typeMap = _typeMap.UpdateEntityMap;
            var type = typeof(T);
            if (!typeMap.ContainsKey(type)) return null;
            var result = typeMap[type](payload);
            return result as T;
        }

        public void RemoveById(string id)
        {
            var typeMap = _typeMap.DeleteEntityMap;
            var type = typeof(T);
            if (!typeMap.ContainsKey(type)) return;
            typeMap[type](id);
        }
    }
}