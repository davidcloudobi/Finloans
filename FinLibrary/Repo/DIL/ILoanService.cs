using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinLibrary.Repo.EF;

namespace FinLibrary.Model.Services
{
    public interface ILoanService
    {
        void Add(LoanInfo item);
        IEnumerable<LoanInfo> GetAll();
        LoanInfo Get(int id);
    }
}
