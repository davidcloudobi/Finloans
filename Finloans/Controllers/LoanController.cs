using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinLibrary.Model.Services;
using FinLibrary.Repo.EF;

namespace Finloans.Controllers
{
    public class LoanController : Controller
    {
        private readonly ICompanyService _db;

        public LoanController(ICompanyService db)
        {
            this._db = db;
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
    }
}