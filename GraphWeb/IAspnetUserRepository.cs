using Mimikko.WebApi.Framework.User.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public interface IAspnetUserRepository
    {
        IEnumerable<UserInformationViewModel> GetAll();


        UserInformationViewModel GetByUserId(string userId);

        UserInformation GetUserInformationByUserId(string userId);
    }
}
