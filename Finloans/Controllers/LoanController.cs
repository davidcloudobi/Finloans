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
    public class LoanController : Controller
    {
        private readonly ICompanyService _db;
        private readonly ISubService sub;

        public LoanController(ICompanyService db, ISubService sub)
        {
            this._db = db;
            this.sub = sub;
        }
        //GET: Loan
       [HttpGet]
        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyInfo item)
        {

            if (ModelState.IsValid)
            {
                _db.Add(item);
                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            var item = (LoanInfo)Session["item"];
            var email = (string)Session["Email"];
            var breakdown = _db.LoanBreakDown(item.Amount, item.Duration, id, email);
            var model = _db.Get(id);
            ViewBag.breakdown = breakdown;
            ViewBag.time = (int)item.Duration;
            ViewBag.amount = (int)item.Amount;
            ViewBag.res = model.WebAddress;





            return View(model);
        }


        [HttpGet]
        public ActionResult FilteredResult()
        {
            var item = (LoanInfo)Session["item"];
            var model = _db.GetAllFiltered(item);

            return View(model);
        }



        [HttpGet]
        public ActionResult GetAllCompaines()
        {

            var model = _db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Website(int id)
        {
            var model = _db.Get(id);
            var email = (string)Session["Email"];

            _db.Unique(id, email);

            return Redirect($"https://{model.WebAddress}");
        }

        [HttpGet]
        public ActionResult Subscribe()
        {
            var model = _db.Get(1);

            return View(model);

        }

        [HttpGet]
        public async Task<ActionResult> Payment(int id)
        {

         var  numb = _db.Amount(id);
            //ViewBag.Message = "Your contact page.";

            var email = (string)Session["Email"];
            var paystackTransactionAPI = new PaystackTransaction("sk_test_4f260b0736ab1d07afe4642756c7868359abb180");
            //var response = await paystackTransactionAPI.InitializeTransaction("davidcloudobi@gmail.com", 500000);
            var response = await paystackTransactionAPI.InitializeTransaction(email, numb, callbackUrl: "https://localhost:44367/");
            if (response.status)
            {
             

                Response.AddHeader("Access-Control-Allow-Origin", "*");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");

                var currentSub = sub.Get(email);
                if (currentSub == null)
                {
                    sub.AddSub(id, email);
                }

                if (currentSub != null)
                {
                    sub.UpdateSub(id, email);
                }

                Response.Redirect(response.data.authorization_url);

            }
            else
            {
                return RedirectToAction("Error");
            }




          

            return RedirectToAction("Error");

           
        }


        [HttpGet]

        public  ActionResult Error()
        {

            return View();
        }
    }
}