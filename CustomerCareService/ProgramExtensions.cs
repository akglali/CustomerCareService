using Shared.Repositories;

namespace CustomerCareService
{
    public static class ProgramExtensions
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<CompanyRepository>();
            services.AddScoped<OfficeRepository>();
            services.AddScoped<CustomerRepository>();



        }
    }
}
