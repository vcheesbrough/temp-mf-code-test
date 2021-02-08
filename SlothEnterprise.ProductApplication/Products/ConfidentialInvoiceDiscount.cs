using SlothEnterprise.External;
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

        public int Id { get; set; }

        public decimal TotalLedgerNetworth { get; set; }

        public decimal AdvancePercentage { get; set; }

        public decimal VatRate { get; set; } = VatRates.UkVatRate;

        public int ExternalServiceRequest(ISellerApplication application)
        {
            var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                new CompanyDataRequest
                {
                    CompanyFounded = application.CompanyData.Founded,
                    CompanyNumber = application.CompanyData.Number,
                    CompanyName = application.CompanyData.Name,
                    DirectorName = application.CompanyData.DirectorName
                }, TotalLedgerNetworth, AdvancePercentage, VatRate);

            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}