using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphWeb
{
    public static class New<T> where T : new()
    {
        public static readonly Func<object[],T> Instance = Expression.Lambda<Func<object[],T>>(Expression.New(typeof(T))).Compile();
    }
}
