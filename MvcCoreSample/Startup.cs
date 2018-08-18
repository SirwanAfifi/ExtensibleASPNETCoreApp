using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcCoreSample.DataLayer;
using MvcCoreSample.Extensibility.Common;

namespace MvcCoreSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add our Config object so it can be injected
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<MovieDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("MovieConnection")));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            ModuleEvents = new MvcCoreSampleModuleEvents();
            var modulesConfig = Configuration.Get<AppSettings>();
            if (modulesConfig?.ExtensibilityModules == null) return;
            foreach (var moduleConfig in modulesConfig?.ExtensibilityModules)
            {
                var module = Activator.CreateInstance(Type.GetType(moduleConfig.Type)) as ICoreModule;
                if (module != null)
                {
                    module.Initialize(ModuleEvents);
                }
            }
        }

        public static MvcCoreSampleModuleEvents ModuleEvents { get; set; }
    }
}
