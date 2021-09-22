using HSN.Framework.Core.Application;
using HSN.Framework.EndPoints.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SpecificationPatternLearning.Core.Application.Personnels.Queries.GetPersonnels;
using SpecificationPatternLearning.Core.Domain.PersonnelEducations;
using SpecificationPatternLearning.Core.Domain.Personnels;
using SpecificationPatternLearning.Infra.Data.EfCore.SQL;
using SpecificationPatternLearning.Infra.Data.EfCore.SQL.PersonnelEducations;
using SpecificationPatternLearning.Infra.Data.EfCore.SQL.Personnels;
using System;
using System.Linq;

namespace SpecificationPatternLearning.EndPoints.API
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
            services.AddControllers();

            services.AddDbContext<PersonnelDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, PersonnelDbContext>();

            services.AddScoped<IPersonnelRepository, PersonnelRepository>();
            services.AddScoped<IPersonnelEducationRepository, PersonnelEducationRepository>();

            AddCommandQueryHandlers(services, typeof(IQueryHandler<,>));
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpecificationPatternLearning.EndPoints.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpecificationPatternLearning.EndPoints.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddCommandQueryHandlers(IServiceCollection services, Type handlerInterface)
        {
            var handlers = typeof(GetPersonnelsQueryHandler).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)
            );

            foreach (var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
            }
        }
    }
}
