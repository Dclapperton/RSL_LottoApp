using Business.Services;
using System;
using System.Net.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RSL_LottoApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://data.api.thelott.com")
            };

            container.RegisterInstance<HttpClient>(httpClient, InstanceLifetime.Singleton);
            container.RegisterType<ILottoServiceProvider, LottoServiceProvider>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}