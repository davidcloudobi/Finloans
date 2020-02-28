using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FinLibrary.Model.Services;
using FinLibrary.Repo.EF;
using NLog;
using Paystack.Net.SDK.Transactions;

namespace Finloans.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoanService _db;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

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


            try
            {
               

                if (!ModelState.IsValid)
                {

                    return View();
                }
                item.LoanType = LoanType;

                _logger.Info(item.LoanType);
                _db.Add(item);

                Session["item"] = item;
                
            }
            catch (Exception e)
            {
                //Logger logger = LogManager.GetLogger("fileLogger");

                // add custom message and pass in the exception
                _logger.Error(e, "Whoops!");
            }
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
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            return View();
        }

        


        [HttpGet]
        public ActionResult SingleBlog()
        {
            return View();
        }

      
    }
}