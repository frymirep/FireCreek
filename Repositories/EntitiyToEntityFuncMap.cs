using System;
using System.Collections.Generic;
using Model.Domain;

namespace Repositories
{
    public class EntityToEntityFuncMap : Dictionary<Type, Func<IdentifiableEntity, IdentifiableEntity>> { }
}
