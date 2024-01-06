using System.ComponentModel.DataAnnotations;

namespace BankLoanCalculation.Models
{
    public class LoanCalculatorModel
    {
        [Required]
        public decimal LoanAmount { get; set; }

        [Required]
        public DateTime NextPaymentDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 20, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        [Required]
        public double InterestRate { get; set; } = 12;

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required]
        public bool Include13thMonthSalary { get; set; } = true;
    }
}
