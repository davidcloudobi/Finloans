﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinLibrary.Repo.EF;

namespace FinLibrary.Model.Services
{
    public class LoanService : ILoanService
    {
        private readonly Finloans _db;
        private readonly Subscription sub;

        public LoanService(Finloans db, Subscription sub)
        {
            _db = db;
            this.sub = sub;
        }


        public void Add(LoanInfo item)
        {

            _db.LoanInfoes.Add(item);
            _db.SaveChanges();
        }

        public IEnumerable<LoanInfo> GetAll()
        {
            return _db.LoanInfoes;
        }

        public LoanInfo Get(int id)
        {
            return _db.LoanInfoes.FirstOrDefault(val => val.Id == id);
        }
    }
}
