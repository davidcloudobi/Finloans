using FinLibrary.Repo.EF;

namespace FinLibrary.Model.Services
{
    public interface ISubService
    {
        void AddSub(int id,string email);
        Subscription Get(string email);
        void UpdateSub(int id, string email);
        bool CheckSub(string email);
    }
}