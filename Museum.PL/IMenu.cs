using Museum.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.PL
{
    interface IMenu
    {
        void MainMenu();
        void GetGrafik(IGrafikService grafikService);
        void SearchExposition(IGrafikService grafikService);
        void GetExposition(IExpositionService expositionService);
        void GetExpositionExcursions(IExcursionsScheduleService excursionsScheduleService);
        void GetExpositionScheduleExcursions(IExcursionsScheduleService excursionsScheduleService);
        void GetExpositionCustomerExcursions(IExcursionsScheduleService excursionsScheduleService);
        void SingUpTOCustomerExcursions(IExcursionsScheduleService excursionsScheduleService);
    }
}
