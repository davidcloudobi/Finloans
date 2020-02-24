using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinLibrary.Repo.EF;

namespace FinLibrary.Model.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly Finloans _db;
        private readonly VisitInfo data;

        public CompanyService(Finloans db, VisitInfo data)
        {
            _db = db;
            this.data = data;
        }

        public void Add(CompanyInfo item)
        {

            _db.CompanyInfoes.Add(item);
            _db.SaveChanges();


        }

        public IEnumerable<CompanyInfo> GetAll()
        {
            return _db.CompanyInfoes;
        }



        public IEnumerable<CompanyInfo> GetAllFiltered(LoanInfo item)
        {
            return _db.CompanyInfoes.Where(val => val.TypeOfLoan == item.LoanType);



        }

        public CompanyInfo Get(int id)
        {
            return _db.CompanyInfoes.FirstOrDefault(val => val.Id == id);
        }

        public bool Unique(int id, string email)
        {
            var company = _db.CompanyInfoes.FirstOrDefault(r => r.Id == id);
            var data2 = data;
            data2.Email = email;
            var filterVisit = _db.VisitInfoes.FirstOrDefault(r => r.Email == data2.Email);


            if (filterVisit.UniqueVisit == true && filterVisit.Company == data2.Company && filterVisit.LoanType == data2.LoanType)
            {
                return false;
            }

            

            filterVisit.UniqueVisit = true;
            _db.SaveChanges();
            company.UniqueVisit += 1;
            _db.SaveChanges();

           // if (filterVisit != null && filterVisit.Company == data2.Company && filterVisit.LoanType == data2.LoanType)
           // {
           //     return false;
           // }

           // data2.UniqueVisit = true;
           // _db.VisitInfoes.Add(data2);
           // _db.SaveChanges();


           // var res =  _db.CompanyInfoes.FirstOrDefault(val => val.Id == id);
           //res.UniqueVisit += 1;
           //_db.SaveChanges();
           return true;

        }


        public decimal LoanBreakDown(decimal amount, double time, int id, string email)
        {
            try
            {



                var person = _db.CompanyInfoes.FirstOrDefault(val => val.Id == id);
                var oldId = _db.VisitInfoes.Count();

                var datas = data;
                datas.LoanType = person.TypeOfLoan;
                datas.Company = person.Name;
                datas.Email = email;
                //datas.Id = oldId + 1;
                var filterVisit = _db.VisitInfoes.FirstOrDefault(r => r.Email == datas.Email);
               

                //var interest = (amount * person.Rate * (decimal)time)/100;
                //var loanInterest = amount + interest;
                //var loanRepayment = loanInterest / ((int)time);
                var loanRepayment = (amount * person.Rate) / 100;

                if (filterVisit != null && filterVisit.Company == datas.Company && filterVisit.LoanType == datas.LoanType)
                {
                    return loanRepayment;
                }

                datas.VisitCounter = true;
                datas.UniqueVisit = false;
                _db.VisitInfoes.Add(datas);
                _db.SaveChanges();
                person.VisitCounter += 1;
                _db.SaveChanges();

                return loanRepayment;
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
