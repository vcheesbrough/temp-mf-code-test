using System;
using NSubstitute;
using NUnit.Framework;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Tests
{
    [TestFixture]
    public class BusinessLoansTests
    {
        [Test]
        public void WhenExternalServiceRequest_ThenServiceInvokedWithArguments()
        {
            var mockExternalService = Substitute.For<IBusinessLoansService>();
            var target = new BusinessLoans(mockExternalService)
            {
                InterestRatePerAnnum = 123.42M, 
                LoanAmount = 10000M
            };
            var sellerCompanyData = new SellerCompanyData
            {
                DirectorName = "Adam Smith",
                Founded = DateTime.Parse("29/02/2024"),
                Name = "Acme Business Stuff",
                Number = 42
            };

            mockExternalService.SubmitApplicationFor(
                Arg.Do<CompanyDataRequest>(request =>
                {
                    Assert.That(request.CompanyFounded, Is.EqualTo(sellerCompanyData.Founded));
                    Assert.That(request.DirectorName, Is.EqualTo(sellerCompanyData.DirectorName));
                    Assert.That(request.CompanyName, Is.EqualTo(sellerCompanyData.Name));
                    Assert.That(request.CompanyNumber, Is.EqualTo(sellerCompanyData.Number));
                }),
                Arg.Do<LoansRequest>(request =>
                {
                    Assert.That(request.InterestRatePerAnnum, Is.EqualTo(123.42M));
                    Assert.That(request.LoanAmount, Is.EqualTo(10000m));
                }));

            target.ExternalServiceRequest(new SellerApplication
            {
                Product = target,
                CompanyData = sellerCompanyData
            });
        }
    }
}