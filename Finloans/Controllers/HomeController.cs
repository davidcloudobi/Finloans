using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FinLibrary.Model.Services;
using FinLibrary.Repo.EF;
using Paystack.Net.SDK.Transactions;

namespace Finloans.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoanService _db;

        public HomeController(ILoanService db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {



            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoanInfo item, string LoanType)
        {
            //LoanInfo item


            if (!ModelState.IsValid)
            {

                return View();
            }
            item.LoanType = LoanType;
            _db.Add(item);

            Session["item"] = item;
           


            return RedirectToAction("FilteredResult", "Loan");

        }

        public ActionResult AllLoans()
        {
            var model = _db.GetAll();
            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Contact(int id)
        {
            ViewBag.Message = "Your contact page.";


            var paystackTransactionAPI = new PaystackTransaction("sk_test_4f260b0736ab1d07afe4642756c7868359abb180");
            var response = await paystackTransactionAPI.InitializeTransaction("davidcloudobi@gmail.com", 500000);
            if (response.status)
            {
                Response.AddHeader("Access-Control-Allow-Origin", "*");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Redirect(response.data.authorization_url);
            }
            else
            {
                //Handle Error
            }

            return View(response);
        }

        [HttpPost]

        public async Task<ActionResult> Contact()
        {
            var paystackTransactionAPI = new PaystackTransaction("sk_test_4f260b0736ab1d07afe4642756c7868359abb180");
            var response = await paystackTransactionAPI.VerifyTransaction("cipyd2ikxw");

            return RedirectToAction("About");
        }

        [HttpGet]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Blog()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Elements()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Faq()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Loan()
        {
            return View();
        }


        [HttpGet]
        public ActionResult SingleBlog()
        {
            return View();
        }
    }
}