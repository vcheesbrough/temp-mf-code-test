using System;
using SlothEnterprise.External;

namespace SlothEnterprise.ProductApplication.Applications
{
    public interface ISellerCompanyData
    {
        string Name { get; set; }
        int Number { get; set; }
        string DirectorName { get; set; }
        DateTime Founded { get; set; }

        CompanyDataRequest AsCompanyDataRequest();

    }


    public class SellerCompanyData : ISellerCompanyData
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string DirectorName { get; set; }
        public DateTime Founded { get; set; }
        public CompanyDataRequest AsCompanyDataRequest()
        {
            return new CompanyDataRequest
            {
                CompanyFounded = Founded,
                DirectorName = DirectorName,
                CompanyName = Name,
                CompanyNumber = Number
            };
        }
    }
}