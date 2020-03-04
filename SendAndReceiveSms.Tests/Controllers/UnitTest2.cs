using NUnit.Framework;
using Stripe;
using System;namespace SendAndReceiveSms.Tests.Controllers
{
    [TestFixture]
    public class UnitTest2
    {

        [SetUp]
        public void Setup()
        {
            var stripeKey = "pk_test_dkXUOStgaMMg7pON6wgj3Zwf00uT267OoG";
            StripeConfiguration.SetApiKey(stripeKey);
        }

        [Test]
        public void ConnectionTest_InvalidKey()
        {
            // Arrange
            var service = new TokenService();
            var options = new TokenCreateOptions();
            // Act
            TestDelegate testDelegate = () => service.Create(options);
            // Assert
            var ex = Assert.Throws<StripeException>(testDelegate);
            StringAssert.Contains("Invalid API Key provided", ex.Message);
        }

        [Test]
        public void ConnectionTest_CreateTokenPassed()
        {
            var options = new TokenCreateOptions
            {
                BankAccount = new BankAccountOptions
                {
                    Country = "US",
                    Currency = "usd",
                    AccountHolderName = "Jenny Rosen",
                    AccountHolderType = "individual",
                    RoutingNumber = "110000000",
                    AccountNumber = "000123456789"
                }
            };

            var service = new TokenService();
            Token stripeToken = service.Create(options);
        }
    }
}
