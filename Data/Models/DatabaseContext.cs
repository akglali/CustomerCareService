using Microsoft.EntityFrameworkCore;


namespace Data.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)  { }

        // DbSet properties representing your database tables

        public DbSet<Company> Companies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerCase> CustomersCases { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeDailyHours> EmployeesDailyHours { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Salary> Salaries { get; set; }


    }
}
