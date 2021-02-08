using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.Products
{
    public class ConfidentialInvoiceDiscount : IProduct
    {
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;

        public ConfidentialInvoiceDiscount(IConfidentialInvoiceService confidentialInvoiceWebService)
        {
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
        }

        public decimal TotalLedgerNetworth { get; set; }

        public decimal AdvancePercentage { get; set; }

        public decimal VatRate { get; set; } = VatRates.UkVatRate;

        public int Id { get; set; }

        public int ExternalServiceRequest(ISellerApplication application)
        {
            var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                application.CompanyData.AsCompanyDataRequest(), TotalLedgerNetworth, AdvancePercentage, VatRate);

            return result.AsApplicationId();
        }
    }
}