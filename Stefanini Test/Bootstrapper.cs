using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Stefinini_Test.IoC;
using Unity.Mvc3;

namespace Stefanini_Test
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = RegisterUnityContainer.Create();

            return container;
        }
    }
}