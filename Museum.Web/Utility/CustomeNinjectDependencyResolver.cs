using System.Web.Http.Dependencies;
using Ninject;
using System.Collections.Generic;
using System;
using AutoMapper;
using Museum.BLL.Interfaces;
using Museum.BLL.Services;

namespace OnlineAuction.Web.Utility
{
    public class CustomeNinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;
        public CustomeNinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IExcursionsScheduleService>().To<ExcursionsScheduleService>();
            kernel.Bind<IGrafikService>().To<GrafikService>();
        }
    }
}
