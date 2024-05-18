namespace Shared.Services.Interface
{
    public interface ISalaryService
    {
        double CalculateSalary(double totalHour, double hourlyWage);
        Task MakePaymentForAllEmployees(int month);
        Task MakePayment(int EmpCode, int month);


    }
}