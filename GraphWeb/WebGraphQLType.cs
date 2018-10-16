using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class WebGraphQLType : IGraphQLType
    {
        private readonly Dictionary<string, Type> nameType = new Dictionary<string, Type>();
        private readonly IAspnetUserRepository _userRepository;

        public WebGraphQLType(IAspnetUserRepository userRepository)
        {
            nameType.Add("user", typeof(AspnetUserQuery));
            nameType.Add("text", typeof(TotalUserQuery));
            _userRepository = userRepository;
        }

        public bool TryGetGraphQLType(string typeName, out dynamic qlType)
        {
            Type type = null;
            bool isTrue = false;
            if (isTrue = nameType.TryGetValue(typeName, out type))
            {
                object[] parameters = new object[1];
                parameters[0] = _userRepository;
                qlType = Activator.CreateInstance(type, parameters);
            }
            else
            {
                qlType = null;
            }

            return isTrue;
        }

        public AspnetUserQuery getAspnetUser()
        {
            object[] parameters = new object[1];
            parameters[0] = _userRepository;
            var qlType = Activator.CreateInstance(typeof(AspnetUserQuery), parameters);

            return (AspnetUserQuery)qlType;
        }

    }
}
