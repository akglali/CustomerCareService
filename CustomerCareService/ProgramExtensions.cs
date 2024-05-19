using Shared.Repositories;
using Shared.Services;

namespace CustomerCareService
{
    public static class ProgramExtensions
    {

        public static void AddServices(this IServiceCollection services)
        {

            //Repositories
            services.AddScoped<CompanyRepository>();
            services.AddScoped<OfficeRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<CustomerCaseRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<DailyHoursRepository>();
            services.AddScoped<SalaryRepository>();



            //Services
            services.AddScoped<SalaryService>();
            services.AddScoped<CompanyService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<CustomerCaseService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<EmployeeDailyHoursService>();
            services.AddScoped<OfficeService>();

           // services.AddScoped<ISalaryService, SalaryService>();


     




        }
    }
}
