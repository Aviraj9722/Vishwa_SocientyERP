using BusinessLayer.IService;
using DataLayer.IService;
using DataLayer.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SocietyERP
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //Data Layer
            container.RegisterType<IMentor, AdminRepo>();

            //Business Layer
            container.RegisterType<IMentorBusiness, AdminBusiness>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}