using AlgebraSeminar.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AlgebraSeminar
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IPredbiljezbaRepository, PredbiljezbaRepository>();
            container.RegisterType<ISeminarRepository, SeminarRepository>();
            container.RegisterType<IZaposlenikRepository, ZaposlenikRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}