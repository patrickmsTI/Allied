using Allied.Application.Middlewares;
using Allied.Data;
using Allied.Domain.Interface.Repository;
using Allied.Domain.Interface.Service;
using Allied.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Reflection;

namespace Allied.Application
{ 
    /// <summary>
    /// The startup class of application.
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BaseContext>(options => options.UseInMemoryDatabase(databaseName: "MockDB"));
            this.RegisterDependencies(services);
            this.RegisterSwaggerData(services);
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson(c =>
            {
                c.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseDeveloperExceptionPage();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Allied - PhonePlan - V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Registers the dependencies.
        /// </summary>
        /// <param name="services">The services.</param>
        private void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IPhonePlanService, PhonePlanService>();
            services.AddScoped<IPhonePlanRepository, PhonePlanRepository>();
        }

        /// <summary>
        /// Registers the swagger data.
        /// </summary>
        /// <param name="services">The services.</param>
        private void RegisterSwaggerData(IServiceCollection services)
        {
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "INTEGRATION API FOR PHONE PLANS",
                    Version = "v1",
                    Description = "REST API CREATED WITH ASP.NET CORE"
                });        

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(@".\App_Data", xmlFile);
                options.IncludeXmlComments(xmlPath, true);
            });
        }
    }
}
