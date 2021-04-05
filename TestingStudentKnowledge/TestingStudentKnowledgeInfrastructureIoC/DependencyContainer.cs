﻿using Microsoft.Extensions.DependencyInjection;
using TestingStudentKnowledgeApplication.Interfaces;
using TestingStudentKnowledgeApplication.Services;
using TestingStudentKnowledgeDomain.Interfaces;


namespace TestingStudentKnowledgeInfrastructureIoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();

            //services.AddScoped<ITestRepository, TestRepository>();
        }
    }
}