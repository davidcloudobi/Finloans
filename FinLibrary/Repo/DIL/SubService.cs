using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinLibrary.Model.Services;
using FinLibrary.Repo.EF;

namespace FinLibrary.Repo.DIL
{
  public  class SubService: ISubService
    {
        private readonly Finloans sub;
        private readonly Subscription newSub;

        public SubService(Finloans sub, Subscription newSub)
        {
            this.sub = sub;
            this.newSub = newSub;
        }
        public void AddSub(int id, string email)
        {
            var newSubscription = newSub;
            newSubscription.Email = email;
            newSubscription.Package = id;
            newSubscription.Start = DateTime.Today;
            newSubscription.Status = true;

            if (id == 1)
            {
                newSubscription.End = DateTime.Today.AddMonths(1);
            }
            if (id == 2)
            {
                newSubscription.End = DateTime.Today.AddYears(1);
            }
            if (id == 3)
            {
                newSubscription.End = DateTime.Today.AddMonths(6);
            }

            sub.Subscriptions.Add(newSubscription);
            sub.SaveChanges();

        }

        public Subscription Get(string email)
        {
            var currentSub = sub.Subscriptions.FirstOrDefault(r => r.Email == email);
            return currentSub;
        }

        public void UpdateSub(int id, string email)
        {
            var currentSub = sub.Subscriptions.FirstOrDefault(r => r.Email == email);

            if (currentSub != null)
            {
                if (id == 1)
                {
                    currentSub.End = DateTime.Today.AddMonths(1);
                    
                }
                if (id == 2)
                {
                    currentSub.End = DateTime.Today.AddYears(1);
                }
                if (id == 3)
                {
                    currentSub.End = DateTime.Today.AddMonths(6);
                }
                currentSub.Start = DateTime.Today;
                currentSub.Status = true;
                sub.SaveChanges();

            }
        }

        public bool CheckSub(string email)
        {
            var currentSub = sub.Subscriptions.FirstOrDefault(r => r.Email == email);
            var todayDate = DateTime.Today;

            if (currentSub.End.Date < todayDate.Date)
            {
                return false;
            }

            return true;
        }
    }
}
