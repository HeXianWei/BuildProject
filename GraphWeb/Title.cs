using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mimikko.WebApi.Framework.User.Primitives
{
    public class Title
    {
        public string TitleId { get; set; }

        public string IconUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// 是否被删除
        /// </summary>
        public bool IsDeleted { get; set; }
        //权重
        public int Index { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserTitle> UserTitle { get; set; }

        public string Access { get; set; }

        public DateTime CreationDate { get; set; }

        public Title()
        {
            TitleId = Guid.NewGuid().ToString();
        }
    }
}
