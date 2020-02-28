using System.Collections.Generic;
using FinLibrary.Repo.EF;

namespace FinLibrary.Model.Services
{
    public interface ICompanyService
    {
        void Add(CompanyInfo item);
        IEnumerable<CompanyInfo> GetAll();
        IEnumerable<CompanyInfo> GetAllFiltered(LoanInfo item);
        CompanyInfo Get(int id);
        decimal LoanBreakDown(decimal amount, double time, int id, string email);
        bool Unique(int id, string email);
        int Amount(int id);
    }
}