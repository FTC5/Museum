using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Museum.BLL.DTO;
using Museum.BLL.Infrastructure;
using Museum.BLL.Interfaces;
using Museum.BLL.Services;
using Museum.PL.Models;
using Museum.PL.Utility;

namespace Museum.PL
{
    class Menu : MenuTemplate, IMenu
    {
        private IMapper mapper;
        public Menu(IMapper mapper, IExcursionsScheduleService excursionsScheduleService, IExpositionService expositionService, IGrafikService grafikService) 
            : base(excursionsScheduleService, expositionService, grafikService)
        {
            this.mapper = mapper;
        }
        private void Choice(string message)
        {
            string input="";
            while (true)
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (Int32.TryParse(input, out choice))
                {
                    return;
                }
                else
                {
                    Console.WriteLine("//|Wrong input!|\\\\");
                }
            }
        }
        public override void GetExposition(IExpositionService expositionService)
        {
            Choice("Please enter grafik or exposition Id :");
            var exposition = expositionService.GetExpositionInfo(choice);
            if (exposition==null)
            {
                Console.WriteLine("Not found");
                return;
            }
            Console.WriteLine(exposition.ToString());
        }

        public override void GetExpositionCustomerExcursions(IExcursionsScheduleService excursionsScheduleService)
        {
            Choice("Please enter grafik or exposition Id :");
            var customeExcursion = excursionsScheduleService.GetCustomExcursions(choice);
            if (customeExcursion == null)
            {
                Console.WriteLine("Not found");
                return;
            }
            foreach (var item in customeExcursion)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public override void GetExpositionExcursions(IExcursionsScheduleService excursionsScheduleService)
        {
            Choice("Please enter grafik or exposition Id :");
            var scheduleExcursion = excursionsScheduleService.GetScheduledExcursionsInfo(choice);
            if (scheduleExcursion == null)
            {
                Console.WriteLine("Not found");
                return; 
            }
            Console.WriteLine(scheduleExcursion.ToString());
            var customeExcursion = excursionsScheduleService.GetCustomExcursions(choice);
            foreach (var item in customeExcursion)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public override void GetExpositionScheduleExcursions(IExcursionsScheduleService excursionsScheduleService)
        {
            Choice("Please enter grafik or exposition Id :");
            var scheduleExcursion = excursionsScheduleService.GetScheduledExcursionsInfo(choice);
            if (scheduleExcursion == null)
            {
                Console.WriteLine("Not found");
                return;
            }
            Console.WriteLine(scheduleExcursion.ToString());
        }

        public override void GetGrafik(IGrafikService grafikService)
        {
            var grafiks = grafikService.GetGrafiks();
            if (grafiks == null)
            {
                Console.WriteLine("Not found");
                return;   
            }
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
            Choice("Please enter custome excursion id:");
            string setting="";
            Console.WriteLine("Register one persone press 1.\n" +
                "Register many persone press another symbol");
            setting = Console.ReadLine();
            try
            {
                if (setting == "1")
                {
                    excursionsScheduleService.SignUpToCustomExcursion(choice, mapper.Map<CustomerDTO>(CreateOne()));
                }
                else
                {
                    excursionsScheduleService.SignUpToCustomExcursion(choice, mapper.Map<IEnumerable<CustomerDTO>>(CreateMany()));
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
        private CustomerModel CreateOne()
        {
            CustomerModel customer = new CustomerModel();
            Console.WriteLine("Name (First name and Last name)");
            customer.Name = Console.ReadLine();
            Console.WriteLine("Age");
            customer.Age = Convert.ToInt32(Console.ReadLine());
            return customer;
        }
        private IEnumerable<CustomerModel> CreateMany()
        {
            int count=0;
            Console.WriteLine("Count of person");
            count = Convert.ToInt32(Console.ReadLine());
            CustomerModel[] customers = new CustomerModel[count];
            for (int i = 0; i < count; i++)
            {
                customers[i] = CreateOne();
            }
            return customers;
        }
    }
}
