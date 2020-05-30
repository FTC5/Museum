using Museum.BLL.DTO;
using Museum.BLL.Interfaces;
using Museum.DAL.Context;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Museum.DAL;
using Museum.BLL.Infrastructure;

namespace Museum.BLL.Services
{
    public class ExcursionsScheduleService : IExcursionsScheduleService
    {
        private IRebuilderService rebuilder;
        private IExpositionService expositionService;
        public ExcursionsScheduleService()
        {
            rebuilder = new RebuilderService();
            expositionService = new ExpositionService();
        }

        public bool SignUpToCustomExcursion(int excursionId, CustomerDTO customer)
        {
            using (var context = new MuseumContext())
            {
                var excursion = context.CustomExcursions.Find(excursionId);
                if (excursion == null)
                    throw new ExcursionNotFoundException("Excursion with id not found");
                if (customer.Age < excursion.ExcursionsSchedule.Grafik.Exposition.TargetAudience)
                    throw new SmallAgeCustomerException("Small age customer found");

                var customerE = rebuilder.CustomerDTOToCustomer(customer);
                context.Customer.Add(customerE);
                excursion.Customers.Add(customerE);
                context.Entry(excursion).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            throw new SmallAgeCustomerException("Customer is already registere");
        }
        public void SignUpToCustomExcursion(int excursionId, IEnumerable<CustomerDTO> customers)
        {
            using (var context = new MuseumContext())
            {
                var excursion = context.CustomExcursions.Find(excursionId);
                if (excursion == null)
                    throw new ExcursionNotFoundException("Excursion with id not found");

                var smallCustomers = cheackAge(customers, excursion.ExcursionsSchedule.Grafik.Exposition.TargetAudience);
                if (smallCustomers.Count() > 0)
                    throw new SmallAgeCustomerException("Small age customers found",smallCustomers.ToList());

                var customerE = rebuilder.CustomerDTOToCustomer(customers);
                foreach (var peaple in customerE)
                {
                    context.Customer.Add(peaple);
                    excursion.Customers.Add(peaple);
                }
                context.Entry(excursion).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        private IEnumerable<CustomerDTO> cheackAge(IEnumerable<CustomerDTO> customers,int ageLimit)
        {
            List<CustomerDTO> small = new List<CustomerDTO>();
            foreach (var item in customers)
            {
                if (item.Age < ageLimit)
                {
                    small.Add(item);
                }
            }
            return small;
        }
        public IEnumerable<CustomExcursionDTO> GetCustomExcursions(int id)
        {
            using (var context = new MuseumContext()) 
            {
                var excursionShedule = (from excursionsSchedule in context.ExcursionsSchedules
                                        where excursionsSchedule.Id == id
                                        select excursionsSchedule).Include(s => s.CustomExcursions).FirstOrDefault();
                return rebuilder.CustomExcursionToCustomExcursionDTO(excursionShedule.CustomExcursions);
            }
            
        }

        public ExcursionDTO GetScheduledExcursionsInfo(int id)
        {
            using (var context = new MuseumContext())
            {
                var excursion = context.Excursions.Find(id);
                return rebuilder.ExcursionToExcursionDTO(excursion);
            }
        }
    }
}
