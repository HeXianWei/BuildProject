using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mimikko.WebApi.Framework.User.Primitives
{
    public class UserInformation
    {
        public string UserInformationId { get; set; }

        public string RaceId { get; set; }

        public string ProfessionId { get; set; }

        public string UserId { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime CreationTime { get; set; }

        public UserInformation()
        {
            this.UserInformationId = Guid.NewGuid().ToString();
            CreationTime = DateTime.UtcNow;
            CustormValid = false;
        }

        //        public virtual User User { get; set; }


        #region 1.8.8 
        /// <summary>
        /// 头像Url
        /// </summary>
        public string AvatarUrl { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// 个人签名
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 背景图片
        /// </summary>
        public string BackgroundUrl { get; set; }
        /// <summary>
        /// 透明度
        /// </summary>
        public double Pellucidity { get; set; }
        /// <summary>
        /// 主题色
        /// </summary>
        public string ThemeColor { get; set; }
        /// <summary>
        /// 模糊度
        /// </summary>
        public double Fuzziness { get; set; }
        /// <summary>
        /// UI名称
        /// </summary>
        public string UIName { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public Identity Identity { get; set; }

        public bool CustormValid { get; set; }

        #endregion

    }

    public enum Identity
    {
        Freelancer,

        OfficeWorker,

        Student
    }

    public enum Sex
    {
        UnSet,

        Man,

        Woman
    }
}
