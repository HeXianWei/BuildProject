using System;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GraphQL.Types;
using static GraphWeb.InformationType;

namespace GraphWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddEntityFrameworkMySql().AddDbContext<MimikkoCloudTestDbContext>(optins =>
            //    optins.UseMySql($@"server=139.196.139.156;Port=3306;user id = mimikko; Password=mimikko_mysql;database=test;Convert Zero Datetime=True;"));

            var options = new DbContextOptionsBuilder<MimikkoCloudTestDbContext>()
              .UseMySql($@"server=139.196.139.156;Port=3306;user id = mimikko; Password=mimikko_mysql;database=test;Convert Zero Datetime=True;")
              .Options;
            services.AddScoped(s => new MimikkoCloudTestDbContext(options));

            services.AddSingleton<IGraphQLType, WebGraphQLType>();

            services.AddSingleton<IAspnetUserRepository, AspnetUserRepository>();

            services.AddSingleton<IDependencyResolver, GraphResolver>();

            services.AddSingleton<TotalUserQuery>();

            services.AddSingleton<UserQuery>();

            services.AddSingleton<TitleType>();

            services.AddSingleton<InformationType>();

           

            services.AddSingleton<SexEnum>();

            services.AddSingleton(ser=> {

                return new UserInformationType(ser.GetService<IAspnetUserRepository>());
            });
            
            services.AddSingleton<AspnetUserQuery>(ser=> {
                return new AspnetUserQuery(ser.GetService<IAspnetUserRepository>());
            });

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddGraphQL(_ =>
            {
                _.EnableMetrics = true;
                _.ExposeExceptions = true;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<GraphQLMiddleware>();

            app.UseMvc();
        }
    }
}
