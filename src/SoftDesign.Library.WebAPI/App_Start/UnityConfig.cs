using SoftDesign.Library.Domain.Interfaces.Repositories;
using System.Data.Entity;
using System.Web.Mvc;
using Unity.Lifetime;
using Unity;
using SoftDesign.Library.Infrastructure.DataPersistence;
using SoftDesign.Library.Infrastructure.DataPersistence.Repositories;
using Unity.AspNet.Mvc;
using SoftDesign.Library.Domain.Entities.Books;
using SoftDesign.Library.Domain.Entities.Rentals;
using SoftDesign.Library.Domain.Entities.Users;

namespace SoftDesign.Library.WebAPI.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            Container = new UnityContainer();

            Container.RegisterType<IRepository<Book>, Repository<Book>>();
            Container.RegisterType<IRepository<User>, Repository<User>>();
            Container.RegisterType<IRepository<Rental>, Repository<Rental>>();
            Container.RegisterType<DbContext, SoftDesignLibraryContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}