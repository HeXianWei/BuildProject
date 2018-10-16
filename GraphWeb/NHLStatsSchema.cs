using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class NHLStatsSchema : Schema
    {
        public NHLStatsSchema()
        {
        }

        public NHLStatsSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ObjectGraphType>();
        }
    }
}
