using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService : IProductApplicationService
    {
        public int SubmitApplicationFor(ISellerApplication application)
        {
            return application.Product.ExternalServiceRequest(application);
        }
    }
}