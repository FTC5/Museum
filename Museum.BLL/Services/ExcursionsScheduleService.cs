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
using AutoMapper;
using Museum.UoW.Interfaces;

namespace Museum.BLL.Services
{
    public class ExcursionsScheduleService : Service,IExcursionsScheduleService
    {
        private IExpositionService expositionService;
        public ExcursionsScheduleService(IExpositionService expositionService,IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
            this.expositionService = expositionService;
        }

        public bool SignUpToCustomExcursion(int excursionId, CustomerDTO customer)
        {
            var excursion = db.CustomExcursion.Get(excursionId);
            if (excursion == null)
                throw new ExcursionNotFoundException("Excursion with id not found");
            if (customer.Age < excursion.ExcursionsSchedule.Grafik.Exposition.TargetAudience)
                throw new SmallAgeCustomerException("Small age customer found");

            var customerE = mapper.Map<Customer>(customer);
            db.Customer.Create(customerE);
            excursion.Customers.Add(customerE);
            db.CustomExcursion.Update(excursion);
            db.Save();
            return true;
        }
        public void SignUpToCustomExcursion(int excursionId, IEnumerable<CustomerDTO> customers)
        {
            var excursion = db.CustomExcursion.Get(excursionId);
            if (excursion == null)
                throw new ExcursionNotFoundException("Excursion with id not found");

            var smallCustomers = cheackAge(customers, excursion.ExcursionsSchedule.Grafik.Exposition.TargetAudience);
            if (smallCustomers.Count() > 0)
                throw new SmallAgeCustomerException("Small age customers found",smallCustomers.ToList());

            var customersE = mapper.Map<IEnumerable<Customer>>(customers);
            foreach (var peaple in customersE)
            {
                db.Customer.Create(peaple);
                excursion.Customers.Add(peaple);
            }
            db.CustomExcursion.Update(excursion);
            db.Save();
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
            var excursionShedule = db.ExcursionsSchedule.Get(id);
            if (excursionShedule == null)
            {
                return null;
            }
            return mapper.Map<IEnumerable<CustomExcursionDTO>>(excursionShedule.CustomExcursions);
            
        }
        public ExcursionDTO GetScheduledExcursionsInfo(int id)
        {
                var excursion = db.Excursion.Get(id);
                return mapper.Map<ExcursionDTO>(excursion);
        }
    }
}
