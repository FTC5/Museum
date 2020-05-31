using AutoMapper;
using Museum.BLL.Interfaces;
using Museum.BLL.Services;
using Museum.PL.Utility;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.PL.Utility
{
    class PLModule : NinjectModule
    {
        public PLModule()
        {
        }
        public override void Load()
        {
            Bind<IExcursionsScheduleService>().To<ExcursionsScheduleService>();
            Bind<IGrafikService>().To<GrafikService>();
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }
        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
                cfg.AddProfile<Museum.BLL.Infrastructure.AutoMapping>();
                cfg.ConstructServicesUsing(type => context.Kernel.GetType());
            }).CreateMapper();
            return mapper;
        }
    }
}
