using AutoMapper;
using Museum.BLL;
using Museum.BLL.Infrastructure;
using Museum.BLL.Interfaces;
using Museum.BLL.Services;
using Museum.PL.Utility;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Museum.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IKernel kernel = new StandardKernel(new PLModule(), new BLLModule("MuseumContext"));
            kernel.Load(Assembly.GetExecutingAssembly());
            IMapper mapper = kernel.Get<IMapper>();
            IExcursionsScheduleService excursionsSchedule = kernel.Get<IExcursionsScheduleService>();
            IExpositionService exposition = kernel.Get<IExpositionService>();
            IGrafikService grafik = kernel.Get<IGrafikService>();
            IMenu menu = new Menu(mapper,excursionsSchedule,exposition, grafik);
            menu.MainMenu();
        }
    }
}
