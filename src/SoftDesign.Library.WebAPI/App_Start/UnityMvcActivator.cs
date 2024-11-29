using SoftDesign.Library.WebAPI.App_Start;
using System.Linq;
using System.Web.Mvc;

using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SoftDesign.Library.WebAPI.UnityMvcActivator), nameof(SoftDesign.Library.WebAPI.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(SoftDesign.Library.WebAPI.UnityMvcActivator), nameof(SoftDesign.Library.WebAPI.UnityMvcActivator.Shutdown))]

namespace SoftDesign.Library.WebAPI
{
  
    public static class UnityMvcActivator
    {
        public static void Start() 
        {
            //FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            //FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));
            //DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));

        }
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}