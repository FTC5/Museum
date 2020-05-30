using Museum.BLL;
using Museum.BLL.Interfaces;
using Museum.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            IExcursionsScheduleService excursionsSchedule = new ExcursionsScheduleService();
            IExpositionService exposition = new ExpositionService();
            IGrafikService grafik = new GrafikService();
            IMenu menu = new Menu(excursionsSchedule,exposition, grafik);
            menu.MainMenu();
        }
    }
}
