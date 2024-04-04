using System.ComponentModel.DataAnnotations;

namespace BankLoanCalculation.Models
{
    public class CalculatedLoanViewModel
    {
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,### VND}")]
        public decimal InterestPaymentAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,### VND}")]
        public decimal DefaultLoanPaymentAmount { get; set; } = 5_000_000;
        [DisplayFormat(DataFormatString = "{0:#,### VND}")]
        public decimal TotalDefaultPaymentAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,### VND}")]
        public decimal AdditionalPaymentAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,### VND}")]
        public decimal AdditionalPaymentFee { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,### VND}")]
        public decimal TotalLoanPayment { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,### VND}")]
        public decimal BeforePaidLoan { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,### VND}")]
        public decimal AfterPaidLoan { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,### VND}")]
        public decimal TotalAdditionalFee { get; set; }
    }
}
