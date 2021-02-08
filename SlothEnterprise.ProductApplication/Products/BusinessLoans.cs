using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.Products
{
    public class BusinessLoans : IProduct
    {
        private readonly IBusinessLoansService _businessLoansService;

        public BusinessLoans(IBusinessLoansService businessLoansService)
        {
            _businessLoansService = businessLoansService;
        }

        public int Id { get; set; }

        /// <summary>
        /// Per annum interest rate
        /// </summary>
        public decimal InterestRatePerAnnum { get; set; }

        /// <summary>
        /// Total available amount to withdraw
        /// </summary>
        public decimal LoanAmount { get; set; }

        public int ExternalServiceRequest(ISellerApplication application)
        {
            var result = _businessLoansService.SubmitApplicationFor(
                application.CompanyData.AsCompanyDataRequest(),
                new LoansRequest
                {
                    InterestRatePerAnnum = InterestRatePerAnnum,
                    LoanAmount = LoanAmount
                });
            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}