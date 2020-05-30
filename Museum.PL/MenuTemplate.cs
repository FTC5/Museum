using Museum.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.PL
{
    abstract class MenuTemplate : IMenu
    {
        protected IExcursionsScheduleService excursionsScheduleService;
        protected IExpositionService expositionService;
        protected IGrafikService grafikService;
        protected int choice = 7;
        protected MenuTemplate(IExcursionsScheduleService excursionsScheduleService, IExpositionService expositionService, IGrafikService grafikService)
        {
            this.excursionsScheduleService = excursionsScheduleService;
            this.expositionService = expositionService;
            this.grafikService = grafikService;
        }

        public void MainMenu()
        {
            Console.WriteLine("\n");
            while (true){
                switch (choice)
                {
                    case 1:
                        SearchExposition(grafikService);
                        break;
                    case 2:
                        GetExposition(expositionService);
                        break;
                    case 3:
                        GetExpositionExcursions(excursionsScheduleService);
                        break;
                    case 4:
                        GetExpositionScheduleExcursions(excursionsScheduleService);
                        break;
                    case 5:
                        GetExpositionCustomerExcursions(excursionsScheduleService);
                        break;
                    case 6:
                        SingUpTOCustomerExcursions(excursionsScheduleService);
                        break;
                    case 7:
                        GetGrafik(grafikService);
                        break;
                    case 8:
                        return;
                    default:
                        break;
                }
                Console.WriteLine("1) Search for exposure in the grafik\n" +
                    "2) View exposure information\n" +
                    "3) View excursions of the exhibition\n" +
                    "4) View planned excursions\n" +
                    "5) View excursions on request\n" +
                    "6) Registration for excursion on request\n" +
                    "7) View grafik\n" +
                    "8) Exit");
                choice = Convert.ToInt32(Console.ReadLine());
            }
        }
        public abstract void GetGrafik(IGrafikService grafikService);
        public abstract void SearchExposition(IGrafikService grafikService);
        public abstract void GetExposition(IExpositionService expositionService);
        public abstract void GetExpositionExcursions(IExcursionsScheduleService excursionsScheduleService);
        public abstract void GetExpositionScheduleExcursions(IExcursionsScheduleService excursionsScheduleService);
        public abstract void GetExpositionCustomerExcursions(IExcursionsScheduleService excursionsScheduleService);
        public abstract void SingUpTOCustomerExcursions(IExcursionsScheduleService excursionsScheduleService);
    }
}
