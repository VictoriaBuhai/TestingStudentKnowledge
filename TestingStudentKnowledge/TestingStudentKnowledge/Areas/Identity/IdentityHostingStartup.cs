using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestingStudentKnowledgeInfrastructureData.Data;
using TestingStudentKnowledge;


[assembly: HostingStartup(typeof(TestingStudentKnowledge.Areas.Identity.IdentityHostingStartup))]
namespace TestingStudentKnowledge.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestingStudentKnowledgeDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestingStudentKnowledgeDbContextConnection")));

                services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TestingStudentKnowledgeDbContext>();
            });
        }
    }
}