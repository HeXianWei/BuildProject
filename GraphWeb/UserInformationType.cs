using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class UserInformationType:ObjectGraphType<UserInformationViewModel>
    {

        public UserInformationType(IAspnetUserRepository userRepository)
        {
            Field(x => x.UserId);

            Field<ListGraphType<TitleType>>("Titles");

            
        }

    }
}
