using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tess.Agent.Interfaces;
using Tess.Agent.Services;
using Tess.Server.API;
using Tess.Server.Data;
using Tess.Server.Services;
using Tess.Shared.Models;
using Tess.Shared.Utilities;
using System;

namespace Tess.Tests
{
    [TestClass]
    public class IoCActivator
    {
        public static IServiceProvider ServiceProvider { get; set; }
        private static IWebHostBuilder builder;

        public static void Activate()
        {
            if (builder is null)
            {
                builder = WebHost.CreateDefaultBuilder()
                   .UseStartup<Startup>()
                   .CaptureStartupErrors(true);

                builder.Build();
            }
        }


        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Activate();
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<AppDb>(options =>
            {
                options.UseInMemoryDatabase("Tess");
            });

            services.AddScoped(p =>
                p.GetRequiredService<IDbContextFactory<AppDb>>().CreateDbContext());

            services.AddIdentity<TessUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
             .AddEntityFrameworkStores<AppDb>()
             .AddDefaultUI()
             .AddDefaultTokenProviders();

            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IApplicationConfig, ApplicationConfig>();
            services.AddTransient<IEmailSenderEx, EmailSenderEx>();

            if (EnvironmentHelper.IsWindows)
            {
                services.AddTransient<IDeviceInformationService, DeviceInformationServiceWin>();
            }
            else if (EnvironmentHelper.IsLinux)
            {
                services.AddTransient<IDeviceInformationService, DeviceInformationServiceLinux>();
            }

            IoCActivator.ServiceProvider = services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }


}
