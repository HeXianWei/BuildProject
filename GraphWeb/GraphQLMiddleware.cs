using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraphWeb
{
    public class GraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IGraphQLType _graphQLType;
        private readonly IServiceProvider _serviceProvider;
        public GraphQLMiddleware(RequestDelegate next, IGraphQLType graphQLType,IServiceProvider serviceProvider)
        {
            this._next = next;
            this._graphQLType = graphQLType;
            this._serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/grahql"))
            {
                using (var stream = new StreamReader(httpContext.Request.Body))
                {
                    var query = await stream.ReadToEndAsync();
                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        Schema schema = null;
                        //using (dynamic item = _graphQLType.getAspnetUser())
                        //{
                        //    if (item != null)
                        //    //dynamic item = null;
                        //    //if(_graphQLType.TryGetGraphQLType("user", out item))
                        //    {
                        //        schema = new Schema() { Query = item };
                        //        var result = await new DocumentExecuter()
                        //            .ExecuteAsync(options =>
                        //            {
                        //                options.Schema = schema;
                        //                options.Query = query;
                        //            });
                        //        await WriteResultAsync(httpContext, result);
                        //    }
                        //    else
                        //    {
                        //        await _next(httpContext);
                        //    } 
                        //}
                        var post = httpContext.Request.Path.Value.Replace("/grahql/","");
                        post = post.Split("/").FirstOrDefault();
                        if (string.IsNullOrWhiteSpace(post))
                        {
                            await _next(httpContext);
                            return;
                        }
                        dynamic item = null;
                        if (_graphQLType.TryGetGraphQLType(post, out item))
                        {
                            var t = _serviceProvider.GetService(typeof(IDependencyResolver));

                            schema = new Schema((IDependencyResolver)t) { Query = item };
                            var result = await new DocumentExecuter()
                                .ExecuteAsync(options =>
                                {
                                    options.Schema = schema;
                                    options.Query = query;
                                });
                            await WriteResultAsync(httpContext, result);
                        }
                        else
                        {
                            await _next(httpContext);
                        }

                    }
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

        private async Task WriteResultAsync(HttpContext httpContext, ExecutionResult executionResult)
        {
            var json = new DocumentWriter(indent: true).Write(executionResult);
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
            return;
        }

    }
}
