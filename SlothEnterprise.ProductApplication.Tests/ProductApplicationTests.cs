using NSubstitute;
using NUnit.Framework;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.Tests
{
    [TestFixture]
    public class ProductApplicationTests
    {
        [SetUp]
        public void Setup()
        {
            _target = new ProductApplicationService();
            _mockSellerApplication = Substitute.For<ISellerApplication>();
        }

        private ProductApplicationService _target;
        private ISellerApplication _mockSellerApplication;

        [Test]
        public void WhenSubmitApplicationFor_ThenProductExternalServiceRequestCalledWithPassedApplication()
        {
            _target.SubmitApplicationFor(_mockSellerApplication);
            _mockSellerApplication.Product.Received(1).ExternalServiceRequest(_mockSellerApplication);
        }

        [Test]
        public void WhenSubmitApplicationFor_ThenReturnValueFromExternalServiceRequestIsReturned()
        {
            _mockSellerApplication.Product.ExternalServiceRequest(Arg.Any<ISellerApplication>()).Returns(245);

            Assert.That(_target.SubmitApplicationFor(_mockSellerApplication), Is.EqualTo(245));
        }
    }
}