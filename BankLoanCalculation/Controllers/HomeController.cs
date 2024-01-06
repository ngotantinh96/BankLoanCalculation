using BankLoanCalculation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankLoanCalculation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CalculateLoan(LoanCalculatorModel model)
        {
            if(ModelState.IsValid)
            {
                ViewData["LoanInfo"] = model;
                List<CalculatedLoanViewModel> calculatedLoans = [];
                decimal remainingLoan = model.LoanAmount;
                DateTime paymentDate = model.NextPaymentDate;
                decimal interestRate = (decimal)(model.InterestRate / 100 / 12);
                while (remainingLoan > 0)
                {
                    var monthlyPayment = new CalculatedLoanViewModel
                    {
                        PaymentDate = paymentDate,
                        InterestPaymentAmount = Math.Round(remainingLoan * interestRate),
                    };

                    monthlyPayment.TotalDefaultPaymentAmount = monthlyPayment.DefaultLoanPaymentAmount + monthlyPayment.InterestPaymentAmount;

                    decimal monthlyPaymentAmount = model.PaymentAmount;

                    if (model.Include13thMonthSalary && paymentDate.Month == 1)
                    {
                        monthlyPaymentAmount += model.PaymentAmount;
                    }    

                    decimal remainingLoanAmount = Math.Round(monthlyPaymentAmount - monthlyPayment.TotalDefaultPaymentAmount);
                    monthlyPayment.AdditionalPaymentFee = Math.Round(remainingLoanAmount * (decimal)0.018);
                    monthlyPayment.AdditionalPaymentAmount = remainingLoanAmount - monthlyPayment.AdditionalPaymentFee;
                    monthlyPayment.BeforePaidLoan = remainingLoan;
                    monthlyPayment.TotalLoanPayment = monthlyPayment.DefaultLoanPaymentAmount + monthlyPayment.AdditionalPaymentAmount;
                    monthlyPayment.AfterPaidLoan = Math.Round(monthlyPayment.BeforePaidLoan - monthlyPayment.TotalLoanPayment);
                    calculatedLoans.Add(monthlyPayment);

                    paymentDate = paymentDate.AddMonths(1);
                    remainingLoan = monthlyPayment.AfterPaidLoan;
                }    

                return View(calculatedLoans);
            }
            return Redirect("/Home/Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
