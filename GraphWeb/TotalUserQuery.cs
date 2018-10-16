using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class TotalUserQuery : ObjectGraphType
    {
        public TotalUserQuery(IAspnetUserRepository userRepository)
        {
            Name = "totaluser";
            Field<UserQuery>("information",resolve:context=>new { });

            Field<AspnetUserQuery>("title", resolve: context => new { });
        }

    }
}
