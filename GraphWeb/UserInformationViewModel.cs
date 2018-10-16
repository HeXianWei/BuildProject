using Mimikko.WebApi.Framework.User.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class UserInformationViewModel
    {
        public string UserId { get; set; }

        public List<Title> Titles { get; set; }

    }
}
