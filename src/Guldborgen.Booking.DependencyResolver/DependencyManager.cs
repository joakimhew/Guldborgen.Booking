using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using Guldborgen.Booking.DataAccess;
using Guldborgen.Booking.DataAccess.Repositories;
using Guldborgen.Booking.Domain;
using Ninject;
using Ninject.Infrastructure.Language;
using Ninject.Web.Common;

namespace Guldborgen.Booking.DependencyResolver
{
    public class DependencyManager : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public DependencyManager(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void RegisterAll()
        {
            var registerMethods = GetType().GetMethods()
                .Where(x => x.HasAttribute(typeof (DependencyRegisterAttribute)));

            foreach (var method in registerMethods)
            {
                method.Invoke(this, null);
            }
        }

        [DependencyRegister]
        public void RegisterServices()
        {
            _kernel.Bind<IAccountService>().To<AccountService>().InRequestScope();
            _kernel.Bind<IBookingService>().To<BookingService>().InRequestScope();
        }

        [DependencyRegister]
        public void RegisterRepositories()
        {
            _kernel.Bind<IUserRepository>().To<UserRepository>();
            _kernel.Bind<IRoleRepository>().To<RoleRepository>();
            _kernel.Bind<ISessionRepository>().To<SessionRepository>();
            _kernel.Bind<ILaundryTimeRepository>().To<LaundryTimeRepository>();
            _kernel.Bind<IReservationRepository>().To<ReservationRepository>();
        }

        [DependencyRegister]
        public void RegisterDatabases()
        {
            _kernel.Bind<IDbConnection>().To<SqlConnection>()
                .InRequestScope()
                .WithConstructorArgument("connectionString",
                    ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public TModel Resolve<TModel>()
        {
            return _kernel.Get<TModel>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }

    public class DependencyRegisterAttribute : Attribute
    {
    }
}