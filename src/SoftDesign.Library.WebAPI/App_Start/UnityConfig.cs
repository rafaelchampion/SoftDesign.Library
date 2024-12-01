using System.Data.Entity;
using System.Web.Mvc;
using SoftDesign.Library.Domain.Entities.Books;
using SoftDesign.Library.Domain.Entities.Rentals;
using SoftDesign.Library.Domain.Entities.Users;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using SoftDesign.Library.Domain.Interfaces.Services;
using SoftDesign.Library.Infrastructure.DataPersistence;
using SoftDesign.Library.Infrastructure.DataPersistence.Repositories;
using SoftDesign.Library.Services.Services;
using Unity;
using Unity.AspNet.Mvc;

namespace SoftDesign.Library.WebAPI.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            Container = new UnityContainer();

            Container.RegisterType<DbContext, SoftDesignLibraryContext>();
            Container.RegisterType<IRepository<Book>, Repository<Book>>();
            Container.RegisterType<IRepository<User>, Repository<User>>();
            Container.RegisterType<IRepository<Rental>, Repository<Rental>>();
            Container.RegisterType<IAuthenticationService, AuthenticationService>();
            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<IBookService, BookService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}