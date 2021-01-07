using Microsoft.Practices.Unity;
using Stefanini_Test.Data;
using Stefanini_Test.Data.Repository;
using Stefanini_Test.Domain.Repositories;
using Stefanini_Test.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefinini_Test.IoC
{
    public abstract class RegisterUnityContainer
    {
        public static IUnityContainer Create()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterInstance(new StefaniniDataContext());

            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ISellerService, SellerService>();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ISellerRepository, SellerRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();


            return container;
        }
    }
}
