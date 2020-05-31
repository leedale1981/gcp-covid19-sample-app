using System;
using System.IO;
using COV19.Services.Data.Factories;
using COV19.Services.Domain;
using COV19.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace COV19.Services.Auth
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
            ILogger logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            IConfigurationRoot config = Startup.GetConfiguration();
            Console.WriteLine("Environment Vars:");
            foreach (string key in Environment.GetEnvironmentVariables().Keys)
            {
                Console.WriteLine($"{key}:{Environment.GetEnvironmentVariable(key)}");
            }
        
            Console.WriteLine($"Connection String Config: {config.GetConnectionString("AuthDb")}");
            IQueryFactory<ClientRegistration> clientRegistrationQueryFactory = new ClientRegistrationQueryFactory(
                logger, config.GetConnectionString("AuthDb"));
            
            services.AddSingleton<ILogger>(logger);
            services.AddScoped<IQueryFactory<ClientRegistration>>((serviceProvider) => clientRegistrationQueryFactory);

            services.AddIdentityServer(options => 
            {
                options.IssuerUri = config["Identity:Issuer"];
            })
            .AddDeveloperSigningCredential()
            .AddInMemoryApiResources(Config.GetApiResources(clientRegistrationQueryFactory).Result)
            .AddInMemoryClients(Config.GetClients(clientRegistrationQueryFactory).Result)
            .AddInMemoryPersistedGrants();
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowClientOrigin",
                builder => 
                {
                    builder.WithOrigins(config["Identity:Origin"])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors("AllowClientOrigin");
            app.UseIdentityServer();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        internal static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.Development.json", true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
