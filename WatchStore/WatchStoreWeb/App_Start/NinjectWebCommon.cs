using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WatchStore.BusinessLogic;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.BusinessLogic.Services;
using WatchStore.DataAccess;
using WatchStore.DataAccess.Interfaces;
using WatchStore.DataAccess.Repositories;
using WatchStoreWeb;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace WatchStoreWeb
{
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
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IWatchRepository>().To<WatchRepository>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IWatchService>().To<WatchService>();
            kernel.Bind<IImageService>().To<ImageService>();
            kernel.Bind<IImageRepository>().To<ImageRepository>();
            kernel.Bind<WatchStoreDataContext>().ToSelf().InRequestScope();
            kernel.Bind<IOrderWatchRepository>().To<OrderWatchRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IBrandRepository>().To<BrandRepository>();
            kernel.Bind<IBrandService>().To<BrandService>();

            kernel.Bind<IRequestContext>().To<RequestContext>().InRequestScope().OnActivation(ctx =>
            {
                var httpContext = HttpContext.Current;

                ctx.IPAddress = httpContext.Request.UserHostAddress;
                ctx.Session = httpContext.Session.SessionID;

                if (httpContext.User.Identity.IsAuthenticated)
                {
                    ctx.User = kernel.Get<IUserRepository>().GetUserByName(httpContext.User.Identity.Name);
                }
            });

        }        
    }
}
