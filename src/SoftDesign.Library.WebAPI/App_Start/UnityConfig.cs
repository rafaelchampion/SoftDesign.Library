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
using Unity.Lifetime;

namespace SoftDesign.Library.WebAPI.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            Container = new UnityContainer();

            Container.RegisterType<DbContext, SoftDesignLibraryContext>();
            Container.RegisterType<IAuthenticationService, AuthenticationService>();
            Container.RegisterType<IRepository<Book>, Repository<Book>>();
            Container.RegisterType<IRepository<User>, Repository<User>>();
            Container.RegisterType<IRepository<Rental>, Repository<Rental>>();
            Container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            Container.RegisterType<IRentalRepository, RentalRepository>(new HierarchicalLifetimeManager());
            Container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            Container.RegisterType<IBookService, BookService>();
            Container.RegisterType<IRentalService, RentalService>();
            Container.RegisterType<IUserService, UserService>();
            Container.AddExtension(new Diagnostic());

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}