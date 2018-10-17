using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mimikko.WebApi.Framework.User.Primitives
{
    public class UserTitle
    {
        public string UserTitleId { get; set; }

        public string UserId { get; set; }


        public virtual string TitleId { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Title Title { get; set; }

        public int SelectedIndex { get; set; }

        public UserTitle()
        {
            this.UserTitleId = Guid.NewGuid().ToString();
            this.SelectedIndex = 0;
        }
    }
}
