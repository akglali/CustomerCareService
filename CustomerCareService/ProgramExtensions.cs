﻿using Shared.Repositories;

namespace CustomerCareService
{
    public static class ProgramExtensions
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<CompanyRepository>();
           
        }
    }
}