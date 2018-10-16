using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public interface IGraphQLType
    {
        bool TryGetGraphQLType(string typeName,out dynamic qlType);

        AspnetUserQuery getAspnetUser();
    }
}
