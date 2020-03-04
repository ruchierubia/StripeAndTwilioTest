using System;
using System.Configuration;
using NUnit.Framework;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SendAndReceiveSms.Tests.Controllers
{
    [TestFixture]
    public class UnitTest1
    {

        [SetUp]
        public void Init()
        {
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            TwilioClient.Init(accountSid, authToken);

        }

        [Test]
        public void TwilioConnectionPassed()
        {
            var to = new PhoneNumber(ConfigurationManager.AppSettings["ToNumber"]);
            var from = new PhoneNumber(ConfigurationManager.AppSettings["FromNumber"]);
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Hey");

            Assert.AreEqual(null,message.ErrorCode);

        }
    }
}
