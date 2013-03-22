[assembly: WebActivator.PreApplicationStartMethod(typeof(Curso.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Curso.App_Start.NinjectWebCommon), "Stop")]

namespace Curso.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Repository;
    using Repository.Impl;
    using Repository.Interfaces;

    using Services;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IHibernateSessionFactory>().To<HibernateSessionFactory>().InSingletonScope();

            kernel.Bind<IManagerRepository>().To<ManagerRepository>().InSingletonScope().WithConstructorArgument("IHibernateSessionFactory", kernel.GetService(typeof(IHibernateSessionFactory)));
            kernel.Bind<IManagerService>().To<ManagerService>().InSingletonScope().WithConstructorArgument("IManagerRepository", kernel.GetService(typeof(IManagerRepository)));

            kernel.Bind<IInterestedRepository>().To<InterestedRepository>().InSingletonScope();
            kernel.Bind<IInterestedService>().To<InterestedService>().InSingletonScope().WithConstructorArgument("IInterestedRepository", kernel.GetService(typeof(IInterestedRepository)));
        }        
    }
}
