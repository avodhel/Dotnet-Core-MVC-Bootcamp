using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App5.Api.Integration.Tests.Infrastructure
{
    public class TestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder().UseStartup<TStartup>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseKestrel()
                .UseSolutionRelativeContentRoot("")
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    var env = builderContext.HostingEnvironment;
                    var path = Path.Combine(env.ContentRootPath, "tests\\App5.Api.Integration.Tests");

                    config.SetBasePath(path)
                        .AddJsonFile("appsettings.json");
                    config.AddEnvironmentVariables();
                });
            base.ConfigureWebHost(builder);
        }
    }
}
