using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class AspnetUserQuery : ObjectGraphType, IDisposable
    {
        public AspnetUserQuery(IAspnetUserRepository userRepository)
        {
            Name = "Title";
            

            Field<UserInformationType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("userId");
                    return userRepository.GetByUserId(id);
                });
            Field<ListGraphType<UserInformationType>>(
                "users",
                resolve: context =>
                {
                    return userRepository.GetAll();
                });
        }
        public void Dispose()
        {
            Dispose(true);
        }

        ~AspnetUserQuery()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            //为true时表示是客户显式调用了释放函数，需通知GC不要再调用对象的Finalize方法 
            //为false时肯定是GC调用了对象的Finalize方法，所以没有必要再告诉GC你不要调用我的Finalize方法啦 
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

    }
}
