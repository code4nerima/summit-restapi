using CfjSummit.Domain;
using CfjSummit.Domain.Repositories;
using CfjSummit.Infrastructure.Contexts;
using CfjSummit.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WebApi
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

            services.AddDbContext<CfjContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CfjContext"),
                x => x.MigrationsAssembly(Configuration.GetValue<string>("MigrationAssembly"))).EnableSensitiveDataLogging());

            services.AddMediatR(typeof(CfjSummitDomain).GetTypeInfo().Assembly);
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IProgramRepository, ProgramRepository>();
            services.AddScoped<IRequestLogRepository, RequestLogRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
