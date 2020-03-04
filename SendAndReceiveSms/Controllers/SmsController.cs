using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace SendAndReceiveSms.Controllers
{
    public class SmsController : Controller
    {
        // GET: Sms
        public ActionResult SendSms()
        {
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber(ConfigurationManager.AppSettings["ToNumber"]);
            var from = new PhoneNumber(ConfigurationManager.AppSettings["FromNumber"]);
            var message = MessageResource.Create(
                to: to,
                from:from,
                body: "Hey");

            return Content(message.Sid);
        }
    }
}