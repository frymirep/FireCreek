using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;

namespace Repositories
{
    static class ContextExtensions
    {
        public static void AttachAsModified<T>(this ObjectSet<T> objectSet, T entity) where T : class
        {
            objectSet.Attach(entity);
            objectSet.Context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public static void AttachAllAsModified<T>(this ObjectSet<T> objectSet, IEnumerable<T> entities) where T : class
        {
            foreach (var item in entities)
            {
                objectSet.Attach(item);
                objectSet.Context.ObjectStateManager.ChangeObjectState(item, EntityState.Modified);
            }
        }
    }
}