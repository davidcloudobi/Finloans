using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FinLibrary.Model.Services;
using FinLibrary.Repo.EF;
//using FinLibrary.Repo.EF;
using Microsoft.AspNet.Identity;

namespace Finloans.App_Start
{
    public class ContainerConfig
    {

        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CompanyService>()
                .As<ICompanyService>()
                .InstancePerRequest();
            builder.RegisterType<LoanService>()
                .As<ILoanService>()
                .InstancePerRequest();
            builder.RegisterType<VisitInfo>()
                .InstancePerRequest();
            builder.RegisterType<FinLibrary.Repo.EF.Finloans>().InstancePerRequest();
            //builder.RegisterType<myDatabase>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

    }
}