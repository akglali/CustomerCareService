using Shared.Repositories;
using Shared.Services;
using Shared.Services.Interface;

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
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerCaseService, CustomerCaseService>();
            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<IEmployeeDailyHoursService,EmployeeDailyHoursService>();
            services.AddScoped<IOfficeService, OfficeService>();

           // services.AddScoped<ISalaryService, SalaryService>();


     




        }
    }
}
