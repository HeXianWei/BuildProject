using GraphQL.Types;
using Mimikko.WebApi.Framework.User.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class TitleType:ObjectGraphType<Title>
    {
        public TitleType()
        {
            Field(x => x.TitleId);
            Field<StringGraphType>("Name");
            Field<StringGraphType>("IconUrl");
            Field<StringGraphType>("Description");
            Field<StringGraphType>("Access");
        }



    }
}
