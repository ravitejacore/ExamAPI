using System.Web.Mvc;
using TweetsAPI.Service;
using Unity;
using Unity.Mvc5;

namespace TweetsAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ITweetService, TweetService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}