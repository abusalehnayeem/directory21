using System;
using System.Web;
using directory21.Core;
using directory21.Core.Data;
using directory21.Data;
using directory21.Data.Repositories;
using directory21.Service.CategoriesService;
using directory21.Service.ItemsService;
using directory21.Service.ResourcesService;
using directory21.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace directory21.Web
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IResourceRepository>().To<ResourceRepository>().InRequestScope();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>().InRequestScope();
            kernel.Bind<IItemRepository>().To<ItemRepository>().InRequestScope();
            kernel.Bind<ICategoriesService>().To<CategoriesService>().InRequestScope();
            kernel.Bind<IItemsService>().To<ItemsService>().InRequestScope();
            kernel.Bind<IResourcesService>().To<ResourcesService>().InRequestScope();
            //kernel.Bind(
            //    x => x.From(Assembly.GetExecutingAssembly())
            //        .IncludingNonPublicTypes()
            //        .SelectAllTypes()
            //        .BindAllInterfaces());
        }
    }
}