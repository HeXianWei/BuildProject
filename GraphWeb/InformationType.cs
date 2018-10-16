using GraphQL.Types;
using Mimikko.WebApi.Framework.User.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class InformationType:ObjectGraphType<UserInformation>
    {
        public InformationType()
        {
            Field(x => x.UserId);
            Field<SexEnum>("Sex");
            Field<StringGraphType>("Signature");
            Field<StringGraphType>("UIName");
            

            Field<StringGraphType>("Region");
        }

        public class SexEnum : EnumerationGraphType<Sex>
        {
        }

    }
}
