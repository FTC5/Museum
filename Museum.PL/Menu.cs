using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Museum.BLL.DTO;
using Museum.BLL.Infrastructure;
using Museum.BLL.Interfaces;
using Museum.BLL.Services;

namespace Museum.PL
{
    class Menu : MenuTemplate, IMenu
    {
        private ICheckIntService check;
        public Menu(IExcursionsScheduleService excursionsScheduleService, IExpositionService expositionService, IGrafikService grafikService) 
            : base(excursionsScheduleService, expositionService, grafikService)
        {
            check = new CheckIntService();
        }
        private void Choice()
        {
            choice = check.NumberCheck("Please enter grafik or exposition Id :");
        }
        public override void GetExposition(IExpositionService expositionService)
        {
            Choice();
            var exposition = expositionService.GetExpositionInfo(choice);
            Console.WriteLine(exposition.ToString());
        }

        public override void GetExpositionCustomerExcursions(IExcursionsScheduleService excursionsScheduleService)
        {
            Choice();
            var customeExcursion = excursionsScheduleService.GetCustomExcursions(choice);
            foreach (var item in customeExcursion)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public override void GetExpositionExcursions(IExcursionsScheduleService excursionsScheduleService)
        {
            Choice();
            var scheduleExcursion = excursionsScheduleService.GetScheduledExcursionsInfo(choice);
            Console.WriteLine(scheduleExcursion.ToString());
            var customeExcursion = excursionsScheduleService.GetCustomExcursions(choice);
            foreach (var item in customeExcursion)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public override void GetExpositionScheduleExcursions(IExcursionsScheduleService excursionsScheduleService)
        {
            Choice();
            var scheduleExcursion = excursionsScheduleService.GetScheduledExcursionsInfo(choice);
            Console.WriteLine(scheduleExcursion.ToString());
        }

        public override void GetGrafik(IGrafikService grafikService)
        {
            var grafiks = grafikService.GetGrafiks();
            foreach (var item in grafiks)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public override void SearchExposition(IGrafikService grafikService)
        {
            string search;
            Console.WriteLine("Please enter exposition name:");
            search = Console.ReadLine();
            var grafiks = grafikService.FindByName(search);
            foreach (var item in grafiks)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public override void SingUpTOCustomerExcursions(IExcursionsScheduleService excursionsScheduleService)
        {
            choice = check.NumberCheck("Please enter custome excursion id:");
            string setting="";
            Console.WriteLine("Register one persone press 1.\n" +
                "Register many persone press another symbol");
            setting = Console.ReadLine();
            try
            {
                if (setting == "1")
                {
                    excursionsScheduleService.SignUpToCustomExcursion(choice, CreateOne());
                }
                else
                {
                    excursionsScheduleService.SignUpToCustomExcursion(choice, CreateMany());
                }
            }catch(ExcursionNotFoundException ex1)
            {
                Console.WriteLine(ex1.Message);
            }
            catch(SmallAgeCustomerException ex2)
            {
                Console.WriteLine(ex2.ToString());
            }
        }
        private CustomerDTO CreateOne()
        {
            CustomerDTO customer = new CustomerDTO();
            Console.WriteLine("Name (First name and Last name)");
            customer.Name = Console.ReadLine();
            Console.WriteLine("Age");
            customer.Age = Convert.ToInt32(Console.ReadLine());
            return customer;
        }
        private IEnumerable<CustomerDTO> CreateMany()
        {
            int count=0;
            Console.WriteLine("Count of person");
            count = Convert.ToInt32(Console.ReadLine());
            CustomerDTO[] customers = new CustomerDTO[count];
            for (int i = 0; i < count; i++)
            {
                customers[i] = CreateOne();
            }
            return customers;
        }
    }
}
