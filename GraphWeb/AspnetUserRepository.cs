using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mimikko.WebApi.Framework.User.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class AspnetUserRepository : IAspnetUserRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public AspnetUserRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public IEnumerable<UserInformationViewModel> GetAll()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var dbcontext = scope.ServiceProvider.GetService<MimikkoCloudTestDbContext>())
                {
                    return dbcontext.UserTitles.Include(x => x.Title).Where(x => 1 == 1).GroupBy(x => x.UserId).Skip(0).Take(10).Select(x => new UserInformationViewModel()
                    {
                        UserId = x.Key,
                        Titles = x.Select(z => z.Title).ToList()
                    }).ToList();

                    //return new List<UserInformationViewModel>() {
                    //    new UserInformationViewModel()
                    //    {
                    //        UserId = "zzz",
                    //        Titles = new List<Mimikko.WebApi.Framework.User.Primitives.Title>(){
                    //            new Mimikko.WebApi.Framework.User.Primitives.Title(){
                    //                TitleId = "aasd",
                    //                Access = "test",
                    //                Description = "aaaa",
                    //                IconUrl = "ppp"
                    //            }
                    //        }
                    //    }
                    //};
                }
            }
        }

        public UserInformationViewModel GetByUserId(string userId)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var dbcontext = scope.ServiceProvider.GetService<MimikkoCloudTestDbContext>())
                {
                    return dbcontext.UserTitles.Include(x => x.Title).Where(x => x.UserId == userId).GroupBy(x => x.UserId).Select(x => new UserInformationViewModel()
                    {
                        UserId = x.Key,
                        Titles = x.Select(z => z.Title).ToList()
                    }).FirstOrDefault();
                }
            }
        }

        public UserInformation GetUserInformationByUserId(string userId)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var dbcontext = scope.ServiceProvider.GetService<MimikkoCloudTestDbContext>())
                {
                    return dbcontext.UserInformations.FirstOrDefault(x=>x.UserId==userId);
                }
            }

        }

    }
}
