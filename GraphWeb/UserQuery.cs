using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class UserQuery : ObjectGraphType
    {

        public UserQuery(IAspnetUserRepository userRepository)
        {
            Name = "Information";

            Field<InformationType>(
                "information",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("userId");
                    return userRepository.GetUserInformationByUserId(id);
                }
                );

        }

    }
}
