using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Paystack.Net.SDK.Transactions;

namespace Finloans.Controllers
{
    public class SubController : Controller
    {
        // GET: Sub
        public async Task<ActionResult> Index(int value)
        {

            int numb = 0;
            int month = 0;

            switch (value)
            {
                case 1:
                    numb = 500000;
                    month = 1;

                    break;
                case 2:
                    numb = 2200000;
                    month = 6;
                    break;
                case 3:
                    numb = 4000000;
                    month = 12;
                    break;
                default:
                    numb = 0;
                    break;
            }

            TempData["month"] = month;
            string secretKey = ConfigurationManager.AppSettings["PayStackSec"];
            var paystackTransactionAPI = new PaystackTransaction(secretKey);
            string email = User.Identity.GetUserName();
            var response = await paystackTransactionAPI.InitializeTransaction(email, numb, callbackUrl: "https://localhost:44377/Suscription/VerifyPayment");
            if (response.status)
            {
                Session["paymentRef"] = response.data.reference;
                Response.AddHeader("Access-Control-Allow-Origin", "*");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                return Redirect(response.data.authorization_url);
            }

            return RedirectToAction("Failed");


        }

        [Authorize]
        public async Task<ActionResult> VerifyPayment()
        {
            string reference = (string)Session["paymentRef"];
            string secretKey = ConfigurationManager.AppSettings["PayStackSec"];
            var paystackTransactionApi = new PaystackTransaction(secretKey);
            var response = await paystackTransactionApi.VerifyTransaction(reference);

            if (response.status && response.data.status.Equals("success"))
            {
                //string userId = User.Identity.GetUserId();
                //var loggedInUser = _repo.GetUserById(userId);
                //loggedInUser.ActiveSub = true;
                //Index
                var month = Convert.ToInt32(TempData["month"]);
                var startDate = DateTime.Now;
                var endDate = DateTime.Now.AddDays(month * 31);




                //UserIdentity.userEmail = User.Identity.GetUserName();
                //UserIdentity.ValidityPeriod = endDate - startDate;



                //_repo.Save();
                //int providerId = (int)Session["providerId"];
                // Session["paymentRef"] = null;
                //return RedirectToAction("Details", "Provider", new { id = providerId });
            }
            return RedirectToAction("Failed");
        }
    }
}