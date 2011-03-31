using System;
using System.Collections.Generic;
using Model.Domain;

namespace Repositories
{
    public class StringToEntityFuncMap : Dictionary<Type, Func<String, IdentifiableEntity>> { }
}
